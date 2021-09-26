using AutoMapper;
using тестове_xn__80aafim4ba8l_2.Models;
using тестове_xn__80aafim4ba8l_2.Data.DatabaseModels;

namespace тестове_xn__80aafim4ba8l_2.AutoMapperConfig
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Account, AccountCreateModel>();
            CreateMap<Account, AccountReadModel>();

            CreateMap<Contact, ContactCreateModel>();
            CreateMap<Contact, ContactReadModel>();

            CreateMap<Incident, IncidentCreateModel>();
            CreateMap<Incident, IncidentReadModel>();
        }
    }
}
