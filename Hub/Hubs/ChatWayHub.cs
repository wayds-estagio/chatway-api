using Domain.Entities;
using Microsoft.AspNetCore.SignalR;
using Service.Services;
using System;
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

        public override async Task OnDisconnectedAsync(Exception exception) {
            await base.OnDisconnectedAsync(exception);

            await SendDebug("OnDisconnectedAsync");
        }

        public async Task LinkChatToGroup(string chatId) {
            await Groups.AddToGroupAsync(Context.ConnectionId, chatId);

            await SendDebug("LinkChatToGroup: " + chatId);
        }

        public async Task CreateNewChat(Chat chat) {
            await Clients.Group("Atendente").SendAsync("ReceiveNewChatOpen", chat);

            await SendDebug("createNewChat");
        }

        public async Task Send(Mensagem message, string chatId) {
            _mensagemService.Create(message);
            //await Clients.OthersInGroup(chatId).SendAsync("Receive", message);

            Chat chat = _chatService.Get(chatId);
            if (chat.Atendente == null) {
                await Clients.Group("Atendente").SendAsync("ReceiveMessageOpen", message);
            }
            else {
                await Clients.OthersInGroup(chatId).SendAsync("ReceiveMessageAttendance", message);
                await Clients.OthersInGroup(chatId).SendAsync("Receive", message);
            }

            await SendDebug("Send");
        }

        public async Task sendChatAttendant(string chatId, Usuario atendente) {
            _chatService.UpdateAtendente(chatId, atendente);
            await SendDebug("sendChatAttendant");
            await Clients.OthersInGroup(chatId).SendAsync("ReceiveAttendant", atendente);
        }

        public Task SendDebug(string method) {
            return Clients.Caller.SendAsync("ReceiveDebug", method);
        }
    }
}
