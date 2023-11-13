using AutoMapper;
using teretana.Models;
using teretana.Models.DTO;

namespace teretana.Mappers
{
    public class TreningMapper
    {
        public static Mapper InitializeAutomaper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Trening, TreningDTO>()
                .ForMember(dest => dest.Oprema, act => act.MapFrom(src => src.Oprema!.Naziv))
                .ForMember(dest => dest.BrojKorisnika, act => act.MapFrom(src => src.Korisnici.Count));
            });

            var mapper = new Mapper(config);
            return mapper;
        }

        
    }
}
