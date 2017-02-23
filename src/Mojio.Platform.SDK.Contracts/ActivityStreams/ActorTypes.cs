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

namespace Mojio.Platform.SDK.Contracts.ActivityStreams
{
    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Application
    /// Notes:	Describes a software application.
    /// Extends:	Actor
    /// Properties:	Inherits all properties from Actor.
    /// </summary>
    public interface IApplication : IActor
    {
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Group
    /// Notes:	Represents a formal or informal collective of Actors.
    /// Extends:	Actor
    /// Properties:	Inherits all properties from Actor.
    /// </summary>
    public interface IGroup : IActor
    {
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Organization
    /// Notes:	Represents an organization.
    /// Extends:	Actor
    /// Properties:	Inherits all properties from Actor.
    /// </summary>
    public interface IOrganization : IActor
    {
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Person
    /// Notes:	Represents an individual person.
    /// Extends:	Actor
    /// Properties:	Inherits all properties from Actor.
    /// </summary>
    public interface IPerson : IActor
    {
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Service
    /// Notes:	Represents a service of any kind.
    /// Extends:	Actor
    /// Properties:	Inherits all properties from Actor.
    /// </summary>
    public interface IService : IActor
    {
    }
}