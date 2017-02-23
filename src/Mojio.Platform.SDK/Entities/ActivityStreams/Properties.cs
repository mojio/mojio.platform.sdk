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

using System.Collections.Generic;
using Mojio.Platform.SDK.Contracts.ActivityStreams;

namespace Mojio.Platform.SDK.Entities.ActivityStreams
{


    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#attachment	
    /// Notes:	Identifies a resource attached or related to an object that potentially requires special handling.The intent is to provide a model that is at least semantically similar to attachments in email.
    /// Domain:	Object
    /// Range:	Object | Link
    /// </summary>
    public class Attachment : Link, IAttachment
    {
        public Attachment()
        {
            Type = this.GetType().Name;
        }
    }
    

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#attributedTo	
    /// Notes:	Identifies one or more entities to which this object is attributed.The attributed entities might not be Actors.For instance, an object might be attributed to the completion of another activity.
    /// Domain:	Link | Object
    /// Range:	Link | Object
    /// </summary>
    public class AttributedTo : Link, IAttributedTo
    {
        public AttributedTo()
        {
            Type = this.GetType().Name;
        }
    }
    

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#bcc	
    /// Notes:	Identifies one or more Actors that are part of the private secondary audience of this Object.
    /// Domain:	Object
    /// Range:	Actor | Link
    /// </summary>
    public class Bcc : Link, IBcc
    {
        public Bcc()
        {
            Type = this.GetType().Name;
        }
    }
    

    /// <summary>
    ///     URI:	http://www.w3.org/ns/activitystreams#bto	
    ///     Notes:	Identifies an Actor that is part of the private primary audience of this Object.
    ///     Domain:	Object
    ///     Range:	Actor | Link
    /// </summary>
    public class Bto : Link, IBto
    {
        public Bto()
        {
            Type = this.GetType().Name;
        }
    }
    

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#cc	
    /// Notes:	Identifies an Actor that is part of the public secondary audience of this Object.
    /// Domain:	Object
    /// Range:	Actor | Link
    /// </summary>
    public class Cc : Link, ICc
    {
        public Cc()
        {
            Type = this.GetType().Name;
        }
    }
    
    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#current	
    /// Notes:	In a paged Collection, indicates the page that contains the most recently updated member items.
    /// Domain:	CollectionPage
    /// Range:	CollectionPage | Link
    /// Functional:	True
    /// </summary>
    public class Current : Link, ICurrent
    {
        public Current()
        {
            Type = this.GetType().Name;
        }

    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#first	
    /// Notes:	In a paged Collection, indicates the furthest preceeding page of items in the collection.
    /// Domain:	CollectionPage
    /// Range:	CollectionPage | Link
    /// Functional:	True    /// </summary>
    public class First : Link, IFirst
    {
        public First()
        {
            Type = this.GetType().Name;
        }

    }
    
    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#generator	
    /// Notes:	Identifies the entity(e.g.an application) that generated the object.
    /// Domain:	Object
    /// Range:	Object | Link
    /// </summary>
    public class Generator : Link, IGenerator
    {
        public Generator()
        {
            Type = this.GetType().Name;
        }
    }
    
    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#icon	
    /// Notes:	Indicates an entity that describes an icon for this object. The image should have an aspect ratio of one (horizontal) to one (vertical) and should be suitable for presentation at a small size.
    /// Domain:	Object
    /// Range:	Image | Link
    /// </summary>
    public class Icon : Link, IIcon
    {
        public Icon()
        {
            Type = this.GetType().Name;
        }

    }
    
    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#image	
    ///    JSON
    ///EXAMPLE 376
    ///{
    ///  "@context": "http://www.w3.org/ns/activitystreams",
    ///  "type": "Note",
    ///  "content": "A Simple note",
    ///  "image": {
    ///    "type": "Image",
    ///    "name": "A Cat",
    ///    "url": "http://example.org/cat.png"
    ///  }
    ///}
    ///JSON
    ///EXAMPLE 381
    ///{
    ///  "@context": "http://www.w3.org/ns/activitystreams",
    ///  "type": "Note",
    ///  "content": "A Simple note",
    ///  "image": [
    ///    {
    ///      "type": "Image",
    ///      "name": "Cat 1",
    ///      "url": "http://example.org/cat1.png"
    ///    },
    ///    {
    ///      "type": "Image",
    ///      "name": "Cat 2",
    ///      "url": "http://example.org/cat2.png"
    ///    }
    ///  ]
    ///}
    ///Notes:	Indicates an entity that describes an image for this object. Unlike the icon property, there are no aspect ratio or display size limitations assumed.
    ///Domain:	Object
    ///Range:	Image | Link
    /// </summary>
    public class ImageImage : Image, IImageImage
    {
        public ImageImage()
        {
            Context = "http://www.w3.org/ns/activitystreams#image";
            Type = this.GetType().Name;

        }

    }
    
    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#inReplyTo	
    /// JSON
    /// EXAMPLE 386
    /// {
    /// "@context": "http://www.w3.org/ns/activitystreams",
    /// "type": "Note",
    /// "content": "A simple note",
    /// "inReplyTo": {
    /// "type": "Note",
    /// "content": "Another note"
    /// }
    /// }
    /// JSON
    /// EXAMPLE 391
    /// {
    /// "@context": "http://www.w3.org/ns/activitystreams",
    /// "type": "Note",
    /// "content": "A simple note",
    /// "inReplyTo": "http://example.org/posts/1"
    /// }
    /// Notes:	Indicates one or more entities for which this object is considered a response.
    /// Domain:	Object
    /// Range:	Object | Link
    /// </summary>
    public class InReplyTo : Link, IInReplyTo
    {
        public InReplyTo()
        {
            Type = this.GetType().Name;
        }

    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#instrument	
    /// JSON
    /// EXAMPLE 396
    /// {
    /// "@context": "http://www.w3.org/ns/activitystreams",
    /// "type": "Listen",
    /// "actor": {
    /// "type": "Person",
    /// "name": "Sally"
    /// },
    /// "object": "http://example.org/foo.mp3",
    /// "instrument": {
    /// "type": "Service",
    /// "name": "Acme Music Service"
    /// }
    /// }
    /// Notes:	Identifies one or more objects used(or to be used) in the completion of an Activity.
    /// Domain:	Activity
    /// Range:	Object | Link
    /// </summary>
    public class Instrument : Link, IInstrument
    {
        public Instrument()
        {
            Type = this.GetType().Name;
        }

    }
    
    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#last	
    /// Notes:	In a paged Collection, indicates the furthest proceeding page of the collection.
    /// Domain:	CollectionPage
    /// Range:	CollectionPage | Link
    /// Functional:	True    
    /// </summary>
    public class Last : Link, ILast
    {
        public Last()
        {
            Type = this.GetType().Name;
        }

    }
    

