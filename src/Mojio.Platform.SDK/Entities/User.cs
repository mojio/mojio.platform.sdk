using Mojio.Platform.SDK.Contracts.Entities;
using System;
using System.Collections.Generic;

namespace Mojio.Platform.SDK.Entities
{
    public class UsersResponse : IUsersResponse
    {
        public int Results { get; set; }
        public IDictionary<string, string> Links { get; set; }
        public IList<IUser> Data { get; set; }
    }
    public class User : IUser
    {
        public string UserName { get; set; }
        public IList<IEmail> Emails { get; set; }
        public IList<ITelephoneNumber> PhoneNumbers { get; set; }
        public IImage Image { get; set; }
        public IList<string> Tags { get; set; }
        public string Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset LastModified { get; set; }
        public IDictionary<string, string> Links { get; set; }
    }
}