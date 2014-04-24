using System;
using ServiceStack.Text;

namespace MediaWiki.Queries
{
    public abstract class Query
    {
        public virtual object BuildResult(string json)
        {
            throw new NotImplementedException();
        }

        public virtual object BuildResultFullJson(JsonObject jsonObject)
        {
            throw new NotImplementedException();
        }
    }
}