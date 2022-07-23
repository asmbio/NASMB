using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace NASMB.TYPES
{

    // 刷新投票流程
    // 1) 扣除手续费，修改slice ,lock =true
    // 2) 刷新hb，返回结果
    // 3) 根据结果，修改 slice 状态是否为空，
    // 4) lock = false 解除锁定
    public struct VoteState
    {
        //自己的总票数 = votes + othervotes
        //
        public BigInteger? Votes; //自己的投票票数

        public BigInteger? OtherVotes; //别人给自己的投票
        public string To;   //投票的目标地址,如果投票给自己，地址为空
                            //Slice      []byte   //投票的目标生产分片，如果投票给别人,目标分片为空
                            // 0:producing 消息锁 1:生产状态 2:
        public byte Lock; //  事务锁 ，一个8位，同时进行8个事务 ，刷新投票手续费扣除后  处于锁定状态，执行返回后解除锁定// 如果无法解除锁定，需要追加手续费
    }
    public class StateAccount
    {
        //Nonce   uint64
        //   trie* trie.Trie

        public BigInteger? Balance;
        public BigInteger? LockedAmount; // 投票中（votes+），赎回中（balance +）
        public VoteState Votest;      // 投票和得票状态VoteState cid
                                      // 邀请人
                                      //
        public byte[] ExInfo;// 附件数据
                             // 点对点交易 ：
                             //1)输出方签名以后发送给接收方，输出方如果余额不足时，如果接收方有意接收该未来票据
                             //	1.接收方把收到的票据保存，等输出方又余额时发送的网络进行确认
                             //	2.其他节点收到余额不足的交易直接丢弃
                             //	3.如果输出法秘钥修改，接收方需要将交易发送给输出者再次签名
                             // 节点确认时判断 nonce 是否是最新的切不能重复，如果不是最新的，
        public byte[] Receipts;//确认消息列表trie key:cid, value: Sign：1 cfm：2 	exc：3 确认状态+追加信息
                               //Input  []byte

        //Root     common.Hash // merkle root of the storage trie
        //CodeHash []byte
    }

    //public class StateAccount
    //{
    //}
}
