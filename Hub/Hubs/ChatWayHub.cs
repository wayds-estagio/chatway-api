using Domain.Entities;
using Microsoft.AspNetCore.SignalR;
using Service.Services;
using System;
using System.Threading.Tasks;

namespace Hubs.Hubs {

    public class ChatWayHub : Microsoft.AspNetCore.SignalR.Hub {
        //public readonly MensagemService _mensagemService;
        //public readonly ChatService _chatService;
        //public readonly UsuarioHandler _usuarioHandler;

        //public ChatWayHub(MensagemService mensagemService, ChatService chatService, UsuarioHandler usuarioHandler) {
        //    this._mensagemService = mensagemService;
        //    this._chatService = chatService;
        //    this._usuarioHandler = usuarioHandler;
        //}

        //public Task EnviarMensagem(Mensagem mensagem) {
        //    bool notificarPendente = false;
        //    if (mensagem.Chat == null) {
        //        notificarPendente = true;
        //    }
        //    try {
        //        _mensagemService.Create(mensagem);
        //        var chat = _chatService.Get(mensagem.Chat);
        //        if (notificarPendente) {
        //            Clients.Group("atendente").SendAsync("NovoChatPendente", chat);
        //        }
        //        else {
        //            NotificarDestinatario(mensagem);
        //        }
        //        return Clients.Caller.SendAsync("MensagemEnviada", mensagem);
        //    }
        //    catch (Exception e) {
        //        return null;
        //    }
        //}

        //public Chat AtenderChatPendente() {
        //    var chat = _chatService.GetPendente();
        //    chat.Atendente = _usuarioHandler.GetUsuario(Context.ConnectionId);
        //    _chatService.Update(chat.Id, chat);
        //    Clients.Group("atendente").SendAsync("ChatAtendido", chat);
        //    return chat;
        //}

        //public Task NotificarDestinatario(Mensagem mensagem) {
        //    var chat = _chatService.Get(mensagem.Chat);
        //    if (mensagem.Remetente == chat.Atendente) {
        //        return Clients.Client(_usuarioHandler.GetId(chat.Motorista)).SendAsync("MensagemRecebida", mensagem);
        //    }
        //    else {
        //        return Clients.Client(_usuarioHandler.GetId(chat.Atendente)).SendAsync("MensagemRecebida", mensagem);
        //    }
        //}

        //public Task Autenticar(Usuario usuario, string funcao) {
        //    try {
        //        this._usuarioHandler.Registrar(Context.ConnectionId, usuario.Id);
        //        switch (funcao) {
        //            case "atendente":
        //                return Groups.AddToGroupAsync(Context.ConnectionId, "atendente");

        //            case "motorista":
        //                return Groups.AddToGroupAsync(Context.ConnectionId, "motorista");

        //            default:
        //                break;
        //        }
        //        return null;
        //    }
        //    catch (Exception e) {
        //        return null;
        //    }
        //}

        //public override async Task OnConnectedAsync() {
        //    Console.WriteLine(Context.ConnectionId);
        //    await Groups.AddToGroupAsync(Context.ConnectionId, "SignalR Users");
        //    await base.OnConnectedAsync();
        //}

        //public override async Task OnDisconnectedAsync(Exception exception) {
        //    await Groups.RemoveFromGroupAsync(Context.ConnectionId, "SignalR Users");
        //    try {
        //        this._usuarioHandler.Remover(Context.ConnectionId);
        //    }
        //    catch (Exception e) {
        //    }
        //    await base.OnDisconnectedAsync(exception);
        //}
        public readonly MensagemService _mensagemService;

        public readonly ChatService _chatService;

        public ChatWayHub(MensagemService mensagemService, ChatService chatService) {
            this._mensagemService = mensagemService;
            this._chatService = chatService;
        }

        public override async Task OnConnectedAsync() {
            await base.OnConnectedAsync();
            await Clients.Caller.SendAsync("Receive", "OnConnectedAsync");

            await Clients.Caller.SendAsync("ReceiveChatId", "ChatID_01");
        }

        public async Task Send(object message, string chatId) {
            //await Task.Delay(5000);
            await Clients.Caller.SendAsync("Receive", "Send");
            await SendGroup(chatId, "Pelo amor");
        }

        public async Task GetIdChat(Chat chat) {
            //await Task.Delay(5000);
            //await SendGroup("chat", "Pelo amor");
            await Clients.Caller.SendAsync("Receive", "GetIdChat");
        }

        //public async Task GetGroupId(object newchat) {
        //    var chat = new Chat {
        //        Motorista = "Marcos",
        //        Unidade = "Unidade1",
        //        Concluido = false,
        //        Atendente = "Atendente"
        //    };
        //    Console.WriteLine(newchat);

        //    var id = ObjectId.GenerateNewId();

        //    //_chatService.Create(chat);
        //    //var v = new { chatId };

        //    await Clients.Caller.SendAsync("ReceiveChatId", id);
        //}

        public async Task AddId(string id) {
            await Groups.AddToGroupAsync(Context.ConnectionId, id);
        }

        public async Task Send(Mensagem message, string chatId) {
            //_mensagemService.Create(message);
            //await Clients.OthersInGroup(chatId).SendAsync("Receive", message);
            await Clients.OthersInGroup("chat").SendAsync("Receive", message);

            //Chat chat = _chatService.Get(chatId);
            //if (chat.Atendente == null) {
            //    await Clients.OthersInGroup("Atendente").SendAsync("NewMessageChat", message);
            //} else {
            //    await Clients.OthersInGroup(chatId).SendAsync("Receive", message);
            //}

        public Task SendGroup(string group, object message) {
            return Clients.Group(group).SendAsync("Receive", message);
        }

        public Task SendId(string Id, object message) {
            return Clients.User(Id).SendAsync("Receive", message);
        }

        public override async Task OnDisconnectedAsync(Exception exception) {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, "SignalR Users");
            try {
                //this._usuarioHandler.Remover(Context.ConnectionId);
            }
            catch (Exception e) {
            }
            await base.OnDisconnectedAsync(exception);
        }
    }
}