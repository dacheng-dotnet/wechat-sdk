namespace Dacheng.Wechat.Pay;

/// <summary>
/// 微信支付客户端
/// </summary>
public class WechatPayClient : HttpClient
{
    public WechatPayOption? WechatPayOption { get; set; }

    public WechatPayClient() : base()
    {
    }

    public WechatPayClient(HttpMessageHandler handler) : base(handler)
    {
    }

    public WechatPayClient(HttpMessageHandler handler, bool disposeHandler) : base(handler, disposeHandler)
    {
    }

    public WechatPayClient(WechatPayOption option) : base()
    {
        WechatPayOption = option;
    }

    public WechatPayClient(WechatPayOption option, HttpMessageHandler handler) : base(handler)
    {
        WechatPayOption = option;
    }

    public WechatPayClient(WechatPayOption option, HttpMessageHandler handler, bool disposeHandler) : base(handler,
        disposeHandler)
    {
        WechatPayOption = option;
    }
}