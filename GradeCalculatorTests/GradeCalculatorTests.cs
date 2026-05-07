using ESWA07CalculadoraDeMedias;
using OOPFoundation;
using Xunit;
using static System.Net.Mime.MediaTypeNames;

namespace ESWA07CalculadoraDeMedias.Tests
{
    /// <summary>
    /// Testes Unitários - Calculadora de Médias Semestral e Final
    /// Convenção: Testing[Classe|Método]AssertType
    /// </summary>
    public class GradeCalculatorTests
    {
        private readonly GradeCalculator _calculator = new GradeCalculator();

        // ═══════════════════════════════════════════════════════════
        // RF-010 | Validação de Notas
        // ═══════════════════════════════════════════════════════════

        [Theory]
        [InlineData(0.0)]
        [InlineData(5.0)]
        [InlineData(10.0)]
        [InlineData(7.5)]
        public void TestingNoteValidation_IsValid_ReturnsTrue(double note)
            => Assert.True(_calculator.IsNoteValid(note));   // RF-010

        [Theory]
        [InlineData(-0.1)]
        [InlineData(10.1)]
        [InlineData(-1.0)]
        [InlineData(100.0)]
        public void TestingNoteValidation_IsInvalid_ReturnsFalse(double note)
            => Assert.False(_calculator.IsNoteValid(note));  // RF-010

        // ═══════════════════════════════════════════════════════════
        // RF-010 | Validação de Pesos
        // ═══════════════════════════════════════════════════════════

        [Theory]
        [InlineData(0.0)]
        [InlineData(0.4)]
        [InlineData(0.2)]
        [InlineData(1.0)]
        public void TestingWeightValidation_IsValid_ReturnsTrue(double weight)
            => Assert.True(_calculator.IsWeightValid(weight)); // RF-010

        [Theory]
        [InlineData(-0.1)]
        [InlineData(1.1)]
        [InlineData(2.0)]
        public void TestingWeightValidation_IsInvalid_ReturnsFalse(double weight)
            => Assert.False(_calculator.IsWeightValid(weight)); // RF-010

        // ═══════════════════════════════════════════════════════════
        // RF-010 | Validação da Soma dos Pesos
        // ═══════════════════════════════════════════════════════════

        [Fact]
        public void TestingWeightSumValidation_SumEqualsOne_ReturnsTrue()
            => Assert.True(_calculator.IsWeightSumValid(0.4, 0.4, 0.2)); // RF-010

        [Fact]
        public void TestingWeightSumValidation_SumNotOne_ReturnsFalse()
            => Assert.False(_calculator.IsWeightSumValid(0.5, 0.4, 0.2)); // RF-010

        // ═══════════════════════════════════════════════════════════
        // RF-006 | Cálculo da Média Semestral
        // ═══════════════════════════════════════════════════════════

        [Theory]
        [InlineData(8.0, 8.0, 8.0, 8.0)]   // (32+32+16)/10 = 8,0
        [InlineData(10.0, 10.0, 10.0, 10.0)]
        [InlineData(0.0, 0.0, 0.0, 0.0)]
        [InlineData(7.0, 7.0, 7.0, 7.0)]   // limiar: exatamente 7,0
        [InlineData(6.0, 8.0, 5.0, 6.9)]   // (24+32+10)/10 = 6,6 → 6,6; testar arredondamento
        public void TestingGradeCalculator_CalculateSemestralAverage_CorrectResult(
            double np1, double np2, double pim, double expected)
        {
            double result = _calculator.CalculateSemestralAverage(np1, np2, pim);
            Assert.Equal(expected, result); // RF-006
        }

        [Fact]
        public void TestingGradeCalculator_CalculateSemestralAverage_Rounding()
        {
            // (4*5 + 4*5 + 2*5) / 10 = 5,0
            double result = _calculator.CalculateSemestralAverage(5.0, 5.0, 5.0);
            Assert.Equal(5.0, result); // RF-007
        }

        [Fact]
        public void TestingGradeCalculator_CalculateSemestralAverage_InvalidNoteThrows()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => _calculator.CalculateSemestralAverage(11.0, 5.0, 5.0)); // RF-010
        }

        // ═══════════════════════════════════════════════════════════
        // RF-006 | Status Semestral
        // ═══════════════════════════════════════════════════════════

        [Theory]
        [InlineData(7.0, StudentStatus.Aprovado)]
        [InlineData(8.5, StudentStatus.Aprovado)]
        [InlineData(10.0, StudentStatus.Aprovado)]
        public void TestingGradeCalculator_GetSemestralStatus_Approved(
            double ms, StudentStatus expected)
            => Assert.Equal(expected, _calculator.GetSemestralStatus(ms)); // RF-006

        [Theory]
        [InlineData(6.9, StudentStatus.EmExame)]
        [InlineData(0.0, StudentStatus.EmExame)]
        [InlineData(5.0, StudentStatus.EmExame)]
        public void TestingGradeCalculator_GetSemestralStatus_InExam(
            double ms, StudentStatus expected)
            => Assert.Equal(expected, _calculator.GetSemestralStatus(ms)); // RF-006

        // ═══════════════════════════════════════════════════════════
        // RF-006 | Cálculo da Média Final
        // ═══════════════════════════════════════════════════════════

        [Theory]
        [InlineData(6.0, 6.0, 6.0)]   // (6+6)/2 = 6,0
        [InlineData(5.0, 5.0, 5.0)]   // limiar: exatamente 5,0
        [InlineData(4.0, 6.0, 5.0)]
        [InlineData(0.0, 10.0, 5.0)]
        public void TestingGradeCalculator_CalculateFinalAverage_CorrectResult(
            double ms, double exam, double expected)
        {
            double result = _calculator.CalculateFinalAverage(ms, exam);
            Assert.Equal(expected, result); // RF-006
        }

        // ═══════════════════════════════════════════════════════════
        // RF-006 | Status Final
        // ═══════════════════════════════════════════════════════════

        [Theory]
        [InlineData(5.0, StudentStatus.Aprovado)]
        [InlineData(7.0, StudentStatus.Aprovado)]
        [InlineData(10.0, StudentStatus.Aprovado)]
        public void TestingGradeCalculator_GetFinalStatus_Approved(
            double mf, StudentStatus expected)
            => Assert.Equal(expected, _calculator.GetFinalStatus(mf)); // RF-006

        [Theory]
        [InlineData(4.9, StudentStatus.Reprovado)]
        [InlineData(0.0, StudentStatus.Reprovado)]
        [InlineData(3.0, StudentStatus.Reprovado)]
        public void TestingGradeCalculator_GetFinalStatus_Reprovado(
            double mf, StudentStatus expected)
            => Assert.Equal(expected, _calculator.GetFinalStatus(mf)); // RF-006
    }

    /// <summary>
    /// Testes de Sanitização e Validação de Texto (OOPFoundation.Text)
    /// </summary>
    public class TextSanitizationTests
    {
        private readonly OOPFoundation.Text _text = new OOPFoundation.Text();

        [Theory]
        [InlineData("7,5", "7,5")]
        [InlineData("10,0", "10,0")]
        [InlineData("abc7,5xyz", "7,5")]
        [InlineData("7.5", "75")]       // ponto é removido, só vírgula é aceita
        [InlineData("!@#7,5$%", "7,5")]
        public void TestingText_Sanitize_RemovesInvalidChars(string input, string expected)
            => Assert.Equal(expected, _text.Sanitize(input)); // RF-010
    }
}