    /// <summary>
    ///    URI:	http://www.w3.org/ns/activitystreams#location	
    ///EXAMPLE 411
    ///{
    ///  "@context": "http://www.w3.org/ns/activitystreams",
    ///  "type": "Person",
    ///  "name": "Sally",
    ///  "location": {
    ///    "type": "Place",
    ///    "longitude": 12.34,
    ///    "latitude": 56.78,
    ///    "altitude": 90,
    ///    "units": "m"
    ///  }
    ///}
    ///Notes:	Indicates one or more physical or logical locations associated with the object.
    ///Domain:	Object
    ///Range:	Object | Link
    /// /// </summary>
    public class Location : Link, ILocation
    {
        public Location()
        {
            Type = this.GetType().Name;
        }

        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public double? Altitude { get; set; }
        public string Units { get; set; }
        public double? Radius { get; set; }
    }
    
    /// <summary>
    ///    URI:	http://www.w3.org/ns/activitystreams#items	
    ///EXAMPLE 416
    ///{
    ///  "@context": "http://www.w3.org/ns/activitystreams",
    ///  "type": "Collection",
    ///  "totalItems": 2,
    ///  "items": [
    ///    {
    ///      "type": "Note",
    ///      "name": "A Simple Note"
    ///    },
    ///    {
    ///      "type": "Note",
    ///      "name": "Another Simple Note"
    ///    }
    ///  ]
    ///}
    ///EXAMPLE 421
    ///{
    ///  "@context": "http://www.w3.org/ns/activitystreams",
    ///  "type": "OrderedCollection",
    ///  "totalItems": 2,
    ///  "orderedItems": [
    ///    {
    ///      "type": "Note",
    ///      "name": "A Simple Note"
    ///    },
    ///    {
    ///      "type": "Note",
    ///      "name": "Another Simple Note"
    ///    }
    ///  ]
    ///}
    ///Notes:	Identifies the items contained in a collection.The items might be ordered or unordered.
    ///Domain:	Collection
    ///Range:	Object | Link | Ordered List of[Object | Link]    
    /// </summary>
    public class Items : Link, IItems
    {
        public Items()
        {
            Type = this.GetType().Name;
        }

    }
    
    /// <summary>
    ///    URI:	http://www.w3.org/ns/activitystreams#items	
    ///EXAMPLE 416
    ///{
    ///  "@context": "http://www.w3.org/ns/activitystreams",
    ///  "type": "Collection",
    ///  "totalItems": 2,
    ///  "items": [
    ///    {
    ///      "type": "Note",
    ///      "name": "A Simple Note"
    ///    },
    ///    {
    ///      "type": "Note",
    ///      "name": "Another Simple Note"
    ///    }
    ///  ]
    ///}
    ///EXAMPLE 421
    ///{
    ///  "@context": "http://www.w3.org/ns/activitystreams",
    ///  "type": "OrderedCollection",
    ///  "totalItems": 2,
    ///  "orderedItems": [
    ///    {
    ///      "type": "Note",
    ///      "name": "A Simple Note"
    ///    },
    ///    {
    ///      "type": "Note",
    ///      "name": "Another Simple Note"
    ///    }
    ///  ]
    ///}
    ///Notes:	Identifies the items contained in a collection.The items might be ordered or unordered.
    ///Domain:	Collection
    ///Range:	Object | Link | Ordered List of[Object | Link]    
    /// </summary>
    public class ItemsOrderedList : OrderedCollection, IItemsOrderedList
    {
        public ItemsOrderedList()
        {
            Context = "http://www.w3.org/ns/activitystreams#items";
            Type = this.GetType().Name;

        }
    }

