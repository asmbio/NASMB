using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace NASMB.TYPES
{
    public struct Summarystate
    {

        //每个区块权重计数：+=生产者的质押票数，总计权重：自基础高度累计权重 2）作用：计算叉链主链
        public BigInteger Totalweight { get; set; }


        public UInt64 Baseheight { get; set; } //统计基础高度（分叉时基础高度
                                               //第一个字节是否分叉 0：分叉结束无状态 ； 1:合并中 ；2：分叉中；  3:左+；  4：右+；
        public byte ForkMark { get; set; }
        // 生产者确定分叉标记设置倒计时 （Producer_n*2-当前排名）-- 距离分叉递减
        // 倒计时==0,下一个执行新的片
        public byte Forkcountdown { get; set; }
        //准备分叉
        //拆分准备中:MedianSlice = median ，
        //分叉准备中:MedianSlice = median ，
        //左+： MedianSlice =
        //右+： MedianSlice = 右median
        //左右+：  nil(判断是取左右区块判断)
        public byte[] MedianSlice { get; set; }
        //每个区块大小：messagelist内容 rlp编码后大小，总计大小：自基础高度累计	2）作用：分叉因素
        //  Totalsize> Maxblocksize*0.9 *(height-baseheight)  分成两块
        //  LTotalsize>=Maxblocksize*0.4 *(height-baseheight) &&（Totalsize< Maxblocksize*0.4 *(height-baseheight) ） 合并到左右区块
        //	- 首链 Totalsize<0.25
        // ~ 尾链 Totalsize<0.25
        public UInt32 Totalsize { get; set; }
        // 创世期：基础奖励=1，手续费奖励给创世者
        // 彩蛋1： 基础奖励=1   nihil 尼尔(大無) ，nil 無（小無），抽奖 每次=1大無
        // 彩蛋2：以后固定补充奖励0
        // 奖励接收流程：1）被奖励生产者添加手续费率并发送的slice 2）所在slice 生产者 确认并得到手续费
        // 奖励接收流程2：1）被奖励生产者和生产slice 同片 生产者状态直接获取 所有奖励
        // 本出块奖励：基础奖励（经济模型）+ 手续费
        //TotalCoinbase *big.Int //统计周期内总奖励  奖励计算

    }

    // slice == maxslice 存 producer 排名
    public class BlockHeader
    {

        public UInt64 Height { get; set; }        // identical for all blocks in same tipset
        public AsmbAddress Miner { get; set; }// unique per block/miner
        public byte[] Parent;        //parent trieindex  hash 高度+分片 作为key的区块树，左右两个都放进去
        public Messagebs[] Cfmmessages { get; set; }  //交易消息列表，先执行输入，在执行输出，防止金额不足 // 如何计算分叉点，中位数 怎么计算
        public byte[] State;        //账户状态树 //验证逻辑：父区块state + Cfmmessages
        public Summarystate Sumarystate { get; set; } //汇总信息

        public byte[] Slice;        // 分片范围 最大 ~ 最小 -
        public BigInteger Coinbase;    // 奖励+手续费

        public UInt64 Timestamp;       // identical
        public byte[] Producer;        //生产者排名有序状态树 trie，key: hb+ 质押票数+地址，value: pdstate// 结算周期对应的高度结算，结算后n块开始执行

        //rmkey []Messagebs //验证缓存 不可逆后删除
    }

    public class SignBlockHeader
    {

        public BlockHeader Bh { get; set; }

        public byte[] Sign;

        [JsonIgnore]
        public DateTime Time { get { return new DateTime((long)Bh.Timestamp/100+ 621355968000000000); } }
     
        //[JsonIgnore]
        //public AsmbAddress Slice { get { return Body.Slice(Msgtype); } }
        [JsonIgnore]
        public string Coinbase
        {
            get
            {
                return Nihil.FromNil(Bh.Coinbase);
            }
        }
    }

}
