using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASMB.TYPES
{
    public enum Msgtype
    {

        Unknown = Byte.MaxValue,

        PubBlock = 1,

        JionPD, // 加入生产链
                // 贡献奖励,奖励给 miner body 是区块树根
        SysCoinbase,

        SignTrans,//正常交易消息

        CfmTrans,//交易输入确认


        SignVote, //投票消息 （预先扣除手续费）->from 所在slice 消息发出后必须成功执行（追加手续费），不然就一直锁定

        CfmVote,  //确认form 投票 -> to 所在 slice，修改to 状态

        RSignVote,// 解除from锁定回执，votes +


        SignCancelvote,    //撤销投票

        CfmCancelvote,      //

        ExcCancelVote,     // 刷新成功

        ExcCancelVoteFail,   // 刷新失败

        RSignCancelvoteSucc,// 执行回执 根据上一步执行结果 设置 revokingvote 值

        RSignCancelvoteFail,//
                            // CfmtoCancelvote    //确认to 撤销投票->to 挖矿所在slice
                            // CfmSliceCancelvote //确认to 挖矿所在slice 撤销-> from 状态修改
        SignProducing, // 扣除手续费，生产刷新不能并行 消息锁=1，消息执行完毕后才能进行下一个消息

        ExcProducing, // 刷新排名

        ExcProducingFail,

        RSignProducingSucc,// 设置生产中 ，生产中不能再次执行signproducing（生产中只能执行刷新），撤销生产后才可以

        RSignProducingFail, // 生产成功，生产失败

        SignCancelProducing, // 撤销生产

        ExcCancelProducing,

        ExcCancelProducingFail,

        RSignCancelProducingSucc,

        RSignCancelProducingFail,


        SignVoteRefresh,//(不需要消息锁)刷新生产票数 修改金额（from 手续费扣除

        ExcVoteRefresh,  //刷新投票状态-> from 挖矿所在slice 修改排名

        ExcVoteRefreshFail,
        //RSignVoteRefresh // 刷新回执，解除消息锁
        //VoteRefreshSucc //成功失败，修改from slice 状态
        //VoteRefreshFail //

        Addcharges,// 追加手续费


        SignEgg1, // 彩蛋1

        CfmEgg1, // 确认彩蛋
    }
}
