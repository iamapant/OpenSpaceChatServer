using System.Diagnostics;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using Api.DAL;
using Api.Database.Models;
using Api.DTO;
using Api.Hashing;
using Api.Providers;
using Api.Providers.Email;
using Api.Providers.Hashing;
using Api.Providers.Notification;
using Api.Providers.PasswordGenerator;
using Api.Providers.Token;

namespace Api.Services;

public class UserService {
    private UserRepository _user;
    private UserBlacklistRepository _blacklist;
    private UserInfoRepository _info;
    private UserTimeoutRepository _timeout;
    private GlobalSettings _globalSettings;
    private RefreshTokenProvider _refresh;
    private JwtTokenProvider _jwt;
    private IEmailProvider _email;

    public UserService(UserRepository user
      , GlobalSettings globalSettings
      , UserInfoRepository info
      , RefreshTokenProvider refresh
      , UserBlacklistRepository blacklist
      , UserTimeoutRepository timeout
      , IEmailProvider email
      , JwtTokenProvider jwt
      , IPushNotificationProvider notification) {
        _user = user;
        _globalSettings = globalSettings;
        _info = info;
        _refresh = refresh;
        _blacklist = blacklist;
        _timeout = timeout;
        _email = email;
        _jwt = jwt;
    }

#region Login
    public async Task<ValidationResult<User>> CreateAccount(CreateAccountDto dto) {
        //Generate Random password
        //Add password to user
        //Save user
        //Generate jwt token for email ****
        //Send email

        try {
            (await ValidateUsername(dto.Username)).ThrowIfInvalid();

            var user = dto.Map();
            if (user == null) throw new Exception("Cannot map user.");

            var pass = PasswordGenerator.GeneratePassword(_globalSettings.Admin);
            user.PasswordHash = Hasher.Current.Hash(pass);
            (await _user.Add(user)).ThrowIfInvalid();
            var jwt = _jwt.Create(user
              , new {
                    Expire = TimeSpan.FromMinutes(
                        _globalSettings.Admin.CreateAccountTokenExpireInMinute
                     ?? _globalSettings.Jwt.TokenExpireInMinute)
                }
            );

            // (await _email.Send(new CreateAccountMail(new CreateAccountMailDto {
            //     Id = user.Id.ToString(), Username = dto.Username, Password = pass
            //   , Email = dto.Email, Jwt = jwt
            // }))).ThrowIfInvalid();

            return new ValidationResult<User>(user);
        } catch (Exception ex) { return new(ex); }
    }

    public async Task<ValidationResult<User>> Login(string username, string password) {
        var res = new ValidationResult<User>();
        try {
            var settings = _globalSettings.Admin;
            //Find user: by username -> by email
            var user = await _user.GetByUsername(username);
            if (user == null && settings.AllowsLoginThroughEmail)
                user = await _user.GetByEmail(username, _info);
            if (user == null) throw new Exception("Username not found.");

            //Check password
            if (!Hasher.Current.Verify(password, user.PasswordHash))
                throw new InvalidOperationException("Incorrect password.");

            //Add refresh token
            if (!_refresh.Validate(user.RefreshToken)) {
                user.RefreshToken = _refresh.Create(user);
            }

            res += await _user.Update(user);
            res.Value = res ? user : null;
            return res;
        } catch (Exception ex) { return new(ex); }
    }

    public async Task LogoutAll(string id) {
        try {
            var user = await FindOrThrow(id);

            user.RefreshToken = null;
            var res = await _user.Update(user);
        } catch (Exception ex) { Debug.WriteLine(ex.Message); }
    }

    public async Task<ValidationResult> ChangeEmail(UserEmailChangeDto dto) {
        try {
            var user = await FindOrThrow(dto.Id);

            dto.Map(user);
            return await _user.Update(user);
        } catch (Exception ex) { return new(ex); }
    }

    public async Task<ValidationResult> ChangeUsername(UserUsernameChangeDto dto) {
        try {
            var user = await FindOrThrow(dto.Id);
            var validate = await ValidateUsername(dto.Name);
            if (!validate) return validate;

            dto.Map(user);
            return await _user.Update(user);
        } catch (Exception ex) { return new(ex); }
    }

    public async Task<ValidationResult> ChangePassword(UserPasswordChangeDto dto) {
        try {
            var user = await FindOrThrow(dto.Id);
            var validate = ValidatePassword(dto.NewPassword);
            if (!validate) return validate;

            var oldPassword = user.PasswordHash;
            user.PasswordHash = Hasher.Current.Hash(dto.NewPassword);
            return await _user.Update(user);
        } catch (Exception ex) { return new(ex); }
    }


