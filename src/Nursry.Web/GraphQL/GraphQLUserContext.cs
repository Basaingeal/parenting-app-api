using System.Security.Claims;

namespace Nursry.Web.GraphQL
{
    public class GraphQLUserContext
    {
        public ClaimsPrincipal User { get; set; }
    }
}
