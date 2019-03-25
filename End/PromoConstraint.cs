using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Bookstore
{
    public class PromoConstraint : IRouteConstraint
    {
        private readonly IEnumerable<string> _promoCodes;

        public PromoConstraint()
        {
            _promoCodes = new List<string> { "code1", "code3" };
        }

        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            string promoCode = values["code"]?.ToString();

            return _promoCodes.Contains(promoCode);
        }
    }
}