    public async Task<ValidationResult> ValidateUsername(string username) {
        var res = new ValidationResult(this);
        try {
            if (_user.Where(e => e.Name.Equals(username
                       , StringComparison.OrdinalIgnoreCase))
                     .Any())
                throw new InvalidOperationException("Username already exists.");
            if ((await _info.GetByEmail(username)) != null)
                throw new InvalidOperationException("Username already exists.");
            if ((await _info.GetByPhone(username)) != null)
                throw new InvalidOperationException("Username already exists.");

            if (username.Length > _globalSettings.Admin.UsernameMaxLength)
                res.AddError(new Exception(
                    $"Username must be less than {_globalSettings.Admin.UsernameMaxLength} characters."));
            if (username.Length < _globalSettings.Admin.UsernameMinLength)
                res.AddError(new Exception(
                    $"Username must be at least {_globalSettings.Admin.UsernameMinLength} characters."));
            if (Regex.IsMatch(username
                  , $"[{_globalSettings.Admin.UsernameExcludedCharacters}]"))
                res.AddError(new Exception(
                    $"Username must not contains characters '{_globalSettings.Admin.UsernameExcludedCharacters}'."));
            if (!Regex.IsMatch(username, "^[\\p{L}\\p{N}@$!%*?&._-]+$"))
                res.AddError(new Exception(
                    "Username can only contain letters, numbers, and underscores."));
            if (_globalSettings.Admin.GetUsernameExcludedWords()
                               .Any(w => username.Contains(w
                                 , StringComparison.OrdinalIgnoreCase)))
                res.AddError(new Exception(
                    $"Username cannot contain words: {string.Join(", ", _globalSettings.Admin.GetUsernameExcludedWords())}."));
        } catch (Exception ex) { res.AddError(ex); }

        return res;
    }

    public ValidationResult ValidatePassword(string password) {
        var res = new ValidationResult(this);
        try {
            if (password.Length > _globalSettings.Admin.PasswordMaxLength)
                res.AddError(new Exception(
                    $"Password must be less than {_globalSettings.Admin.PasswordMaxLength} characters."));
            if (password.Length < _globalSettings.Admin.PasswordMinLength)
                res.AddError(new Exception(
                    $"Password must be at least {_globalSettings.Admin.PasswordMinLength} characters."));
            if (Regex.IsMatch(password
                  , $"[{_globalSettings.Admin.PasswordExcludedCharacters}]"))
                res.AddError(new Exception(
                    $"Password must not contains characters '{_globalSettings.Admin.UsernameExcludedCharacters}'."));
            if (_globalSettings.Admin.PasswordContainsNumber
             && !Regex.IsMatch(password, "[\\d]"))
                res.AddError(new Exception("Password must contain at least 1 number."));
            if (_globalSettings.Admin.PasswordContainsSpecial
             && !Regex.IsMatch(password
                  , $"[{_globalSettings.Admin.PasswordAllowedSpecials}]"))
                res.AddError(new Exception(
                    $"Password must contain at least 1 Special character '{_globalSettings.Admin.PasswordAllowedSpecials}'."));
            if (_globalSettings.Admin.GetPasswordExcludedWords()
                               .Any(w => password.Contains(w
                                 , StringComparison.OrdinalIgnoreCase)))
                res.AddError(new Exception(
                    $"Password cannot contain words: {string.Join(", ", _globalSettings.Admin.GetPasswordExcludedWords())}."));
            if (!Regex.IsMatch(password, "^[A-Za-z\\d@$!%*?&._-]+$"))
                res.AddError(
                    new Exception("Password containing un-supported characters."));
        } catch (Exception ex) { res.AddError(ex); }

        return res;
    }
#endregion

#region Blacklist
    public async Task<ValidationResult<ICollection<Guid>>> GetBlacklistingUserIds(
        string id) {
        try {
            var blacklists = await _blacklist.GetBlacklist(id);
            return new(blacklists.Select(e => e.BlacklistId).ToList());
        } catch (Exception ex) { return new(ex); }
    }

    public async Task<ValidationResult<ICollection<Guid>>> GetBlacklistedByUserIds(
        string id) {
        try {
            var blacklists = await _blacklist.GetBlacklistedBy(id);
            return new(blacklists.Select(e => e.Id).ToList());
        } catch (Exception ex) { return new(ex); }
    }

    public async Task DeBlacklistUser(DeBlacklistDto dto) {
        try {
            var user = await FindOrThrow(dto.UserId);
            var blacklist = await FindOrThrow(dto.BlacklistId
              , "Blacklist user not found.");

            var previous = await _blacklist.Find(user.Id, blacklist.Id);
            if (previous == null) return;

            await _blacklist.Remove(previous);
        } catch (Exception e) { Debug.WriteLine(e); }
    }

