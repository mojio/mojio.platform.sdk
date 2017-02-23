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

namespace Mojio.Platform.SDK.Contracts.Entities
{
    public interface IAuthorization
    {
        bool IsLoggedIn { get; set; }
        string MojioApiToken { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
        string AccessToken { get; set; }
        string TokenType { get; set; }
        DateTimeOffset Expires { get; }
        string RefreshToken { get; set; }
        int ExpiresIn { get; set; }
        string Scope { get; set; }
        bool HasExpired { get; }
        bool Refreshed { get; set; }
        bool Success { get; set; }
        string Signature { get; }
    }
}