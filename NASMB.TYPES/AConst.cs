using System;
using System.Collections.Generic;
using System.Text;

namespace NASMB
{
   





    public class AConst
    {
        public const string ASMB_ID = "0";// 本地测试链0, 测试链1，主链2
        public const int Chainid = 0;//区块链id 与上面相同 类型不同
        public const string ASMB_ETCD_START = "asmb/" + ASMB_ID;                         //  值 ==1 可以start 值 不等于1 ，等待==1 时start
        public static byte[] ASMB_ETCD_SHAREDB_SLICEMG = System.Text.Encoding.Default.GetBytes( "asmb/" + ASMB_ID + "/slice/");   // 分片管理,%s:slice/nodeid,value = exinfo
        public static byte[] ASMB_ETCD_SHAREDB_SLICEMG_END = System.Text.Encoding.Default.GetBytes("asmb/" + ASMB_ID + "/slice~");// 分片管理,%s:slice+nodeid,value = exinfo
                                                                                          //const SHAREDB_ASMB_PRESLICEMG = "asmb/preslice/%s"       // 分片管理,%s:slice,value = exinfo
        public const string ASMB_ETCD_SHAREDB_SPARESERVERS = "asmb/" + ASMB_ID + "/aspareservers/";// 空闲服务器，%s:节点id ,value = exinfo
        public const string ASMB_ETCD_MSGS = "asmb/" + ASMB_ID + "/msgs/";                   // 未消费的消息，分叉时产生，%s:地址+费率+time ,value = msgbs
        public const string ASMB_IPFS_PUBSUB_CHAIN = "asmb/" + ASMB_ID + "/chain/";                 // 区块分发通道
        public const string ASMB_IPFS_PUBSUB_MSG = "asmb/" + ASMB_ID + "/msg/";          // 区块分片massagemanager 消息pubsub通道前缀
        public const string RAFT_LVLDB_MSGS = "asmb/" + ASMB_ID + "/msgs/";              //区块分片massagemanager
        public static byte[] RAFT_LVLDB_MSGS_B = System.Text.Encoding.Default.GetBytes(RAFT_LVLDB_MSGS);


        public const int HashLen = 32; // 不可修改
        public const int AddrLen = 20; // 不可修改


        public static byte[] MinSlice = { 0 };
        public static byte[] MaxSlice = { 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255 };
    }
}
