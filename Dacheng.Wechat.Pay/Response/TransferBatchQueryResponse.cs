using System.Text.Json.Serialization;

namespace Dacheng.Wechat.Pay.Response;

/// <summary>
/// 微信商家转账批次查询响应
/// </summary>
public class TransferBatchQueryResponse : WechatPayResponseBase
{
    /// <summary>
    /// 转账批次单
    /// 转账批次单基本信息
    /// </summary>
    [JsonPropertyName("transfer_batch")]
    public TransferBatchModel TransferBatch { get; set; } = null!;

    /// <summary>
    /// 转账明细单列表
    /// 当批次状态为“FINISHED”（已完成），且成功查询到转账明细单时返回。包括微信明细单号、明细状态信息
    /// </summary>
    [JsonPropertyName("transfer_detail_list")]
    public List<TransferDetailModel>? TransferDetailList { get; set; }

    /// <summary>
    /// 转账批次
    /// </summary>
    public class TransferBatchModel
    {
        /// <summary>
        /// 商户号
        /// 微信支付分配的商户号
        /// </summary>
        [JsonPropertyName("mchid")]
        public string MchId { get; set; } = "";

        /// <summary>
        /// 商家批次单号
        /// 商户系统内部的商家批次单号，在商户系统内部唯一
        /// </summary>
        [JsonPropertyName("out_batch_no")]
        public string OutBatchNo { get; set; } = "";

        /// <summary>
        /// 微信批次单号
        /// 微信批次单号，微信商家转账系统返回的唯一标识
        /// </summary>
        [JsonPropertyName("batch_id")]
        public string BatchId { get; set; } = "";

        /// <summary>
        /// 商户appid
        /// 申请商户号的appid或商户号绑定的appid（企业号corpid即为此appid）
        /// </summary>
        [JsonPropertyName("appid")]
        public string AppId { get; set; } = "";

        /// <summary>
        /// 批次状态
        /// WAIT_PAY: 待付款确认。需要付款出资商户在商家助手小程序或服务商助手小程序进行付款确认
        /// ACCEPTED:已受理。批次已受理成功，若发起批量转账的30分钟后，转账批次单仍处于该状态，可能原因是商户账户余额不足等。
        /// 商户可查询账户资金流水，若该笔转账批次单的扣款已经发生，则表示批次已经进入转账中，请再次查单确认
        /// PROCESSING:转账中。已开始处理批次内的转账明细单
        /// FINISHED:已完成。批次内的所有转账明细单都已处理完成
        /// CLOSED:已关闭。可查询具体的批次关闭原因确认
        /// </summary>
        [JsonPropertyName("batch_status")]
        public string BatchStatus { get; set; } = "";

        /// <summary>
        /// 批次类型
        /// API:API方式发起
        /// WEB:页面方式发起
        /// </summary>
        [JsonPropertyName("batch_type")]
        public string BatchType { get; set; } = "";

        /// <summary>
        /// 批次名称
        /// 该笔批量转账的名称
        /// </summary>
        [JsonPropertyName("batch_name")]
        public string BatchName { get; set; } = "";

        /// <summary>
        /// 批次备注
        /// 转账说明，UTF8编码，最多允许32个字符
        /// </summary>
        [JsonPropertyName("batch_remark")]
        public string BatchRemark { get; set; } = "";

        /// <summary>
        /// 批次关闭原因
        /// 如果批次单状态为“CLOSED”（已关闭），则有关闭原因
        /// 可选取值：
        /// OVERDUE_CLOSE: 系统超时关闭，可能原因账户余额不足或其他错误
        /// TRANSFER_SCENE_INVALID: 付款确认时，转账场景已不可用，系统做关单处理
        /// </summary>
        [JsonPropertyName("close_reason")]
        public string? CloseReason { get; set; }

        /// <summary>
        /// 转账总金额
        /// 转账金额单位为“分”
        /// </summary>
        [JsonPropertyName("total_amount")]
        public int TotalAmount { get; set; }

        /// <summary>
        /// 转账总笔数
        /// 一个转账批次单最多发起三千笔转账
        /// </summary>
        [JsonPropertyName("total_num")]
        public int TotalNum { get; set; }

        /// <summary>
        /// 批次创建时间
        /// 批次受理成功时返回，按照使用rfc3339所定义的格式，格式为YYYY-MM-DDThh:mm:ss+TIMEZONE
        /// </summary>
        [JsonPropertyName("create_time")]
        public string? CreateTime { get; set; }

        /// <summary>
        /// 批次更新时间
        /// 批次最近一次状态变更的时间，按照使用rfc3339所定义的格式，格式为YYYY-MM-DDThh:mm:ss+TIMEZONE
        /// </summary>
        [JsonPropertyName("update_time")]
        public string? UpdateTime { get; set; }

        /// <summary>
        /// 转账成功金额
        /// 转账成功的金额，单位为“分”。当批次状态为“PROCESSING”（转账中）时，转账成功金额随时可能变化
        /// </summary>
        [JsonPropertyName("success_amount")]
        public int SuccessAmount { get; set; }

        /// <summary>
        /// 转账成功笔数
        /// 转账成功的笔数。当批次状态为“PROCESSING”（转账中）时，转账成功笔数随时可能变化
        /// </summary>
        [JsonPropertyName("success_num")]
        public int SuccessNum { get; set; }

        /// <summary>
        /// 转账失败金额
        /// 转账失败的金额，单位为“分”
        /// </summary>
        [JsonPropertyName("fail_amount")]
        public int FailAmount { get; set; }

        /// <summary>
        /// 转账失败笔数
        /// 转账失败的笔数
        /// </summary>
        [JsonPropertyName("fail_num")]
        public int FailNum { get; set; }

        /// <summary>
        /// 转账场景ID
        /// 指定的转账场景ID
        /// </summary>
        [JsonPropertyName("transfer_scene_id")]
        public string? TransferSceneId { get; set; }
    }

    /// <summary>
    /// 转账明细
    /// </summary>
    public class TransferDetailModel
    {
        /// <summary>
        /// 微信明细单号
        /// 微信支付系统内部区分转账批次单下不同转账明细单的唯一标识
        /// </summary>
        [JsonPropertyName("detail_id")]
        public string DetailId { get; set; } = "";

        /// <summary>
        /// 商家明细单号
        /// 商户系统内部区分转账批次单下不同转账明细单的唯一标识
        /// </summary>
        [JsonPropertyName("out_detail_no")]
        public string OutDetailNo { get; set; } = "";

        /// <summary>
        /// 明细状态
        /// INIT: 初始态。 系统转账校验中
        /// WAIT_PAY: 待确认。待商户确认, 符合免密条件时, 系统会自动扭转为转账中
        /// PROCESSING:转账中。正在处理中，转账结果尚未明确
        /// SUCCESS:转账成功
        /// FAIL:转账失败。需要确认失败原因后，再决定是否重新发起对该笔明细单的转账（并非整个转账批次单）
        /// </summary>
        [JsonPropertyName("detail_status")]
        public string DetailStatus { get; set; } = "";
    }
}