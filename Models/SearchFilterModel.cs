using System;
using System.ComponentModel.DataAnnotations;

namespace IndicadorChileWeb.Models
{
    public record SearchFilterModel
    {
        #region Field
        [
            Display(
                AutoGenerateField = false,
                AutoGenerateFilter = false,
                Description = "0 = Dólar; 1 = UF",
                GroupName = nameof(SearchFilterModel),
                Name = "Tipo de divisa",
                Order = 1,
                Prompt = "Ingrese aquí el tipo de divisa.",
                ShortName = "Tipo de divisa"
            ),
            Editable(
                allowEdit: true
            ),
            EnumDataType(
                enumType: typeof(Enums.currencyTypeEnum)
            ),
            Required(
                AllowEmptyStrings = false
            )
        ]
        public required Enums.currencyTypeEnum CurrencyType { get; init; }

        [
            Display(
                AutoGenerateField = false,
                AutoGenerateFilter = false,
                Description = "Parámetro para buscar el año",
                GroupName = nameof(SearchFilterModel),
                Name = "Año",
                Order = 2,
                Prompt = "Ingrese aquí el año.",
                ShortName = "Año"
            ),
            Editable(
                allowEdit: true
            ),
            Required(
                AllowEmptyStrings = false
            ),
            Range(
                minimum: 2013,
                maximum: ushort.MaxValue
            )
        ]
        public required ushort Year { get; init; }

        [
            Display(
                AutoGenerateField = false,
                AutoGenerateFilter = false,
                Description = "Parámetro para buscar el mes",
                GroupName = nameof(SearchFilterModel),
                Name = "Mes",
                Order = 3,
                Prompt = "Ingrese aquí el mes.",
                ShortName = "Mes"
            ),
            Editable(
                allowEdit: true
            ),
            Range(
                minimum: 1,
                maximum: 12
            )
        ]
        public byte? Month { get; init; }
        #endregion
    }
}