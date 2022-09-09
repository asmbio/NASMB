using NASMB.TYPES;
using NBitcoin.Secp256k1;
using Nethereum.Signer;
using Nethereum.Signer.Crypto;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASMB.Wallet
{
    public class Keys
    {
        public Key Defaultkey;//当前签名key

        public Key[] Keylist;
        //public  Key list;
    }
    public class Wallet
    {
        private string _pwd;

        public string Pwd
        {
            set
            {
                _pwd = value;
            }
        }

        public bool Vdpwd(string pwd)
        {
            return _pwd == pwd;
        }
        private string _wname;
        public Keys Keys;
        public Wallet(string path,string pwd)
        {
            
            _pwd = pwd;
        //    var md5pwd = ;
           // _pwd =System.Text.Encoding.Default.GetBytes(  Convert.ToHexString(md5pwd).Substring(0,32));

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
          
            var filename = path + "/wallet.w";
            _wname = filename;
            if (!File.Exists(filename))
            {
                Keys = new Keys() { Keylist = new Key[] { } };
                store();
            }
            
            var keybytes =File.ReadAllBytes(filename);

            var kw =NASMB.Utils.AESEncrypt.Decrypt(keybytes, System.Security.Cryptography.SHA256.HashData(System.Text.Encoding.Default.GetBytes(_pwd)));
            Keys= Newtonsoft.Json.JsonConvert.DeserializeObject<Keys>(kw);

        }
        public byte[] New() {

            var asmbKey = NASMB.Wallet.AsmbKey.GenerateKey();

            Key key = new Key() { Type = 1, PrivateKey = asmbKey.GetPrivateKeyAsBytes() };
            //key.KeyInfo = new KeyInfo() ;
            key.asmbKey = asmbKey;
            key.PublicKey = asmbKey.GetPubKey();
            key.Address = new AsmbAddress(asmbKey.GetAsmbAddress()) ;
            //var en =   asmbKey.Sign( AConst.MinSlice);
            //asmbKey.Verify()
            //en.To64ByteArray();

            if (Keys.Defaultkey == null)
            {
                Keys.Defaultkey = key;
            }
            Keys.Keylist=    Keys.Keylist.Append(key).ToArray();

            store();
            
            return key.Address.GetAddressbyte();
        }

        protected void store() {

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(Keys);

            var aw = NASMB.Utils.AESEncrypt.Encrypt(json, System.Security.Cryptography.SHA256.HashData(System.Text.Encoding.Default.GetBytes(_pwd)));
            File.WriteAllBytes(_wname, aw);
        }
        public byte[][] List() {
            //
            return Keys.Keylist.Select(p => p.Address.GetAddressbyte()).ToArray();            
        }

        public bool Import(string hex, string pwd)
        {

            var hbyte = Convert.FromHexString(hex);

            var kw = NASMB.Utils.AESEncrypt.Decrypt(hbyte, System.Security.Cryptography.SHA256.HashData(System.Text.Encoding.Default.GetBytes(pwd)));

            var keks = Newtonsoft.Json.JsonConvert.DeserializeObject<Keys>(kw);
          //  Keys.Keylist = Keys.Keylist.Concat(keks.Keylist).ToArray();
            foreach (var item in keks.Keylist)
            {
                if (Keys.Keylist.FirstOrDefault(p => p.Address.GetAddressbyte().SequenceEqual(item.Address.GetAddressbyte())) == null){
                 Keys.Keylist =   Keys.Keylist.Append(item).ToArray();
                }              
            }
            if (Keys.Defaultkey == null)
            {
                Keys.Defaultkey = keks.Keylist[0];
            }
            store();

            return true;
        }

         public void Setdefault(byte[] address)
        {
            var dkey = Keys.Keylist.FirstOrDefault(p => p.Address.GetAddressbyte().SequenceEqual(address));
            if (dkey != null)
            {
                Keys.Defaultkey = dkey;
                store();
            }
        }
        public byte[] Sign(byte[] address, byte[] msg ) 
        {
            if (address == null)
            {
                address = Keys.Defaultkey.Address.GetAddressbyte();
            }
            var a = Keys.Keylist.FirstOrDefault(p =>  p.Address.GetAddressbyte().SequenceEqual( address));
            if (a == null)
            {
                throw new Exception($"没有秘钥{address}");
            }
            Konscious.Security.Cryptography.HMACBlake2B blke2b = new Konscious.Security.Cryptography.HMACBlake2B(256);

        
            var sig= a.asmbKey.SignAndCalculateV(blke2b.ComputeHash(msg));
            //a.asmbKey.
            //sig.ToDER();
            //sig.ToDER
            //sig.v

           // AsmbKey.RecoverFromSignature
            return sig.Marshal();
    
        }
        //Verify(ctx context.Context, address[]byte, msg[]byte, sig[]byte, stype crypto.SigType) (bool, error)

        public static bool Verify(byte[] address, byte[] msg, byte[] sig)
        {


            AsmbECDSASignature ethECDSASignature = AsmbECDSASignature.UnMarshal(sig);

            //  AsmbECDSASignature.FromDER
            Konscious.Security.Cryptography.HMACBlake2B blke2b = new Konscious.Security.Cryptography.HMACBlake2B(160);
            Konscious.Security.Cryptography.HMACBlake2B blke2b2 = new Konscious.Security.Cryptography.HMACBlake2B(256);
            //for (int i = 0; i < 4; i++)
            //{

            var ret = ECKey.RecoverFromSignature(ethECDSASignature.V[0], ethECDSASignature.ECDSASignature, blke2b2.ComputeHash(msg), false);

            //  blke2b.Clear();
            var ad = blke2b.ComputeHash(ret.GetPubKey(false));

            if (ad.SequenceEqual(address))
            {
                return true;
            }

            //}
            return false;


        }
        public string Export()
        {
            // var xx = Newtonsoft.Json.JsonConvert.SerializeObject(Keys);

            var keybytes = File.ReadAllBytes(_wname);

            return Convert.ToHexString(keybytes);            
        }

    }
}
