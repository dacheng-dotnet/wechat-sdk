using System.Net;
using Dacheng.Wechat.Pay;

namespace Dacheng.Wechat.Pay.Test;

public abstract class WechatPayTestBase
{
    protected WechatPayClient? _client { get; private set; }
    protected WechatPayOption? _option { get; private set; }

    [SetUp]
    public void Setup()
    {
        _option = new WechatPayOption()
        {
            MchId = "",
            AppId = "",
            AppPrivateKey = "",
            AppCertSn = "",
        };

        _client = new WechatPayClient(_option);
    }
}