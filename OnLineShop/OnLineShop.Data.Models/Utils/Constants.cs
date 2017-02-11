namespace OnLineShop.Data.Models.Utils
{
    public class Constants
    {
        //public const string En = @"^[a-zA-Z]+$";
        //public const string EnMinus = @"^[a-zA-Z\-]+$";
        //public const string EnSpace = @"^[a-zA-Z\s]+$";
        ////public const string EnSpaceMinus = @"^[a-zA-Z\s\-]+$";
        //public const string EnBg = @"^[a-zA-Zа-яА-Я]+$";
        //public const string EnBgMinus = @"^[a-zA-Zа-яА-Я\-]+$";
        //public const string EnBgSpace = @"^[a-zA-Zа-яА-Я\s]+$";
        public const string EnBgSpaceMinus = @"^[a-zA-Zа-яА-Я\s\-]+$";
        public const string EnBgDigitSpaceMinus = @"^[a-zA-Zа-яА-Я0-9\s\-]+$";
        //public const string Bg = @"^[а-яА-Я]+$";
        //public const string BgMinus = @"^[а-яА-Я\-]+$";
        //public const string BgSpace = @"^[а-яА-Я\s]+$";
        //public const string BgSpaceMinus = @"^[а-яА-Я\s\-]+$";
        public const string DescriptionRegex = @"^[a-zA-Zа-яА-Я0-9\s\-\.,!():;?/+_%@""'#&=\*]+$";

        // sourse http://stackoverflow.com/questions/8908976/c-sharp-regex-to-validate-phone-number
        public const string Phone = @"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$";

        // source https://msdn.microsoft.com/en-us/library/01escwtf(v=vs.110).aspx
        public const string Email = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

        public const int NameMinLength = 1;
        public const int NameMaxLength= 20;

        public const int DescriptionMinLength = 10;
        public const int DescriptionMaxLength = 500;
    }
}
