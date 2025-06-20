using Dacheng.Wechat.Pay.Response;

namespace Dacheng.Wechat.Pay.Request;

/// <summary>
/// 通过微信明细单号查询明细单
/// </summary>
public class TransferDetailQueryByDetailIdRequest : WechatPayRequestBase<TransferDetailQueryResponse>
{
    /// <summary>
    /// 请求方式
    /// </summary>
    public override WechatPayMethod Method => WechatPayMethod.Get;

    /// <summary>
    /// 接口名称
    /// </summary>
    public override string Api => $"/v3/transfer/batches/batch-id/{BatchId}/details/detail-id/{DetailId}";

    /// <summary>
    /// 微信批次单号
    /// 微信批次单号，微信商家转账系统返回的唯一标识
    /// </summary>
    public string BatchId { get; set; } = "";

    /// <summary>
    /// 微信明细单号
    /// 微信支付系统内部区分转账批次单下不同转账明细单的唯一标识
    /// </summary>
    public string DetailId { get; set; } = "";
}