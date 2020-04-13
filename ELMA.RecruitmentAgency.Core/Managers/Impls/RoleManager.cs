using RecruitmentAgency.Core.Entities;
using RecruitmentAgency.Core.Repositories;
using System.Collections.Generic;

namespace RecruitmentAgency.Core.Managers.Impls
{
    public class RoleManager: IRoleManager
    {
        private readonly IRoleRepository roleRepository;

        public RoleManager(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        public Role Get(int id)
        {
            return roleRepository.FirstOrDefault(e => e.Id == id);
        }

        public ICollection<Role> GetAll()
        {
            return roleRepository.GetAllList();
        }
    }
}
