using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Aimirim.iView
{

	public class MessageService : IMessage
	{
		private Timer _tmr;
		private static readonly List<IMessageCallback> subscribers = new List<IMessageCallback>();
		private List<ITag> _lastTagList = new List<ITag>();
		
		private MessageService()
		{
			_tmr = new Timer();
			_tmr.Interval = 1000;
			_tmr.Tick += delegate
			{
//				string message = string.Format("message #{0}", DateTime.Now.ToString());
//				Console.WriteLine(">>> Sending "+message);
				
				_lastTagList = TagManager.Instance.Tags.FindAll
					(
						delegate(ITag tag)
						{
							ITag lastTagListItem = _lastTagList.Find(delegate(ITag tt){return tt.Name == tag.Name;});
							return lastTagListItem == null || tag.Value != lastTagListItem.Value;
						}
					);
				
				string[] message = new string[_lastTagList.Count];
				for (int i=0; i < message.Length;i++)
				{
					message[i] = _lastTagList[i].Name + "|" + _lastTagList[i].Value;
					//Console.WriteLine(">>> Sending "+ message[i]);
				}
				AddMessage(message);
			};
			_tmr.Start();
			
		}
		
		public void AddMessage(string[] message)
		{
			subscribers.ForEach(delegate(IMessageCallback callback)
			                    {
			                    	if (((ICommunicationObject)callback).State == CommunicationState.Opened)
			                    	{
			                    		callback.OnMessageAdded(message, DateTime.Now);
			                    	}
			                    	else
			                    	{
			                    		subscribers.Remove(callback);
			                    	}
			                    });
		}
		public bool Subscribe()
		{
			try
			{
				IMessageCallback callback = OperationContext.Current.GetCallbackChannel<IMessageCallback>();
				if (!subscribers.Contains(callback))
					subscribers.Add(callback);
				return true;
			}
			catch
			{
				return false;
			}
		}
		public bool Unsubscribe()
		{
			try
			{
				IMessageCallback callback = OperationContext.Current.GetCallbackChannel<IMessageCallback>();
				if (!subscribers.Contains(callback))
					subscribers.Remove(callback);
				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}
