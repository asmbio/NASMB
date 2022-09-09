using Nethereum.RLP;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace NASMB.TYPES
{

    //    type Worksmsg struct {

    //    Msgtype Msgtype // models.Works

    //    From, Channel types.Address

    //    Feesrate uint64 //

    //    Content       string //内容
    //    Time          uint64 //时间
    //}
    //type SignWorksmsg struct {

    //    Worksmsg Worksmsg
    //	Sign     [] byte
    //}

    //type WorksmsgEx struct {

    //    pltrie* trie.Trie

    //    Up uint32 //支持 点赞 数  key +"1"

    //    Down uint32 //反对 踩 数	key +"2"

    //    Fenxiang uint32 //分享次数

    //    PinglunTimes uint32 //评论次数

    //    Pinglun[]byte //默克尔树根

    //}
    //type SignWorksmsgEx struct {

    //    *SignWorksmsg

    //    WorksmsgEx
    //}
    public class Worksmsg
    {

        public Msgtype Msgtype = Msgtype.SignWorks;// models.Trans

        public AsmbAddress From
        {
            get; set;
        }
        public AsmbAddress Channel
        {
            get; set;
        }
        
        public UInt64 Feesrate
        {
            get; set;
        }
        
        public string Title { get; set; }
        public byte[] Content { get; set; }
        public UInt64 Time { get; set; }
        [JsonIgnore]
        public string Content2
        {
            get
            {
                return  Content.ToStringFromRLPDecoded();
            }
        }


        //    From, Channel types.Address

        //    Feesrate uint64 //

        //    Content       string //内容
        //    Time          uint64 //时间

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
                Channel.GetAddressbyte(),                
                ConvertorForRLPEncodingExtensions.ToBytesFromNumber(BitConverter.GetBytes( Feesrate)),
                Title.ToBytesForRLPEncoding(),
                Content,
                ConvertorForRLPEncodingExtensions.ToBytesFromNumber(BitConverter.GetBytes( Time)),
            });

        }
    }
    public class SignWorksmsg : Itrans
    {

        public Worksmsg Worksmsg { get; set; }
        public byte[] Sign;

        public BigInteger Balance()
        {
            return BigInteger.Zero;
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

            if (t == Msgtype.SignWorks) {

                return Worksmsg.From;
            }
            return Worksmsg.Channel;
        }
        public BigInteger Rate()
        {
            return Worksmsg.Feesrate;
        }

        public ulong Time()
        {
            return Worksmsg.Time;
        }
        public byte[] RlpEncode()
        {
            return RLP.EncodeList(new byte[][] {
                Worksmsg.RlpEncode(),
                RLP.EncodeElement(Sign),
            });
        }
    }
}
