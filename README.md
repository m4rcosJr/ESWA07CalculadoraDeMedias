# ESWA07CalculadoraDeMedias
# ESWA07CalculadoraDeMedias

> Biblioteca de Classes — Engenharia de Software Ágil Aplicada | Atividade II | Equipe 04

---

## 📋 Sobre o Projeto

Biblioteca desenvolvida em **C#** contendo as regras de negócio para o cálculo de médias semestral e final de alunos de instituições de ensino superior (IES) e médio/técnico (IEMT).

Este projeto faz parte da **Atividade II** das disciplinas de ESWA e POO-C# ministradas pelo Prof. Marcos M. Chaves.

---

## 🏗️ Estrutura do Projeto

```
ESWA07CalculadoraDeMedias/
├── OOPFoundation/
│   ├── IDoubleValidation.cs       # Interface de validação numérica
│   ├── ADoubleValidation.cs       # Classe abstrata com limites
│   ├── NoteValidation.cs          # Valida notas [0,0 ; 10,0]
│   ├── WeightValidation.cs        # Valida pesos [0,0 ; 1,0]
│   ├── ISanitization.cs           # Interface de sanitização
│   ├── ITextValidation.cs         # Interface de validação textual
│   ├── SanitizationPattern.cs     # Padrões de caracteres permitidos
│   ├── AText.cs                   # Classe abstrata de texto
│   └── Text.cs                    # Sanitização de campos de nota
├── GradeCalculator.cs             # Lógica de cálculo de médias
├── StudentStatus.cs               # Enum de status do aluno
└── GradeCalculatorTests/
    └── GradeCalculatorTests.cs    # Testes unitários (xUnit)
```

---

## 📐 Regras de Negócio

### Média Semestral (MS)
```
MS = (4 × NP1 + 4 × NP2 + 2 × PIM) / 10
```
- MS ≥ 7,0 → **Aprovado**
- MS < 7,0 → **Em Exame**

### Média Final (MF)
```
MF = (MS + Exame) / 2
```
- MF ≥ 5,0 → **Aprovado**
- MF < 5,0 → **Reprovado**

### Arredondamento
```csharp
Math.Round(media, 1, MidpointRounding.AwayFromZero)
```

---

## ✅ Testes Unitários

Framework: **xUnit**

| Teste | Status |
|---|---|
| TestingNoteValidation_IsValid_ReturnsTrue | ✔ Aprovado |
| TestingNoteValidation_IsInvalid_ReturnsFalse | ✔ Aprovado |
| TestingWeightValidation_IsValid_ReturnsTrue | ✔ Aprovado |
| TestingWeightValidation_IsInvalid_ReturnsFalse | ✔ Aprovado |
| TestingWeightSumValidation_SumEqualsOne_ReturnsTrue | ✔ Aprovado |
| TestingWeightSumValidation_SumNotOne_ReturnsFalse | ✔ Aprovado |
| TestingGradeCalculator_CalculateSemestralAverage_CorrectResult | ✔ Aprovado |
| TestingGradeCalculator_CalculateSemestralAverage_Rounding | ✔ Aprovado |
| TestingGradeCalculator_CalculateSemestralAverage_InvalidNoteThrows | ✔ Aprovado |
| TestingGradeCalculator_GetSemestralStatus_Approved | ✔ Aprovado |
| TestingGradeCalculator_GetSemestralStatus_InExam | ✔ Aprovado |
| TestingGradeCalculator_CalculateFinalAverage_CorrectResult | ✔ Aprovado |
| TestingGradeCalculator_GetFinalStatus_Approved | ✔ Aprovado |
| TestingGradeCalculator_GetFinalStatus_Reprovado | ✔ Aprovado |
| TestingText_Sanitize_RemovesInvalidChars | ✔ Aprovado |

---

## 📦 NuGet

A biblioteca está disponível como pacote NuGet:

```
dotnet add package ESWA07CalculadoraDeMedias
```

---

## 🛠️ Tecnologias

- C# / .NET 10
- xUnit (testes unitários)
- Princípios S.O.L.I.D.
- Paradigma de Orientação a Objetos

---

## 👥 Equipe 07

| Aluno | RA |
|---|---|
| Marcos Ferreira dos Saantos Junior | F3616F2|
| Cauã Santos Aguirre | 000002 |
| Eduardo Matheus Barboza de Medeiros| H659558 |


---

> Disciplinas: Engenharia de Software Ágil Aplicada + POO-C#
> Prof. Marcos M. Chaves — 2026
