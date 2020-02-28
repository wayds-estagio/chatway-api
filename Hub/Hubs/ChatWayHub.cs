using Domain.Entities;
using Microsoft.AspNetCore.SignalR;
using Service.Services;
using System.Threading.Tasks;

namespace Hubs.Hubs {

    public class ChatWayHub : Microsoft.AspNetCore.SignalR.Hub {
        public readonly MensagemService _mensagemService;
        public readonly ChatService _chatService;

        public ChatWayHub(MensagemService mensagemService, ChatService chatService) {
            _mensagemService = mensagemService;
            _chatService = chatService;
        }

        public override async Task OnConnectedAsync() {
            await base.OnConnectedAsync();

            await SendDebug("OnConnectedAsync");
        }

        public async Task LinkChatToGroup(string chatId) {
            await Groups.AddToGroupAsync(Context.ConnectionId, chatId);

            await SendDebug("LinkChatToGroup");
        }

        public async Task Send(Mensagem message, string chatId) {
            //await Clients.OthersInGroup(chatId).SendAsync("Receive", message);
            message.Content = "> " + message.Content;
            await Clients.Group(chatId).SendAsync("Receive", message);

            await SendDebug("Send");
        }

        public Task SendDebug(string method) {
            return Clients.Caller.SendAsync("ReceiveDebug", method);
        }
    }
}
