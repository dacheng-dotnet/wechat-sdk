using System.Text.Json.Serialization;
using Dacheng.Wechat.Pay.Response;

namespace Dacheng.Wechat.Pay.Request;

/// <summary>
/// 查询单笔退款
/// </summary>
public class RefundQueryRequest : WechatPayRequestBase<RefundQueryResponse>
{
    /// <summary>
    /// 请求方式
    /// </summary>
    [JsonIgnore]
    public override WechatPayMethod Method => WechatPayMethod.Get;

    /// <summary>
    /// 接口名称
    /// </summary>
    [JsonIgnore]
    public override string Api => $"/v3/refund/domestic/refunds/{OutRefundNo}";

    /// <summary>
    /// 商户退款单号
    /// 商户系统内部的退款单号，商户系统内部唯一，只能是数字、大小写字母_-|*@ ，同一退款单号多次请求只退一笔。
    /// </summary>
    [JsonPropertyName("out_refund_no")]
    public string OutRefundNo { get; set; } = "";
}