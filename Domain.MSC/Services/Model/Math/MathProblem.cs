using System;
using System.Collections.Generic;

namespace Domain.MSC
{
	public class MathProblem {

		private String problem;
		private String solution;

		private String givenAnswer;
		private bool answered;
		private HashSet<String> allAnswers;

		public MathProblem(String problem, String solution) {
			this.problem = problem;
			this.solution = solution;
			this.allAnswers = new HashSet<String>();
			allAnswers.Add(solution);
		}

		public MathProblem addAnswer(String wrongAnswer) {
			allAnswers.Add(wrongAnswer);
			return this;
		}

		public String getProblem() {
			return problem;
		}

		public String[] getRandomizedAnswers() {
			String[] randomizedAnswers = new String[allAnswers.Count];
			List<string> copiedList = new List<string>(allAnswers);

			Random ran = new Random(problem.GetHashCode());

			int nextIndex = 0;
			while (copiedList.Count > 0) {
				int nextAnswerIndex = ran.Next(copiedList.Count);
				String nextAnswer = copiedList[nextAnswerIndex];
				randomizedAnswers[nextIndex] = nextAnswer;
				copiedList.Remove(nextAnswer);
				nextIndex++;
			}

			return randomizedAnswers;
		}

		public bool hasAnswer(String answer) {
			return allAnswers.Contains(answer);
		}

		public bool IsAnswerCorrect(String answer) {
			givenAnswer = answer;
			answered = solution.Equals(answer);

			return answered;
		}

	}

}

