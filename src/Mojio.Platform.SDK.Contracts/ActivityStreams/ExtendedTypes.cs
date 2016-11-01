namespace Mojio.Platform.SDK.Contracts.ActivityStreams
{
    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Accept
    /// Notes:	Indicates that the actor accepts the object. The target property can be used in certain circumstances to indicate the context into which the object has been accepted. For instance, when expressing the activity, "Sally accepted Joe into the Club", the "target" would identify the "Club".
    /// Properties:	Inherits all properties from Activity.
    /// Extends:	Activity
    /// </summary>
    public interface IAccept : IActivity
    {
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Add	
    /// Notes:	Indicates that the actor has added the object to the target.If the target property is not explicitly specified, the target would need to be determined implicitly by context. The origin can be used to identify the context from which the object originated.
    /// Extends:	Activity
    /// Properties:	Inherits all properties from Activity.
    /// </summary>
    public interface IAdd : IActivity
    {
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Announce	
    /// Notes:	
    /// Indicates that the actor is calling the target's attention the object.
    /// 
    /// The origin typically has no defined meaning.
    /// 
    /// Extends:	Activity
    /// Properties:	Inherits all properties from Activity.
    /// </summary>
    public interface IAnnounce : IActivity
    {
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Arrive	
    ///Notes:	An IntransitiveActivity that indicates that the actor has arrived at the location.The origin can be used to identify the context from which the actor originated.The target typically has no defined meaning.
    ///Extends:	IntransitiveActivity
    ///Properties:	Inherits all properties fom IntransitiveActivity.
    /// </summary>
    public interface IArrive : IIntransitiveActivity, IGeoSocialEventActivity
    {
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Block	
    /// Notes:	Indicates that the actor is blocking the object. Blocking is a stronger form of Ignore.The typical use is to support social systems that allow one user to block activities or content of other users.The target and origin typically have no defined meaning.
    /// Extends:	Ignore
    /// Properties:	Inherits all properties from Ignore.
    /// </summary>
    public interface IBlock : IIgnore
    {
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Create	
    /// Notes:	
    /// Indicates that the actor has created the object.
    ///     Extends:	Activity
    /// Properties:	Inherits all properties from Activity.
    /// </summary>
    public interface ICreate : IActivity
    {
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Delete	
    /// Notes:	Indicates that the actor has deleted the object. If specified, the origin indicates the context from which the object was deleted.
    /// Extends:	Activity
    /// Properties:	Inherits all properties from Activity.
    /// </summary>
    public interface IDelete : IActivity
    {
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Dislike	
    /// Notes:	Indicates that the actor dislikes the object.
    /// Extends:	Activity
    /// Properties:	Inherits all properties from Activity.
    /// </summary>
    public interface IDislike : IActivity
    {
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Flag	   
    /// Notes:	Indicates that the actor is "flagging" the object. Flagging is defined in the sense common to many social platforms as reporting content as being inappropriate for any number of reasons.
    /// Extends:	Activity
    /// Properties:	Inherits all properties from Activity.
    /// </summary>
    public interface IFlag : IActivity
    {
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Follow	
    /// Notes:	Indicates that the actor is "following" the object. Following is defined in the sense typically used within Social systems in which the actor is interested in any activity performed by or on the object. The target and origin typically have no defined meaning.
    /// Extends:	Activity
    /// Properties:	Inherits all properties from Activity.
    /// </summary>
    public interface IFollow : IActivity
    {
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Ignore	 
    /// Notes:	Indicates that the actor is ignoring the object. The target and origin typically have no defined meaning.
    /// Extends:	Activity
    /// Properties:	Inherits all properties from Activity.
    /// </summary>
    public interface IIgnore : IActivity
    {
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Invite	   
    /// Notes:	A specialization of Offer in which the actor is extending an invitation for the object to the target.
    /// Extends:	Offer
    /// Properties:	Inherits all properties from Offer.
    /// </summary>
    public interface IInvite : IOffer
    {
    }

    /// <summary>
    /// 	URI:	http://www.w3.org/ns/activitystreams#Join	  
    ///Notes:	Indicates that the actor has joined the object. The target and origin typically have no defined meaning.
    ///Extends:	Activity
    ///Properties:	Inherits all properties from Activity.
    /// </summary>
    public interface IJoin : IActivity
    {
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Leave	
    /// Notes:	Indicates that the actor has left the object. The target and origin typically have no meaning.
    /// Extends:	Activity
    /// Properties:	Inherits all properties from Activity.
    /// </summary>
    public interface ILeave : IIntransitiveActivity, IGeoSocialEventActivity
    {
    }

    public interface IGeoSocialEventActivity : IActivity
    {
        
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Like	
    /// Notes:	
    /// Indicates that the actor likes, recommends or endorses the object. The target and origin typically have no defined meaning.
    /// Extends:	Activity
    /// Properties:	Inherits all properties from Activity.
    /// </summary>
    public interface ILike : IActivity
    {
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Listen	
    /// Notes:	Indicates that the actor has listened to the object.
    /// Extends:	Activity
    /// Properties:	Inherits all properties from Activity.
    /// </summary>
    public interface IListen : IActivity
    {
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Move	   
    /// Notes:	Indicates that the actor has moved object from origin to target.If the origin or target are not specified, either can be determined by context.
    /// Extends:	Activity
    /// Properties:	Inherits all properties from Activity.
    /// </summary>
    public interface IMove : IActivity
    {
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Offer	
    /// Notes:	Indicates that the actor is offering the object. If specified, the target indicates the entity to which the object is being offered.
    /// Extends:	Activity
    /// Properties:	Inherits all properties from Activity.
    /// </summary>
    public interface IOffer : IActivity
    {
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Question	   
    /// Notes:	
    /// Represents a question being asked.Question objects are an extension of IntransitiveActivity.That is, the Question object is an Activity, but the direct object is the question itself and therefore it would not contain an object property.
    /// 
    /// Either of the anyOf and oneOf properties may be used to express possible answers, but a Question object must not have both properties.
    /// 
    /// Extends:	IntransitiveActivity.
    /// Properties:	
    /// oneOf | anyOf
    /// 
    /// Inherits all properties from IntransitiveActivity.
    /// </summary>
    public interface IQuestion : IIntransitiveActivity
    {
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Reject	
    /// Notes:	Indicates that the actor is rejecting the object. The target and origin typically have no defined meaning.
    /// Extends:	Activity
    /// Properties:	Inherits all properties from Activity.
    /// </summary>
    public interface IReject : IActivity
    {
    }


    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Read	 
    /// Notes:	Indicates that the actor has read the object.
    /// Extends:	Activity
    /// Properties:	Inherits all properties from Activity.
    /// </summary>
    public interface IRead : IActivity
    {
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Remove	    
    /// Notes:	Indicates that the actor is removing the object. If specified, the origin indicates the context from which the object is being removed.
    /// Extends:	Activity
    /// Properties:	Inherits all properties from Activity.
    /// </summary>
    public interface IRemove : IActivity
    {
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#TentativeReject	
    /// Notes:	A specialization of Reject in which the rejection is considered tentative.
    /// Extends:	Reject
    /// Properties:	Inherits all properties from Reject.
    /// </summary>
    public interface ITentativeReject : IReject
    {
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#TentativeAccept	
    ///Notes:	A specialization of Accept indicating that the acceptance is tentative.
    ///Extends:	Accept
    ///Properties:	Inherits all properties from Accept.
    /// </summary>
    public interface ITentativeAccept : IAccept
    {
    }


    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Travel	
    /// Notes:	Indicates that the actor is traveling to target from origin.Travel is an IntransitiveObject whose actor specifies the direct object. If the target or origin are not specified, either can be determined by context.
    /// Extends:	IntransitiveActivity
    /// Properties:	Inherits all properties from IntransitiveActivity.
    /// </summary>
    public interface ITravel : IIntransitiveActivity, IGeoSocialEventActivity
    {
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Undo	
    /// Notes:	Indicates that the actor is undoing the object. In most cases, the object will be an Activity describing some previously performed action(for instance, a person may have previously "liked" an article but, for whatever reason, might choose to undo that like at some later point in time).
    /// The target and origin typically have no defined meaning.
    /// Extends:	Activity
    /// Properties:	Inherits all properties from Activity.
    /// </summary>
    public interface IUndo : IActivity
    {
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Update	
    /// Notes:	
    /// Indicates that the actor has updated the object. Note, however, that this vocabulary does not define a mechanism for describing the actual set of modifications made to object.
    /// The target and origin typically have no defined meaning.
    /// Extends:	Activity
    /// Properties:	Inherits all properties from Activity.
    /// </summary>
    public interface IUpdate : IActivity
    {
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#View	
    /// Notes:	Indicates that the actor has viewed the object.
    /// Extends:	Activity
    /// Properties:	Inherits all properties from Activity.
    /// </summary>
    public interface IView : IActivity
    {
    }
}