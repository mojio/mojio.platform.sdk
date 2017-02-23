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

using Mojio.Platform.SDK.Contracts.ActivityStreams;

namespace Mojio.Platform.SDK.Entities.ActivityStreams
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
    public class Relationship : TargetObject, IRelationship
    {
        public Relationship()
        {
            Context = "http://www.w3.org/ns/activitystreams#Relationship";
            Type = this.GetType().Name;
        }
    }


    public class TargetObject : ActivityObject
    {
        public TargetObject()
        {
            Context = "http://www.w3.org/ns/activitystreams#target";
            Type = this.GetType().Name;

        }

        public string HRef { get; set; }
        public string Rel { get; set; }
        public string HRefLang { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
    }

    public class TargetLink : Link
    {
        public TargetLink()
        {
            Type = this.GetType().Name;
        }

    }


    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Article	
    /// Notes:	Represents any kind of multi-paragraph written work.
    /// Extends:	Object
    /// Properties:	Inherits all properties from Object.
    /// </summary>
    public class Article : ActivityObject, IArticle
    {
        public Article()
        {
            Context = "http://www.w3.org/ns/activitystreams#Article";
            Type = this.GetType().Name;
        }
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Document	
    /// Notes:	Represents a document of any kind.
    /// Extends:	Object
    /// Properties:	Inherits all properties from Object.    /// </summary>
    public class Document : ActivityObject, IDocument
    {
        public Document()
        {
            Context = "http://www.w3.org/ns/activitystreams#Document";
            Type = this.GetType().Name;
        }
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Audio	
    /// Notes:	Represents an audio document of any kind.
    /// Extends:	Document
    /// Properties:	Inherits all properties from Document.
    /// </summary>
    public class Audio : ActivityObject, IAudio
    {
        public Audio()
        {
            Context = "http://www.w3.org/ns/activitystreams#Audio";
            Type = this.GetType().Name;
        }
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Image	
    /// Notes:	An image document of any kind
    /// Extends:	Document
    /// Properties:	Inherits all properties from Document.
    /// </summary>
    public class Image : ActivityObject, IImage
    {
        public Image()
        {
            Context = "http://www.w3.org/ns/activitystreams#Image";
            Type = this.GetType().Name;
        }
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Video	
    /// Notes:	Represents a video document of any kind.
    /// Extends:	Document
    /// Properties:	Inherits all properties from Document.
    /// </summary>
    public class Video : ActivityObject, IVideo
    {
        public Video()
        {
            Context = "http://www.w3.org/ns/activitystreams#Video";
            Type = this.GetType().Name;
        }
    }


    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Note	
    /// Notes:	Represents a short written work typically less than a single paragraph in length.
    /// Extends:	Object
    /// Properties:	Inherits all properties from Object.
    /// </summary>
    public class Note : ActivityObject, INote
    {
        public Note()
        {
            Context = "http://www.w3.org/ns/activitystreams#Note";
            Type = this.GetType().Name;
        }
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Page	
    ///Notes:	Represents a Web Page.
    ///Extends:	Document
    ///Properties:	Inherits all properties from Document.
    /// </summary>
    public class Page : ActivityObject, IPage
    {
        public Page()
        {
            Context = "http://www.w3.org/ns/activitystreams#Page";
            Type = this.GetType().Name;
        }
    }


    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#Event	
    /// Notes:	Represents any kind of event.
    /// Extends:	Object
    /// Properties:	Inherits all properties from Object.
    /// </summary>
    public class Event : ActivityObject, IEvent
    {
        public Event()
        {
            Context = "http://www.w3.org/ns/activitystreams#Event";
            Type = this.GetType().Name;
        }
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
    public class Place : Location, IPlace
    {
        public Place()
        {
            Context = "http://www.w3.org/ns/activitystreams#Place";
            Type = this.GetType().Name;
        }

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
    public class Mention : Activity, IMention
    {
        public Mention()
        {
            Context = "http://www.w3.org/ns/activitystreams#Mention";
            Type = this.GetType().Name;
        }

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
    public class Profile : ActivityObject, IProfile
    {
        public Profile()
        {
            Context = "http://www.w3.org/ns/activitystreams#Profile";
            Type = this.GetType().Name;
        }

    }
}