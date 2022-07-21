using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASMB.TYPES
{
    public class Address
    {
         byte[] _address;

        public string String()
        {
            return SimpleBase.Base58.Bitcoin.Encode(_address);
        }
    }
}
