using NASMB.TYPES;
using dotnet_etcd;

using Etcdserverpb;
using Google.Protobuf;
using SimpleBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using Org.BouncyCastle.Ocsp;
using System.Runtime.Intrinsics.X86;
using System.Drawing;

namespace NASMB
{
    public class Fullapi
    {
       static EtcdClient client;

       // static AuthenticateResponse authRes;
       
    //    static  Grpc.Core.Metadata entries;
        static Fullapi()
        {

            //EtcdClient client = new EtcdClient("host1:port1:,...., hostN:portN");
            //// E.g.
            //EtcdClient etcdClient = new EtcdClient("https://localhost:23790,https://localhost:23791,https://localhost:23792");
            client = new EtcdClient(AConfig.FullapilistConfig.Endpoints);
           var authRes = client.Authenticate(new Etcdserverpb.AuthenticateRequest()
            {
                Name = AConfig.FullapilistConfig.Username,
                Password = AConfig.FullapilistConfig.Password,
            });
          //  client.LeaseKeepAlive
            //  Put key "foo/bar" with value "barfoo" with authenticated token
          //  entries = new Grpc.Core.Metadata() { new Grpc.Core.Metadata.Entry("token", authRes.Token) };
            //client.Put("foo/bar", "barfoo", new Grpc.Core.Metadata() {
            //    new Grpc.Core.Metadata.Entry("token",authRes.Token)
            //});
            //var rq = new Etcdserverpb.RangeRequest();
            //rq.Key = 
            //client.Get(request:   )

            //client = new Client(AConfig.FullapilistConfig.Endpoints);
            //client.NewAuthToken("root", "123"); // if etcd has auth enable, please use user and pwd to get auth
            ////client.Put("key", "value");  // put key/vale to etcd

            //// get value 
            //var res = client.Range("key");

            //client.GetAll("key",)           
        }
        //public static string testc()
        //{
        //    return authRes.Token;
        //}
        //public static Grpc.Core.Metadata test2()
        //{
        //    return entries;
        //}
        //public static void test3()
        //{
        //    var ex = new NASMB.TYPES.ExchangeChainInfoMessage() { From = AConst.MinSlice, Slice = AConst.MaxSlice };

        //    var jsonex = Newtonsoft.Json.JsonConvert.SerializeObject(ex);

        //    client.Put("tests", jsonex, entries);

        //    var xx=    client.Get("tests", entries);
            
        //}
        /// <summary>
        /// /
        /// </summary>
        /// <param name="from"> 从小到大</param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static AsmbAddress[] GetSliceList(byte[] from, int n)
        {
            if (from == null)
            {
                from = AConst.MinSlice;
            }

            var shareslice = AConst.ASMB_ETCD_SHAREDB_SLICEMG.Concat(from).ToArray();
            RangeRequest rangeRequest = new RangeRequest();
            rangeRequest.Key = ByteString.CopyFrom(shareslice);
            rangeRequest.RangeEnd = ByteString.CopyFrom(AConst.ASMB_ETCD_SHAREDB_SLICEMG_END);
            rangeRequest.Limit = n * AConfig.SliceMgBackupCount;
            var authRes = client.Authenticate(new Etcdserverpb.AuthenticateRequest()
            {
                Name = AConfig.FullapilistConfig.Username,
                Password = AConfig.FullapilistConfig.Password,
            });
            var rp = client.Get(rangeRequest, new Grpc.Core.Metadata() { new Grpc.Core.Metadata.Entry("token", authRes.Token) });
            var rets = new List<AsmbAddress>();

            if (rp.Kvs.Count == 0)
            {
                return rets.ToArray();
            }
            foreach (var item in rp.Kvs)
            {
           
                    var s = item.Key.Skip(13).Take(20);

                    //    ASMB_ETCD_SHAREDB_SLICEMG
                    //ret:= k.Key[:bytes.LastIndex(k.Key, []byte("/"))]

                    if (from.SequenceEqual(s))
                    {
                        continue;

                    }
                    var add = new AsmbAddress(s.ToArray());
                  //  add.SetAddressByte();
                    rets.Add(add);

                    from = add.GetAddressbyte();

                    n--;

                    if (n == 0 || add.GetAddressbyte().SequenceEqual(AConst.MaxSlice))
                    {
                        return rets.ToArray();

                    }
                    //item.Value.
                    //var jsonstring = item.Value.ToArray();
                    //var jstring = Convert.FromBase64String(item.Value.ToString(Encoding.UTF8));

                    //ExchangeChainInfoMessage


                    //     var ex = Newtonsoft.Json.JsonConvert.DeserializeObject<ExchangeChainInfoMessage>(item.Value.ToString(Encoding.Default));


            
            }
            if (rets.Count > 0)
            {
                var rets2 = GetSliceList(from, n);

                if (rets2.Length == 0)
                {
                    return rets.ToArray();
                }
                rets.AddRange(rets2);

            }
            return rets.ToArray();
        }
        internal static ARpcClient FindApiService(byte[] addr)
        {
            return FindSliceApiService(TYPES.ATypes.Addone(addr));
        }
        internal static ARpcClient FindSliceApiService(byte[] slice )
        {
            try
            {
                
                //ARpcClient aclient = null;
                
                var shareslice= AConst.ASMB_ETCD_SHAREDB_SLICEMG.Concat(slice).ToArray();
                RangeRequest rangeRequest = new RangeRequest();
                rangeRequest.Key = ByteString.CopyFrom(shareslice);
                rangeRequest.RangeEnd = ByteString.CopyFrom(AConst.ASMB_ETCD_SHAREDB_SLICEMG_END);
                rangeRequest.Limit = AConfig.SliceMgBackupCount;
                var authRes = client.Authenticate(new Etcdserverpb.AuthenticateRequest()
                {
                    Name = AConfig.FullapilistConfig.Username,
                    Password = AConfig.FullapilistConfig.Password,
                });
                var rp=  client.Get(rangeRequest, new Grpc.Core.Metadata() { new Grpc.Core.Metadata.Entry("token", authRes.Token) });


                //var rp = client.Range(ByteString.CopyFrom( ByteString.CopyFrom( AConst.ASMB_ETCD_SHAREDB_SLICEMG).Concat(slice).ToArray()), ByteString.CopyFrom(AConst.ASMB_ETCD_SHAREDB_SLICEMG_END), limit: AConfig.SliceMgBackupCount);


                foreach (var item in rp.Kvs)
                {
                   
                        //item.Value.
                        //var jsonstring = item.Value.ToArray();
                        //var jstring = Convert.FromBase64String(item.Value.ToString(Encoding.UTF8));

                        //ExchangeChainInfoMessage

                        
                        var ex = Newtonsoft.Json.JsonConvert.DeserializeObject<ExchangeChainInfoMessage>(item.Value.ToString(Encoding.Default));

                         AuthenticationHeaderValue DefaultauthenticationHeaderValue = new AuthenticationHeaderValue("Bearer", Utils. AESEncrypt.Decrypt(ex.Token, System.Text.Encoding.Default.GetBytes( AConfig.FullapilistConfig.MinersliceAeskey)));
                        
                        ARpcClient aRpcClient = new ARpcClient(ex.Url, "asmb_" + Base58.Bitcoin.Encode(ex.Slice),DefaultauthenticationHeaderValue);
                        return aRpcClient;
              


                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }
    
        }
    }
}
