using NASMB;
using NASMB.TYPES;
using Google.Protobuf;
using SimpleBase;
using StreamJsonRpc;
using System.Net.Http.Headers;
using System.Net.WebSockets;
using Org.BouncyCastle.Utilities;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodaddr()
        {
            Transmsg transmsg = new Transmsg();
            transmsg.From.SetAddressByte(AConst.MaxSlice); //transmsg.To.SetAddressByte(AConst.MinSlice);
            transmsg.Marks = "ddd";
            var jsons = Newtonsoft.Json.JsonConvert.SerializeObject(transmsg);

            var t2= Newtonsoft.Json.JsonConvert.DeserializeObject<Transmsg>(jsons);

        }
            [TestMethod]
        public void TestMethod1()
        {
            Konscious.Security.Cryptography.HMACBlake2B blke2b = new Konscious.Security.Cryptography.HMACBlake2B(160);

          

            byte[] arr1 = { 93, 5, 3, 55, 57 };
            byte[] arr2 = { 93, 5, 3, 55, 57 };

            var ret1 = blke2b.ComputeHash(arr1);
            var ret2 = blke2b.ComputeHash(arr2);
            // ==比较
            Assert.IsFalse( (arr1 == arr2));
            // equals
            Assert.IsTrue( arr1.SequenceEqual(arr2));


            test1();
         

            Console.ReadKey();
        }

        private async void test1()
        {

            byte[] slices = { 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255 };

          var ssname= Base58.Bitcoin.Encode(slices);
           var sname = "asmb_4ZrjxJnU1LA5xSyrWMNuXTvSYKwt";
            Assert.IsTrue(ssname.Equals(sname));
            var uri = new Uri("http://asmb.site:8106/" + sname + "/v0");
            
            HttpClient httpClient = new HttpClient();

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, uri);
            request.Headers.Add("Authorization", "Bearer " + "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJBbGxvdyI6WyJyZWFkIiwid3JpdGUiLCJzaWduIiwiYWRtaW4iXX0.ae22SYWjZ_RJRRhfWDpVFzWThu_6EQ-iBgAn8vdrR-w");
            //   httpClient.Send(request)
            //    HttpClientHandler handler = new HttpClientHandler();        
            Console.WriteLine(request.ToString());
            Console.WriteLine(request.Content);
            var sm=  await  httpClient.SendAsync(request);
            

            using (var webSocket = new ClientWebSocket())
            {
                //Console.WriteLine("正在与服务端建立连接...");
                //var uri = new Uri("ws://asmb.site:8106/" + sname + "/v0");

                //await webSocket.ConnectAsync(uri, CancellationToken.None);



                //Console.WriteLine("已建立连接");

                //Console.WriteLine("开始向服务端发送消息...");
                //var messageHandler = new WebSocketMessageHandler(webSocket);
                //var greeterClient = JsonRpc.Attach<IASMB>(messageHandler);
                
                //JsonRpc.
                ////    JsonRpc.Attach<IASMB>(messageHandler)()
                //var response = await greeterClient.GetBlockbyHS(1, slices);
                //Console.WriteLine($"收到来自服务端的响应：{response}");

                //Console.WriteLine("正在断开连接...");
                //await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "断开连接", CancellationToken.None);
                //Console.WriteLine("已断开连接");
            }

        }

        public async void tesst2()
        {
            byte[] slices = { 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255 };
            var sname = "asmb_4ZrjxJnU1LA5xSyrWMNuXTvSYKwt";
            var uri = new Uri("http://120.48.85.133:8106/" + sname + "/v0");

           // HttpClient httpClient = new HttpClient();
            AuthenticationHeaderValue authenticationHeaderValue = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJBbGxvdyI6WyJyZWFkIiwid3JpdGUiLCJzaWduIiwiYWRtaW4iXX0.ae22SYWjZ_RJRRhfWDpVFzWThu_6EQ-iBgAn8vdrR-w");
            Nethereum.JsonRpc.Client.RpcClient rpcClient = new Nethereum.JsonRpc.Client.RpcClient(uri,authenticationHeaderValue);

            
          //  httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJBbGxvdyI6WyJyZWFkIiwid3JpdGUiLCJzaWduIiwiYWRtaW4iXX0.ae22SYWjZ_RJRRhfWDpVFzWThu_6EQ-iBgAn8vdrR-w");
           // httpClient.DefaultRequestHeaders.Add("Content-Type", "application/json");
         //  httpClient.DefaultRequestHeaders.Authorization = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJBbGxvdyI6WyJyZWFkIiwid3JpdGUiLCJzaWduIiwiYWRtaW4iXX0.ae22SYWjZ_RJRRhfWDpVFzWThu_6EQ-iBgAn8vdrR-w");
           Nethereum.JsonRpc.Client.RpcRequest rpcRequest = new Nethereum.JsonRpc.Client.RpcRequest(1, "asmb_4ZrjxJnU1LA5xSyrWMNuXTvSYKwt.GetBlockbyHS", 1, slices);
            // rpcRequest.Method=

            //  var ret =await rpcClient.SendRequestAsync<object>("asmb_4ZrjxJnU1LA5xSyrWMNuXTvSYKwt.GetBlockbyHS", paramList:  new object[] { 1, slices});
           var ret = await rpcClient.SendRequestAsync<object>(rpcRequest);
            //            rpcRequest.Method = s

            Console.WriteLine(ret);

        }
        [TestMethod]
        public  void TestMethod2()
        {
            //HttpClientHandler handler = new HttpClientHandler();
            //   HttpClient httpClient = new HttpClient();
            //   httpClient.BaseAddress = new Uri("127.0.0.1:8106/");
            //   using (HttpRequestMessage request = new HttpRequestMessage())
            //   {
            //       request.Method = HttpMethod.Post;
            //      // request.RequestUri = new Uri(url);
            ////      request
            //   }
              

            tesst2();
            Console.ReadKey();
        }

        [TestMethod]
        public void TestMethod4()
        {
            for (int i = 0; i < 10; i++)
            {
                var test1 = Fullapi.testc();
                Thread.Sleep(1000);

                //var test2 = Fullapi.testc();
            }
            
        }

        [TestMethod]
        public void TestMethod3()
        {
            //HttpClientHandler handler = new HttpClientHandler();
            //   HttpClient httpClient = new HttpClient();
            //   httpClient.BaseAddress = new Uri("127.0.0.1:8106/");
            //   using (HttpRequestMessage request = new HttpRequestMessage())
            //   {
            //       request.Method = HttpMethod.Post;
            //      // request.RequestUri = new Uri(url);
            ////      request
            //   }


            testfuall();
            Console.ReadKey();
        }

      async void test3()
        {
            ARpcClient aRpcClient = new ARpcClient(AConfig.Rpcclientaddr, "asmb_"+Base58.Bitcoin.Encode(AConst.MaxSlice));

             var ret = await  aRpcClient.SendRequestAsync<object>("GetBlockbyHS", null, 1, AConst.MaxSlice );

        }

        async void testwalletnew()
        {
         //     var bs=   ByteString.CopyFrom(AConst.ASMB_ETCD_SHAREDB_SLICEMG);
         //   //bs.Concat()
         // var bsa=  System.Text.Encoding.Default.GetBytes(AConst.ASMB_ETCD_SHAREDB_SLICEMG);
         //   var ss = ByteString.CopyFrom(AConst.MaxSlice);
            //ss.ToString
        //    var ss1 = AConst.ASMB_ETCD_SHAREDB_SLICEMG + ss.ToString();

            ARpcClient aRpcClient = new ARpcClient("http://127.0.0.1:10106", "wallet");

            var ret = await aRpcClient.SendRequestAsync<object>("New", null, 1);

        }

        async void testfuall()
        {
            var aRpcClient = Fullapi.FindSliceApiService(AConst.MaxSlice);

            var ret = await aRpcClient.SendRequestAsync<object>("GetBlockbyHS", null, 1, AConst.MaxSlice);

        }

        [TestMethod]
        public void TestMethod5() {
            //var ex =new NASMB.ATypes.ExchangeChainInfoMessage() { From = AConst.MinSlice,Slice= AConst.MaxSlice};

            //var jsonex=Newtonsoft.Json.JsonConvert.SerializeObject(ex);

            Fullapi.test3();

        }

        [TestMethod]
        public void TestMethod6()
        {
            //var ex =new NASMB.ATypes.ExchangeChainInfoMessage() { From = AConst.MinSlice,Slice= AConst.MaxSlice};

            //var jsonex=Newtonsoft.Json.JsonConvert.SerializeObject(ex);
           

        }

    }
}