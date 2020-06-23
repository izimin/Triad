using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriadNSim.Data.Enums;

namespace TriadNSim.Data
{
    public class Person : Thing
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDay { get; set; }
        public string ProfileUrl { get; set; }
        public string PhotoUrl { get; set; }
        public GenderEnum Gender { get; set; }
        public List<string> FriendsIds { get; set; }
        public List<string> CommunityIds { get; set; }
        public List<string> Interests { get; set; }
        public List<Event> Events { get; set; }

        public Person(SocialNetworkEnum sn, string id, string firstName, string lastName, string photoUrl, GenderEnum gender, List<string> friendsIds, List<string> communityIds, List<string> interests)
            : base(sn, ThingTypeEnum.Person, id)
        {
            FirstName = firstName;
            LastName = lastName;
            PhotoUrl = photoUrl;
            Gender = gender;
            FriendsIds = friendsIds;
            CommunityIds = communityIds;
            Interests = interests;
            Events = new List<Event>();
        }

        public Person(SocialNetworkEnum socialNetwork, string id)
            : base(socialNetwork, ThingTypeEnum.Person, id)
        {
            FriendsIds = new List<string>();
            CommunityIds = new List<string>();
            Interests = new List<string>();
            Events = new List<Event>();
        }

        public override string ToString()
        {
            return $"ID: {Id}\nИмя: {FirstName} \n" +
                   $"Фамилия: {LastName} \n" +
                   $"Интересы: {Interests} \n" +
                   $"Группы: {CommunityIds} \n" +
                   $"Друзья: {FriendsIds} \n" +
                   $"ДР: {BirthDay}";
        }
    }
}
