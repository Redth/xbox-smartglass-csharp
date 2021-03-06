using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SmartGlass.Messaging.Session.Messages;
using SmartGlass.Common;
using SmartGlass.Messaging.Session;
using SmartGlass.Channels.Broadcast;
using SmartGlass.Channels.Broadcast.Messages;
using Newtonsoft.Json.Serialization;

namespace SmartGlass.Channels.Broadcast
{
    public class GamestreamException : SmartGlassException
    {
        public GamestreamException(string message, GamestreamError result)
            : base(message, (int)result)
        {
        }

        public GamestreamError Error => (GamestreamError)HResult;
    }
}