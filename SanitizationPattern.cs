namespace OOPFoundation
{
    /// <summary>
    /// Padrões de sanitização para diferentes tipos de entrada.
    /// </summary>
    public class SanitizationPattern
    {
        public static string CNPJ    { get; } = "a-zA-Z0-9";
        public static string CPF     { get; } = "0-9";
        public static string ISBN    { get; } = "0-9";
        public static string ISSN    { get; } = "0-9Xx";
        public static string PHONE   { get; } = "0-9";
        private static string PIV   { get; } = "0-9A-Z";
        public static string RG      { get; } = "0-9Xx";

        /// <summary>Padrão para notas: apenas dígitos e vírgula.</summary>
        public static string NOTE    { get; } = @"[^0-9,]";
    }
}
