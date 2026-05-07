namespace OOPFoundation
{
    /// <summary>
    /// Valida pesos no intervalo fechado [0,0 ; 1,0].
    /// </summary>
    public class WeightValidation : ADoubleValidation
    {
        public WeightValidation()
        {
            LowerLimit = 0.0;
            UpperLimit = 1.0;
        }

        public override bool DoubleIsValid(double doubleToValidate)
        {
            return doubleToValidate >= LowerLimit && doubleToValidate <= UpperLimit;
        }
    }
}
