using AutoMapper;
using Compugraf.Application.ViewModel;
using Compugraf.Domain.Model;

namespace Compugraf.Application.MappingProfile
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonVm>().ReverseMap();
            CreateMap<CreatePersonVm, Person>();
        }
    }
}
