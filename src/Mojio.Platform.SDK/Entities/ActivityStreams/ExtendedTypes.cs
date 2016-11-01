using Mojio.Platform.SDK.Contracts.ActivityStreams;

namespace Mojio.Platform.SDK.Entities.ActivityStreams
{

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Accept
    /// Notes:	Indicates that the actor accepts the object. The target property can be used in certain circumstances to indicate the context into which the object has been accepted. For instance, when expressing the activity, "Sally accepted Joe into the Club", the "target" would identify the "Club".
    /// Properties:	Inherits all properties from Activity.
    /// Extends:	Activity
    /// </summary>
    public class Accept : Activity, IAccept
    {
        public Accept()
        {
            Context = "http://www.w3.org/ns/activitystreams#Accept";
            Type = this.GetType().Name;
        }
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Add	
    /// Notes:	Indicates that the actor has added the object to the target.If the target property is not explicitly specified, the target would need to be determined implicitly by context. The origin can be used to identify the context from which the object originated.
    /// Extends:	Activity
    /// Properties:	Inherits all properties from Activity.
    /// </summary>
    public class Add : Activity, IAdd
    {
        public Add()
        {
            Context = "http://www.w3.org/ns/activitystreams#Add";
            Type = this.GetType().Name;
        }
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
    public class Announce : Activity, IAnnounce
    {
        public Announce()
        {
            Context = "http://www.w3.org/ns/activitystreams#Announce";
            Type = this.GetType().Name;
        }
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Arrive	
    ///Notes:	An IntransitiveActivity that indicates that the actor has arrived at the location.The origin can be used to identify the context from which the actor originated.The target typically has no defined meaning.
    ///Extends:	IntransitiveActivity
    ///Properties:	Inherits all properties fom IntransitiveActivity.
    /// </summary>
    public class Arrive : Activity, IArrive
    {
        public Arrive()
        {
            Context = "http://www.w3.org/ns/activitystreams#Arrive";
            Type = this.GetType().Name;
        }
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Block	
    /// Notes:	Indicates that the actor is blocking the object. Blocking is a stronger form of Ignore.The typical use is to support social systems that allow one user to block activities or content of other users.The target and origin typically have no defined meaning.
    /// Extends:	Ignore
    /// Properties:	Inherits all properties from Ignore.
    /// </summary>
    public class Block : Activity, IBlock
    {
        public Block()
        {
            Context = "http://www.w3.org/ns/activitystreams#Block";
            Type = this.GetType().Name;
        }
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Create	
    /// Notes:	
    /// Indicates that the actor has created the object.
    ///     Extends:	Activity
    /// Properties:	Inherits all properties from Activity.
    /// </summary>
    public class Create : Activity, ICreate
    {
        public Create()
        {
            Context = "http://www.w3.org/ns/activitystreams#Create";
            Type = this.GetType().Name;
        }
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Delete	
    /// Notes:	Indicates that the actor has deleted the object. If specified, the origin indicates the context from which the object was deleted.
    /// Extends:	Activity
    /// Properties:	Inherits all properties from Activity.
    /// </summary>
    public class Delete : Activity, IDelete
    {
        public Delete()
        {
            Context = "http://www.w3.org/ns/activitystreams#Delete";
            Type = this.GetType().Name;
        }
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Dislike	
    /// Notes:	Indicates that the actor dislikes the object.
    /// Extends:	Activity
    /// Properties:	Inherits all properties from Activity.
    /// </summary>
    public class Dislike : Activity, IDislike
    {
        public Dislike()
        {
            Context = "http://www.w3.org/ns/activitystreams#Dislike";
            Type = this.GetType().Name;
        }
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Flag	   
    /// Notes:	Indicates that the actor is "flagging" the object. Flagging is defined in the sense common to many social platforms as reporting content as being inappropriate for any number of reasons.
    /// Extends:	Activity
    /// Properties:	Inherits all properties from Activity.
    /// </summary>
    public class Flag : Activity, IFlag
    {
        public Flag()
        {
            Context = "http://www.w3.org/ns/activitystreams#Flag";
            Type = this.GetType().Name;
        }
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Follow	
    /// Notes:	Indicates that the actor is "following" the object. Following is defined in the sense typically used within Social systems in which the actor is interested in any activity performed by or on the object. The target and origin typically have no defined meaning.
    /// Extends:	Activity
    /// Properties:	Inherits all properties from Activity.
    /// </summary>
    public class Follow : Activity, IFollow
    {
        public Follow()
        {
            Context = "http://www.w3.org/ns/activitystreams#Follow";
            Type = this.GetType().Name;
        }
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Ignore	 
    /// Notes:	Indicates that the actor is ignoring the object. The target and origin typically have no defined meaning.
    /// Extends:	Activity
    /// Properties:	Inherits all properties from Activity.
    /// </summary>
    public class Ignore : Activity, IIgnore
    {
        public Ignore()
        {
            Context = "http://www.w3.org/ns/activitystreams#Ignore";
            Type = this.GetType().Name;
        }
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Invite	   
    /// Notes:	A specialization of Offer in which the actor is extending an invitation for the object to the target.
    /// Extends:	Offer
    /// Properties:	Inherits all properties from Offer.
    /// </summary>
    public class Invite : Activity, IInvite
    {
        public Invite()
        {
            Context = "http://www.w3.org/ns/activitystreams#Invite";
            Type = this.GetType().Name;
        }
    }

