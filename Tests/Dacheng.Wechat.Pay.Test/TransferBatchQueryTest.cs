using Dacheng.Wechat.Pay.ExtensionMethods;
using Dacheng.Wechat.Pay.Request;

namespace Dacheng.Wechat.Pay.Test;

/// <summary>
/// 商家转账批次查询测试
/// </summary>
public class TransferBatchQueryTest : WechatPayTestBase
{
    [Test]
    public async Task TestTransferBatchQueryByBatchId()
    {
        var request = new TransferBatchQueryByBatchIdRequest()
        {
            BatchId = "131000009034101730878572023100350019199239",
            NeedQueryDetail = true,
        };
        var response = await _client!.SendAsync(request);
    }

    [Test]
    public async Task TestTransferBatchQueryByOutBatchNo()
    {
        var request = new TransferBatchQueryByOutBatchNoRequest()
        {
            OutBatchNo = "3fe35a12b1244a6dad3a979e6692d1c5",
            NeedQueryDetail = true,
        };
        var response = await _client!.SendAsync(request);
    }
}