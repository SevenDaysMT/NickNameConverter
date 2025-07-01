using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;

namespace NickNameConverter
{
    internal class Model_ : INotifyPropertyChanged
    {
        private readonly Dictionary<string, string> _dictionary = new();
        private string _rusLetterNick;
        private string _engLetterNick;
        public string RusLetterNick
        {
            get => _rusLetterNick;
            set
            {
                if (_rusLetterNick != value)
                {
                    _rusLetterNick = value;
                    OnPropertyChanged(nameof(RusLetterNick));
                    EngLetterNick = ConvertToEnglishNick(value);
                }
            }
        }
        public string EngLetterNick
        {
            get => _engLetterNick;
            private set
            {
                if (_engLetterNick != value)
                {
                    _engLetterNick = value;
                    OnPropertyChanged(nameof(EngLetterNick));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public Model_()
        {
            InitializeDictionary();
        }
        private void InitializeDictionary()
        {
            string[] russianLetters = "А Б В Г Д Е Ё Ж З И Й К Л М Н О П Р С Т У Ф Х Ц Ч Ш Щ Ы Ь Э Ю Я а б в г д е ё ж з и й к л м н о п р с т у ф х ц ч ш щ ы ь э ю я 1 2 3 4 5 6 7 8 9 0 _".Split(' ');
            string[] englishLetters = "A 6 B r D E E )I( 3 u u K Jl M H O n p C T Y F X u 4 W W bl b E I-O 9l a 6 B r g e e )l( 3 u u k Jl m H o n p c T y f x u 4 w w bl b e l-o 9l 1 2 3 4 5 6 7 8 9 0 _".Split(' ');
            for (int i = 0; i < russianLetters.Length; i++)
            {
                _dictionary[russianLetters[i]] = englishLetters[i];
            }
            _dictionary[" "] = "_";
        }
        private string ConvertToEnglishNick(string rusNick)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (char character in rusNick)
            {
                if (_dictionary.TryGetValue(character.ToString(CultureInfo.InvariantCulture), out string engChar))
                {
                    stringBuilder.Append(engChar);
                }
                else
                {
                    stringBuilder.Append("*");
                }
            }

            return stringBuilder.ToString();
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
