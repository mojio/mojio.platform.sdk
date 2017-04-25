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
using System.Linq;
using System.Threading.Tasks;
using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Contracts.Client;
using Mojio.Platform.SDK.Contracts.Entities;
using Xunit;

namespace Mojio.Platform.SDK.Tests
{
    public class BasicTests
    {
        readonly IClient _loginSimpleClient = Mother.GetNewSimpleClient;

        private IPlatformResponse<IAuthorization> loginResults = null;
        public BasicTests()
        {
            loginResults = _loginSimpleClient.Login(Mother.Username, Mother.Password).Result;
        }

        [Fact]
        [Trait("Category", "Functional")]
        [Trait("Category", "UnitTest")]
        public async Task BasicLoginTest()
        {
            Assert.NotNull(loginResults?.Response?.MojioApiToken);
        }

        [Fact]
        [Trait("Category", "Functional")]
        [Trait("Category", "UnitTest")]
        public async Task GetVehicles()
        {
            var vehicles = await _loginSimpleClient.Vehicles();
            Assert.NotNull(vehicles?.Response?.Data);

        }

        [Fact]
        [Trait("Category", "Functional")]
        [Trait("Category", "UnitTest")]
        public async Task GetMojios()
        {
            var vehicles = await _loginSimpleClient.Mojios();
            Assert.NotNull(vehicles?.Response?.Data);

        }
        [Fact]
        [Trait("Category", "Functional")]
        [Trait("Category", "UnitTest")]
        public async Task GetMe()
        {
            var vehicles = await _loginSimpleClient.Me();
            Assert.NotNull(vehicles?.Response?.Id);
            Assert.True(vehicles?.Response?.Id != Guid.NewGuid());         

        }
    }
}