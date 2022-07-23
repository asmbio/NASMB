using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASMB.TYPES
{
    public class AsmbAddress
    {
        byte[] __address;
        internal byte[] _Address
        {
            get
            {
                return __address;
            }
            set
            {
                if (__address != value)
                {
                    __address = value;
                    address = SimpleBase.Base58.Bitcoin.Encode(__address);
                }
            }
        }
        string address;

        public string Address
        {
            set
            {
                address = value;
                __address = SimpleBase.Base58.Bitcoin.Decode(address).ToArray();
            }
            get { return address; }
        }
    }
}
