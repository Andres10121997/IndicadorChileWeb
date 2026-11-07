using System;
using System.ComponentModel.DataAnnotations;

namespace IndicadorChileWeb
{
    public static class Enums
    {
        public enum currencyTypeEnum : byte
        {
            [
                Display(
                    AutoGenerateField = false,
                    AutoGenerateFilter = false,
                    Description = "",
                    GroupName = "Divisa",
                    Name = "Dólar estadounidense",
                    Order = 1,
                    Prompt = "",
                    ShortName = "USD"
                )
            ]
            USD,

            [
                Display(
                    AutoGenerateField = false,
                    AutoGenerateFilter = false,
                    Description = "",
                    GroupName = "Divisa",
                    Name = "Unidad de Fomento",
                    Order = 2,
                    Prompt = "",
                    ShortName = "UF"
                )
            ]
            UF
        }

        public enum monthNameEnum : byte
        {
            Enero = 1,
            Febrero,
            Marzo,
            Abril,
            Mayo,
            Junio,
            Julio,
            Agosto,
            Septiembre,
            Octubre,
            Noviembre,
            Diciembre
        }
    }
}