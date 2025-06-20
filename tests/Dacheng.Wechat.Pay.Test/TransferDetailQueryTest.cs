using Dacheng.Wechat.Pay.ExtensionMethods;
using Dacheng.Wechat.Pay.Request;

namespace Dacheng.Wechat.Pay.Test;

/// <summary>
/// 微信转账明细查询测试
/// </summary>
public class TransferDetailQueryTest : WechatPayTestBase
{
    [Test]
    public async Task TestTransferDetailQueryByDetailId()
    {
        var request = new TransferDetailQueryByDetailIdRequest()
        {
            BatchId = "131000009034101730878572023100350019199239",
            DetailId = "132000009034101730878572023100332718734401",
        };
        var response = await _client!.SendAsync(request);
    }

    [Test]
    public async Task TestTransferDetailQueryByOutDetailNo()
    {
        var request = new TransferDetailQueryByOutDetailNoRequest()
        {
            OutBatchNo = "3fe35a12b1244a6dad3a979e6692d1c5",
            OutDetailNo = "test1",
        };
        var response = await _client!.SendAsync(request);
    }
}