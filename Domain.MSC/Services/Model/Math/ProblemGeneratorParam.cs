using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.MSC
{
	public class ProblemGeneratorParam
	{
		public ProblemGeneratorParam ()
		{
			Operateurs = new List<OperationFrequency> ();
			Seed = DateTime.Now.GetHashCode ();
		}

		public int Seed { get; set; }

		public List<OperationFrequency> Operateurs { get; set; }

		public bool? IdenticalOperands { get; set; } = true;

		public bool SimilarAnswers { get; set; } = false;

		public short AnswerOptions { get; set; } = 4;

		public bool Shuffle { get; set; }
	}
}

