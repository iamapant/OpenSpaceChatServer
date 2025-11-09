using Api.DAL;

namespace Api.Services;

public class CleanupService {
    private readonly UserRepository _user;
    private readonly UserTimeoutRepository _timeout;
    private readonly UserBlacklistRepository _blacklist;
    private readonly FontFamilyRepository _fontFamily;
    private readonly FontStyleRepository _style;
    private readonly StickerStyleRepository _stickerStyle;
    private readonly StickerUrlRepository _stickerUrl;
    private readonly ILogger<CleanupService> _log;

    public CleanupService(UserRepository user
      , UserBlacklistRepository blacklist
      , ILogger<CleanupService> log
      , UserTimeoutRepository timeout
      , FontFamilyRepository fontFamily
      , FontStyleRepository style
       , StickerUrlRepository stickerUrl
       , StickerStyleRepository stickerStyle) {
        _user = user;
        _blacklist = blacklist;
        _log = log;
        _timeout = timeout;
        _fontFamily = fontFamily;
        _style = style;
        _stickerUrl = stickerUrl;
        _stickerStyle = stickerStyle;
    }

    public void Cleanup() {
        var task = Task.Run(async () => {
            await _user.DeleteExpiredUsers(_log);
            await _blacklist.RemoveTimeoutBlacklist(_log);
            await _timeout.RemoveExpiredTimeouts(_log);
            await _fontFamily.RemoveUnused(_log);
            await _style.RemoveUnused(_log);
            await _stickerStyle.RemoveUnused(_log);
            await _stickerUrl.RemoveUnused(_log);
        });
        task.Start();
    }
}