#region copyright
/******************************************************************************
* Moj.io Inc. CONFIDENTIAL
* 2017 Copyright Moj.io Inc.
* All Rights Reserved.
* 
* NOTICE:  All information contained herein is, and remains, the property of 
* Moj.io Inc. and its suppliers, if any.  The intellectual and technical 
* concepts contained herein are proprietary to Moj.io Inc. and its suppliers
* and may be covered by Patents, pending patents, and are protected by trade
* secret or copyright law.
*
* Dissemination of this information or reproduction of this material is strictly
* forbidden unless prior written permission is obtained from Moj.io Inc.
*******************************************************************************/
#endregion

using System;
using System.Collections.Generic;

namespace Mojio.Platform.SDK.Contracts.Entities
{
    public interface IUsersResponse
    {
        IList<IUser> Data { get; set; }
        int Results { get; set; }
        IDictionary<string, string> Links { get; set; }
    }

    public interface IUser
    {
        string UserName { get; set; }
        IList<IEmail> Emails { get; set; }
        IList<ITelephoneNumber> PhoneNumbers { get; set; }
        IImage Image { get; set; }
        IList<string> Tags { get; set; }
        Guid Id { get; set; }
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