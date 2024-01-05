using SR.Entities.Enums;

namespace SR.Core.Utilities.Localization
{
    public interface ILocalizationService
    {
        string this[string key] { get; }
        string this[MessageCodes messageCodes] { get; }
        int IsLanguage(string language);
    }
}
