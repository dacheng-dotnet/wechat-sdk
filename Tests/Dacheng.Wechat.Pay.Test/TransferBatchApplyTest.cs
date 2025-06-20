using Dacheng.Wechat.Pay.ExtensionMethods;
using Dacheng.Wechat.Pay.Request;

namespace Dacheng.Wechat.Pay.Test;

public class TransferBatchApplyTest : WechatPayTestBase
{
    [Test]
    public async Task Test()
    {
        var request = new TransferBatchApplyRequest()
        {
            AppId = _option!.AppId,
            OutBatchNo = Guid.NewGuid().ToString("N"),
            BatchName = "转账测试1",
            BatchRemark = "转账备注1",
            TotalAmount = 1,
            TotalNum = 1,
        };
        request.TransferDetailList.Add(new TransferBatchApplyRequest.TransferDetailModel()
        {
            OutDetailNo = "test1",
            TransferAmount = 1,
            TransferRemark = "转账备注1",
            OpenId = "testopenid",
        });
        await _client!.SendAsync(request);
    }
}