    public async Task<ValidationResult> Blacklist(BlacklistDto dto) {
        var res = new ValidationResult();
        try {
            var user = await FindOrThrow(dto.UserId);
            var blacklist = await FindOrThrow(dto.BlacklistId
              , "Blacklist user not found.");

            var previous = await _blacklist.Find(user.Id, blacklist.Id);
            if (previous != null) {
                previous.Temporary = dto.Until != null;
                previous.Until = dto.Until ?? DateTime.MaxValue;

                res += await _blacklist.Update(previous);
            }
            else { res += await _blacklist.Add(dto); }
        } catch (Exception e) { res.AddError(e); }

        return res;
    }
#endregion

#region Info
    public async Task<ValidationResult> UpdateInfo(UserInfoDto dto) {
        try {
            var user = await FindOrThrow(dto.Id);
            await _user.Load(user, u => u.UserInfo);
            dto.Map(user.UserInfo);

            return await _user.Update(user);
        } catch (Exception e) { return new ValidationResult(e); }
    }

    private async Task<ValidationResult> ClearInfos(string id, Action<UserInfo> action) {
        try {
            var info = await _info.FindById(id);
            if (info == null) throw new ArgumentNullException(nameof(id));
            action(info);

            return await _info.Update(info);
        } catch (Exception e) { return new ValidationResult(e); }
    }

    public async Task<ValidationResult> ClearPhoneNumber(string id) {
        return await ClearInfos(id, i => i.Phone = null);
    }

    public async Task<ValidationResult> ClearLastName(string id) {
        return await ClearInfos(id, i => i.LastName = null);
    }

    public async Task<ValidationResult> ClearDisplayName(string id) {
        return await ClearInfos(id, i => i.DisplayName = null);
    }

    public async Task<ValidationResult> ClearBio(string id) {
        return await ClearInfos(id, i => i.Bio = null);
    }

    public async Task<ValidationResult> ClearAvatar(string id) {
        return await ClearInfos(id, i => i.AvatarUrl = null);
    }

    public async Task<ValidationResult> ClearCover(string id) {
        return await ClearInfos(id, i => i.CoverUrl = null);
    }

    public async Task<ValidationResult> ClearCountry(string id) {
        return await ClearInfos(id, i => i.CountryCode = null);
    }
#endregion

#region Timeout
    public async Task<UserTimeout?> GetTimeout(string id)
        => await _timeout.FindById(id);

    public async Task<UserTimeout?> GetTimeout(User user)
        => await _timeout.Find(user.Id);

    public async Task<UserTimeout?> GetTimeout(Guid id)
        => await _timeout.Find(id);


    public async Task<ValidationResult> SetTimeout(TimeoutDto dto) {
        try {
            var prev = await _timeout.FindById(dto.UserId);
            if (prev == null)
                return await _timeout.Add(dto);
            else {
                dto.Map(prev);
                return await _timeout.Update(prev);
            }
        } catch (Exception ex) { return new(ex); }
    }

    public async Task RemoveTimeout(string id) {
        try { await _timeout.Delete(id); } catch (Exception ex) { Debug.WriteLine(ex); }
    }
#endregion

    public async Task<ValidationResult<User>> GetUser<T>(string id
      , params Expression<Func<User, T?>>[] includings) where T : class {
        try {
            var user = await FindOrThrow(id);
            foreach (var include in includings) { await _user.Load(user, include); }

            return new(user);
        } catch (Exception ex) { return new(ex); }
    }

    public async Task RushDeletingUsers() {
        await _user.ForEach(
            predicate: u => u.IsDeleted != null
          , action: async void (u) => {
                try { await _user.Remove(u); } catch { /* ignored */
                }
            }
          , CancellationToken.None);
    }

    public async Task<ICollection<User>> FindByBirthYear(int year) {
        var list = await _info.GetByBirthYear(year);
        var result = new List<User>();
        foreach (var id in list) {
            var u = await _user.Find(id);
            if (u != null) result.Add(u);
        }

        return result;
    }

    public async Task<ICollection<User>> FindByBirthday(DateTime date) {
        var list = await _info.GetByBirthday(date);
        var result = new List<User>();
        foreach (var id in list) {
            var u = await _user.Find(id);
            if (u != null) result.Add(u);
        }

        return result;
    }

    public async Task<User?> FindByEmail(string email) {
        var list = await _info.GetByEmail(email);
        return list.HasValue ? await _user.Find(list.Value) : null;
    }

    public async Task<User?> FindByPhoneNumber(string phone) {
        var list = await _info.GetByPhone(phone);
        return list.HasValue ? await _user.Find(list.Value) : null;
    }

    public async Task<User?> FindByName(string id) { return await _user.FindByName(id); }

    private async Task<User> FindOrThrow(string id, string message = "User not found.") {
        var user = await _user.FindById(id);
        if (user == null) throw new Exception(message);

        return user;
    }
}