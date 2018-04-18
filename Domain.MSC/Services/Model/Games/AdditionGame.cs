using System;
using System.Linq;

namespace Domain.MSC
{
	public class AdditionGame: GameModel
	{
		public AdditionGame () : base (10, null)
		{
			CurrentLevel = null;
			CurrentLevelMessage = "Try to get as many as possible. Answer quick and you will have more time for the next answer!";
		}

		// TODO generate similar answers instead of random
		public override void NextLevel (int level)
		{
			Reset ();

			ProblemGeneratorParam.Shuffle = false;

			short operandDecimal1 = 0;
			short operandMin1 = 1;
			short operandMax1 = 20;

			short operandDecimal2 = 0;
			short operandMin2 = 1;
			short operandMax2 = 20;

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
						new Operand{ Decimal = operandDecimal2, Min = operandMin2, Max = operandMax2 }, 
						Operator.Plus));
			}

			TimeToSolveMs = 10000;
		}
	}
}

