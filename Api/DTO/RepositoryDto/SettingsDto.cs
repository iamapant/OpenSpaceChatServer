using Api.Database.Models;

namespace Api.DTO;

public class CuratorSettingsDto : IUpdateDto<CuratorSettings> {
    public float? DefaultMessageDurationInHour { get; set; }
    public int? DefaultMessageHighlightThreshold { get; set; }
    public int? DefaultMessageArchiveThreshold { get; set; }
    public double? DefaultChannelRadiusInKm { get; set; }
    public float? LandmarkTaggableRangeInKm { get; set; }
    public float? UserChatRangeInKm { get; set; }
    public float? PrivateMessagePublishDeadlineInHour { get; set; }
    public float? PublicMessageFrequencyPerInterval { get; set; }
    public int? PublicMessageFrequencyIntervalInSecond { get; set; }
    public float? DefaultTimeoutPeriodInMinute { get; set; }
    
    //Default font style
    public int? DefaultFontWeight { get; set; }
    public string? DefaultFontStyle { get; set; }
    public float? DefaultFontSizeInPx { get; set; }
    public float? DefaultLetterSpacing { get; set; }
    public float? DefaultLineSpacing { get; set; }
    public string? DefaultTextDecoration { get; set; }
    public string? DefaultTextTransform { get; set; }
    public void Map(CuratorSettings entity) {
        if (DefaultMessageDurationInHour.HasValue) entity.DefaultMessageDurationInHour = DefaultMessageDurationInHour.Value;
        if (DefaultMessageHighlightThreshold.HasValue) entity.DefaultMessageHighlightThreshold = DefaultMessageHighlightThreshold.Value;
        if (DefaultMessageArchiveThreshold.HasValue) entity.DefaultMessageArchiveThreshold = DefaultMessageArchiveThreshold.Value;
        if (DefaultChannelRadiusInKm.HasValue) entity.DefaultChannelRadiusInKm = DefaultChannelRadiusInKm.Value;
        if (LandmarkTaggableRangeInKm.HasValue) entity.LandmarkTaggableRangeInKm = LandmarkTaggableRangeInKm.Value;
        if (UserChatRangeInKm.HasValue) entity.UserChatRangeInKm = UserChatRangeInKm.Value;
        if (PrivateMessagePublishDeadlineInHour.HasValue) entity.PrivateMessagePublishDeadlineInHour = PrivateMessagePublishDeadlineInHour.Value;
        if (PublicMessageFrequencyPerInterval.HasValue) entity.PublicMessageFrequencyPerInterval = PublicMessageFrequencyPerInterval.Value;
        if (PublicMessageFrequencyIntervalInSecond.HasValue) entity.PublicMessageFrequencyIntervalInSecond = PublicMessageFrequencyIntervalInSecond.Value;
        if (DefaultTimeoutPeriodInMinute.HasValue) entity.DefaultTimeoutPeriodInMinute = DefaultTimeoutPeriodInMinute.Value;
        if (DefaultFontWeight.HasValue) entity.DefaultFontWeight = DefaultFontWeight.Value;
        if (DefaultFontStyle != null) entity.DefaultFontStyle = DefaultFontStyle;
        if (DefaultFontSizeInPx.HasValue) entity.DefaultFontSizeInPx = DefaultFontSizeInPx.Value;
        if (DefaultLetterSpacing.HasValue) entity.DefaultLetterSpacing = DefaultLetterSpacing.Value;
        if (DefaultLineSpacing.HasValue) entity.DefaultLineSpacing = DefaultLineSpacing.Value;
        if (DefaultTextDecoration != null) entity.DefaultTextDecoration = DefaultTextDecoration;
        if (DefaultTextTransform  != null) entity.DefaultTextTransform = DefaultTextTransform;

    }
}

public class AdminSettingsDto : IUpdateDto<AdminSettings> {

    //Settings refresh
    public float? SettingsRefreshIntervalInHour { get; set; }
    
    //Login
    public bool? AllowsLoginThroughEmail { get; set; }
    public int? UsernameMaxLength { get; set; }
    public int? UsernameMinLength { get; set; }
    public string? UsernameExcludedCharacters { get; set; }
    public string? UsernameExcludedWords { get; set; }
    public int? PasswordMaxLength { get; set; }
    public int? PasswordMinLength { get; set; }
    public string? PasswordExcludedCharacters { get; set; }
    public bool? PasswordContainsNumber { get; set; }
    public bool? PasswordContainsSpecial { get; set; }
    public bool? PasswordContainsUpper { get; set; }
    public bool? PasswordContainsLower { get; set; }
    public int? PasswordDefaultLength { get; set; }
    public string? PasswordAllowedSpecials { get; set; }
    public string? PasswordExcludedWords { get; set; }
    
    //Email
    public float? CreateAccountTokenExpireInMinute { get; set; }
    public void Map(AdminSettings entity) {
        if (SettingsRefreshIntervalInHour.HasValue) entity.SettingsRefreshIntervalInHour =  SettingsRefreshIntervalInHour.Value;
        if (AllowsLoginThroughEmail.HasValue)   entity.AllowsLoginThroughEmail = AllowsLoginThroughEmail.Value;
        if (UsernameMaxLength.HasValue) entity.UsernameMaxLength = UsernameMaxLength.Value;
        if (UsernameMinLength.HasValue) entity.UsernameMinLength = UsernameMinLength.Value;
        if (UsernameExcludedCharacters != null) entity.UsernameExcludedCharacters = UsernameExcludedCharacters;
        if (UsernameExcludedWords != null) entity.UsernameExcludedWords = UsernameExcludedWords;
        if (PasswordMaxLength.HasValue) entity.PasswordMaxLength = PasswordMaxLength.Value;
        if (PasswordMinLength.HasValue) entity.PasswordMinLength = PasswordMinLength.Value;
        if (PasswordExcludedCharacters != null) entity.PasswordExcludedCharacters = PasswordExcludedCharacters;
        if (PasswordContainsNumber.HasValue) entity.PasswordContainsNumber = PasswordContainsNumber.Value;
        if (PasswordContainsSpecial.HasValue) entity.PasswordContainsSpecial = PasswordContainsSpecial.Value;
        if (PasswordContainsUpper.HasValue) entity.PasswordContainsUpper = PasswordContainsUpper.Value;
        if (PasswordContainsLower.HasValue) entity.PasswordContainsLower = PasswordContainsLower.Value;
        if (PasswordDefaultLength.HasValue) entity.PasswordDefaultLength = PasswordDefaultLength.Value;
        if (PasswordAllowedSpecials != null) entity.PasswordAllowedSpecials = PasswordAllowedSpecials;
        if (PasswordExcludedWords != null) entity.PasswordExcludedWords = PasswordExcludedWords;
        if (CreateAccountTokenExpireInMinute.HasValue) entity.CreateAccountTokenExpireInMinute = CreateAccountTokenExpireInMinute.Value;
    }
}