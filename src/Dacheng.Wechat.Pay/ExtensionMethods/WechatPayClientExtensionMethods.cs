using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Masuit.Tools.Security;

namespace Dacheng.Wechat.Pay.ExtensionMethods;

public static class WechatPayClientExtensionMethods
{
    public static async Task<T> SendAsync<T>(this WechatPayClient client, WechatPayRequestBase<T> request)
        where T : WechatPayResponseBase
    {
        return await client.SendAsync(request, null);
    }

    public static async Task<T> SendAsync<T>(this WechatPayClient client, WechatPayRequestBase<T> request,
        WechatPayOption? option) where T : WechatPayResponseBase
    {
        option ??= client.WechatPayOption;

        if (option == null) throw new WechatPayException("WechatPay gateway config empty");

        // 组装请求方式和请求接口地址
        var uri = WechatPayConstants.PrimaryEndpoint + request.Api;
        var httpRequestMessage = request.Method switch
        {
            WechatPayMethod.Get => new HttpRequestMessage(HttpMethod.Get, uri),
            WechatPayMethod.Post => new HttpRequestMessage(HttpMethod.Post, uri),
            WechatPayMethod.Put => new HttpRequestMessage(HttpMethod.Put, uri),
            WechatPayMethod.Delete => new HttpRequestMessage(HttpMethod.Delete, uri),
            _ => throw new WechatPayException("WechatPay method not support")
        };

        // 设置请求内容及内容类型
        string body = "";
        if (request is ISerializable serializableRequest)
        {
            body = serializableRequest.Serialize();
            var content = new StringContent(body);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            httpRequestMessage.Content = content;
        }

        // 设置请求头 accept
        httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        // 设置请求头 user-agent
        var ua = new ProductInfoHeaderValue("dotnet", Environment.Version.Major.ToString());
        httpRequestMessage.Headers.UserAgent.Add(ua);

        // 计算签名
        var signStringBuilder = new StringBuilder();
        var methodName = Enum.GetName(typeof(WechatPayMethod), request.Method)!.ToUpper();
        signStringBuilder.Append(methodName).Append('\n'); // step 1
        signStringBuilder.Append(request.Api).Append('\n'); // step 2
        var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        signStringBuilder.Append(timestamp).Append('\n'); // step 3
        var nonce = Guid.NewGuid().ToString("N");
        signStringBuilder.Append(nonce).Append('\n'); // step 4
        signStringBuilder.Append(body).Append('\n'); // step 5
        var plainText = signStringBuilder.ToString();
        var sign = plainText.SignatureString(option.AppPrivateKey, HashAlgo.SHA256);
        // 构造微信 Authorization 头信息
        var authStringBuilder = new StringBuilder();
        authStringBuilder.Append("mchid=").Append('"').Append(option.MchId).Append('"').Append(',');
        authStringBuilder.Append("nonce_str=").Append('"').Append(nonce).Append('"').Append(',');
        authStringBuilder.Append("signature=").Append('"').Append(sign).Append('"').Append(',');
        authStringBuilder.Append("timestamp=").Append('"').Append(timestamp).Append('"').Append(',');
        authStringBuilder.Append("serial_no=").Append('"').Append(option.AppCertSn).Append('"');
        var authValue = authStringBuilder.ToString();
        var authHeader = new AuthenticationHeaderValue(WechatPayConstants.WechatAuthScheme, authValue);
        // 设置微信 Authorization 请求头
        httpRequestMessage.Headers.Authorization = authHeader;

        // 发送 http 请求
        var httpResponseMessage = await client.SendAsync(httpRequestMessage);

        // 读取 http 响应体内容
        var result = await httpResponseMessage.Content.ReadAsStringAsync();

        // 微信支付网关返回结果为空
        if (string.IsNullOrEmpty(result))
        {
            throw new WechatPayException($"WechatPay empty response: {httpResponseMessage.ReasonPhrase}");
        }

        // 反序列化为微信响应对象
        var response = JsonSerializer.Deserialize<T>(result);

        if (response == null)
        {
            throw new WechatPayException("WechatPay error: fail to deserialize response");
        }

        if (!httpResponseMessage.IsSuccessStatusCode)
        {
            var errMsg = $"WechatPay error: [{response.Code} - {response.Message}]";
            throw new WechatPayException(errMsg, response);
        }

        return response;
    }
}