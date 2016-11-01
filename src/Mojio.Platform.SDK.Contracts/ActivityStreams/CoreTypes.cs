using System;
using System.Collections.Generic;

namespace Mojio.Platform.SDK.Contracts.ActivityStreams
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
    public interface IActivityObject
    {
        string Id { get; set; }
        IAttachment Attachment { get; set; }

        string Context { get; set; }
        string Type { get; set; }
        string Name { get; set; }
        ILanguageString NameMap { get; set; }
        DateTimeOffset? EndTime { get; set; }
        IGenerator Generator { get; set; }
        IIcon Icon { get; set; }
        IImage Image { get; set; }
        IInReplyTo InReplyTo { get; set; }
        ILocation Location { get; set; }
        IPreview Preview { get; set; }
        DateTimeOffset? Published { get; set; }
        IReplies Replies { get; set; }
        IScope Scope { get; set; }
        DateTimeOffset? StartTime { get; set; }
        ILanguageString SummaryMap { get; set; }

        ITag Tag { get; set; }
        DateTimeOffset? Updated { get; set; }

        ILink Url { get; set; }
        ITo To { get; set; }
        IBto Bto { get; set; }
        ICc CC { get; set; }
        IBcc BCC { get; set; }
        string MediaType { get; set; }
        TimeSpan? Duration { get; set; }

        IEnumerable<string> Groups { get; set; }
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
    public interface ILink : IActivityObject
    {
        string HRef { get; set; }
        string Rel { get; set; }
        string MediaType { get; set; }
        string Name { get; set; }
        string HRefLang { get; set; }

        int? Height { get; set; }
        int? Width { get; set; }

        string Type { get; set; }
    }

    /// <summary>
    /// URI:	        http://www.w3.org/ns/activitystreams#Activity
    /// Notes:	        An Activity is a subclass of Object that describes some form of action that may happen, is currently happening, or has already happened. The Activity class itself serves as an abstract base class for all types of activities. It is important to note that the Activity class itself does not carry any specific semantics about the kind of action being taken.
    /// Extends:	    Object
    /// Properties:     actor | object | target | result | origin | instrument
    ///                 Inherits all properties from Object.
    /// </summary>
    public interface IActivity : IActivityObject
    {
        IActor Actor { get; set; }
        ILink Target { get; set; }
        ILink Result { get; set; }
        ILink Origin { get; set; }
        ILink Object { get; set; }
        ILink Instrument { get; set; }
    }

    /// <summary>
    /// URI:	            http://www.w3.org/ns/activitystreams#IntransitiveActivity
    /// Notes:	            Instances of IntransitiveActivity are a subclass of
    ///                     Activity whose actor property identifies the direct
    ///                     object of the action as opposed to using the object property.
    /// Extends:	        Activity
    /// Properties:	        Inherits all properties from Activity except object.
    /// </summary>
    public interface IIntransitiveActivity : IActivity
    {
    }

    /// <summary>
    /// URI:	            http://www.w3.org/ns/activitystreams#Actor
    /// Notes:	            An Actor is any entity that is capable of being the primary
    ///                     actor for an Activity.
    /// Extends:	        Object
    /// Properties:	        Inherits all properties from Object.
    /// </summary>
    public interface IActor : ILink
    {
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
    public interface ICollection : IActivityObject
    {
        int TotalItems { get; set; }
        ICurrent Current { get; set; }
        ILast Last { get; set; }
        IFirst First { get; set; }

        IItems Items { get; set; }
    }

    /// <summary>
    /// URI:	            http://www.w3.org/ns/activitystreams#OrderedCollection
    /// Notes:	            A subclass of Collection in which members of the logical
    ///                     collection are assumed to always be strictly ordered.
    /// Extends:	        Collection
    /// Properties:	        Inherits all properties from Collection.
    /// </summary>
    public interface IOrderedCollection : ICollection
    {
    }

    /// <summary>
    ///	URI:	            http://www.w3.org/ns/activitystreams#CollectionPage
    /// Notes:	            Used to represent distinct subsets of items from a Collection.
    ///                     Refer to the Activity Streams 2.0 Core for a complete description
    ///                     of the CollectionPage object.
    /// Extends:	        Collection
    /// Properties:	        partOf | next | prev   Inherits all properties from Collection.
    /// </summary>
    public interface ICollectionPage : ICollection
    {
    }

    /// <summary>
    /// URI:	            http://www.w3.org/ns/activitystreams#OrderedCollectionPage
    /// Notes:	            Used to represent ordered subsets of items from an OrderedCollection.
    ///                     Refer to the Activity Streams 2.0 Core for a complete description of the OrderedCollectionPage object.
    /// Extends:	        OrderedCollection | CollectionPage
    /// Properties:	        startIndex Inherits all properties from OrderedCollection and CollectionPage.
    /// </summary>
    public interface IOrderedCollectionPage : IOrderedCollection, ICollectionPage
    {
    }
}