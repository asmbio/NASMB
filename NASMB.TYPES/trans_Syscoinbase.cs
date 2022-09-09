using Nethereum.RLP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace NASMB.TYPES
{
    public class SysCoinbasemsg
    {

        public Msgtype Msgtype;
        // 区块根不含左右	，(必须读取内容后，发送到相应的片，以及验证)
        // hash 作为key防止重复验证,value = SignSysCoinbasemsg cid
        // 验证hash 已经不可逆
        public byte[] Hash;
        public byte[] Sslice;        // 区块所在slice ，快速验证获取区块
        public AsmbAddress Miner;   // 生产者 ，奖励目标 ; 消息发送slice
        public UInt64 Feesrate;        // 费率(生产者给的费率)
        public UInt64 Time;
        public byte[] RlpEncode()
        {
        
            //var mbytes =Marks.ToBytesForRLPEncoding();
            return RLP.EncodeDataItemsAsElementOrListAndCombineAsList(new byte[][] {
                RLP.EncodeByte((byte)Msgtype),

              //  From.GetAddressbyte(),
              //  To.GetAddressbyte() ,
              //  Balance.ToBytesForRLPEncoding(),
              //ConvertorForRLPEncodingExtensions.ToBytesFromNumber(BitConverter.GetBytes( Feesrate)),
              //Marks.ToBytesForRLPEncoding(),
                ConvertorForRLPEncodingExtensions.ToBytesFromNumber(BitConverter.GetBytes( Time)),
            });

        }
    }
    public class SignSysCoinbasemsg:Itrans
    {

        public SysCoinbasemsg SysCoinbasemsg;

        public byte[] Sign;

        public BigInteger Balance()
        {
            return BigInteger.Zero;
        }
        public BigInteger Rate()
        {
            return SysCoinbasemsg.Feesrate;
        }


        public AsmbAddress Slice(Msgtype msgtype)
        {
            return SysCoinbasemsg.Miner;
        }

        public ulong Time()
        {
            return SysCoinbasemsg.Time;
        }
        public byte[] RlpEncode()
        {

            return RLP.EncodeList(new byte[][] {
                SysCoinbasemsg.RlpEncode(),
                RLP.EncodeElement(Sign),
            });
        }
    }

}
