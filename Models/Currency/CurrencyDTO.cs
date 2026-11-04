using System;
using System.Numerics;

namespace IndicadorChileWeb.Models.Currency
{
    public record CurrencyDTO<TCurrency>
        where TCurrency : struct, IFloatingPointConstants<TCurrency>
    {
        public required Guid ID { get; init; }
        public required DateOnly Date { get; init; }
        public required string WeekdayName { get; init; }
        public required TCurrency Currency { get; init; }
    }
}