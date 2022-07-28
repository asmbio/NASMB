using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JsonSubTypes;
using System.Linq.Expressions;

namespace NASMB.TYPES
{
    //  [JsonConverter(typeof( PolyConverter))]

    [JsonConverter(typeof(JsonSubtypes))]
    [JsonSubTypes.JsonSubtypes.KnownSubTypeWithProperty(typeof(SignTransmsg), "Transmsg")]
    [JsonSubTypes.JsonSubtypes.KnownSubTypeWithProperty(typeof(SignSysCoinbasemsg), "SysCoinbasemsg")]
    [JsonSubTypes.JsonSubtypes.KnownSubTypeWithProperty(typeof(SignEgg1msg), "Egg1msg")]
    public interface Itrans
    {
        UInt64 Time();
        System.Numerics.BigInteger Balance();
        System.Numerics.BigInteger Rate();
        AsmbAddress Slice(Msgtype msgtype);
        //ConstantExpression
        // Transmsg Transmsg { get; set; }  
        //	vdmsg(c *Chain, ct *StateManager, cmsglen int, rcpkey []byte) (*StateAccount, *big.Int, error)
        //   VdRequest(c* Chain, msgfrom* pubsub.Message,  Messagebs msgbs) error
        //   Vdtrans(c* Chain, nblk* BlockHeader, msg Messagebs, ct* StateManager, blksize* uint32, coinbase* big.Int) ([]byte, error)
        //Rate() uint64
        // Uint64  Timestamp();
        //   Slice(t Msgtype) [] byte
    }
    public class Messagebs
    {

        public Msgtype Msgtype;
        internal int len;
        internal byte[] raw;
        internal byte[] shakey;

        public Itrans Body;    // 可以是cid ,也可以是body(signmsg)
                               //	Hash   []byte // 确认区块hash
                               //	St   byte

        [JsonIgnore]
        public string Mtype
        {
            get
            {
                switch (Msgtype)
                {
                    case Msgtype.Unknown:
                        break;
                    case Msgtype.PubBlock:
                        break;
                    case Msgtype.JionPD:
                        break;
                    case Msgtype.SysCoinbase:
                        return "奖励";
                    case Msgtype.SignTrans:
                        return "输出";
                    case Msgtype.CfmTrans:
                        return "输入";
                    case Msgtype.SignVote:
                        break;
                    case Msgtype.CfmVote:
                        break;
                    case Msgtype.RSignVote:
                        break;
                    case Msgtype.SignCancelvote:
                        break;
                    case Msgtype.CfmCancelvote:
                        break;
                    case Msgtype.ExcCancelVote:
                        break;
                    case Msgtype.ExcCancelVoteFail:
                        break;
                    case Msgtype.RSignCancelvoteSucc:
                        break;
                    case Msgtype.RSignCancelvoteFail:
                        break;
                    case Msgtype.SignProducing:
                        break;
                    case Msgtype.ExcProducing:
                        break;
                    case Msgtype.ExcProducingFail:
                        break;
                    case Msgtype.RSignProducingSucc:
                        break;
                    case Msgtype.RSignProducingFail:
                        break;
                    case Msgtype.SignCancelProducing:
                        break;
                    case Msgtype.ExcCancelProducing:
                        break;
                    case Msgtype.ExcCancelProducingFail:
                        break;
                    case Msgtype.RSignCancelProducingSucc:
                        break;
                    case Msgtype.RSignCancelProducingFail:
                        break;
                    case Msgtype.SignVoteRefresh:
                        break;
                    case Msgtype.ExcVoteRefresh:
                        break;
                    case Msgtype.ExcVoteRefreshFail:
                        break;
                    case Msgtype.Addcharges:
                        break;
                    case Msgtype.SignEgg1:
                        return "抽奖";
                    case Msgtype.CfmEgg1:
                        return "奖励";
                    default:

                        break;
                }
                return Msgtype.ToString();
            }


        }
        [JsonIgnore]
        public DateTime Time { get { return new DateTime((long)Body.Time()/100+ 621355968000000000); } }
        [JsonIgnore]
        public string Balance
        {
            get
            {
                string prex = "+ ";
                switch (Msgtype)
                {
                    case Msgtype.Unknown:
                        break;
                    case Msgtype.PubBlock:
                        break;
                    case Msgtype.JionPD:
                        break;
                    case Msgtype.SysCoinbase:
                        break;
                    case Msgtype.SignTrans:
                        prex = "- ";
                        break;
                    case Msgtype.CfmTrans:
                        break;
                    case Msgtype.SignVote:
                        break;
                    case Msgtype.CfmVote:
                        break;
                    case Msgtype.RSignVote:
                        break;
                    case Msgtype.SignCancelvote:
                        break;
                    case Msgtype.CfmCancelvote:
                        break;
                    case Msgtype.ExcCancelVote:
                        break;
                    case Msgtype.ExcCancelVoteFail:
                        break;
                    case Msgtype.RSignCancelvoteSucc:
                        break;
                    case Msgtype.RSignCancelvoteFail:
                        break;
                    case Msgtype.SignProducing:
                        break;
                    case Msgtype.ExcProducing:
                        break;
                    case Msgtype.ExcProducingFail:
                        break;
                    case Msgtype.RSignProducingSucc:
                        break;
                    case Msgtype.RSignProducingFail:
                        break;
                    case Msgtype.SignCancelProducing:
                        break;
                    case Msgtype.ExcCancelProducing:
                        break;
                    case Msgtype.ExcCancelProducingFail:
                        break;
                    case Msgtype.RSignCancelProducingSucc:
                        break;
                    case Msgtype.RSignCancelProducingFail:
                        break;
                    case Msgtype.SignVoteRefresh:
                        break;
                    case Msgtype.ExcVoteRefresh:
                        break;
                    case Msgtype.ExcVoteRefreshFail:
                        break;
                    case Msgtype.Addcharges:
                        break;
                    case Msgtype.SignEgg1:
                        break;
                    case Msgtype.CfmEgg1:
                        break;
                    default:
                        break;
                }
                return prex + Nihil.FromNil(Body.Balance());
            }
        }
        [JsonIgnore]
        public AsmbAddress Slice { get { return Body.Slice(Msgtype); } }
        [JsonIgnore]
        public string Rate
        {
            get
            {
                return Nihil.FromNil(Body.Rate());
            }
        }
    
    }

    public class PolyConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);

            foreach (var item in jObject.Properties())
            {
                Type type = Type.GetType(item.Name);

                var value = item.Value.ToObject(type);

                return value;
            }
            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            //base.WriteJson(writer,value,serializer);

        }

        //public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        //{
        //    JObject jObject = new JObject();

        //    jObject.Add(value.GetType().FullName, JToken.FromObject(value));

        //    serializer.Serialize(writer, jObject);
        //}
    }


}
