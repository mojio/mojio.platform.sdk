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

using Mojio.Platform.SDK.Contracts;

namespace Mojio.Platform.SDK.Entities.Environments
{
    public partial class Environment : IEnvironment
    {
        public Contracts.Environments SelectedEnvironment { get; set; }
        public string AccountsUri { get; set; }
        public string APIUri { get; set; }
        public string ImagesUri { get; set; }
        public string PushUri { get; set; }
    }
}