using System;

namespace Domain.MSC
{
	public class OperationFrequency
	{
		private bool hasResult;

		private Operand operand1;
		private Operand operand2;
		private Operand result;

		private Tuple<Operand, Operator, Operand> operation;

		public OperationFrequency (short frequency, Operand operand1, Operator operateur, Operand result)
		{
			Operator = operateur;
			Frequency = frequency;
			this.operand1 = operand1;
			this.result = result;

			hasResult = true;

			operation =	Init ();
		}

		public OperationFrequency (short frequency, Operand operand1, Operand operand2, Operator operateur)
		{			
			Operator = operateur;
			Frequency = frequency;
			this.operand1 = operand1;
			this.operand2 = operand2;

			hasResult = false;

			operation = Init ();
		}

		public short Frequency { get; private set; }

		public Operator Operator { get; private set; }


		public Tuple<double, double, double> Next (Random ran)
		{
			var	firstOperand = GenerateOperand (operation.Item1, ran); // always 1st operand
			var	secondOperand = GenerateOperand (operation.Item3, ran); // 2nd operand or result
			double problemResult = SolveProblem (firstOperand, secondOperand, operation.Item2);

			if (hasResult)
				return new Tuple<double, double, double> (problemResult, firstOperand, secondOperand);
			else
				return new Tuple<double, double, double> (firstOperand, secondOperand, problemResult);
		}

		private double GenerateOperand (Operand operand, Random ran)
		{
			var range = operand.Max - operand.Min;
			var result = ran.NextDouble () * range;
			return Math.Round (result, operand.Decimal) + operand.Min;
		}

		private double SolveProblem (double firstOperand, double secondOperand, Operator op)
		{
			switch (op) {
			case Operator.Plus:
				return firstOperand + secondOperand;
			case Operator.Minus:
				return firstOperand - secondOperand;
			case Operator.Multiply:
				return firstOperand * secondOperand;
			case Operator.Divide:
				return firstOperand / secondOperand;
			default:
				throw new Exception ("Unknown Operator");
			}
		}

		private Tuple<Operand, Operator, Operand>  Init ()
		{
			if (!hasResult)
				return new Tuple<Operand, Operator, Operand> (operand1, Operator, operand2);

			switch (Operator) {
			case Operator.Plus:
				return new Tuple<Operand, Operator, Operand> (result, Operator.Minus, operand1);
			case Operator.Minus:
				return new Tuple<Operand, Operator, Operand> (result, Operator.Plus, operand1);
			case Operator.Multiply:
				return new Tuple<Operand, Operator, Operand> (result, Operator.Divide, operand1);
			case Operator.Divide:
				return new Tuple<Operand, Operator, Operand> (result, Operator.Multiply, operand1);
			default:
				throw new Exception ("Operation not supported");
			}
		}
	}
}

