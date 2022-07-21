using System;
using System.Collections.Generic;
using System.Text;

namespace NASMB
{

	public class FullapilistConfig
	{
		//	TrustedNetchianUrl []ExchangeChainInfoMessage //可信列表
		public string MinersliceAeskey = "eyJhbGciOiJIUzI1eyJhbGciOiJIUzI1";//旷工分片许可证

		public string MinersliceNet = "mountain";//旷工分片网络集合名称

		//	public string Endpoints = "asmb.site:2379,asmb.site:2379";

		public string Endpoints =  "http://127.0.0.1:2379" ;//etcd url

		public string Username = "root"; // etcd username

		public string Password = "mountainfa"; // etcd password
	}
	public class AConfig
	{
		public static string Rpcclientaddr = "http://120.48.85.133:8106";
		public static FullapilistConfig FullapilistConfig = new FullapilistConfig();

		public static int NormalServerLoadCount = 9; //正常分片数量，资源紧缺时 上浮 1/3 (最大 ChainInstancesQty/3*4)
		public static int SliceMgBackupCount = 1; // 相同分片安全备用服务数量

	}
}
