using AutoMapper;
using LibraryManagement.Core.Domain.RequestModels;
using LibraryManagement.Core.Domain.ResponseModels;
using LibraryManagement.Infra.Domain.Models;

namespace LibraryManagement.API.Configuration;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<StudentRequestModel, Student>();
        CreateMap<Student, StudentResponseModel>().ReverseMap();
    }
}
