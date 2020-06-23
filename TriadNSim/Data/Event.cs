    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using java.security;
using TriadNSim.Data.Enums;

namespace TriadNSim.Data
{
    public class Event
    {
        public EventTypeEnum EventType { get; set; }
        public string IdPost { get; set; }
        public string IdOwner { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateEvent { get; set; }
        public bool IsAds { get; set; }

        public string getUrl()
        {
            return $"https://vk.com/club{IdOwner}?w=wall{IdPost}";
        }

        public override string ToString()
        {
            return EventType == EventTypeEnum.Online ? "Появился в сети" 
                : EventType == EventTypeEnum.Offline ? "Вышел из сети" 
                : EventType == EventTypeEnum.PostSeen ? "Просмотрел пост" 
                : EventType == EventTypeEnum.PostLiked ? "Поставил лайк" 
                : EventType == EventTypeEnum.PostAdd ? "Добавил пост" 
                : "Сделал репост";
        }
    }
}
