using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Signer;
using Nethereum.Signer.Crypto;
using Nethereum.Util;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASMB
{
    public class AsmbKey : Nethereum.Signer.EthECKey
    {
        protected static readonly SecureRandom SecureRandom = new SecureRandom();
        protected byte[] _address { get; set; }
        public AsmbKey(string privateKey) : base(privateKey)
        {
        }
        public AsmbKey(byte[] vch, bool isPrivate):base(vch, isPrivate)
        {

        }

        public static AsmbKey GenerateKey()
        {
            ECKeyPairGenerator eCKeyPairGenerator = new ECKeyPairGenerator("EC");
            KeyGenerationParameters parameters = new KeyGenerationParameters(SecureRandom, 256);
            eCKeyPairGenerator.Init(parameters);
            byte[] array = ((ECPrivateKeyParameters)eCKeyPairGenerator.GenerateKeyPair().Private).D.ToByteArrayUnsigned();
            if (array.Length != 32)
            {
                return GenerateKey();
            }

            return new AsmbKey(array, isPrivate: true);
        }


        public byte[] GetAsmbAddress()
        {
            if (_address == null)
            {
                 Konscious.Security.Cryptography.HMACBlake2B blke2b = new Konscious.Security.Cryptography.HMACBlake2B(160);
                
                _address =  blke2b.ComputeHash(this.GetPubKeyNoPrefix());
            }
            return _address;
        }
    }
}
