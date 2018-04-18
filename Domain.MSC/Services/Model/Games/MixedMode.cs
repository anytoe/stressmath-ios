using System;
using System.Linq;

namespace Domain.MSC
{
	// TODO Math generator generates 0
	public class MixedMode: GameModel
	{
		public MixedMode () : base (10, 7) // TODO level count 4 means 3 games, crappy!
		{
			CurrentLevel = 1;
			CurrentLevelMessage = "Let's start simple with basic operations.";
		}

		public override void NextLevel (int level)
		{
			Reset ();

			switch (level) {
			case 1:
				Level1 ();
				break;
			case 2:
				Level2 ();
				break;
			case 3:
				Level3 ();
				break;
			case 4:
				Level4 ();
				break;
			case 5:
				Level5 ();
				break;
			case 6:
				Level6 ();
				break;
			}
		}

		private void Level1 ()
		{
			TimeToSolveMs = 5000;

			// Simple add and subtract
			ProblemGeneratorParam.Operateurs.Add (
				new OperationFrequency (3,
					new Operand{ Min = 1, Max = 30, Decimal = 0  }, 
					new Operand{ Min = 1, Max = 30, Decimal = 0  }, 
					Operator.Plus));

			ProblemGeneratorParam.Operateurs.Add (
				new OperationFrequency (3,
					new Operand{ Min = 1, Max = 30, Decimal = 0  }, 
					new Operand{ Min = 1, Max = 30, Decimal = 0  }, 
					Operator.Minus));

			ProblemGeneratorParam.Shuffle = true;

			CurrentLevel++;
			CurrentLevelMessage = "Well done, let's make it more difficult!";
		}

		private void Level2 ()
		{
			TimeToSolveMs = 6000;

			// More difficult add and subtract
			ProblemGeneratorParam.Operateurs.Add (
				new OperationFrequency (3,
					new Operand{ Min = 19, Max = 50, Decimal = 0  }, 
					new Operand{ Min = 19, Max = 50, Decimal = 0  }, 
					Operator.Plus));

			ProblemGeneratorParam.Operateurs.Add (
				new OperationFrequency (3,
					new Operand{ Min = 19, Max = 50, Decimal = 0  }, 
					new Operand{ Min = 19, Max = 50, Decimal = 0  }, 
					Operator.Minus));

			ProblemGeneratorParam.Shuffle = true;

			CurrentLevel++;
			CurrentLevelMessage = "Nice one, do you like decimals?";
		}

		private void Level3 ()
		{
			TimeToSolveMs = 7000;

			// Increasing decimal from 0-1, plus, minus each
			ProblemGeneratorParam.Operateurs.Add (
				new OperationFrequency (1,
					new Operand{ Min = 0, Max = 1, Decimal = 1  }, 
					new Operand{ Min = 0, Max = 1, Decimal = 1  }, 
					Operator.Plus));

			ProblemGeneratorParam.Operateurs.Add (
				new OperationFrequency (1,
					new Operand{ Min = 0, Max = 1, Decimal = 1 }, 
					new Operand{ Min = 0, Max = 1, Decimal = 1  }, 
					Operator.Minus));

			ProblemGeneratorParam.Operateurs.Add (
				new OperationFrequency (1,
					new Operand{ Min = 0, Max = 1, Decimal = 2  }, 
					new Operand{ Min = 0, Max = 1, Decimal = 2  }, 
					Operator.Plus));

			ProblemGeneratorParam.Operateurs.Add (
				new OperationFrequency (1,
					new Operand{ Min = 0, Max = 1, Decimal = 2 }, 
					new Operand{ Min = 0, Max = 1, Decimal = 2  }, 
					Operator.Minus));

			ProblemGeneratorParam.Operateurs.Add (
				new OperationFrequency (1,
					new Operand{ Min = 0, Max = 1, Decimal = 3  }, 
					new Operand{ Min = 0, Max = 1, Decimal = 3  }, 
					Operator.Plus));

			ProblemGeneratorParam.Operateurs.Add (
				new OperationFrequency (1,
					new Operand{ Min = 0, Max = 1, Decimal = 3 }, 
					new Operand{ Min = 0, Max = 1, Decimal = 3  }, 
					Operator.Minus));

			ProblemGeneratorParam.Shuffle = false;

			CurrentLevel++;
			CurrentLevelMessage = "Let's take this to another level.";

		}

