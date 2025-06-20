using System.Text.Json.Serialization;

namespace Dacheng.Wechat.Pay;

/// <summary>
/// 微信支付响应
/// </summary>
public abstract class WechatPayResponseBase
{
    /// <summary>
    /// 详细错误码
    /// </summary>
    [JsonPropertyName("code")]
    public string? Code { get; set; }
    
    /// <summary>
    /// 错误描述，使用易理解的文字表示错误的原因
    /// </summary>
    [JsonPropertyName("message")]
    public string? Message { get; set; }
}