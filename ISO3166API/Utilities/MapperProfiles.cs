using AutoMapper;
using ISO3166API.DTO;
using ISO3166API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISO3166API.Utilities
{
    public class MapperProfiles:Profile
    {
        public MapperProfiles()
        {
            CreateMap<CountryCreationDTO, Country>();
            CreateMap<Country, CountryDTO>();
            CreateMap<CountryDTO, Country>();

            CreateMap<StateCreationDTO, State>();
            CreateMap<State, StateDTO>();
            CreateMap<StateDTO, State>();
        }
    }
}
