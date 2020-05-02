using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorChatSample.Client.Data
{
    public class ChatClient : IAsyncDisposable
    {
        public const string HUBURL = "/ChatHub";
        private readonly NavigationManager _navigationManager;
        private HubConnection _hubConnection;
        private readonly string _userName;
        private bool _started = false;
        public ChatClient(string usernName,NavigationManager navigationManager)
        {
            this._navigationManager = navigationManager;
            this._userName = usernName;
        }
        public async Task StartAsync()
        {
            if (!_started)
            {
                _hubConnection = new HubConnectionBuilder()
                    .WithUrl(_navigationManager.ToAbsoluteUri(HUBURL))
                    .Build();
                Console.WriteLine("ChatClient:calling Start()");
            }
            _hubConnection.On<string, string>(Messages.RECEIVE, (user, message) => 
            {
                HandleReceiveMessage(user, message);
            });
            await _hubConnection.StartAsync();
            Console.WriteLine("ChatClient:Start Returned");
            _started = true;
            await _hubConnection.SendAsync(Messages.REGISTER,_userName);
        }

        private void HandleReceiveMessage(string username, string message)
        {
            MessageReceived?.Invoke(this, new MessageReceivedEventArgs(username, message));
        }
        public event MessageReceivedEventHandler MessageReceived;
        public delegate void MessageReceivedEventHandler(object sender, MessageReceivedEventArgs e);

        public async Task SendAsync(string message)
        {
            if (!_started)
            {
                throw new InvalidOperationException("Client not started");
            }
            await _hubConnection.SendAsync(Messages.SEND, _userName, message);
        }

        public async Task StopAsync()
        {
            if (_started)
            {
                await _hubConnection.StopAsync();
                await _hubConnection.DisposeAsync();
                _hubConnection = null;
                _started = false;

            }
        }

        public async ValueTask DisposeAsync()
        {
            Console.WriteLine("ChatClient:Disposing");
            await StopAsync();
        }

    }
}
