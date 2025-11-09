using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Database.Models;

public class AdminSettings {
    [Key]
    public int Id { get; set; } = 1;

    //Settings refresh
    public float SettingsRefreshIntervalInHour { get; set; }

    //Login
    public bool AllowsLoginThroughEmail { get; set; }
    public int UsernameMaxLength { get; set; }
    public int UsernameMinLength { get; set; }
    public string UsernameExcludedCharacters { get; set; }
    public char ExcludedWordsSeparator { get; set; }
    public string UsernameExcludedWords { get; set; }
    public int PasswordMaxLength { get; set; }
    public int PasswordMinLength { get; set; }
    public string PasswordExcludedCharacters { get; set; }
    public bool PasswordContainsNumber { get; set; }
    public bool PasswordContainsSpecial { get; set; }
    public bool PasswordContainsUpper { get; set; }
    public bool PasswordContainsLower { get; set; }
    public int PasswordDefaultLength { get; set; }
    public string PasswordAllowedSpecials { get; set; }
    public string PasswordExcludedWords { get; set; }

    //Email
    public float? CreateAccountTokenExpireInMinute { get; set; }


    public string[] GetPasswordExcludedWords() {
        return PasswordExcludedWords.Split(ExcludedWordsSeparator);
    }

    public string[] GetUsernameExcludedWords() {
        return UsernameExcludedWords.Split(ExcludedWordsSeparator);
    }

    //Token
    public float RefreshTokenTimeoutInHour { get; set; }
    public int RefreshTokenLength { get; set; }
    public char RefreshTokenSeparator { get; set; }
    public string RefreshTokenCharacters { get; set; }

    //Delete
    public float SoftDeleteRetentionInHours { get; set; }
}

public class AdminSettingsCreationModel : IModelCreationSettings<AdminSettings> {
    public void
        OnModelCreating(EntityTypeBuilder<AdminSettings> builder, ModelBuilder mb) {
        builder.HasData(new AdminSettings {
            Id = 1
          , SettingsRefreshIntervalInHour = 1
          , AllowsLoginThroughEmail = true
          , UsernameMaxLength = 25
          , UsernameMinLength = 5
          , UsernameExcludedCharacters = @"!""#$%&'()*+,/:;<=>?@[\]^`{|}~"
          , ExcludedWordsSeparator = '#'
          , UsernameExcludedWords = "" //TODO: Add bad words
          , PasswordMaxLength = 30
          , PasswordMinLength = 8
          , PasswordExcludedCharacters = "\t\n\r\e\a"
          , PasswordContainsNumber = true
          , PasswordContainsSpecial = true
          , PasswordContainsUpper = true
          , PasswordContainsLower = true
          , PasswordDefaultLength = 8
          , PasswordAllowedSpecials = @"!""#$%&'()*+,-./:;<=>?@[\]^`{|}~"
          , PasswordExcludedWords = "" //TODO: Add bad words
          , CreateAccountTokenExpireInMinute = 30
          , RefreshTokenTimeoutInHour = 2
          , RefreshTokenLength = 10
          , RefreshTokenSeparator = '_'
          , RefreshTokenCharacters = @"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!""#$%&'()*+,-./:;<=>?@[\]^`{|}~"
          , SoftDeleteRetentionInHours = 1440
        });
    }
}