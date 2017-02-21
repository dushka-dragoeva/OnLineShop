namespace OnLineShop.Data.Models.Utils
{
    public class Constants
    {
        public const string EnBgSpaceMinus = @"^[a-zA-Zа-яА-Я\s\-]+$";
        public const string EnBgDigitSpaceMinus = @"^[a-zA-Zа-яА-Я0-9\s\-]+$";
        public const string DescriptionRegex = @"^[a-zA-Zа-яА-Я0-9\s\-\.,!():;?/+_%@""'#&=\*]+$";

        // sourse http://stackoverflow.com/questions/8908976/c-sharp-regex-to-validate-phone-number
        public const string PhoneRegex = @"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$";

        // source https://msdn.microsoft.com/en-us/library/01escwtf(v=vs.110).aspx
        public const string EmailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

        // source http://stackoverflow.com/questions/5717312/regular-expression-for-url
        public const string UrlRegex = @"^(http|https|ftp|)\://|[a-zA-Z0-9\-\.]+\.[a-zA-Z](:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$";

        public const int NameMinLength = 1;
        public const int NameMaxLength= 40;

        public const int DescriptionMinLength = 10;
        public const int DescriptionMaxLength = 500;

        public const string ShortUrlError = "Линка към снимката трябва да бъде поне 6 символа";
        public const string LongUrlError = "Линка към снимката може да бъде максимум  символа";

        public const string ShortNameError= "Името трябва да бъде поне 1 символа";
        public const string LongNameError = "Името може да бъде максимум 40 символа";

        public const string ShortDescriptionError= "Описанието трябва да бъде поне 10 символа";
        public const string LongDescriptionError= "Описанието може да бъде максимум 500 символа";

        public const string NotAllowedSymbolsError = "Неразрешени символи";
        


    }
}
