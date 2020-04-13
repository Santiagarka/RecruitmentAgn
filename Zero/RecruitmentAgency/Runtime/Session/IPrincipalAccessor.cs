using System.Security.Claims;

namespace RecruitmentAgency.Runtime.Session
{
    public interface IPrincipalAccessor
    {
        ClaimsPrincipal Principal { get; }
    }
}
