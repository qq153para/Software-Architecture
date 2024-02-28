using System;
using System.IO;
using NUnit.Framework;

namespace Tasks
{
	[TestFixture]
	public sealed class ApplicationTest
	{
		public const string PROMPT = "> ";

		private FakeConsole console;
		private System.Threading.Thread applicationThread;

		[SetUp]
		public void StartTheApplication()
		{
			this.console = new FakeConsole();
			var taskList = new TaskList(console);
			this.applicationThread = new System.Threading.Thread(() => taskList.Run());
			applicationThread.Start();
		}

		[TearDown]
		public void KillTheApplication()
		{
			if (applicationThread == null || !applicationThread.IsAlive)
			{
				return;
			}

			applicationThread.Abort();
			throw new Exception("The application is still running.");
		}

		[Test, Timeout(1000)]
		public void ItWorks()
		{
			Execute("show");

			Execute("add project secrets");
			Execute("add task secrets 1 Eat more donuts.");
			Execute("add task secrets 2 Destroy all humans.");

			Execute("show");
			ReadLines(
				"secrets",
				"    [ ] 1: Eat more donuts.",
				"    [ ] 2: Destroy all humans.",
				""
			);

			Execute("add project training");
			Execute("add task training 3 Four Elements of Simple Design");
			Execute("add task training 4 SOLID");
			Execute("add task training 5 Coupling and Cohesion");
			Execute("add task training 6 Primitive Obsession");
			Execute("add task training 7 Outside-In TDD");
			Execute("add task training 8 Interaction-Driven Design");

			Execute("check 1");
			Execute("check 3");
			Execute("check 5");
			Execute("check 6");
            Execute("setdeadline 1 2024-02-28");
            Execute("setdeadline 5 2024-02-29");
            Execute("today");
            ReadLines(
                "Task Eat more donuts. is due today.",
                ""
            );
            Execute("delete 7");
			ReadLines("Task with ID 7 has been deleted.");
            Execute("show");
            ReadLines(
                "secrets",
                "    [x] 1: Eat more donuts.",
                "    [ ] 2: Destroy all humans.",
                "",
                "training",
                "    [x] 3: Four Elements of Simple Design",
                "    [ ] 4: SOLID",
                "    [x] 5: Coupling and Cohesion",
                "    [x] 6: Primitive Obsession",
                //"    [ ] 7: Outside-In TDD",
                "    [ ] 8: Interaction-Driven Design",
                ""
            );
            Execute("viewbydate");
            ReadLines(
                "Task 1 - Start Date: 2024/2/29: Eat more donuts.",
                "Task 2 - Start Date: 2024/2/29: Destroy all humans.",
                "Task 3 - Start Date: 2024/2/29: Four Elements of Simple Design",
                "Task 4 - Start Date: 2024/2/29: SOLID",
                "Task 5 - Start Date: 2024/2/29: Coupling and Cohesion",
                "Task 6 - Start Date: 2024/2/29: Primitive Obsession",
                "Task 8 - Start Date: 2024/2/29: Interaction-Driven Design"
            );
            Execute("viewbydeadline");
            ReadLines(
                "Task 2 - Deadline: 0001/1/1: Destroy all humans.",
                "Task 3 - Deadline: 0001/1/1: Four Elements of Simple Design",
                "Task 4 - Deadline: 0001/1/1: SOLID",
                "Task 6 - Deadline: 0001/1/1: Primitive Obsession",
                "Task 8 - Deadline: 0001/1/1: Interaction-Driven Design",
                "Task 1 - Deadline: 2024/2/28: Eat more donuts.",
                "Task 5 - Deadline: 2024/2/29: Coupling and Cohesion"
            );
            Execute("quit");
		}

		private void Execute(string command)
		{
			Read(PROMPT);
			Write(command);
		}

		private void Read(string expectedOutput)
		{
			var length = expectedOutput.Length;
			var actualOutput = console.RetrieveOutput(expectedOutput.Length);
			Assert.AreEqual(expectedOutput, actualOutput);
		}

		private void ReadLines(params string[] expectedOutput)
		{
			foreach (var line in expectedOutput)
			{
				Read(line + Environment.NewLine);
			}
		}

		private void Write(string input)
		{
			console.SendInput(input + Environment.NewLine);
		}
	}
}
