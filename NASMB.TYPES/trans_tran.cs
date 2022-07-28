using Nethereum.RLP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.PortableExecutable;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace NASMB.TYPES
{
 
    //交易费一份为二，两次确认
    public class Transmsg
    {

        public Msgtype Msgtype = Msgtype.SignTrans; // models.Trans

        public AsmbAddress From, To;
        
        public BigInteger Balance;
        public UInt64 Feesrate;
        public string Marks ="";
        public UInt64 Time;

        public byte[] RlpEncode() {
            //var mbytes =Marks.ToBytesForRLPEncoding();
            return RLP.EncodeDataItemsAsElementOrListAndCombineAsList(new byte[][] {
                RLP.EncodeByte((byte)Msgtype),

                From.GetAddressbyte(),
                To.GetAddressbyte() ,
                Balance.ToBytesForRLPEncoding(),
              ConvertorForRLPEncodingExtensions.ToBytesFromNumber(BitConverter.GetBytes( Feesrate)),
              Marks.ToBytesForRLPEncoding(),
                ConvertorForRLPEncodingExtensions.ToBytesFromNumber(BitConverter.GetBytes( Time)),
            });

        }

        public Transmsg RlpDecode(byte[] row) {

            //var decodedList = RLP.Decode(row);
            //var decodedElements = (RLPCollection)decodedList;
            //Transmsg transmsg = new Transmsg();
            //transmsg.Header = RLP.Decode(decodedElements[0].RLPData);

            return null;
        }
    }
    public class SignTransmsg:Itrans
    {

        public Transmsg Transmsg;
        public byte[] Sign;

        public BigInteger Balance()
        {
            return Transmsg.Balance;
        }
        public BigInteger Rate()
        {
            return Transmsg.Feesrate;
        }

        public byte[] RlpEncode() {

            return RLP.EncodeDataItemsAsElementOrListAndCombineAsList(new byte[][] {
                Transmsg.RlpEncode(),
                Sign,
            });
        }

        public AsmbAddress Slice(Msgtype msgtype)
        {
            if (msgtype == Msgtype.SignTrans)
            {
                return Transmsg.From;

            }
            return Transmsg.To;
        }

        public ulong Time()
        {
            return Transmsg.Time;
        }
    }
}
