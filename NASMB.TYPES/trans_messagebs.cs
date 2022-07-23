using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASMB.TYPES
{

    public interface Itrans
    {
        //	vdmsg(c *Chain, ct *StateManager, cmsglen int, rcpkey []byte) (*StateAccount, *big.Int, error)
        //   VdRequest(c* Chain, msgfrom* pubsub.Message,  Messagebs msgbs) error
        //   Vdtrans(c* Chain, nblk* BlockHeader, msg Messagebs, ct* StateManager, blksize* uint32, coinbase* big.Int) ([]byte, error)
        //Rate() uint64
        // Uint64  Timestamp();
        //   Slice(t Msgtype) [] byte
    }
    public struct Messagebs
    {

        public byte Msgtype;
        public int len;
        public byte[] raw;
        public byte[] shakey;
        public Itrans Body;    // 可以是cid ,也可以是body(signmsg)
                               //	Hash   []byte // 确认区块hash
                               //	St   byte
    }
}
