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
    public class WorksmsgEx
    {       
        public UInt32 Up
        {
            get; set;
        }
        public UInt32 Down
        {
            get; set;
        }
        public UInt32 Fenxiang
        {
            get; set;
        }
        public UInt32 PinglunTimes
        {
            get; set;
        }
     
        public byte[] Pinglun;
       
        [JsonIgnore]
        public byte AddrState
        { get; set; }

        [JsonIgnore]
        public DateTime Laststatetime
        { get; set; }

        [JsonIgnore]
        public ObservableCollection< Messagebs> Receipts { get;set; }
        //[JsonIgnore]
      //  public ObservableCollection<Messagebs> MyReceipts { get; set; }
        //    From, Channel types.Address

        //    Feesrate uint64 //

        //    Content       string //内容
        //    Time          uint64 //时间

        public byte[] RlpEncode()
        {
            return null;
            //if (Marks == null)
            //{
            //    Marks = "";
            //}
            //var mbytes =Marks.ToBytesForRLPEncoding();
            //return RLP.EncodeDataItemsAsElementOrListAndCombineAsList(new byte[][] {
            //    RLP.EncodeByte((byte)Msgtype),

            //    From.GetAddressbyte(),
            //    Channel.GetAddressbyte(),
                
            //    ConvertorForRLPEncodingExtensions.ToBytesFromNumber(BitConverter.GetBytes( Feesrate)),
            //    Content,

            //    ConvertorForRLPEncodingExtensions.ToBytesFromNumber(BitConverter.GetBytes( Time)),
            //});

        }
    }

    public interface IWorksEx
    {

        AsmbAddress WAddr();

        byte[] Rcphash();

       // Msgtype GetTag();
        WorksmsgEx GetWorksmsgEx();
        void SetWorksmsgEx(WorksmsgEx worksmsgEx);
        //ConstantExpression
        // Transmsg Transmsg { get; set; }  
        //	vdmsg(c *Chain, ct *StateManager, cmsglen int, rcpkey []byte) (*StateAccount, *big.Int, error)
        //   VdRequest(c* Chain, msgfrom* pubsub.Message,  Messagebs msgbs) error
        //   Vdtrans(c* Chain, nblk* BlockHeader, msg Messagebs, ct* StateManager, blksize* uint32, coinbase* big.Int) ([]byte, error)
        //Rate() uint64
        //Uint64  Timestamp();
        //Slice(t Msgtype) [] byte
    }
    public class SignWorksmsgEx : Itrans,IWorksEx
    {
        public SignWorksmsg SignWorksmsg { get; set; }
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

            return SignWorksmsg.Slice(t);
        }
        public BigInteger Rate()
        {
            return SignWorksmsg.Rate();
        }

        public ulong Time()
        {
            return SignWorksmsg.Time();
        }
        public byte[] RlpEncode()
        {
            return SignWorksmsg.RlpEncode();
        }

        public AsmbAddress WAddr()
        {
            return SignWorksmsg.Worksmsg.From;
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
            WorksmsgEx = worksmsgEx;
        }

        //public Msgtype GetTag()
        //{
        //    return SignWorksmsg.Worksmsg.ta;
        //}
    }
}
