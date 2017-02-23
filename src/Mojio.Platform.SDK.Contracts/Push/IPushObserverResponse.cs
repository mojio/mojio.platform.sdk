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

namespace Mojio.Platform.SDK.Contracts.Push
{
    public interface IPushObserverResponse : IPushObserver
    {
        DateTimeOffset CreatedOn { get; set; }
        DateTimeOffset LastModified { get; set; }
        DateTimeOffset ExpiryDate { get; set; }
        string Name { get; set; }
        string Type { get; set; }
        string Subject { get; set; }

        IDictionary<string, string> Links { get; set; } 
    }
}
