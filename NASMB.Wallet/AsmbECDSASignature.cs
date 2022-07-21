using System;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.RLP;
using Nethereum.Signer.Crypto;
using Nethereum.Util;
using Org.BouncyCastle.Math;

namespace NASMB.Wallet
{
    public class AsmbECDSASignature
    {

        //public AsmbECDSASignature(byte[] sig) { 
            
        //}
        internal AsmbECDSASignature(BigInteger r, BigInteger s)
        {
            ECDSASignature = new ECDSASignature(r, s);
        }

        public AsmbECDSASignature(BigInteger r, BigInteger s, byte[] v)
        {
            ECDSASignature = new ECDSASignature(r, s);
            ECDSASignature.V = v;
        }

        internal AsmbECDSASignature(ECDSASignature signature)
        {
            ECDSASignature = signature;
        }

        internal AsmbECDSASignature(BigInteger[] rs)
        {
            ECDSASignature = new ECDSASignature(rs);
        }

        //public AsmbECDSASignature(byte[] Sig)
        //{

        //    ECDSASignature = new ECDSASignature(new BigInteger(Sig,0,32),new BigInteger(Sig,32,64));

        //    ECDSASignature.V =new byte[]{ Sig[64] };
        //}

        internal ECDSASignature ECDSASignature { get; }

        public byte[] R
        {
            get
            {
                return ECDSASignature.R.ToByteArrayUnsigned();
            }
            
        }

        public byte[] S
        {
            get
            {
                return ECDSASignature.S.ToByteArrayUnsigned();
            }
        
        }

        public byte[] V
        {
            get => ECDSASignature.V;
            set => ECDSASignature.V = value;
        }

        public bool IsLowS => ECDSASignature.IsLowS;



        public static string CreateStringSignature(AsmbECDSASignature signature)
        {
            return "0x" + signature.R.ToHex().PadLeft(64, '0') +
                   signature.S.ToHex().PadLeft(64, '0') +
                   signature.V.ToHex();
        }

        public byte[] ToDER()
        {
            return ECDSASignature.ToDER();
        }

        public bool IsVSignedForChain()
        {
            return V.ToBigIntegerFromRLPDecoded() >= 35;
        }

        public bool IsVSignedForLegacy()
        {
            var v = V.ToBigIntegerFromRLPDecoded();
            return v >= 27;
        }

        public bool IsVSignedForYParity()
        {
            var v = V.ToBigIntegerFromRLPDecoded();
            return v == 0 || v == 1;
        }
        public byte[] Marshal()
        {
            var rsigPad = new byte[32];
            Array.Copy(R, 0, rsigPad, rsigPad.Length - R.Length, R.Length);

            var ssigPad = new byte[33];
            Array.Copy(S, 0, ssigPad, 0, S.Length);
            ssigPad[32] = V[0];

            return ByteUtil.Merge(rsigPad, ssigPad);
        }

        public static AsmbECDSASignature UnMarshal(byte[] sig)
        {
            //  R=
            var v = sig[64];

            //if (v == 0 || v == 1)
            //    v = (byte)(v + 27);

            var r = new byte[32];
            Array.Copy(sig, r, 32);
            var s = new byte[32];
            Array.Copy(sig, 32, s, 0, 32);

            return AsmbECDSASignatureFactory.FromComponents(r, s, v);
        }

        public byte[] To64ByteArray()
        {
            var rsigPad = new byte[32];
            Array.Copy(R, 0, rsigPad, rsigPad.Length - R.Length, R.Length);

            var ssigPad = new byte[32];
            Array.Copy(S, 0, ssigPad, ssigPad.Length - S.Length, S.Length);

            return ByteUtil.Merge(rsigPad, ssigPad);
        }

        
    }
}