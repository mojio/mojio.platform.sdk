using Mojio.Platform.SDK.Contracts.Entities;
using System;
using System.Collections.Generic;

namespace Mojio.Platform.SDK.Entities
{
    public class User : IUser
    {
        public string UserName { get; set; }
        public List<IEmail> Emails { get; set; }
        public List<ITelephoneNumber> PhoneNumbers { get; set; }
        public IImage Image { get; set; }
        public List<string> Tags { get; set; }
        public Guid Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset LastModified { get; set; }
        public IDictionary<string, string> Links { get; set; }
    }
}