namespace NoName.Framework.Core.Proxy
{
	public enum ProxyIntent
	{
		AddBeforeAction,

		AddAfterAction,

		// 需要确定优先级
		MapImplementFunctionsFromExistingObject,

		// 网络透明对象传输
		UseObjectFromNetwork
	}
}