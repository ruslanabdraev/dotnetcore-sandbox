using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface ITaskService
    {
        Task<string[]> GetTasksAsync();
    }
}
