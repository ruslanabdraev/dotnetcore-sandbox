using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class TaskService : ITaskService
    {
        public async Task<Contract.Task[]> GetTasksAsync()
        {
            return await Task.Run(() => new Contract.Task[]
                {
                    new Contract.Task{Id=1, Name="Task1" }, new Contract.Task{Id=2, Name="Task2" }
                });
        }
    }
}
