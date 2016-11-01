using System;
using System.Collections.Generic;
using Mojio.Platform.SDK.Contracts.ActivityStreams;

namespace Mojio.Platform.SDK.Entities.ActivityStreams
{

    /// <summary>
    /// URI:	        http://www.w3.org/ns/activitystreams#Object
    /// Notes:	        Describes an object of any kind. The Object class serves as the base class 
    ///                 for most of the other kinds of objects defined in the Activity Vocabulary, 
    ///                 including other Core classes such as Activity, IntransitiveActivity, Actor, 
    ///                 Collection and OrderedCollection.
    /// Disjoint With:	Link
    /// Properties:	    attachment | attributedTo | content | context | name | 
    ///                 endTime | generator | icon | image | inReplyTo | location | 
    ///                 preview | published | replies | scope | startTime | 
    ///                 summary | tag | updated | url | to | bto | cc | bcc | 
    ///                 mediaType | duration
    /// </summary>
    public class ActivityObject : IActivityObject
    {
        public ActivityObject()
        {
            Type = "Object";
        }

        public string Id { get; set; }
        public IAttachment Attachment { get; set; }
        public string Context { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public ILanguageString NameMap { get; set; }
        public DateTimeOffset? EndTime { get; set; }
        public IGenerator Generator { get; set; }
        public IIcon Icon { get; set; }
        public IImage Image { get; set; }
        public IInReplyTo InReplyTo { get; set; }
        public ILocation Location { get; set; }
        public IPreview Preview { get; set; }
        public DateTimeOffset? Published { get; set; }
        public IReplies Replies { get; set; }
        public IScope Scope { get; set; }
        public DateTimeOffset? StartTime { get; set; }
        public ILanguageString SummaryMap { get; set; }
        public ITag Tag { get; set; }
        public DateTimeOffset? Updated { get; set; }
        public ILink Url { get; set; }
        public ITo To { get; set; }
        public IBto  Bto { get; set; }
        public ICc  CC { get; set; }
        public IBcc  BCC { get; set; }
        public string MediaType { get; set; }
        public string Data { get; set; }
        public TimeSpan? Duration { get; set; }
        public IEnumerable<string> Groups { get; set; }
    }

    /// <summary>
    /// URI:	        http://www.w3.org/ns/activitystreams#Link
    /// Notes:	        A Link is an indirect, qualified reference to a resource identified by a URL. 
    ///                 The fundamental model for links is established by [RFC5988]. 
    ///                 Many of the properties defined by the Activity Vocabulary allow values 
    ///                 that are either instances of Object or Link. When a Link is used, 
    ///                 it establishes a qualified relation connecting the subject (the containing object) 
    ///                 to the resource identified by the href.
    /// Disjoint With:	Object
    /// Properties:	    href | rel | mediaType | name | hreflang | height | width
    /// </summary>
    public class Link  : ActivityObject, ILink
    {
        public Link()
        {
            Type = "Link";
        }
        public string HRef { get; set; }
        public string Rel { get; set; }
        public string MediaType { get; set; }
        public string Name { get; set; }
        public string HRefLang { get; set; }
        public int? Height { get; set; }
        public int? Width { get; set; }
        public string Type { get; set; }
    }

    /// <summary>
    /// URI:	        http://www.w3.org/ns/activitystreams#Activity
    /// Notes:	        An Activity is a subclass of Object that describes some form of action that may happen, is currently happening, or has already happened. The Activity class itself serves as an abstract base class for all types of activities. It is important to note that the Activity class itself does not carry any specific semantics about the kind of action being taken.
    /// Extends:	    Object
    /// Properties:     actor | object | target | result | origin | instrument
    ///                 Inherits all properties from Object.
    /// </summary>
    public class Activity : ActivityObject, IActivity
    {
        public Activity()
        {
            Context = "http://www.w3.org/ns/activitystreams#Activity";
            Type = "Activity";

        }

        public IActor Actor { get; set; }
        public ILink Target { get; set; }
        public ILink Result { get; set; }
        public ILink Origin { get; set; }
        public ILink Instrument { get; set; }
        public ILink Object { get; set; }
    }

