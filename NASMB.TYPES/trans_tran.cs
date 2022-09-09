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

   
        public AsmbAddress From
        {
            get; set;
        }
        public AsmbAddress To
        {
            get; set;
        }
        public BigInteger Balance
        {
            get; set;
        }
        public UInt64 Feesrate
        {
            get; set;
        }
        public string Marks
        {
            get; set;
        }
        public UInt64 Time
        {
            get; set;
        }

        public byte[] RlpEncode()
        {
            if (Marks == null)
            {
                Marks = "";
            }
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

        public Transmsg Transmsg { get; set; }
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

            return RLP.EncodeList(new byte[][] {
                Transmsg.RlpEncode(),
                RLP.EncodeElement(Sign),
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
