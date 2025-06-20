using Dacheng.Wechat.Pay.Response;

namespace Dacheng.Wechat.Pay.Request;

/// <summary>
/// 通过商家明细单号查询明细单
/// </summary>
public class TransferDetailQueryByOutDetailNoRequest : WechatPayRequestBase<TransferDetailQueryResponse>
{
    /// <summary>
    /// 请求方式
    /// </summary>
    public override WechatPayMethod Method => WechatPayMethod.Get;

    /// <summary>
    /// 接口名称
    /// </summary>
    public override string Api => $"/v3/transfer/batches/out-batch-no/{OutBatchNo}/details/out-detail-no/{OutDetailNo}";

    /// <summary>
    /// 商家批次单号
    /// 商户系统内部的商家批次单号，在商户系统内部唯一
    /// </summary>
    public string OutBatchNo { get; set; } = "";

    /// <summary>
    /// 商家明细单号
    /// 商户系统内部区分转账批次单下不同转账明细单的唯一标识
    /// </summary>
    public string OutDetailNo { get; set; } = "";
}