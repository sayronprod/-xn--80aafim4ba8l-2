using AutoMapper;
using тестове_xn__80aafim4ba8l_2.Models;
using тестове_xn__80aafim4ba8l_2.Data.DatabaseModels;

namespace тестове_xn__80aafim4ba8l_2.AutoMapperConfig
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<AccountCreateModel, Account>();
            CreateMap<AccountReadModel, Account>();

            CreateMap<ContactCreateModel, Contact>();
            CreateMap<ContactReadModel, Contact>();

            CreateMap<IncidentCreateModel, Incident>();
            CreateMap<IncidentReadModel, Incident>();
        }
    }
}
