namespace OOPFoundation
{
    /// <summary>
    /// Classe abstrata base para validação de valores double com limites inferior e superior.
    /// </summary>
    public abstract class ADoubleValidation : IDoubleValidation
    {
        protected double LowerLimit { get; set; }
        protected double UpperLimit { get; set; }

        public abstract bool DoubleIsValid(double doubleToValidate);
    }
}
