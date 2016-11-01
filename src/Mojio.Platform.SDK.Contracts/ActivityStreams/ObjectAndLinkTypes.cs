namespace Mojio.Platform.SDK.Contracts.ActivityStreams
{

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Relationship	
    /// Notes:	
    /// Describes a relationship between two individuals.The subject and object properties are used to identify the connected individuals.
    /// 
    /// See 5.2 Representing Relationships Between Entities for additional information.
    /// Extends:	Object
    /// Properties:	
    /// subject | object | relationship
    /// Inherits all properties from Object.
    /// </summary>
    public interface IRelationship : IActivityObject
    {
        
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Article	
    /// Notes:	Represents any kind of multi-paragraph written work.
    /// Extends:	Object
    /// Properties:	Inherits all properties from Object.
    /// </summary>
    public interface IArticle : IActivityObject
    {
        
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Document	
    /// Notes:	Represents a document of any kind.
    /// Extends:	Object
    /// Properties:	Inherits all properties from Object.    /// </summary>
    public interface IDocument : IActivityObject
    {
        
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Audio	
    /// Notes:	Represents an audio document of any kind.
    /// Extends:	Document
    /// Properties:	Inherits all properties from Document.
    /// </summary>
    public interface IAudio : IDocument
    {
        
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Image	
    /// Notes:	An image document of any kind
    /// Extends:	Document
    /// Properties:	Inherits all properties from Document.
    /// </summary>
    public interface IImage : IDocument
    {
        
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Video	
    /// Notes:	Represents a video document of any kind.
    /// Extends:	Document
    /// Properties:	Inherits all properties from Document.
    /// </summary>
    public interface IVideo : IDocument
    {

    }


    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Note	
    /// Notes:	Represents a short written work typically less than a single paragraph in length.
    /// Extends:	Object
    /// Properties:	Inherits all properties from Object.
    /// </summary>
    public interface INote : IActivityObject
    {

    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Page	
    ///Notes:	Represents a Web Page.
    ///Extends:	Document
    ///Properties:	Inherits all properties from Document.
    /// </summary>
    public interface IPage : IDocument
    {

    }


    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Event	
    /// Notes:	Represents any kind of event.
    /// Extends:	Object
    /// Properties:	Inherits all properties from Object.
    /// </summary>
    public interface IEvent : IActivityObject
    {

    }



    /// <summary>
    /// 
    /// URI:	http://www.w3.org/ns/activitystreams#Place	
    /// Notes:	Represents a logical or physical location.See 5.3 Representing Places for additional information.
    /// Extends:	Object
    /// Properties:	
    /// accuracy | altitude | latitude | longitude | radius | units
    /// 
    /// Inherits all properties from Object.
    /// </summary>
    public interface IPlace : ILocation
    {

    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Mention	
    ///    EXAMPLE 281
    ///{
    ///  "@context": "http://www.w3.org/ns/activitystreams",
    ///  "type": "Mention",
    ///  "href": "http://example.org/joe",
    ///  "name": "Joe"
    ///}    
     /// Notes:	A specialized Link that represents an @mention.
     /// Extends:	Link
     /// Properties:	Inherits all properties from Link.    /// </summary>
public interface IMention : ILike
    {
        
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Profile	
    ///    JSON
    ///EXAMPLE 286
    ///{
    ///  "@context": "http://www.w3.org/ns/activitystreams",
    ///  "type": "Profile",
    ///  "name": "Sally's Profile",
    ///  "attributedTo": {
    ///    "type": "Person",
    ///    "name": "Sally Smith"
    ///  }
    ///}
    ///Notes:	A Profile is a content object that describes another Object, typically used to describe Actor, objects.The describes property is used to reference the object being described by the profile.
    ///Extends:	Object
    ///Properties:	
    ///describes
    ////Inherits all properties from Object.
    /// </summary>
public interface IProfile : IActivityObject
    {
        
    }
}
