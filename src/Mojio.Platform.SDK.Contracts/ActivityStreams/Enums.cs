namespace Mojio.Platform.SDK.Contracts.ActivityStreams
{
    /// <summary>
    /// The Negating Activity use case primarily deals with the ability to redact previously completed activities. See 5.5 Inverse Activities and "Undo" for more information.
    /// </summary>
    public enum NegatingAcitivies
    {
        Undo
    }

    /// <summary>
    /// The Offers use case deals with activities involving offering one object to another. It can include, for instance, activities such as "Company A is offering a discount on purchase of Product Z to Sally", "Sally is offering to add a File to Folder A", etc.
    /// </summary>
    public enum OfferActivities
    {
        Offer
    }


    /// <summary>
    /// The Relationship Management use case primarily deals with representing activities involving the management of interpersonal and social relationships (e.g. friend requests, management of social network, etc). See 5.2 Representing Relationships Between Entities for more information.
    /// </summary>
    public enum RelationshipActivities
    {
        //Relevant Activities:
        Accept,
        Add,
        Block,
        Create,
        Delete,
        Follow,
        Ignore,
        Invite,
        Reject
    }

    /// <summary>
    /// The Questions use case primarily deals with representing inquiries of any type. See for more information.
    /// </summary>
    public enum QuestionActivities
    {
        Question
    }

    /// <summary>
    /// The Notification use case primarily deals with calling attention to particular objects or notifications.
    /// </summary>
    public enum NotitificationActivities
    {
        Announce
    }

    /// <summary>
    /// The Geo-Social Events use case primarily deals with activities involving geo-tagging type activities. For instance, it can include activities such as "Joe arrived at work", "Sally left work", and "John is travel from home to work".
    /// </summary>
    public enum GeoSocialEventActivities
    {
        Arrive,
        Leave,
        Travel
    }

    /// <summary>
    /// The Content Experience use case primarily deals with describing activities involving listening to, reading, or viewing content. For instance, "Sally read the article", "Joe listened to the song".
    /// </summary>
    public enum ContentExperienceActvities
    {
        Listen,
        Read,
        View
    }

    /// <summary>
    /// The Group Management use case primarily deals with management of groups. It can include, for instance, activities such as "John added Sally to Group A", "Sally joined Group A", "Joe left Group A", etc.
    /// </summary>
    public enum GroupManagementActivities
    {
        Add,
        Join,
        Leave,
        Remove
    }

    /// <summary>
    /// The Event RSVP use case primarily deals with invitations to events and RSVP type responses.
    /// </summary>
    public enum EventRSVPActvities
    {
        Accept,
        Ignore,
        Invite,
        Reject,
        TentativeAccept,
        TentativeReject
    }

    /// <summary>
    /// The Reactions use case primarily deals with reactions to content. This can include activities such as liking or disliking content, ignoring updates, flagging content as being inappropriate, accepting or rejecting objects, etc.
    /// </summary>
    public enum ReactionActivities
    {
        Accept,
        Block,
        Dislike,
        Flag,
        Ignore,
        Like,
        Reject,
        TentativeAccept,
        TentativeReject
    }

    /// <summary>
    /// The Collection Management use case primarily deals with activities involving the management of content within collections. Examples of collections include things like folders, albums, friend lists, etc. This includes, for instance, activities such as "Sally added a file to Folder A", "John moved the file from Folder A to Folder B", etc.
    /// </summary>
    public enum CollectionManagementActivities
    {
        Add,
        Move,
        Remove
    }

    /// <summary>
    /// The Content Management use case primarily deals with activities that involve the creation, modification or deletion of content. This includes, for instance, activities such as "John created a new note", "Sally updated an article", and "Joe deleted the photo".
    /// </summary>
    public enum ContentManagementActivities
    {
        Create,
        Delete,
        Update
    }
}