using RecruitmentAgency.Core.Entities;
using System.Collections.Generic;

namespace RecruitmentAgency.Core.Managers
{
    public interface IRoleManager
    {
        Role Get(int id);
        ICollection<Role> GetAll();
    }
}
