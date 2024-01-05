using Microsoft.Extensions.Localization;
using SR.Core.Localize;
using SR.Entities.Enums;

namespace SR.Core.Utilities.Localization
{
    public class LocalizationService : ILocalizationService
    {
        private readonly IStringLocalizer<Resource> _stringLocalizer;

        public LocalizationService(IStringLocalizer<Resource> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
        }
        public string this[string key]
        {
            get
            {
                return _stringLocalizer[key];
            }
        }

        public string this[MessageCodes messageCodes]
        {
            get
            {
                return this[messageCodes.ToString()];
            }
        }

        public int IsLanguage(string language)
        {
            throw new NotImplementedException();
        }
    }
}
