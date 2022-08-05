using Secp256k1Net;
using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NASMB.GO
{

    /// <summary>
    /// A pointer to a function that applies hash function to a point.
    /// Returns: 1 if a point was successfully hashed. 0 will cause ecdh to fail.
    /// </summary>
    /// <param name="output">Pointer to an array to be filled by the function.</param>
    /// <param name="x">Pointer to a 32-byte x coordinate.</param>
    /// <param name="y">Pointer to a 32-byte y coordinate.</param>
    /// <param name="data">Arbitrary data pointer that is passed through.</param>
    /// <returns>Returns: 1 if a point was successfully hashed. 0 will cause ecdh to fail.</returns>
    public delegate int EcdhHashFunction(Span<byte> output, Span<byte> x, Span<byte> y, IntPtr data);


    public class Egg1 
    {
       


       static readonly Lazy<GetEnEgg1Code> GetEnEgg1Code;
       static readonly Lazy<GetDeEgg1Code> GetDeEgg1Code;
        

        const string LIB = "libegg1";

        public static string LibPath => _libPath.Value;
        static readonly Lazy<string> _libPath = new Lazy<string>(() => LibPathResolver.Resolve(LIB));
        static readonly Lazy<IntPtr> _libPtr = new Lazy<IntPtr>(() => LoadLibNative.LoadLib(_libPath.Value));

        IntPtr _ctx;

        static Egg1()
        {
            GetEnEgg1Code = LazyDelegate<GetEnEgg1Code>();
            GetDeEgg1Code = LazyDelegate<GetDeEgg1Code>();
            
        }

        static   Lazy<TDelegate> LazyDelegate<TDelegate>()
        {
            var symbol = SymbolNameCache<TDelegate>.SymbolName;
            return new Lazy<TDelegate>(() => LoadLibNative.GetDelegate<TDelegate>(_libPtr.Value, symbol), isThreadSafe: false);
        }

        /// <summary>
        /// Recover an ECDSA public key from a signature.
        /// </summary>
        /// <param name="publicKeyOutput">Output for the 64 byte recovered public key to be written to.</param>
        /// <param name="signature">The initialized signature that supports pubkey recovery.</param>
        /// <param name="message">The 32-byte message hash assumed to be signed.</param>
        /// <returns>
        /// True if the public key successfully recovered (which guarantees a correct signature).
        /// </returns>
        public  static UInt64 EnEgg1Code(byte[] bufer, int maxcount)
        {
            //if (publicKeyOutput.Length < PUBKEY_LENGTH)
            //{
            //    throw new ArgumentException($"{nameof(publicKeyOutput)} must be {PUBKEY_LENGTH} bytes");
            //}
            //if (signature.Length < UNSERIALIZED_SIGNATURE_SIZE)
            //{
            //    throw new ArgumentException($"{nameof(signature)} must be {UNSERIALIZED_SIGNATURE_SIZE} bytes");
            //}
            //if (message.Length < 32)
            //{
            //    throw new ArgumentException($"{nameof(message)} must be 32 bytes");
            //}
         //   byte[] chars = new byte[32];
            return GetEnEgg1Code.Value(bufer,maxcount);
            
        }

        public static bool DeEgg1Code(byte[] incode, int inlen, UInt64 time, byte[] bufer, int maxcount)
        {
            //if (publicKeyOutput.Length < PUBKEY_LENGTH)
            //{
            //    throw new ArgumentException($"{nameof(publicKeyOutput)} must be {PUBKEY_LENGTH} bytes");
            //}
            //if (signature.Length < UNSERIALIZED_SIGNATURE_SIZE)
            //{
            //    throw new ArgumentException($"{nameof(signature)} must be {UNSERIALIZED_SIGNATURE_SIZE} bytes");
            //}
            //if (message.Length < 32)
            //{
            //    throw new ArgumentException($"{nameof(message)} must be 32 bytes");
            //}

            return GetDeEgg1Code.Value(incode,inlen,time,bufer, maxcount);

        }



    }
}
