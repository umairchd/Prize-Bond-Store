using PrizeBondStore.Models;

namespace PrizeBondStore.Mappers
{
    public static class Mapper
    {
        public static DenominationModel CreateFrom(this Denomination source)
        {
            return new DenominationModel
            {
                Type = source.Type,
                DenominationId = source.DenominationId
            };

        }

        public static Denomination CreateFrom(this DenominationModel source)
        {
            return new Denomination
            {
                Type = source.Type,
                DenominationId = source.DenominationId
            };

        }

        public static PrizeBondModel CreateFrom(this PrizeBond source)
        {
            return new PrizeBondModel
            {
                Type = source.Denomination?.Type.ToString(),
                Code = source.PrizeBondCode
            };

        }
    }
}
