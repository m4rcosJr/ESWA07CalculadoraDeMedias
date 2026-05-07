namespace OOPFoundation
{
    /// <summary>
    /// Valida notas no intervalo fechado [0,0 ; 10,0].
    /// </summary>
    public class NoteValidation : ADoubleValidation
    {
        public NoteValidation()
        {
            LowerLimit = 0.0;
            UpperLimit = 10.0;
        }

        public override bool DoubleIsValid(double doubleToValidate)
        {
            return doubleToValidate >= LowerLimit && doubleToValidate <= UpperLimit;
        }
    }
}
