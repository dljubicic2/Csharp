using System.Runtime.CompilerServices;
using teretana.Mappers;
using teretana.Models;
using teretana.Models.DTO;

namespace teretana.Extensions
{
    public static class Mapping
    {
        public static List<TreningDTO> MapTrening(this List<Trening> treninzi)
        {
            var mapper = TreningMapper.InitializeAutomaper();
            var vrati = new List <TreningDTO>();
            treninzi.ForEach(t =>
            {
                vrati.Add(mapper.Map<TreningDTO>(t));
            });
            return vrati;
        }
    }
}
