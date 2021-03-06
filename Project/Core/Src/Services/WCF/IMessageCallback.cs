﻿namespace Aimirim.iView
{
    using System;
    using System.ServiceModel;

    interface IMessageCallback
    {
        [OperationContract(IsOneWay = true)]
        void OnMessageAdded(string[] message, DateTime timestamp);
    }
}
