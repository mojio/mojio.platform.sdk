using System;
using System.Collections.Generic;

namespace Mojio.Platform.SDK.Contracts.Entities
{
    public interface IUser
    {
        string UserName { get; set; }
        List<IEmail> Emails { get; set; }
        List<ITelephoneNumber> PhoneNumbers { get; set; }
        IImage Image { get; set; }
        List<string> Tags { get; set; }
        string Id { get; set; }
        DateTimeOffset CreatedOn { get; set; }
        DateTimeOffset LastModified { get; set; }
        IDictionary<string, string> Links { get; set; }
    }

    public interface ITelephoneNumber
    {
        string PhoneNumber { get; set; }
        bool Verified { get; set; }
    }

    public interface IImage
    {
        string Src { get; set; }
        string Normal { get; set; }
        string Thumbnail { get; set; }
    }

    public interface IEmail
    {
        bool Verified { get; set; }
        string Address { get; set; }
    }
}