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

namespace Mojio.Platform.SDK.Contracts
{
    public enum Environments
    {
        //Canada production
        RogersProduction,

        // Canada staging
        RogersStaging,

        //traffic manager url
        Production,

        //traffic manager url
        Staging,

        //direct url
        Trial,

        //direct url
        NaProduction,

        //direct url
        EuProduction,

        //direct url
        NaStaging,

        //direct url
        EuStaging,

        //internal mojio testing
        Develop,

        Load

    }

    public interface IEnvironment
    {
        Environments SelectedEnvironment { get; set; }
        string AccountsUri { get; set; }
        string APIUri { get; set; }
        string ImagesUri { get; set; }
        string PushUri { get; set; }
        string GitHash { get; }
    }
}