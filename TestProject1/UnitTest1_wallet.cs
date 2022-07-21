using NASMB;
using NASMB.TYPES;
using Google.Protobuf;
using SimpleBase;
using StreamJsonRpc;
using System.Net.Http.Headers;
using System.Net.WebSockets;

namespace TestProject1
{
    [TestClass]
    public class UnitTestwallet
    {
        [TestMethod]
        public void TestMethod1()
        {

            // 

            NASMB.Wallet.Wallet wallet = new NASMB.Wallet.Wallet("mywallet", "123456");

            var add = wallet.New();



            Console.ReadKey();
        }
        [TestMethod]
        public void TestMethodlist()
        {

            // 

            NASMB.Wallet.Wallet wallet = new NASMB.Wallet.Wallet("mywallet", "123456");

            var add = wallet.List();

            
            

            Console.ReadKey();
        }
        [TestMethod]
        public void TestMethodsign()
        {
            NASMB.Wallet.Wallet wallet = new NASMB.Wallet.Wallet("mywallet", "123456");

            var add = wallet.Sign(null,System.Text.Encoding.Default.GetBytes("123456"));

            var hexstring = Convert.ToHexString(add);
            Console.ReadKey();
        }

        [TestMethod]
        public void TestMethodv()
        {
            var addr = "3o4JqgXdLogoVE2rnXCbkCDbXf9n";
            var sig = "15539511c5457fb2e82a9a8e488c2abd734c69aed20cacc4fbdaac56dfff7d0664138fe533e2ee52635c6d4c5b7eac55682e766acda6218268a5a72ac9c770d700";
            //wallet = new NASMB.Wallet.Wallet("mywallet", "123456");
            //afdb31fbd0bef3cc7cc7d69cad72d795e21e76edc83073f23c27ab4d7fe48767340e96bb1e6dc16ae18f66eaec7999fd0235152eeba26d616faaca177b97094b7b32d9302be4f307e251a05b6584962c4a10d7a002612d1ae1c09fde608ba6293b1afce83684b4805718fe8374ce44b031666b56f24dbe25975aa79d94d76279df5260b4cc030815466982650a85674fd03b52b2a5678a1fe9cdc096ed5595e722ea618704199dcbc13ab35ed5743aead1ed4f11fb0ab0e5f0166cec25b78cbb6cc8957c38d99e042763da1b64fd2b30c23b6bf76385d9b0490141ee4ab4da92c40f3e52e58f643f6b7e39414b59dbe15a9730a28a14c5f79990863f032d6fa1aa3279832e3cac15baa6614aeed0e42c22c9099aa568589425c58059328115b88e28c2e05945625351c01e2ff37515bc9f7db75dfb7edd2ab8c62711eeb1708bab2adde328e2bf45542a1e11162a5afc866e22c85cb8ab55e672969ec7b9300dce156c7292762f63ff1f468664636975838cc95843b437502fa6bf558e619af1b79c923a02108e180af3c2be4fa92bb41c2044888a180298ae4a3e8da2d7468b8c2b71cd53d2380ea515fa89d2a881667b5b3e4381a3fea1e692e436ff0754d40fbe8d50465990dd736f36a32d4f6757
            //var add = wallet.(null, AConst.MaxSlice);
            var ret =NASMB.Wallet.Wallet.Verify(SimpleBase.Base58.Bitcoin.Decode(addr).ToArray(), System.Text.Encoding.Default.GetBytes("123456"), Convert.FromHexString(sig));

         //  var hexstring = Convert.ToHexString(add);
            Console.ReadKey();
        }

        [TestMethod]
        public void TestMethodimport()
        {
            //var addr = "38uhc9kTGxa3tBSZqFY18faxTLQP";
            var hex = "afdb31fbd0bef3cc7cc7d69cad72d795e21e76edc83073f23c27ab4d7fe487677dc5bec27c43cac326c2bdb858b03011a1e35781aa972b701915418aa6da773edd5d409115bf3da95ac54e5b1b3ff9e220d1c98960b115536ee195043d18658492a8d333716bc2e46df71bdd6bebe1c44cb619b0537607b60b117a1ea8bc5e5ee5af4a8565746dd212c9b50af0072f9fdc5217b11bb82e8b20154e7d282e030b6fd36bc66f7526b3c6ba001c9f8cdefe64a5e39bc6b6faf22f0227d68fa5635722cc2699837ea85f46414b46f038dec942565aa60eddca535ba0781a99a4431b880778bee04bef876dba532f4e8109c1c8b781974d0d330b06956cead8cb2f586a3dad24c6c2caf913c8288ff85db8a4f2838460647ab011a9bbde9364fa20918bbef8e3d0a370195929d5152eba60d5e636714cff8e8a89f6279ceac9fd7bbe62df83905c5a1d40b4732a06f238cec9d335782bd9bae28df7fd48bac08005c5c18a54d89cd410602599f36293bc7288a3236a4e341e02ea20b4f623a1a6f57dcd14526cb45bb357a154263e52f2c9a9c6b7130b18da9c94eeca42c29768c17410e9ea0b3cdaffbeb7f23e08678e9db026848690acbf5491870765c93287de2e857574738a33945d2aaca2618f78fd51";
            //wallet = new NASMB.Wallet.Wallet("mywallet", "123456");
            //
            //var add = wallet.(null, AConst.MaxSlice);

            NASMB.Wallet.Wallet wallet = new NASMB.Wallet.Wallet("mywallet", "123456");
            //var ret = NASMB.Wallet.Wallet.Verify(SimpleBase.Base58.Bitcoin.Decode(addr).ToArray(), AConst.MaxSlice, Convert.FromHexString(sig));

          var ret =  wallet.Import(hex, "123456");

            //  var hexstring = Convert.ToHexString(add);
            Console.ReadKey();
        }



        [TestMethod]
        public void TestMethodmd5()
        {
            
            var md5pwd = System.Security.Cryptography.MD5.HashData(System.Text.Encoding.Default.GetBytes("123456"));

            Convert.ToHexString(md5pwd);

        }


    }
}