    /// <summary>
    /// 	URI:	http://www.w3.org/ns/activitystreams#Join	  
    ///Notes:	Indicates that the actor has joined the object. The target and origin typically have no defined meaning.
    ///Extends:	Activity
    ///Properties:	Inherits all properties from Activity.
    /// </summary>
    public class Join : Activity, IJoin
    {
        public Join()
        {
            Context = "http://www.w3.org/ns/activitystreams#Join";
            Type = this.GetType().Name;
        }
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Leave	
    /// Notes:	Indicates that the actor has left the object. The target and origin typically have no meaning.
    /// Extends:	Activity
    /// Properties:	Inherits all properties from Activity.
    /// </summary>
    public class Leave : Activity, ILeave
    {
        public Leave()
        {
            Context = "http://www.w3.org/ns/activitystreams#Leave";
            Type = this.GetType().Name;
        }
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Like	
    /// Notes:	
    /// Indicates that the actor likes, recommends or endorses the object. The target and origin typically have no defined meaning.
    /// Extends:	Activity
    /// Properties:	Inherits all properties from Activity.
    /// </summary>
    public class Like : Activity, ILike
    {
        public Like()
        {
            Context = "http://www.w3.org/ns/activitystreams#Like";
            Type = this.GetType().Name;
        }
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Listen	
    /// Notes:	Indicates that the actor has listened to the object.
    /// Extends:	Activity
    /// Properties:	Inherits all properties from Activity.
    /// </summary>
    public class Listen : Activity, IListen
    {
        public Listen()
        {
            Context = "http://www.w3.org/ns/activitystreams#Listen";
            Type = this.GetType().Name;
        }
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Move	   
    /// Notes:	Indicates that the actor has moved object from origin to target.If the origin or target are not specified, either can be determined by context.
    /// Extends:	Activity
    /// Properties:	Inherits all properties from Activity.
    /// </summary>
    public class Move : Activity, IMove
    {
        public Move()
        {
            Context = "http://www.w3.org/ns/activitystreams#Move";
            Type = this.GetType().Name;
        }
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Offer	
    /// Notes:	Indicates that the actor is offering the object. If specified, the target indicates the entity to which the object is being offered.
    /// Extends:	Activity
    /// Properties:	Inherits all properties from Activity.
    /// </summary>
    public class Offer : Activity, IOffer
    {
        public Offer()
        {
            Context = "http://www.w3.org/ns/activitystreams#Offer";
            Type = this.GetType().Name;
        }
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
    public class Question : Activity, IQuestion
    {
        public Question()
        {
            Context = "http://www.w3.org/ns/activitystreams#Question";
            Type = this.GetType().Name;
        }
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Reject	
    /// Notes:	Indicates that the actor is rejecting the object. The target and origin typically have no defined meaning.
    /// Extends:	Activity
    /// Properties:	Inherits all properties from Activity.
    /// </summary>
    public class Reject : Activity, IReject
    {
        public Reject()
        {
            Context = "http://www.w3.org/ns/activitystreams#Reject";
            Type = this.GetType().Name;
        }
    }


    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Read	 
    /// Notes:	Indicates that the actor has read the object.
    /// Extends:	Activity
    /// Properties:	Inherits all properties from Activity.
    /// </summary>
    public class Read : Activity, IRead
    {
        public Read()
        {
            Context = "http://www.w3.org/ns/activitystreams#Read";
            Type = this.GetType().Name;
        }
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Remove	    
    /// Notes:	Indicates that the actor is removing the object. If specified, the origin indicates the context from which the object is being removed.
    /// Extends:	Activity
    /// Properties:	Inherits all properties from Activity.
    /// </summary>
    public class Remove : Activity, IRemove
    {
        public Remove()
        {
            Context = "http://www.w3.org/ns/activitystreams#Remove";
            Type = this.GetType().Name;
        }
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#TentativeReject	
    /// Notes:	A specialization of Reject in which the rejection is considered tentative.
    /// Extends:	Reject
    /// Properties:	Inherits all properties from Reject.
    /// </summary>
    public class TentativeReject : Activity, ITentativeReject
    {
        public TentativeReject()
        {
            Context = "http://www.w3.org/ns/activitystreams#TentativeReject";
            Type = this.GetType().Name;
        }
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#TentativeAccept	
    ///Notes:	A specialization of Accept indicating that the acceptance is tentative.
    ///Extends:	Accept
    ///Properties:	Inherits all properties from Accept.
    /// </summary>
    public class TentativeAccept : Activity, ITentativeAccept
    {
        public TentativeAccept()
        {
            Context = "http://www.w3.org/ns/activitystreams#TentativeAccept";
            Type = this.GetType().Name;
        }
    }


    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Travel	
    /// Notes:	Indicates that the actor is traveling to target from origin.Travel is an IntransitiveObject whose actor specifies the direct object. If the target or origin are not specified, either can be determined by context.
    /// Extends:	IntransitiveActivity
    /// Properties:	Inherits all properties from IntransitiveActivity.
    /// </summary>
    public class Travel : Activity, ITravel
    {
        public Travel()
        {
            Context = "http://www.w3.org/ns/activitystreams#Travel";
            Type = this.GetType().Name;
        }
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Undo	
    /// Notes:	Indicates that the actor is undoing the object. In most cases, the object will be an Activity describing some previously performed action(for instance, a person may have previously "liked" an article but, for whatever reason, might choose to undo that like at some later point in time).
    /// The target and origin typically have no defined meaning.
    /// Extends:	Activity
    /// Properties:	Inherits all properties from Activity.
    /// </summary>
    public class Undo : Activity, IUndo
    {
        public Undo()
        {
            Context = "http://www.w3.org/ns/activitystreams#Undo";
            Type = this.GetType().Name;
        }
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Update	
    /// Notes:	
    /// Indicates that the actor has updated the object. Note, however, that this vocabulary does not define a mechanism for describing the actual set of modifications made to object.
    /// The target and origin typically have no defined meaning.
    /// Extends:	Activity
    /// Properties:	Inherits all properties from Activity.
    /// </summary>
    public class Update : Activity, IUpdate
    {
        public Update()
        {
            Context = "http://www.w3.org/ns/activitystreams#Update";
            Type = this.GetType().Name;
        }
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#View	
    /// Notes:	Indicates that the actor has viewed the object.
    /// Extends:	Activity
    /// Properties:	Inherits all properties from Activity.
    /// </summary>
    public class View : Activity, IView
    {
        public View()
        {
            Context = "http://www.w3.org/ns/activitystreams#View";
            Type = this.GetType().Name;
        }
    }
}