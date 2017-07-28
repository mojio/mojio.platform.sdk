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
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
        public Guid TenantId { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset LastModified { get; set; }
        public IDictionary<string, string> Links { get; set; }
    }
}