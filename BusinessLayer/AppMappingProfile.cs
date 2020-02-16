using AutoMapper;
using Entities = DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<Entities.Task, Contract.Task>()
                .ForMember(c => c.Id, o => o.MapFrom(o => o.TaskId))
                .ForMember(c => c.Name, o => o.MapFrom(o => o.TaskName));
        }
    }
}
