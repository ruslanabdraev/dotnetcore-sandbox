using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Entities = DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class TaskService : ITaskService
    {
        private readonly IMapper _mapper;
        private readonly TaskContext _context;

        public TaskService(IMapper mapper, TaskContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Contract.Task[]> GetTasksAsync()
        {
            return _mapper.Map<Entities.Task[], Contract.Task[]>(await _context.Tasks.ToArrayAsync());
        }
    }
}
