using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NASMB
{
    //	Init(ctx context.Context, typ crypto.SigType) (address.Address, error)                       //perm:admin
    //  New(ctx context.Context, typ crypto.SigType) (address.Address, error)                        //perm:admin
    //  List(ctx context.Context) ([] address.Address, error)                                         //perm:admin
    //	Delete(ctx context.Context, address address.Address) error                                   //perm:admin
    //	SignDefault(ctx context.Context, msg[]byte) (* crypto.Signature, error)                      //perm:admin
    //	Sign(ctx context.Context, address[]byte, msg[]byte) (* crypto.Signature, error)             //perm:admin
    //	Verify(ctx context.Context, address[]byte, msg[]byte, sig* crypto.Signature) (bool, error) //perm:admin
    //	Export(ctx context.Context) (string, error)                                                  //perm:admin
    //	Import(ctx context.Context, hexs string, pwd string) error                                   //perm:admin
    //	Default(ctx context.Context) address.Address                                                 //perm:admin
    //	Setdefault(ctx context.Context, a address.Address) error                                     //perm:admin
    //	Close() error                                                                                //perm:admin
	public interface IASMB
    {
       // GetBlockbyHS(ctx context.Context, h uint64, s[]byte) (* SignBlockHeader, error)
        Task<object> GetBlockbyHS( UInt64 h, byte[] s );
    }




}
