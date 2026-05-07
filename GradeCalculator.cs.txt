using OOPFoundation;

namespace ESWA07CalculadoraDeMedias
{
    /// <summary>
    /// Calculadora de médias semestral e final.
    /// Aplica as regras de negócio conforme especificação ESWA Atividade II.
    /// </summary>
    public class GradeCalculator
    {
        private readonly NoteValidation _noteValidation;
        private readonly WeightValidation _weightValidation;

        // Pesos padrão conforme especificação
        private const double WeightNP1 = 4.0;
        private const double WeightNP2 = 4.0;
        private const double WeightPIM = 2.0;
        private const double TotalWeight = 10.0;

        private const double ApprovalThreshold = 7.0;
        private const double FinalApprovalThreshold = 5.0;

        public GradeCalculator()
        {
            _noteValidation = new NoteValidation();
            _weightValidation = new WeightValidation();
        }

        /// <summary>
        /// Calcula a Média Semestral:
        /// MS = (4*NP1 + 4*NP2 + 2*PIM) / 10
        /// Arredondamento matemático para 1 casa decimal (AwayFromZero).
        /// </summary>
        public double CalculateSemestralAverage(double np1, double np2, double pim)
        {
            ValidateNote(np1, nameof(np1));
            ValidateNote(np2, nameof(np2));
            ValidateNote(pim, nameof(pim));

            double ms = (WeightNP1 * np1 + WeightNP2 * np2 + WeightPIM * pim) / TotalWeight;
            return Math.Round(ms, 1, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// Calcula a Média Final:
        /// MF = (MS + EX) / 2
        /// Arredondamento matemático para 1 casa decimal (AwayFromZero).
        /// </summary>
        public double CalculateFinalAverage(double semestralAverage, double exam)
        {
            ValidateNote(semestralAverage, nameof(semestralAverage));
            ValidateNote(exam, nameof(exam));

            double mf = (semestralAverage + exam) / 2.0;
            return Math.Round(mf, 1, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// Define o status do aluno com base na Média Semestral.
        /// MS >= 7,0 → Aprovado; MS < 7,0 → Em Exame
        /// </summary>
        public StudentStatus GetSemestralStatus(double semestralAverage)
        {
            return semestralAverage >= ApprovalThreshold
                ? StudentStatus.Aprovado
                : StudentStatus.EmExame;
        }

        /// <summary>
        /// Define o status do aluno com base na Média Final.
        /// MF >= 5,0 → Aprovado; MF < 5,0 → Reprovado
        /// </summary>
        public StudentStatus GetFinalStatus(double finalAverage)
        {
            return finalAverage >= FinalApprovalThreshold
                ? StudentStatus.Aprovado
                : StudentStatus.Reprovado;
        }

        /// <summary>
        /// Valida se a nota está no intervalo [0,0 ; 10,0].
        /// </summary>
        public bool IsNoteValid(double note) => _noteValidation.DoubleIsValid(note);

        /// <summary>
        /// Valida se o peso está no intervalo [0,0 ; 1,0].
        /// </summary>
        public bool IsWeightValid(double weight) => _weightValidation.DoubleIsValid(weight);

        /// <summary>
        /// Valida se a soma dos pesos é igual a 1,0.
        /// </summary>
        public bool IsWeightSumValid(params double[] weights)
        {
            double sum = weights.Sum();
            return Math.Abs(sum - 1.0) < 1e-9;
        }

        private void ValidateNote(double note, string paramName)
        {
            if (!_noteValidation.DoubleIsValid(note))
                throw new ArgumentOutOfRangeException(paramName,
                    $"A nota '{paramName}' deve estar no intervalo [0,0; 10,0]. Valor: {note}");
        }
    }
}
