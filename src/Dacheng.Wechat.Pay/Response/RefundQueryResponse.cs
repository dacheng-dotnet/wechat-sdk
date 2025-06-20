using System.Text.Json.Serialization;

namespace Dacheng.Wechat.Pay.Response;

/// <summary>
/// 申请退款
/// </summary>
public class RefundQueryResponse : WechatPayResponseBase
{
    /// <summary>
    /// 微信支付退款单号
    /// </summary>
    [JsonPropertyName("refund_id")]
    public string RefundId { get; set; }
    
    /// <summary>
    /// 商户退款单号
    /// 商户系统内部的退款单号，商户系统内部唯一，只能是数字、大小写字母_-|*@ ，同一退款单号多次请求只退一笔。
    /// </summary>
    [JsonPropertyName("out_refund_no")]
    public string OutRefundNo { get; set; }
    
    /// <summary>
    /// 微信支付订单号
    /// 微信支付交易订单号
    /// </summary>
    [JsonPropertyName("transaction_id")]
    public string TransactionId { get; set; }
    
    /// <summary>
    /// 商户订单号
    /// 原支付交易对应的商户订单号
    /// </summary>
    [JsonPropertyName("out_trade_no")]
    public string OutTradeNo { get; set; }
    
    /// <summary>
    /// 退款渠道
    /// 枚举值：
    /// ORIGINAL：原路退款
    /// BALANCE：退回到余额
    /// OTHER_BALANCE：原账户异常退到其他余额账户
    /// OTHER_BANKCARD：原银行卡异常退到其他银行卡
    /// </summary>
    [JsonPropertyName("channel")]
    public string Channel { get; set; }

    /// <summary>
    /// 退款入账账户
    /// 取当前退款单的退款入账方，有以下几种情况：
    /// 1）退回银行卡：{银行名称}{卡类型}{卡尾号}
    /// 2）退回支付用户零钱:支付用户零钱
    /// 3）退还商户:商户基本账户商户结算银行账户
    /// 4）退回支付用户零钱通:支付用户零钱通
    /// </summary>
    [JsonPropertyName("user_received_account")]
    public string UserReceivedAccount { get; set; }
    
    /// <summary>
    /// 退款成功时间
    /// 退款成功时间，当退款状态为退款成功时有返回。
    /// </summary>
    [JsonPropertyName("success_time")]
    public string SuccessTime { get; set; }
    
    /// <summary>
    /// 退款创建时间
    /// 退款受理时间
    /// </summary>
    [JsonPropertyName("create_time")]
    public string CreateTime { get; set; }
    
    /// <summary>
    /// 退款状态
    /// 退款到银行发现用户的卡作废或者冻结了，导致原路退款银行卡失败，可前往商户平台-交易中心，手动处理此笔退款。
    /// 枚举值：
    /// SUCCESS：退款成功
    /// CLOSED：退款关闭
    /// PROCESSING：退款处理中
    /// ABNORMAL：退款异常
    /// </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; }
    
    /// <summary>
    /// 资金账户
    /// 退款所使用资金对应的资金账户类型
    /// 枚举值：
    /// UNSETTLED : 未结算资金
    /// AVAILABLE : 可用余额
    /// UNAVAILABLE : 不可用余额
    /// OPERATION : 运营户
    /// BASIC : 基本账户（含可用余额和不可用余额）
    /// </summary>
    [JsonPropertyName("funds_account")]
    public string FundsAccount { get; set; }

    /// <summary>
    /// 金额信息
    /// 金额详细信息
    /// </summary>
    [JsonPropertyName("amount")]
    public RefundAmount Amount { get; set; }
    
    /// <summary>
    /// 优惠退款信息
    /// </summary>
    [JsonPropertyName("promotion_detail")]
    public List<RefundPromotion> PromotionDetail { get; set; }

    public class RefundAmount
    {
        /// <summary>
        /// 订单金额
        /// 订单总金额，单位为分
        /// </summary>
        [JsonPropertyName("total")]
        public int Total { get; set; }
        
