using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mojio.Platform.SDK.Contracts.Entities;
using Action = Mojio.Platform.SDK.Contracts.Entities.Action;

namespace Mojio.Platform.SDK.Entities
{
    public class GroupResponse : IGroupResponse
    {
        public IList<IGroup> Data { get; set; }
        public int Results { get; set; }
        public IDictionary<string, string> Links { get; set; }
    }

    public class Group : IGroup
    {
        public Group()
        {
            Metadata = new Dictionary<string, IList<string>>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public IList<string> Tags { get; set; }
        public Guid Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset LastModified { get; set; }
        public IDictionary<string, IList<string>> Metadata { get; set; }

        private IList<Action> GetActionsFromList(IList<string> input)
        {
            var actions = new List<Action>();
            if (input == null) return actions;
            foreach (var i in input)
            {
                var a = Action.None;
                if (System.Enum.TryParse(i,true, out a))
                {
                    actions.Add(a);
                }
            }
            return actions;
        } 

        public IList<Action> UserPermissions => GetActionsFromList((from p in Metadata where p.Key == "UserPermissions" select p.Value).FirstOrDefault());

        public IList<Action> RequestPermissions => GetActionsFromList((from p in Metadata where p.Key == "RequestPermissions" select p.Value).FirstOrDefault());

        public IDictionary<string, string> Links { get; set; }
    }

}