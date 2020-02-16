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
            CreateMap<Contract.Task, Entities.Task>()
                .ForMember(c => c.TaskId, o => o.MapFrom(o => o.Id))
                .ForMember(c => c.TaskName, o => o.MapFrom(o => o.Name));
        }
    }
}
