using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriadNSim.Data.Enums;

namespace TriadNSim.Data
{
    public class Thing
    {
        public SocialNetworkEnum SocialNetwork  { get; set; }
        public ThingTypeEnum ThingType { get; set; }
        public string Id { get; set; }

        public Thing(SocialNetworkEnum socialNetwork, ThingTypeEnum thingType, string id)
        {
            SocialNetwork = socialNetwork;
            ThingType = thingType;
            Id = id;
        }
    }
}
