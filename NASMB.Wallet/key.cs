using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASMB.Wallet
{
   

    public struct KeyInfo
    {

       
    }

    public class Key
    {
        public byte Type;

        public byte[] PrivateKey;

        public byte[] PublicKey ;
        AsmbKey _asmbKey;
        internal AsmbKey asmbKey { 
            get
            {
                if (_asmbKey == null)
                {
                    _asmbKey = new AsmbKey(PrivateKey, true);
                }
                return _asmbKey;
            }
            set
            {
                _asmbKey = value;
            }
        
        }
        byte[] __address;
       internal byte[] _Address
        {
            get
            {
                return __address;
            }
            set
            {
                if(__address != value)
                {
                    __address = value;
                    address = SimpleBase.Base58.Bitcoin.Encode(__address);
                }
            }
        }
        string address;

        public string Address
        {
            set { 
                address = value;
                __address = SimpleBase.Base58.Bitcoin.Decode(address).ToArray();
            }
            get { return address; }           
        }
    }


}
