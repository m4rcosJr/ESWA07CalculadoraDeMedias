using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace OOPFoundation
{
    /// <summary>
    /// Classe abstrata base para manipulação e validação de texto.
    /// Implementa ISanitization e ITextValidation.
    /// </summary>
    public abstract class AText : ISanitization, ITextValidation
    {
        private string _text;
        private string _validPattern;

        protected AText()
        {
            _text = string.Empty;
            _validPattern = string.Empty;
        }

        public string GetText() => _text;

        public string ObtainHashedText() => Hash();

        private string Hash()
        {
            var encoded = Encode();
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(encoded));
            return Convert.ToBase64String(bytes);
        }

        private string Encode()
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(_text));
        }

        /// <summary>
        /// Remove caracteres fora do padrão permitido (regex de caracteres inválidos).
        /// </summary>
        public string Sanitize(string textToSanitize)
        {
            if (string.IsNullOrEmpty(_validPattern))
                return textToSanitize;

            return Regex.Replace(textToSanitize, _validPattern, string.Empty);
        }

        public abstract bool TextIsValid(string textToValidate);

        protected void SetText(string text) => _text = text;
        protected void SetValidPattern(string pattern) => _validPattern = pattern;
    }
}
