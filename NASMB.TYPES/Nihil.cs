using Microsoft.VisualBasic;
using Nethereum.Util;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace NASMB.TYPES
{
    public class Maons
    {

        public static BigInteger ToNil(string strb)
        {
            var strs = strb.Split(" ");
            if (strs.Count() != 2)
            {
                throw new Exception($"StrToBigblance({strb}) 输入格式错误");
            }
            var blance = (BigDecimal)Convert.ToDecimal(strs[0]);

            BigDecimal bigDecimalFromUnit = new BigDecimal(1000_000_000_000_000_000, 0);

            switch (strs[1])
            {
                case "Knil":
                    bigDecimalFromUnit = new BigDecimal(1000, 0);
                    break;
                case "Mnil":
                    bigDecimalFromUnit = new BigDecimal(1000_000, 0);
                    break;
                case "Gnil":
                    bigDecimalFromUnit = new BigDecimal(1000_000_000, 0);
                    break;
                case "MicroMaons":
                    bigDecimalFromUnit = new BigDecimal(1000_000_000_000, 0);
                    break;
                case "MilliMaons":
                    bigDecimalFromUnit = new BigDecimal(1000_000_000_000_000, 0);
                    break;
                case "Maons":
                    bigDecimalFromUnit = new BigDecimal(1000_000_000_000_000_000, 0);
                    break;
                default:
                    bigDecimalFromUnit = new BigDecimal(1000_000_000_000_000_000, 0);
                    break;
            }

            var conversion = blance * bigDecimalFromUnit;
            return conversion.Floor().Mantissa;
        }
        
        public static string FromNil(BigInteger blance, string unit = "Maons")
        {
            switch (unit)
            {
                case "Knil":
                    return ((decimal)new BigDecimal(blance, (3 * -1))).ToString() + " Knil";

                case "Mnil":
                    return ((decimal)new BigDecimal(blance, (6 * -1))).ToString() + " Mnil";

                case "Gnil":
                    return ((decimal)new BigDecimal(blance, (9 * -1))).ToString() + " Gnil";

                case "MicroMaons":
                    return ((decimal)new BigDecimal(blance, (12 * -1))).ToString() + " MicroMaons";

                case "MilliMaons":
                    return ((decimal)new BigDecimal(blance, (15 * -1))).ToString() + " MilliMaons";

                case "Maons":
                    return ((decimal)new BigDecimal(blance, (18 * -1))).ToString() + " Maons";

                default:
                    return ((decimal)new BigDecimal(blance, (18 * -1))).ToString() + " Maons";

            }

        }


        public static decimal FromNildecimal(BigInteger blance, string unit = "Maons")
        {
            switch (unit)
            {
                case "Knil":
                    return ((decimal)new BigDecimal(blance, (3 * -1)));

                case "Mnil":
                    return ((decimal)new BigDecimal(blance, (6 * -1)));

                case "Gnil":
                    return ((decimal)new BigDecimal(blance, (9 * -1)));

                case "MicroMaons":
                    return ((decimal)new BigDecimal(blance, (12 * -1)));

                case "MilliMaons":
                    return ((decimal)new BigDecimal(blance, (15 * -1)));

                case "Maons":
                    return ((decimal)new BigDecimal(blance, (18 * -1)));

                default:
                    return ((decimal)new BigDecimal(blance, (18 * -1)));

            }

        }

    }


}