    /// <summary>
    /// URI:	http://www.w3.org/ns/activitystreams#oneOf	
    ///EXAMPLE 426
    ///{
    ///  "@context": "http://www.w3.org/ns/activitystreams",
    ///  "type": "Question",
    ///  "name": "What is the answer?",
    ///  "oneOf": [
    ///    {
    ///      "type": "Note",
    ///      "name": "Option A"
    ///    },
    ///    {
    ///      "type": "Note",
    ///      "name": "Option B"
    ///    }
    ///  ]
    ///}
    ///Notes:	Identifies an exclusive option for a Question.Use of oneOf implies that the Question can have only a single answer. To indicate that a Question can have multiple answers, use anyOf.
    ///Domain:	Question
    ///Range:	Object | Link
    /// </summary>
    public class OneOf : ActivityObject, IOneOf
    {
        public OneOf()
        {
            Context = "http://www.w3.org/ns/activitystreams#oneOf";
            Type = this.GetType().Name;

        }
        
    }
    

    /// <summary>
    ///    URI:	http://www.w3.org/ns/activitystreams#anyOf	
    ///EXAMPLE 431
    ///{
    ///  "@context": "http://www.w3.org/ns/activitystreams",
    ///  "type": "Question",
    ///  "name": "What is the answer?",
    ///  "anyOf": [
    ///    {
    ///      "type": "Note",
    ///      "name": "Option A"
    ///    },
    ///    {
    ///      "type": "Note",
    ///      "name": "Option B"
    ///    }
    ///  ]
    ///}
    ///Notes:	Identifies an inclusive option for a Question.Use of anyOf implies that the Question can have multiple answers. To indicate that a Question can have only one answer, use oneOf.
    ///Domain:	Question
    ///Range:	Object | Link
    /// </summary>
    public class AnyOf : ActivityObject, IAnyOf
    {
        public AnyOf()
        {
            Context = "http://www.w3.org/ns/activitystreams#anyOf";
            Type = this.GetType().Name;

        }

    }
    
    
    public class Origin : Link, IOrigin
    {
        public Origin()
        {
            Type = this.GetType().Name;
        }

    }

    public class NextCollectionPage : CollectionPage, INext
    {
        public NextCollectionPage()
        {
            Context = "http://www.w3.org/ns/activitystreams#nextCollection";
            Type = this.GetType().Name;

        }

    }

    public class Next : Link, INext
    {
        public Next()
        {
            Type = this.GetType().Name;
        }

    }
    
    public class Prev : Link, IPrev
    {
        public Prev()
        {
            Type = this.GetType().Name;
        }

    }

    public class Preview : Link, IPreview
    {
        public Preview()
        {
            Type = this.GetType().Name;
        }

    }
    
    public class Result : Link, IResult
    {
        public Result()
        {
            Type = this.GetType().Name;
        }

    }

    public class Replies : Collection, IReplies
    {
        public Replies()
        {
            Context = "http://www.w3.org/ns/activitystreams#replies";
            Type = this.GetType().Name;

        }

    }
    
    public class Scope : Link, IScope
    {
        public Scope()
        {
            Type = this.GetType().Name;
        }

    }

    public class TagObject : Link, ITag
    {
        public TagObject()
        {
            Context = "http://www.w3.org/ns/activitystreams#tag";
            Type = this.GetType().Name;

        }

        public string Tag { get; set; }
    }
    

    public class To : Link, ITo
    {
        public To()
        {
            Type = this.GetType().Name;
        }

    }


    public class Url : Link, IUrl
    {
        public Url()
        {
            Type = this.GetType().Name;
        }

    }


    public class PartOf : Link, IPartOf
    {
        public PartOf()
        {
            Type = this.GetType().Name;
        }

    }
    

    public class SubjectObject : Link, ISubject
    {
        public SubjectObject()
        {
            Type = "Subject";
        }

        public string Subject { get; set; }
    }
    
    public class Describes : ActivityObject, IDescribes
    {
        public Describes()
        {
            Context = "http://www.w3.org/ns/activitystreams#Describes";
            Type = this.GetType().Name;

        }

    }
    
    public class LanguageString : Dictionary<string, string>, ILanguageString
    {
    }
}

