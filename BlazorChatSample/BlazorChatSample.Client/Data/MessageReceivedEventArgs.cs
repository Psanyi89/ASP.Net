using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorChatSample.Client.Data
{
    public class MessageReceivedEventArgs : EventArgs
    {
        public string Username { get; set; }
        public string Message { get; set; }
        public MessageReceivedEventArgs(string username,string message)
        {
            Username = username;
            Message = message;
        }
    }
}
