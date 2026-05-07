namespace OOPFoundation
{
    /// <summary>
    /// Classe concreta de texto com padrão de nota (dígitos e vírgula).
    /// </summary>
    public class Text : AText
    {
        public Text()
        {
            // Padrão: aceita apenas dígitos e vírgula
            SetValidPattern(SanitizationPattern.NOTE);
        }

        public override bool TextIsValid(string textToValidate)
        {
            return !string.IsNullOrWhiteSpace(textToValidate);
        }
    }
}
