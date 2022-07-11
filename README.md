# asmbapi.net
asmb 接口C# 实现
```
  var aRpcClient = Fullapi.FindSliceApiService(AConst.MaxSlice);

  var ret = await aRpcClient.SendRequestAsync<object>("GetBlockbyHS", null, 1, AConst.MaxSlice);
```
