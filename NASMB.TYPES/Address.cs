using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NASMB.TYPES
{

    public class AddrConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var ret =new AsmbAddress((string)reader.Value);
            //ret.Address = ;
            return ret;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null|| value.ToString()==null)
            {
                writer.WriteNull(); return;
            }
            else
            {
                writer.WriteRawValue($"\"{value.ToString()}\"");
            }
   
        //    writer.WriteEnd();
        }
    }
    [JsonConverter(typeof(AddrConverter))]
    public class AsmbAddress
    {

        public AsmbAddress(byte[] bytes)
        {
            SetAddressByte(bytes);
        }
        //public AsmbAddress() { }
        public AsmbAddress(string addr)
        {
            Address = addr;
        }
        byte[] __address;
        public byte[] GetAddressbyte()
        {                   
                return __address;                      
        }
        public void SetAddressByte(byte[] bytes)
        {
            
                if (__address != bytes)
                {
                    __address = bytes;
                    address = SimpleBase.Base58.Bitcoin.Encode(__address);
                }
            
        }
        string address;

        public string Address
        {
            get => address;
            set
            {

                address = value;
                __address = SimpleBase.Base58.Bitcoin.Decode(address).ToArray();
            }         
            
        }

        public void SetAddress(string bytes)
        {

            if (address != bytes)
            {
                address = bytes;
                __address = SimpleBase.Base58.Bitcoin.Decode(address).ToArray();
            }

        }
        public override string ToString()
        {
            return address;
           // return ;
        }

     
          
        //public byte[] RlpEncode() {

        //    return Nethereum.RLP.RLP.EncodeElement(__address);
        //}
    }
}
