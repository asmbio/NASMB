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
using System.Runtime.InteropServices;

namespace TestProject1
{
    [TestClass]
    public class UnitTestgo
    {
        [TestMethod]
        public void TestMethodenrandomcode()
        {
            var str = RuntimeInformation.OSArchitecture;

            //var s2 = Environment.OSVersion.Platform;

            //RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
            //byte[] chars = new byte[32];
            //var time= NASMB.GO.Egg1.EnEgg1Code( chars, 32);

            //byte[] dcode = new byte[20];
            //var ret =NASMB.GO.Egg1.DeEgg1Code(chars, 32, time, dcode, 20);

            Console.ReadKey();
        }
        //GetReceipts(ctx context.Context, addr[]byte, t uint64, n int) ([] Messagebs, error)
    }
        //AskNil(ctx context.Context, addr types.Address) error
    
}