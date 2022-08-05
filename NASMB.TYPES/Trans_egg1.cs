using Nethereum.RLP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace NASMB.TYPES
{
    public class Egg1msg
    {

        public Msgtype Msgtype = Msgtype.SignEgg1;// models.Trans

        public AsmbAddress From;

        public byte[] Randomcode;
        public UInt64 Time;


        public byte[] RlpEncode()
        {
            //if (Marks == null)
            //{
            //    Marks = "";
            //}
            //var mbytes =Marks.ToBytesForRLPEncoding();
            return RLP.EncodeDataItemsAsElementOrListAndCombineAsList(new byte[][] {
                RLP.EncodeByte((byte)Msgtype),

                From.GetAddressbyte(),
                Randomcode,
                
                ConvertorForRLPEncodingExtensions.ToBytesFromNumber(BitConverter.GetBytes( Time)),
            });

        }
    }
    public class SignEgg1msg:Itrans
    {

        public Egg1msg Egg1msg;
        public byte[] Sign;

        public BigInteger Balance()
        {
            return Maons.ToNil("1 Maons");
        }

        public AsmbAddress Slice(Msgtype t)
        {
            //  if (t == Msgtype. SignEgg1 ){
            //      // 计算slice
            //      s, err:= DeEgg1Code(&cmsg.Egg1msg)

            //      if err != nil {
            //                  return make([]byte, 20)
            //}
            //      return s

            //      }
            return Egg1msg.From;
        }
        public BigInteger Rate()
        {
            return BigInteger.Zero;
        }

        public ulong Time()
        {
            return Egg1msg.Time;
        }
        public byte[] RlpEncode()
        {

            return RLP.EncodeDataItemsAsElementOrListAndCombineAsList(new byte[][] {
                Egg1msg.RlpEncode(),
                Sign,
            });
        }
    }
}
