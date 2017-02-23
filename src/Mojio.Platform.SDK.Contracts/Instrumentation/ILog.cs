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

namespace Mojio.Platform.SDK.Contracts.Instrumentation
{
    public interface ILog
    {
        void Debug(object obj);

        void Debug(string message, params object[] args);

        void Info(string message, params object[] args);

        void Error(Exception e, string message = null, params object[] args);

        void Fatal(Exception e, string message = null, params object[] args);

        void Event(string message, IDictionary<string, string> properties = null, IDictionary<string, double> metrics = null);
    }
}