using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.Identity;
using ProjectFishing.Models;
using ProjectFishing.Infrastructure;
using System.Threading.Tasks;

namespace ProjectFishing.Hubs
{

    public class ChatHub : Hub
    {
        public static Context _db;
        static List<UserForChat> Users = new List<UserForChat>();
        static List<Chat> _chats = new List<Chat>();

        public Task JoinRoom(string roomName)
        {
            
            return Groups.Add(Context.ConnectionId, roomName);
        }
       
        // Отправка сообщений
        public void Send(string name, string message,string roomName)//проверяй тут в какую комнату высылать
        {
            _db = new Context();
            var _chat = _db.Chats.Where(x => x.RoomName == roomName).FirstOrDefault();

            Clients.Group(roomName).addMessage(name, message);
            var _message = new Message();
            _message.Date = DateTime.Now.ToString();
            _message.MessageText = message;
            _message.SenderName = name;
           // _message.Chat = _chat;
            _chat.Read = false;
            _chat.Messages.Add(_message);
            _db.SaveChanges();
        }

        // Подключение нового пользователя
        public void Connect(string MainUserId, string SecondaryUserId)
        {
            _db = new Context();
            var _dbUser = new ApplicationDbContext();
            var mainUser = _dbUser.Users.Find(MainUserId);
            var secondaryUser = _dbUser.Users.Find(SecondaryUserId);
           var  _chat = _db.Chats.Where(u => u.MainUser == MainUserId && u.SecondaryUser == SecondaryUserId).FirstOrDefault();
            
            if (_chat == null)
            {
                var _roomName = MainUserId + SecondaryUserId;
                
                _chat = new Chat()
                {
                    MainUser = MainUserId,
                   MainUserName = mainUser.UserName,
                   SecondaryUserName=secondaryUser.UserName,
                    SecondaryUser = SecondaryUserId,
                    Messages = new List<Message>(),
                    RoomName = _roomName
                };
                _db.Chats.Add(_chat);
               
                _db.SaveChanges();
            }
           if(_chats.Where(x=>x.ChatId==_chat.ChatId).FirstOrDefault()==null)
            {
                _chats.Add(_chat);
            }
           
            var NeedRoom = _chats.Where(x => x.RoomName == _chat.RoomName).FirstOrDefault();
          
            var Room = JoinRoom(NeedRoom.RoomName);
            // Посылаем сообщение всем пользователям, кроме текущего
        }

        // Отключение пользователя
        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            var item = Users.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
            if (item != null)
            {
                Users.Remove(item);
                var id = Context.ConnectionId;
                Clients.All.onUserDisconnected(id, item.Name);
            }

            return base.OnDisconnected(stopCalled);
        }
    }
}