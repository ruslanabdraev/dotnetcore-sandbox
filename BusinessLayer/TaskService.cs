using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class TaskService : ITaskService
    {
        public async Task<string[]> GetTasksAsync()
        {
            return await Task.Run(() => new string[]
                {
                    "task1", "task2"
                });
        }
    }
}
