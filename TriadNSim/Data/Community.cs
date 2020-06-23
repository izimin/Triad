using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriadNSim.Data.Enums;

namespace TriadNSim.Data
{
    public class Community : Thing
    {
        public string Name { get; set; }

        public string Activity { get; set; }

        public List<Event> Events { get; set; }

        public int CountSubscribers { get; set; }

        public string CommunityUrl
        {
            get
            {
                string id = long.TryParse(Id, out var res) ? $"club{Id}" : $"{Id}";
                return SocialNetwork == SocialNetworkEnum.Vk ? $"https://vk.com/{id}" : "not found";
            }
        }

        public Community(SocialNetworkEnum sn, string id, string name, string activity)
            : base(sn, ThingTypeEnum.Community, id)
        {
            this.Name = name;
            this.Activity = activity;
        }

        public Community(SocialNetworkEnum socialNetwork, string id)
            : base(socialNetwork, ThingTypeEnum.Community, id)
        {
            Events = new List<Event>();
        }

        public override string ToString()
        {
            return $"ID: {Id} \n" +
                   $"Name: {Name} \n" +
                   $"Activity: {Activity}";
        }
    }
}