    /// <summary>
    /// URI:	            http://www.w3.org/ns/activitystreams#IntransitiveActivity
    /// Notes:	            Instances of IntransitiveActivity are a subclass of 
    ///                     Activity whose actor property identifies the direct 
    ///                     object of the action as opposed to using the object property.
    /// Extends:	        Activity
    /// Properties:	        Inherits all properties from Activity except object.
    /// </summary>
    public class IntransitiveActivity : Activity, IIntransitiveActivity
    {
        public IntransitiveActivity()
        {
            Context = "http://www.w3.org/ns/activitystreams#IntransitiveActivity";
            Type = "IntransitiveActivity";

        }

    }

    /// <summary>
    /// URI:	            http://www.w3.org/ns/activitystreams#Actor
    /// Notes:	            An Actor is any entity that is capable of being the primary 
    ///                     actor for an Activity.
    /// Extends:	        Object
    /// Properties:	        Inherits all properties from Object.
    /// </summary>
    public class Actor : Link, IActor
    {
        public Actor()
        {
            Context = "http://www.w3.org/ns/activitystreams#Actor";
            Type = "Actor";

        }

    }

    /// <summary>
    /// URI:	            http://www.w3.org/ns/activitystreams#Collection
    /// Notes:	            A Collection is a subclass of Object that represents ordered or unordered 
    ///                     sets of Object or Link instances.  
    /// 
    ///                     Refer to the Activity Streams 2.0 Core specification for a complete 
    ///                     description of the Collection type.
    /// 
    /// Extends:	        Object
    /// Properties:	        totalItems | current | first | last | items
    ///                     Inherits all properties from Object.
    /// </summary>
    public class Collection : Link, ICollection
    {
        public Collection()
        {
            Context = "http://www.w3.org/ns/activitystreams#Collection";
            Type = "Collection";

        }


        public int TotalItems { get; set; }
        public ICurrent Current { get; set; }
        public ILast Last { get; set; }
        public IFirst First { get; set; }
        public IItems Items { get; set; }
    }

    /// <summary>
    /// URI:	            http://www.w3.org/ns/activitystreams#OrderedCollection
    /// Notes:	            A subclass of Collection in which members of the logical 
    ///                     collection are assumed to always be strictly ordered.
    /// Extends:	        Collection
    /// Properties:	        Inherits all properties from Collection.
    /// </summary>
    public class OrderedCollection : Collection, IOrderedCollection
    {
        public OrderedCollection()
        {
            Context = "http://www.w3.org/ns/activitystreams#OrderedCollection";
            Type = "OrderedCollection";

        }

    }

    /// <summary>
    ///	URI:	            http://www.w3.org/ns/activitystreams#CollectionPage
    /// Notes:	            Used to represent distinct subsets of items from a Collection.
    ///                     Refer to the Activity Streams 2.0 Core for a complete description 
    ///                     of the CollectionPage object.
    /// Extends:	        Collection
    /// Properties:	        partOf | next | prev   Inherits all properties from Collection.
    /// </summary>
    public class CollectionPage : Collection, ICollectionPage
    {
        public CollectionPage()
        {
            Context = "http://www.w3.org/ns/activitystreams#CollectionPage";
            Type = "CollectionPage";

        }

    }

    /// <summary>
    /// URI:	            http://www.w3.org/ns/activitystreams#OrderedCollectionPage
    /// Notes:	            Used to represent ordered subsets of items from an OrderedCollection.
    ///                     Refer to the Activity Streams 2.0 Core for a complete description of the OrderedCollectionPage object.
    /// Extends:	        OrderedCollection | CollectionPage
    /// Properties:	        startIndex Inherits all properties from OrderedCollection and CollectionPage.
    /// </summary>
    public class OrderedCollectionPage : Collection, IOrderedCollectionPage
    {
        public OrderedCollectionPage()
        {
            Context = "http://www.w3.org/ns/activitystreams#OrderedCollectionPage";
            Type = "OrderedCollectionPage";

        }

    }

}
