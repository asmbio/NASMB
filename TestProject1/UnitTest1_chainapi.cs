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
        public void TestMethodGettransEgg1()
        {
            testgettransEgg1();


            Console.ReadKey();
        }
        async void testgettransEgg1()
        {
            try
            {
                NASMB.Wallet.Wallet wallet = new NASMB.Wallet.Wallet("mywallet", "123456");
                //Console.WriteLine(go)
                // var add = wallet.Sign(null, System.Text.Encoding.Default.GetBytes("123456"));

                // 3o4JqgXdLogoVE2rnXCbkCDbXf9n
                // var add = SimpleBase.Base58.Bitcoin.Decode("22xGFn6hd76h5nkA5uFt5pXKDfcb").ToArray();

                SignEgg1msg signEgg1Msg = new SignEgg1msg() { Egg1msg = new Egg1msg() };
                signEgg1Msg.Egg1msg.From.SetAddressByte(wallet.Keys.Defaultkey.Address.GetAddressbyte());

                signEgg1Msg.Egg1msg.Randomcode = new byte[32];
               //signEgg1Msg.Egg1msg.Time = NASMB.GO.Egg1.EnEgg1Code(signEgg1Msg.Egg1msg.Randomcode, 32);
             

                var rlpb = signEgg1Msg.Egg1msg.RlpEncode();
                //var rlphex = Convert.ToHexString(rlpb);
                signEgg1Msg.Sign = wallet.Sign(signEgg1Msg.Egg1msg.From.GetAddressbyte(), rlpb);

                Messagebs messagebs = new Messagebs();
                messagebs.Body = signEgg1Msg;
                messagebs.Msgtype = signEgg1Msg.Egg1msg.Msgtype;

                var msg = Newtonsoft.Json.JsonConvert.SerializeObject(messagebs);


                var aRpcClient = Fullapi.FindSliceApiService(signEgg1Msg.Egg1msg.From.GetAddressbyte());
                var ret = await aRpcClient.SendRequestAsync<object>("Pubmsg", null, messagebs);


                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.Write(e);
            }

            //   Newtonsoft.Json.JsonConvert.DeserializeObject<NASMB.TYPES.StateAccount>(System.Text.Encoding.Default.GetString(ret));
        }

        [TestMethod]
        public  void TestMethodGetReceipts()
        {
            testgetRecipts();


            Console.ReadKey();
        }
        //GetReceipts(ctx context.Context, addr[]byte, t uint64, n int) ([] Messagebs, error)
        async void testgetRecipts()
        {
            try
            {
                // 3o4JqgXdLogoVE2rnXCbkCDbXf9n
                // var add = SimpleBase.Base58.Bitcoin.Decode("22xGFn6hd76h5nkA5uFt5pXKDfcb").ToArray();
                var add = SimpleBase.Base58.Bitcoin.Decode("27pMFz5GtxhR4s1EcZMfpS49GjEv").ToArray();
                var aRpcClient = Fullapi.FindSliceApiService(add);
                var ret1 = await aRpcClient.SendRequestAsync<object>("GetReceipts", null, add, UInt64.MaxValue, 10);

                var ret = await aRpcClient.SendRequestAsync<NASMB.TYPES.Messagebs[]>("GetReceipts", null, add, UInt64.MaxValue,10);

                Console.Write(ret);
            }
            catch (Exception e)
            {
                Console.Write(e);
            }

            //   Newtonsoft.Json.JsonConvert.DeserializeObject<NASMB.TYPES.StateAccount>(System.Text.Encoding.Default.GetString(ret));
        }

        [TestMethod]
        public void TestMethod1()
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
          
                SignTransmsg signTransmsg = new SignTransmsg() { Transmsg = new Transmsg() };
                signTransmsg.Transmsg.From.SetAddressByte( wallet.Keys.Defaultkey.Address.GetAddressbyte());
                signTransmsg.Transmsg.To .SetAddress( "3o4JqgXdLogoVE2rnXCbkCDbXf9n");
                signTransmsg.Transmsg.Feesrate = 1000_000_000_000_000;
                signTransmsg.Transmsg.Balance = NASMB.TYPES.Maons.ToNil("1 Maons");
                //637944439095943909 1658994971263519600
                signTransmsg.Transmsg.Time = 637944439095943909;
                //signTransmsg.Transmsg.Time =(UInt64) System.DateTime.Now.Ticks;
                
                var rlpb = signTransmsg.Transmsg.RlpEncode();
                var rlphex = Convert.ToHexString(rlpb); 
                signTransmsg.Sign = wallet.Sign(signTransmsg.Transmsg.From.GetAddressbyte(), rlpb);

                Messagebs messagebs = new Messagebs();
                messagebs.Body = signTransmsg;
                messagebs.Msgtype = signTransmsg.Transmsg.Msgtype;

                var msg = Newtonsoft.Json.JsonConvert.SerializeObject(messagebs);

             
                var aRpcClient = Fullapi.FindSliceApiService(signTransmsg.Transmsg.From.GetAddressbyte());
                var ret =  await aRpcClient.SendRequestAsync<object>("Pubmsg", null, messagebs);

               // Console.Write(ret);
            }
            catch (Exception e)
            {
                Console.Write(e);
            }

            //   Newtonsoft.Json.JsonConvert.DeserializeObject<NASMB.TYPES.StateAccount>(System.Text.Encoding.Default.GetString(ret));
        }
        //AskNil(ctx context.Context, addr types.Address) error
    }
}