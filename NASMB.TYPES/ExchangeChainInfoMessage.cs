
using System;
using System.Collections.Generic;
using System.Text;

namespace NASMB.TYPES
{
    public class ExchangeChainInfoMessage
    {
        public byte[] From, Slice;
        //BH           uint64 //当前周期基础高度高度
        public byte[]    Token; //aes 加密后
        public string Url;
        //public bool IsAutoServer;  // 无用
        //public UInt64 Failtimes; // 无用
    }
}
