using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MathSpeedChallenge;

namespace Domain.MSC
{
	public class ProblemGenerator
	{
		private ProblemGeneratorParam param;
		private Random ran;

		public IList<MathProblem> mathProblems;

		public MathProblem[] MathProblems { get; private set; }

		public ProblemGenerator (ProblemGeneratorParam param)
		{
			this.param = param;
			ran = new Random (param.Seed);
			mathProblems = new List<MathProblem> ();

			GenerateMathProblems ();

			if (param.Shuffle)
				MathProblems = mathProblems.Shuffle ().ToArray ();
			else
				MathProblems = mathProblems.ToArray ();
		}

		private void GenerateMathProblems ()
		{
			foreach (var opFrequency  in param.Operateurs) {
				for (short frequency = 1; frequency <= opFrequency.Frequency; frequency++) {
					GenerateMathProblem (opFrequency);
				}
			}
		}

		private void GenerateMathProblem (OperationFrequency operation)
		{
			var problemTuple = operation.Next (ran);
			var formattedProblem = FormatProblem (problemTuple.Item1, problemTuple.Item2, operation.Operator);

			var problem = new MathProblem (formattedProblem, GetNumberRepresentation (problemTuple.Item3));
			GenerateWrongAnswers (problem, param.AnswerOptions - 1, operation);

			mathProblems.Add (problem);
		}

		private void GenerateWrongAnswers (MathProblem mathProblem, int answers, OperationFrequency operation)
		{
			for (int counter = 1; counter <= answers; counter++) {
				String wrongAnswer;
				do {
					var problemTuple = operation.Next (ran);
					wrongAnswer = GetNumberRepresentation (problemTuple.Item3);
				} while (mathProblem.hasAnswer (wrongAnswer));
				mathProblem.addAnswer (wrongAnswer);
			}
		}

		private String FormatProblem (double firstOperand, double secondOperand, Operator op)
		{
			var builder = new StringBuilder ();
			builder.Append (GetNumberRepresentation (firstOperand));
			builder.Append (" ");

			switch (op) {
			case Operator.Plus:
				builder.Append ("+");
				break;
			case Operator.Minus:
				builder.Append ("-");
				break;
			case Operator.Multiply:
				builder.Append ("x");
				break;
			case Operator.Divide:
				builder.Append ("÷");
				break;
			}

			builder.Append (" ");
			builder.Append (GetNumberRepresentation (secondOperand));

			return builder.ToString ();
		}

		private string GetNumberRepresentation (double number)
		{
			if (number == (int)number)
				return ((int)number).ToString ();

			return number.ToString ();
		}

	}
}

