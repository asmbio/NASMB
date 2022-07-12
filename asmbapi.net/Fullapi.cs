using asmbapi.net.ATypes;
using dotnet_etcd;

using Etcdserverpb;
using Google.Protobuf;
using SimpleBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace asmbapi.net
{
    public class Fullapi
    {
       static EtcdClient client;

        static AuthenticateResponse authRes;

        static  Grpc.Core.Metadata entries;
        static Fullapi()
        {

            //EtcdClient client = new EtcdClient("host1:port1:,...., hostN:portN");
            //// E.g.
            //EtcdClient etcdClient = new EtcdClient("https://localhost:23790,https://localhost:23791,https://localhost:23792");
            client = new EtcdClient(AConfig.FullapilistConfig.Endpoints);
            authRes = client.Authenticate(new Etcdserverpb.AuthenticateRequest()
            {
                Name = AConfig.FullapilistConfig.Username,
                Password = AConfig.FullapilistConfig.Password,
            });
            //  Put key "foo/bar" with value "barfoo" with authenticated token
            entries = new Grpc.Core.Metadata() { new Grpc.Core.Metadata.Entry("token", authRes.Token) };
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
        public static string testc()
        {
            return authRes.Token;
        }
        public static Grpc.Core.Metadata test2()
        {
            return entries;
        }
        public static void test3()
        {
            var ex = new asmbapi.net.ATypes.ExchangeChainInfoMessage() { From = AConst.MinSlice, Slice = AConst.MaxSlice };

            var jsonex = Newtonsoft.Json.JsonConvert.SerializeObject(ex);

            client.Put("tests", jsonex, entries);

            var xx=    client.Get("tests", entries);
            
        }
        public static ARpcClient FindApiService(byte[] addr)
        {
            return FindSliceApiService(ATypes.ATypes.Addone(addr));
        }
        public static ARpcClient FindSliceApiService(byte[] slice )
        {
            try
            {
                
                //ARpcClient aclient = null;
                
                var shareslice= AConst.ASMB_ETCD_SHAREDB_SLICEMG.Concat(slice).ToArray();
                RangeRequest rangeRequest = new RangeRequest();
                rangeRequest.Key = ByteString.CopyFrom(shareslice);
                rangeRequest.RangeEnd = ByteString.CopyFrom(AConst.ASMB_ETCD_SHAREDB_SLICEMG_END);
                rangeRequest.Limit = AConfig.SliceMgBackupCount;
                var rp=  client.Get(rangeRequest,entries);


                //var rp = client.Range(ByteString.CopyFrom( ByteString.CopyFrom( AConst.ASMB_ETCD_SHAREDB_SLICEMG).Concat(slice).ToArray()), ByteString.CopyFrom(AConst.ASMB_ETCD_SHAREDB_SLICEMG_END), limit: AConfig.SliceMgBackupCount);


                foreach (var item in rp.Kvs)
                {
                    try
                    {
                        //item.Value.
                        //var jsonstring = item.Value.ToArray();
                        //var jstring = Convert.FromBase64String(item.Value.ToString(Encoding.UTF8));

                        //ExchangeChainInfoMessage

                        
                        var ex = Newtonsoft.Json.JsonConvert.DeserializeObject<ExchangeChainInfoMessage>(item.Value.ToString(Encoding.Default));

                         AuthenticationHeaderValue DefaultauthenticationHeaderValue = new AuthenticationHeaderValue("Bearer", AESEncrypt.Decrypt(ex.Token, AConfig.FullapilistConfig.MinersliceAeskey));
                        
                        ARpcClient aRpcClient = new ARpcClient(ex.Url, "asmb_" + Base58.Bitcoin.Encode(ex.Slice),DefaultauthenticationHeaderValue);
                        return aRpcClient;
                    }
                    catch (Exception)
                    {
                        return null;

                    }


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
