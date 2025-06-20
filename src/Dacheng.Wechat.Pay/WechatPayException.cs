namespace Dacheng.Wechat.Pay;

/// <summary>
/// 微信支付异常
/// </summary>
public class WechatPayException : Exception
{
    public WechatPayResponseBase? WechatPayResponse { get; set; }

    public WechatPayException()
    {
    }

    public WechatPayException(string? message) : base(message)
    {
    }

    public WechatPayException(string? message, WechatPayResponseBase response) : base(message)
    {
        WechatPayResponse = response;
    }
}