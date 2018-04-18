using System;
using System.Linq;

namespace Domain.MSC
{
	public class DivisionGame: GameModel
	{
		public DivisionGame () : base (25, null)
		{
			CurrentLevel = null;
			CurrentLevelMessage = "Try to get as many as possible. Answer quick and you will have more time for the next answer!";
		}

		// TODO generate similar answers instead of random
		public override void NextLevel (int level)
		{
			Reset ();

			short operandDecimal1 = 0;
			short operandMin1 = 2;
			short operandMax1 = 5;

			short operandDecimal2 = 0;
			short operandMin2 = 2;
			short operandMax2 = 5;

			for (var counter = 1; counter < 100; counter++) {

				if (counter % 10 == 5) {
					operandDecimal1 += 1;
				} else if (counter % 10 == 0) {
					operandDecimal2 += 1;
				} else if (counter % 3 == 0) {
					operandMin1 = operandMin2 += 3;
					operandMax1 = operandMax2 += 5;
				}

				ProblemGeneratorParam.Operateurs.Add (
					new OperationFrequency (1,
						new Operand{ Decimal = operandDecimal1, Min = operandMin1, Max = operandMax1 }, 
						Operator.Divide, 
						new Operand{ Decimal = operandDecimal2, Min = operandMin2, Max = operandMax2 }
					));
			}

			TimeToSolveMs = 10000;
		}
	}
}

