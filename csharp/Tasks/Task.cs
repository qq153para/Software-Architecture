using System;
using System.Collections.Generic;

namespace Tasks
{
	public class Task
	{
		public string Id { get; set; }

		public string Description { get; set; }

		public bool Done { get; set; }

        public DateTime deadline { get; set; }

		public DateTime startDate { get; set; }

        public Task()
        {
            startDate = DateTime.Today;
            startDate = DateTime.Today.AddDays(1);
        }
    }
}
