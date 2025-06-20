namespace Dacheng.Wechat.Pay;

public abstract class WechatPayRequestBase<T> where T : WechatPayResponseBase
{
    /// <summary>
    /// 请求方式
    /// </summary>
    public virtual WechatPayMethod Method => WechatPayMethod.Get;

    /// <summary>
    /// 接口名称
    /// </summary>
    public virtual string Api => "";
}