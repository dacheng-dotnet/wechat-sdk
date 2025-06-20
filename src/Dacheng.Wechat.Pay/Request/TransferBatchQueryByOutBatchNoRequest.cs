using Dacheng.Wechat.Pay.Response;

namespace Dacheng.Wechat.Pay.Request;

/// <summary>
/// 通过商家批次单号查询批次单
/// </summary>
public class TransferBatchQueryByOutBatchNoRequest : WechatPayRequestBase<TransferBatchQueryResponse>
{
    /// <summary>
    /// 请求方式
    /// </summary>
    public override WechatPayMethod Method => WechatPayMethod.Get;

    /// <summary>
    /// 接口名称
    /// </summary>
    public override string Api => $"/v3/transfer/batches/out-batch-no/{OutBatchNo}" +
                                  $"?need_query_detail={NeedQueryDetail}" +
                                  $"&detail_status={DetailStatus}" +
                                  $"&offset={Offset}" +
                                  $"&limit={Limit}";

    /// <summary>
    /// 商家批次单号
    /// 商户系统内部的商家批次单号，在商户系统内部唯一
    /// </summary>
    public string OutBatchNo { get; set; } = "";

    /// <summary>
    /// 是否查询转账明细单
    /// true-是；false-否，默认否。
    /// 商户可选择是否查询指定状态的转账明细单，当转账批次单状态为“FINISHED”（已完成）时，才会返回满足条件的转账明细单
    /// </summary>
    public bool NeedQueryDetail { get; set; } = false;

    /// <summary>
    /// 明细状态
    /// ALL:全部。需要同时查询转账成功、失败和待确认的明细单
    /// WAIT_PAY: 待确认。待商户确认, 符合免密条件时, 系统会自动扭转为转账中
    /// SUCCESS:转账成功
    /// FAIL:转账失败。需要确认失败原因后，再决定是否重新发起对该笔明细单的转账（并非整个转账批次单）
    /// </summary>
    public string? DetailStatus { get; set; } = "ALL";

    /// <summary>
    /// 请求资源起始位置
    /// 该次请求资源的起始位置。
    /// 返回的明细是按照设置的明细条数进行分页展示的，一次查询可能无法返回所有明细，我们使用该参数标识查询开始位置，默认值为0
    /// </summary>
    public int? Offset { get; set; } = 0;

    /// <summary>
    /// 最大资源条数
    /// 该次请求可返回的最大明细条数，最小20条，最大100条，不传则默认20条。
    /// 不足20条按实际条数返回
    /// </summary>
    public int? Limit { get; set; } = 20;
}