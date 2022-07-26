using NASMB;
using NASMB.TYPES;
using Google.Protobuf;
using SimpleBase;
using StreamJsonRpc;
using System.Net.Http.Headers;
using System.Net.WebSockets;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Ocsp;
using NBitcoin.Secp256k1;

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

        [TestMethod]
        public void TestMethodPubmsg()
        {
            testpubmsg();


            Console.ReadKey();
        }

        //Pubmsg(ctx context.Context, transmsg Messagebs) error                                                                                     //perm:sign

        async void testpubmsg()
        {
            try
            {
                NASMB.Wallet.Wallet wallet = new NASMB.Wallet.Wallet("mywallet", "123456");

               // var add = wallet.Sign(null, System.Text.Encoding.Default.GetBytes("123456"));

                // 3o4JqgXdLogoVE2rnXCbkCDbXf9n
                // var add = SimpleBase.Base58.Bitcoin.Decode("22xGFn6hd76h5nkA5uFt5pXKDfcb").ToArray();
                var add = SimpleBase.Base58.Bitcoin.Decode("3o4JqgXdLogoVE2rnXCbkCDbXf9n").ToArray();
                var aRpcClient = Fullapi.FindSliceApiService(add);
                SignTransmsg signTransmsg = new SignTransmsg() { Transmsg = new Transmsg() };
                signTransmsg.Transmsg.From.SetAddressByte( wallet.Keys.Defaultkey.Address.GetAddressbyte());
                signTransmsg.Transmsg.To.Address= "3o4JqgXdLogoVE2rnXCbkCDbXf9n";
                signTransmsg.Transmsg.Feesrate = 1000_000_000_000_000;
                signTransmsg.Transmsg.Balance = NASMB.TYPES.Nihil.ToNil("1 Nihil");
                //637944439095943909
                signTransmsg.Transmsg.Time = 637944439095943909;
                //signTransmsg.Transmsg.Time =(UInt64) System.DateTime.Now.Ticks;

                var rlpb = signTransmsg.Transmsg.RlpEncode();
                var rlphex = Convert.ToHexString(rlpb); 
                signTransmsg.Sign = wallet.Sign(signTransmsg.Transmsg.From.GetAddressbyte(), rlpb);

                Messagebs messagebs = new Messagebs();
                messagebs.Body = signTransmsg;
                messagebs.Msgtype = signTransmsg.Transmsg.Header;

                var msg = Newtonsoft.Json.JsonConvert.SerializeObject(messagebs);
                var ret =  await aRpcClient.SendRequestAsync<object>("Pubmsg", null, messagebs);

               // Console.Write(ret);
            }
            catch (Exception e)
            {
                Console.Write(e);
            }

            //   Newtonsoft.Json.JsonConvert.DeserializeObject<NASMB.TYPES.StateAccount>(System.Text.Encoding.Default.GetString(ret));
        }

    }
}