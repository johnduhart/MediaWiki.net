using System;
using System.Runtime.Serialization;

namespace MediaWiki.Queries.List
{
    [Query("logevents", "le")]
    public class LogEventsListQuery : ListQuery<LogEventsListQuery, LogEvent>
    {
        [QueryParameter("prop")]
        public LogEventsProperties Properties { get; set; }

        [QueryParameter]
        public string Type { get; set; }

        [QueryParameter]
        public string Action { get; set; }

        [QueryParameter]
        public DateTime Start { get; set; }

        [QueryParameter]
        public DateTime End { get; set; }

        [QueryParameter("dir")]
        public LogEventsDirection Direction { get; set; }

        public string User { get; set; }

    }

    [ApiEnum]
    public enum LogEventsDirection
    {
        Newer,
        Older,
    }

    [Flags, ApiEnum]
    public enum LogEventsProperties
    {
        Ids,
        Title,
        Type,
        User,
        UserId,
        TimeStamp,
        Comment,
        ParsedComment,
        Details,
        Tags,
    }

    public class LogEvent
    {
    }
}