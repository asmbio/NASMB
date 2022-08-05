using Secp256k1Net;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace NASMB.GO
{


    [SymbolName(nameof(GetEnEgg1Code))]
    public delegate UInt64 GetEnEgg1Code(byte[] bufer, int maxcount);

    [SymbolName(nameof(GetDeEgg1Code))]
    public delegate bool GetDeEgg1Code(byte[] incode, int inlen, UInt64 time, byte[] bufer, int maxcount);

}