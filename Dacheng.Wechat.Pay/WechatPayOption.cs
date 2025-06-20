namespace Dacheng.Wechat.Pay;

/// <summary>
/// 微信支付参数
/// </summary>
public class WechatPayOption
{
    /// <summary>
    /// 微信支付网关接口地址
    /// </summary>
    public string Endpoint { get; set; } = "";

    /// <summary>
    /// 微信商户号
    /// </summary>
    public string MchId { get; set; } = "";

    /// <summary>
    /// 应用Id
    /// </summary>
    public string AppId { get; set; } = "";

    /// <summary>
    /// 应用私钥
    /// </summary>
    public string? AppPrivateKey { get; set; }
    
    /// <summary>
    /// 应用证书
    /// </summary>
    public string? AppCert { get; set; }
    
    /// <summary>
    /// 应用证书序列号
    /// </summary>
    public string? AppCertSn { get; set; }
}