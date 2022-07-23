using NASMB;
using NASMB.TYPES;
using Google.Protobuf;
using SimpleBase;
using StreamJsonRpc;
using System.Net.Http.Headers;
using System.Net.WebSockets;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Ocsp;

namespace TestProject1
{
    [TestClass]
    public class UnitTestchainapi
    {
        [TestMethod]
        public  void TestMethod1()
        {
            testfuall();


            Console.ReadKey();
        }

     

        async void testfuall()
        {
            try
            {
                // 3o4JqgXdLogoVE2rnXCbkCDbXf9n
                // var add = SimpleBase.Base58.Bitcoin.Decode("22xGFn6hd76h5nkA5uFt5pXKDfcb").ToArray();
                var add = SimpleBase.Base58.Bitcoin.Decode("3o4JqgXdLogoVE2rnXCbkCDbXf9n").ToArray();
                var aRpcClient = Fullapi.FindSliceApiService(add);

                var ret = await aRpcClient.SendRequestAsync<NASMB.TYPES.StateAccount>("GetAccount", null, add);

                Console.Write(ret);
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
        
         //   Newtonsoft.Json.JsonConvert.DeserializeObject<NASMB.TYPES.StateAccount>(System.Text.Encoding.Default.GetString(ret));
        }

      

    }
}