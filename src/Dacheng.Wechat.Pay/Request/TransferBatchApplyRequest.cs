using System.Text.Json;
using System.Text.Json.Serialization;
using Dacheng.Wechat.Pay.Response;

namespace Dacheng.Wechat.Pay.Request;

/// <summary>
/// 发起商家转账批次请求
/// </summary>
public class TransferBatchApplyRequest : WechatPayRequestBase<TransferBatchApplyResponse>, ISerializable
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
    public override string Api => "/v3/transfer/batches";

    /// <summary>
    /// 商户appid
    /// 申请商户号的appid或商户号绑定的appid（企业号corpid即为此appid)
    /// </summary>
    [JsonPropertyName("appid")]
    public string AppId { get; set; } = "";

    /// <summary>
    /// 商家批次单号
    /// 商户系统内部的商家批次单号，要求此参数只能由数字、大小写字母组成，在商户系统内部唯一
    /// </summary>
    [JsonPropertyName("out_batch_no")]
    public string OutBatchNo { get; set; } = "";

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
    /// 转账总金额
    /// 转账金额单位为“分”。
    /// 转账总金额必须与批次内所有明细转账金额之和保持一致，否则无法发起转账操作
    /// </summary>
    [JsonPropertyName("total_amount")]
    public int TotalAmount { get; set; }

    /// <summary>
    /// 转账总笔数
    /// 一个转账批次单最多发起一千笔转账。
    /// 转账总笔数必须与批次内所有明细之和保持一致，否则无法发起转账操作
    /// </summary>
    [JsonPropertyName("total_num")]
    public int TotalNum { get; set; }

    /// <summary>
    /// 转账明细列表
    /// 发起批量转账的明细列表，最多一千笔
    /// </summary>
    [JsonPropertyName("transfer_detail_list")]
    public List<TransferDetailModel> TransferDetailList { get; set; } = new List<TransferDetailModel>();

    /// <summary>
    /// 转账明细
    /// </summary>
    public class TransferDetailModel
    {
        /// <summary>
        /// 商家明细单号
        /// 商户系统内部区分转账批次单下不同转账明细单的唯一标识，要求此参数只能由数字、大小写字母组成
        /// </summary>
        [JsonPropertyName("out_detail_no")]
        public string OutDetailNo { get; set; } = "";
        
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
        /// 收款用户openid
        /// 商户appid下，某用户的openid
        /// </summary>
        [JsonPropertyName("openid")]
        public string OpenId { get; set; } = "";
        
        /// <summary>
        /// 收款用户姓名
        /// 收款方真实姓名。支持标准RSA算法和国密算法，公钥由微信侧提供
        /// 明细转账金额&lt;0.3元时，不允许填写收款用户姓名
        /// 明细转账金额 &gt;= 2,000元时，该笔明细必须填写收款用户姓名
        /// 同一批次转账明细中的姓名字段传入规则需保持一致，也即全部填写、或全部不填写
        /// 若商户传入收款用户姓名，微信支付会校验用户openID与姓名是否一致，并提供电子回单
        /// </summary>
        [JsonPropertyName("user_name")]
        public string? UserName { get; set; }
    }

    /// <summary>
    /// 转账场景ID
    /// 该批次转账使用的转账场景，如不填写则使用商家的默认场景，如无默认场景可为空，可前往“商家转账到零钱-前往功能”中申请。
    /// 如：1001-现金营销
    /// </summary>
    [JsonPropertyName("transfer_scene_id")]
    public string? TransferSceneId { get; set; }

    public string Serialize()
    {
        return JsonSerializer.Serialize(this);
    }
}