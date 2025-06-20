using System.Text.Json.Serialization;

namespace Dacheng.Wechat.Pay.Response;

/// <summary>
/// 微信转账明细查询响应
/// </summary>
public class TransferDetailQueryResponse : WechatPayResponseBase
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
    /// 商家明细单号
    /// 商户系统内部区分转账批次单下不同转账明细单的唯一标识
    /// </summary>
    [JsonPropertyName("out_detail_no")]
    public string OutDetailNo { get; set; } = "";

    /// <summary>
    /// 微信明细单号
    /// 微信支付系统内部区分转账批次单下不同转账明细单的唯一标识
    /// </summary>
    [JsonPropertyName("detail_id")]
    public string DetailId { get; set; } = "";

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
    
    /// <summary>
    /// 转账金额
    /// 转账金额单位为“分”
    /// </summary>
    [JsonPropertyName("transfer_amount")]
    public int TransferAmount { get; set; }

    /// <summary>
    /// 转账备注
    /// 单条转账备注（微信用户会收到该备注），UTF8编码，最多允许32个字符
    /// </summary>
    [JsonPropertyName("transfer_remark")]
    public string TransferRemark { get; set; } = "";

    /// <summary>
    /// 明细失败原因
    /// 如果转账失败则有失败原因
    /// 可选取值：
    /// ACCOUNT_FROZEN: 该用户账户被冻结
    /// REAL_NAME_CHECK_FAIL: 收款人未实名认证，需要用户完成微信实名认证
    /// NAME_NOT_CORRECT: 收款人姓名校验不通过，请核实信息
    /// OPENID_INVALID: Openid格式错误或者不属于商家公众账号
    /// TRANSFER_QUOTA_EXCEED: 超过用户单笔收款额度，核实产品设置是否准确
    /// DAY_RECEIVED_QUOTA_EXCEED: 超过用户单日收款额度，核实产品设置是否准确
    /// MONTH_RECEIVED_QUOTA_EXCEED: 超过用户单月收款额度，核实产品设置是否准确
    /// DAY_RECEIVED_COUNT_EXCEED: 超过用户单日收款次数，核实产品设置是否准确
    /// PRODUCT_AUTH_CHECK_FAIL: 未开通该权限或权限被冻结，请核实产品权限状态
    /// OVERDUE_CLOSE: 超过系统重试期，系统自动关闭
    /// ID_CARD_NOT_CORRECT: 收款人身份证校验不通过，请核实信息
    /// ACCOUNT_NOT_EXIST: 该用户账户不存在
    /// TRANSFER_RISK: 该笔转账可能存在风险，已被微信拦截
    /// OTHER_FAIL_REASON_TYPE: 其它失败原因
    /// REALNAME_ACCOUNT_RECEIVED_QUOTA_EXCEED: 用户账户收款受限，请引导用户在微信支付查看详情
    /// RECEIVE_ACCOUNT_NOT_PERMMIT: 未配置该用户为转账收款人，请在产品设置中调整，添加该用户为收款人
    /// PAYEE_ACCOUNT_ABNORMAL: 用户账户收款异常，请联系用户完善其在微信支付的身份信息以继续收款
    /// PAYER_ACCOUNT_ABNORMAL: 商户账户付款受限，可前往商户平台获取解除功能限制指引
    /// TRANSFER_SCENE_UNAVAILABLE: 该转账场景暂不可用，请确认转账场景ID是否正确
    /// TRANSFER_SCENE_INVALID: 你尚未获取该转账场景，请确认转账场景ID是否正确
    /// TRANSFER_REMARK_SET_FAIL: 转账备注设置失败， 请调整后重新再试
    /// RECEIVE_ACCOUNT_NOT_CONFIGURE: 请前往商户平台-商家转账到零钱-前往功能-转账场景中添加
    /// BLOCK_B2C_USERLIMITAMOUNT_BSRULE_MONTH: 超出用户单月转账收款20w限额，本月不支持继续向该用户付款
    /// BLOCK_B2C_USERLIMITAMOUNT_MONTH: 用户账户存在风险收款受限，本月不支持继续向该用户付款
    /// MERCHANT_REJECT: 商户员工（转账验密人）已驳回转账
    /// MERCHANT_NOT_CONFIRM: 商户员工（转账验密人）超时未验密
    /// </summary>
    [JsonPropertyName("fail_reason")]
    public string? FailReason { get; set; } = "";

    /// <summary>
    /// 收款用户openid
    /// 商户appid下，某用户的openid
    /// </summary>
    [JsonPropertyName("openid")]
    public string OpenId { get; set; } = "";
    
    /// <summary>
    /// 收款用户姓名
    /// 收款方姓名。采用标准RSA算法，公钥由微信侧提供
    /// 商户转账时传入了收款用户姓名、查询时会返回收款用户姓名
    /// </summary>
    [JsonPropertyName("user_name")]
    public string? UserName { get; set; }

    /// <summary>
    /// 转账发起时间
    /// 转账发起的时间，按照使用rfc3339所定义的格式，格式为YYYY-MM-DDThh:mm:ss+TIMEZONE
    /// </summary>
    [JsonPropertyName("initiate_time")]
    public string InitiateTime { get; set; } = "";

    /// <summary>
    /// 明细更新时间
    /// 明细最后一次状态变更的时间，按照使用rfc3339所定义的格式，格式为YYYY-MM-DDThh:mm:ss+TIMEZONE
    /// </summary>
    [JsonPropertyName("update_time")]
    public string UpdateTime { get; set; } = "";
}