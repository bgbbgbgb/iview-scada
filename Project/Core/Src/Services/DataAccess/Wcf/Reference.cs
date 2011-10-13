
namespace Aimirim.iView
{
	
	[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
	public interface IMessageChannel : IMessage, System.ServiceModel.IClientChannel {
	}
	
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
	public partial class MessageClient : System.ServiceModel.DuplexClientBase<IMessage>, IMessage {
		
		public MessageClient(System.ServiceModel.InstanceContext callbackInstance) :
			base(callbackInstance) {
		}
		
		public MessageClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) :
			base(callbackInstance, endpointConfigurationName) {
		}
		
		public MessageClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) :
			base(callbackInstance, endpointConfigurationName, remoteAddress) {
		}
		
		public MessageClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
			base(callbackInstance, endpointConfigurationName, remoteAddress) {
		}
		
		public MessageClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
			base(callbackInstance, binding, remoteAddress) {
		}
		
		public void AddMessage(string[] message) {
			base.Channel.AddMessage(message);
		}
		
		public bool Subscribe() {
			return base.Channel.Subscribe();
		}
		
		public bool Unsubscribe() {
			return base.Channel.Unsubscribe();
		}
	}
}
