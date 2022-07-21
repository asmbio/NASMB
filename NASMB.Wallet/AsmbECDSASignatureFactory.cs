using Nethereum.Signer;

namespace NASMB.Wallet
{
    public class AsmbECDSASignatureFactory
    {
        public static AsmbECDSASignature FromComponents(byte[] r, byte[] s)
        {
            return new AsmbECDSASignature(ECDSASignatureFactory.FromComponents(r, s));
        }

        public static AsmbECDSASignature FromComponents(byte[] r, byte[] s, byte v)
        {
            var signature = FromComponents(r, s);
            signature.V = new[] {v};
            return signature;
        }

        public static AsmbECDSASignature FromComponents(byte[] r, byte[] s, byte[] v)
        {
            return new AsmbECDSASignature(ECDSASignatureFactory.FromComponents(r, s, v));
        }

        public static AsmbECDSASignature FromComponents(byte[] rs)
        {
            return new AsmbECDSASignature(ECDSASignatureFactory.FromComponents(rs));
        }

        public static AsmbECDSASignature ExtractECDSASignature(string signature)
        {
            return new AsmbECDSASignature(ECDSASignatureFactory.ExtractECDSASignature(signature));
        }
    }
}