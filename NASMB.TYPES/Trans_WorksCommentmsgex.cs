using Nethereum.RLP;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
  
    public class SignWorkscommentmsgEx : Itrans, IWorksEx
    {
        public SignWorkscommentmsg SignWorkscommentmsg { get; set; }
        public WorksmsgEx WorksmsgEx { get; set; }
     //   public byte[] Sign;

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

            return SignWorkscommentmsg.Slice(t);
        }
        public BigInteger Rate()
        {
            return SignWorkscommentmsg.Rate();
        }

        public ulong Time()
        {
            return SignWorkscommentmsg.Time();
        }
        public byte[] RlpEncode()
        {
            return SignWorkscommentmsg.RlpEncode();
        }

        public AsmbAddress WAddr()
        {
            return SignWorkscommentmsg.Workscommentmsg.From;
        }

        public byte[] Rcphash()
        {
            return WorksmsgEx.Pinglun;
        }
       public WorksmsgEx GetWorksmsgEx()
        {
            return WorksmsgEx;
        }

        public void SetWorksmsgEx(WorksmsgEx worksmsgEx)
        {
            WorksmsgEx = worksmsgEx ;
        }
    }
}
