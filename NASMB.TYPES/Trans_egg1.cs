using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace NASMB.TYPES
{
    public class Egg1msg
    {

        public Msgtype Msgtype;// models.Trans

        public AsmbAddress From;

        public byte[] Randomcode;
        public UInt64 Time;
    }
    public class SignEgg1msg:Itrans
    {

        public Egg1msg Egg1msg;
        public byte[] Sign;

        public BigInteger Balance()
        {
            return BigInteger.Zero;
        }

        public AsmbAddress Slice(Msgtype t)
        {
            //  if (t == Msgtype. SignEgg1 ){
            //      // 计算slice
            //      s, err:= DeEgg1Code(&cmsg.Egg1msg)

            //      if err != nil {
            //                  return make([]byte, 20)
            //}
            //      return s

            //      }
            return Egg1msg.From;
        }
        public BigInteger Rate()
        {
            return BigInteger.Zero;
        }

        public ulong Time()
        {
            return Egg1msg.Time;
        }
    }
}
