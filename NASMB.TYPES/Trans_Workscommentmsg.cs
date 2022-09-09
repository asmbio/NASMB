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


//    type Workscommentmsg struct {

//    Msgtype Msgtype // models.Works

//    From, To types.Address

//    Key[]byte //作品key
//    Feesrate uint64 //
//    Tag      byte   //1 - 赞 ；2 - 踩 ；3 - 评论  ；4 - 分享
//    Content  string //内容
//    Time     uint64 //时间
//}
//type SignWorkscommentmsg struct {

//    Workscommentmsg Workscommentmsg
//	Sign            [] byte
//}

    public class Workscommentmsg
    {

        public Msgtype Msgtype = Msgtype.SWorkscomment;// models.Trans

        public AsmbAddress From
        {
            get; set;
        }
        public AsmbAddress To
        {
            get; set;
        }
        public byte[] Key { get; set; }

        public UInt64 Feesrate
        {
            get; set;
        }
        public byte Tag
        {
            get; set;
        }
        public byte[] Content { get; set; }
        public UInt64 Time { get; set; }

        [JsonIgnore]
        public string Content2
        {
            get
            {
                return Content.ToStringFromRLPDecoded();
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
                To.GetAddressbyte(),
                Key,
                ConvertorForRLPEncodingExtensions.ToBytesFromNumber(BitConverter.GetBytes( Feesrate)),
                RLP.EncodeByte(Tag),
                Content,

                ConvertorForRLPEncodingExtensions.ToBytesFromNumber(BitConverter.GetBytes( Time)),
            });

        }
    }
    public class SignWorkscommentmsg : Itrans
    {

        public Workscommentmsg Workscommentmsg { get; set; }
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

            if (t == Msgtype.SWorkscomment) {

                return Workscommentmsg.From;
            }
            return Workscommentmsg.To;
        }
        public BigInteger Rate()
        {
            return Workscommentmsg.Feesrate;
        }

        public ulong Time()
        {
            return Workscommentmsg.Time;
        }
        public byte[] RlpEncode()
        {

            return RLP.EncodeList(new byte[][] {
                Workscommentmsg.RlpEncode(),
                RLP.EncodeElement(Sign),
            });
        }
    }
}
