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