		private void Level4 ()
		{
			TimeToSolveMs = 8000;

			// multiply and divide
			ProblemGeneratorParam.Operateurs.Add (
				new OperationFrequency (3, 
					new Operand{ Min = 2, Max = 20, Decimal = 0  }, 
					new Operand{ Min = 2, Max = 20, Decimal = 0  }, 
					Operator.Multiply));

			ProblemGeneratorParam.Operateurs.Add (
				new OperationFrequency (3,
					new Operand{ Min = 2, Max = 20, Decimal = 0  },  
					Operator.Divide, 
					new Operand{ Min = 2, Max = 20, Decimal = 0  }
				));


			ProblemGeneratorParam.Shuffle = true;

			CurrentLevel++;
			CurrentLevelMessage = "Tough! Right I've got more for you.";
		}

		private void Level5 ()
		{
			TimeToSolveMs = 9000;

			// Basic multiply and divide
			ProblemGeneratorParam.Operateurs.Add (
				new OperationFrequency (3, 
					new Operand{ Min = 19, Max = 50, Decimal = 0  }, 
					new Operand{ Min = 19, Max = 50, Decimal = 0  }, 
					Operator.Multiply));

			ProblemGeneratorParam.Operateurs.Add (
				new OperationFrequency (3,
					new Operand{ Min = 19, Max = 50, Decimal = 0  },  
					Operator.Divide, 
					new Operand{ Min = 19, Max = 50, Decimal = 0  }
				));


			ProblemGeneratorParam.Shuffle = true;

			CurrentLevel++;
			CurrentLevelMessage = "You got to here! The last one!!!";
		}

		private void Level6 ()
		{
			TimeToSolveMs = 10000;

			// Basic multiply and divide
			ProblemGeneratorParam.Operateurs.Add (
				new OperationFrequency (1, 
					new Operand{ Min = 19, Max = 50, Decimal = 1  }, 
					new Operand{ Min = 19, Max = 50, Decimal = 1  }, 
					Operator.Multiply));

			ProblemGeneratorParam.Operateurs.Add (
				new OperationFrequency (1,
					new Operand{ Min = 19, Max = 50, Decimal = 1  },  
					Operator.Divide, 
					new Operand{ Min = 19, Max = 50, Decimal = 1  }
				));

			ProblemGeneratorParam.Operateurs.Add (
				new OperationFrequency (1, 
					new Operand{ Min = 19, Max = 50, Decimal = 2  }, 
					new Operand{ Min = 19, Max = 50, Decimal = 2  }, 
					Operator.Multiply));

			ProblemGeneratorParam.Operateurs.Add (
				new OperationFrequency (1,
					new Operand{ Min = 19, Max = 50, Decimal = 2  },  
					Operator.Divide, 
					new Operand{ Min = 19, Max = 50, Decimal = 2  }
				));

			ProblemGeneratorParam.Operateurs.Add (
				new OperationFrequency (1, 
					new Operand{ Min = 19, Max = 50, Decimal = 2  }, 
					new Operand{ Min = 19, Max = 50, Decimal = 2  }, 
					Operator.Multiply));

			ProblemGeneratorParam.Operateurs.Add (
				new OperationFrequency (1,
					new Operand{ Min = 19, Max = 50, Decimal = 3  },  
					Operator.Divide, 
					new Operand{ Min = 19, Max = 50, Decimal = 3  }
				));


			ProblemGeneratorParam.Shuffle = false;

			CurrentLevel++;
			CurrentLevelMessage = null;
		}

	}
}