        /// <summary>
        /// 退款金额
        /// 退款标价金额，单位为分，可以做部分退款
        /// </summary>
        [JsonPropertyName("refund")]
        public int Refund { get; set; }
        
        /// <summary>
        /// 退款出资账户及金额
        /// 退款出资的账户类型及金额信息
        /// </summary>
        [JsonPropertyName("from")]
        public List<RefundAccount> From { get; set; }
        
        /// <summary>
        /// 用户支付金额
        /// 现金支付金额，单位为分，只能为整数
        /// </summary>
        [JsonPropertyName("payer_total")]
        public int PayerTotal { get; set; }
        
        /// <summary>
        /// 用户退款金额
        /// 退款给用户的金额，不包含所有优惠券金额
        /// </summary>
        [JsonPropertyName("payer_refund")]
        public int PayerRefund { get; set; }
        
        /// <summary>
        /// 应结退款金额
        /// 去掉非充值代金券退款金额后的退款金额，单位为分，退款金额=申请退款金额-非充值代金券退款金额，退款金额&lt;=申请退款金额
        /// </summary>
        [JsonPropertyName("settlement_refund")]
        public int SettlementRefund { get; set; }
        
        /// <summary>
        /// 应结订单金额
        /// 应结订单金额=订单金额-免充值代金券金额，应结订单金额<=订单金额，单位为分
        /// </summary>
        [JsonPropertyName("settlement_total")]
        public int SettlementTotal { get; set; }
        
        /// <summary>
        /// 优惠退款金额
        /// 优惠退款金额<=退款金额，退款金额-代金券或立减优惠退款金额为现金，说明详见代金券或立减优惠，单位为分
        /// </summary>
        [JsonPropertyName("discount_refund")]
        public int DiscountRefund { get; set; }

        /// <summary>
        /// 退款币种
        /// 符合ISO 4217标准的三位字母代码，目前只支持人民币：CNY。
        /// </summary>
        [JsonPropertyName("currency")]
        public string Currency { get; set; } = "CNY";
        
        /// <summary>
        /// 手续费退款金额
        /// 手续费退款金额，单位为分。
        /// </summary>
        [JsonPropertyName("refund_fee")]
        public int RefundFee { get; set; }
    }
    
    /// <summary>
    /// 退款账户及金额信息
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
        [JsonPropertyName("account")]
        public string Account { get; set; }
        
        /// <summary>
        /// 出资金额
        /// 对应账户出资金额
        /// </summary>
        [JsonPropertyName("amount")]
        public int Amount { get; set; }
    }
    
    /// <summary>
    /// 优惠退款信息
    /// </summary>
    public class RefundPromotion
    {
        /// <summary>
        /// 券ID
        /// 券或者立减优惠id
        /// </summary>
        [JsonPropertyName("promotion_id")]
        public string PromotionId { get; set; }
        
        /// <summary>
        /// 优惠范围
        /// 枚举值：
        /// GLOBAL：全场代金券
        /// SINGLE：单品优惠
        /// </summary>
        [JsonPropertyName("scope")]
        public string scope { get; set; }
        
        /// <summary>
        /// 优惠类型
        /// 枚举值：
        /// COUPON：代金券，需要走结算资金的充值型代金券
        /// DISCOUNT：优惠券，不走结算资金的免充值型优惠券
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }
        
        /// <summary>
        /// 优惠券面额
        /// 用户享受优惠的金额（优惠券面额=微信出资金额+商家出资金额+其他出资方金额 ），单位为分
        /// </summary>
        [JsonPropertyName("amount")]
        public int Amount { get; set; }
        
        /// <summary>
        /// 优惠退款金额
        /// 优惠退款金额<=退款金额，退款金额-代金券或立减优惠退款金额为用户支付的现金，说明详见代金券或立减优惠，单位为分
        /// </summary>
        [JsonPropertyName("refund_amount")]
        public int RefundAmount { get; set; }
        
        /// <summary>
        /// 商品列表
        /// 优惠商品发生退款时返回商品信息
        /// </summary>
        [JsonPropertyName("goods_detail")]
        public List<RefundGoods> GoodsDetail { get; set; }
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
}