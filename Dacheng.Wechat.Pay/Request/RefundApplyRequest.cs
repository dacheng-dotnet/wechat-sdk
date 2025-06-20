using System.Text.Json;
using System.Text.Json.Serialization;
using Dacheng.Wechat.Pay.Response;

namespace Dacheng.Wechat.Pay.Request;

/// <summary>
/// 申请退款
/// </summary>
public class RefundApplyRequest : WechatPayRequestBase<RefundQueryResponse>, ISerializable
{
    /// <summary>
    /// 请求方式
    /// </summary>
    [JsonIgnore]
    public override WechatPayMethod Method => WechatPayMethod.Post;

    /// <summary>
    /// 接口名称
    /// </summary>
    [JsonIgnore]
    public override string Api => "/v3/refund/domestic/refunds";

    /// <summary>
    /// 微信支付订单号
    /// 原支付交易对应的微信订单号
    /// </summary>
    [JsonPropertyName("transaction_id")]
    public string TransactionId { get; set; } = "";

    /// <summary>
    /// 商户订单号
    /// 原支付交易对应的商户订单号
    /// </summary>
    [JsonPropertyName("out_trade_no")]
    public string OutTradeNo { get; set; } = "";

    /// <summary>
    /// 商户退款单号
    /// 商户系统内部的退款单号，商户系统内部唯一，只能是数字、大小写字母_-|*@ ，同一退款单号多次请求只退一笔。
    /// </summary>
    [JsonPropertyName("out_refund_no")]
    public string OutRefundNo { get; set; } = "";

    /// <summary>
    /// 退款原因
    /// 若商户传入，会在下发给用户的退款消息中体现退款原因
    /// </summary>
    [JsonPropertyName("reason")]
    public string Reason { get; set; } = "";

    /// <summary>
    /// 退款结果回调url
    /// 异步接收微信支付退款结果通知的回调地址，通知url必须为外网可访问的url，不能携带参数。
    /// 如果参数中传了notify_url，则商户平台上配置的回调地址将不会生效，优先回调当前传的这个地址。
    /// </summary>
    [JsonPropertyName("notify_url")]
    public string NotifyUrl { get; set; } = "";

    /// <summary>
    /// 退款资金来源
    /// 若传递此参数则使用对应的资金账户退款，否则默认使用未结算资金退款（仅对老资金流商户适用）
    /// 枚举值：
    /// AVAILABLE：可用余额账户
    /// </summary>
    [JsonPropertyName("funds_account")]
    public string FundsAccount { get; set; } = "";

    /// <summary>
    /// 金额信息
    /// 订单金额信息
    /// </summary>
    [JsonPropertyName("amount")]
    public RefundAmount Amount { get; set; }
    
    /// <summary>
    /// 退款商品
    /// 指定商品退款需要传此参数，其他场景无需传递
    /// </summary>
    [JsonPropertyName("goods_detail")]
    public List<RefundGoods> GoodsDetail { get; set; }
    
    public class RefundAmount
    {
        /// <summary>
        /// 退款金额
        /// 退款金额，单位为分，只能为整数，不能超过原订单支付金额。
        /// </summary>
        [JsonPropertyName("refund")]
        public int Refund { get; set; }
        
        /// <summary>
        /// 原订单金额
        /// 原支付交易的订单总金额，单位为分，只能为整数。
        /// </summary>
        [JsonPropertyName("total")]
        public int Total { get; set; }

        /// <summary>
        /// 退款币种
        /// 符合ISO 4217标准的三位字母代码，目前只支持人民币：CNY。
        /// </summary>
        [JsonPropertyName("currency")]
        public string Currency { get; set; } = "CNY";
        
        /// <summary>
        /// 退款出资账户及金额
        /// 退款需要从指定账户出资时，传递此参数指定出资金额（币种的最小单位，只能为整数）。
        /// 同时指定多个账户出资退款的使用场景需要满足以下条件：
        /// 1、未开通退款支出分离产品功能；
        /// 2、订单属于分账订单，且分账处于待分账或分账中状态。
        /// 参数传递需要满足条件：
        /// 1、基本账户可用余额出资金额与基本账户不可用余额出资金额之和等于退款金额；
        /// 2、账户类型不能重复。
        /// 上述任一条件不满足将返回错误
        /// </summary>
        [JsonPropertyName("from")]
        public List<RefundAccount> From { get; set; }
    }
    
    /// <summary>
    /// 退款出资账户及金额
    /// </summary>
    public class RefundAccount
    {
        /// <summary>
        /// 出资账户类型
        /// 下面枚举值多选一。
        /// 枚举值：
        /// AVAILABLE : 可用余额
        /// UNAVAILABLE : 不可用余额
        /// </summary>
        public string Account { get; set; } = "";
        
        /// <summary>
        /// 出资金额
        /// 对应账户出资金额
        /// </summary>
        [JsonPropertyName("amount")]
        public int Amount { get; set; }
    }
    
    /// <summary>
    /// 退款商品信息
    /// </summary>
    public class RefundGoods
    {
        /// <summary>
        /// 商户侧商品编码
        /// 由半角的大小写字母、数字、中划线、下划线中的一种或几种组成
        /// </summary>
        [JsonPropertyName("merchant_goods_id")]
        public string MerchantGoodsId { get; set; }
        
        /// <summary>
        /// 微信支付商品编码
        /// 微信支付定义的统一商品编号（没有可不传）
        /// </summary>
        [JsonPropertyName("wechatpay_goods_id")]
        public string WechatpayGoodsId { get; set; }
        
        /// <summary>
        /// 商品名称
        /// 商品的实际名称
        /// </summary>
        [JsonPropertyName("goods_name")]
        public string goods_name { get; set; }
        
        /// <summary>
        /// 商品单价
        /// 商品单价金额，单位为分
        /// </summary>
        [JsonPropertyName("unit_price")]
        public int UnitPrice { get; set; }
        
        /// <summary>
        /// 商品退款金额
        /// 商品退款金额，单位为分
        /// </summary>
        [JsonPropertyName("refund_amount")]
        public int RefundAmount { get; set; }
        
        /// <summary>
        /// 商品退货数量
        /// 单品的退款数量
        /// </summary>
        [JsonPropertyName("refund_quantity")]
        public int RefundQuantity { get; set; }
    }
    
    public string Serialize()
    {
        return JsonSerializer.Serialize(this);
    }
}