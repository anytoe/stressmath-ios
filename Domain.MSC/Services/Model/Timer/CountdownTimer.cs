using System;

namespace Domain.MSC
{
	public class CountdownTimer
	{
		public int InitialValue { get; set; } = 3;

		public int CurrentValue { get; set; } = 3;

		public void Decrement ()
		{
			CurrentValue--;
		}

		public bool IsFinished {
			get { return CurrentValue == 0; }
		}

	}
}

