using System.Security.Claims;
using System.Threading;

namespace RecruitmentAgency.Runtime.Session
{
    public class DefaultPrincipalAccessor : IPrincipalAccessor
    {
        public virtual ClaimsPrincipal Principal
        {
            get { return Thread.CurrentPrincipal as ClaimsPrincipal; }
        }
    }

}
