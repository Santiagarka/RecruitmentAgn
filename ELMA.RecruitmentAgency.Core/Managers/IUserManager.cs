using RecruitmentAgency.Core.Entities;
using System.Collections.Generic;

namespace RecruitmentAgency.Core.Managers
{
    /// <summary>
    /// Менеджер сущности <see cref="User"/>
    /// </summary>
    public interface IUserManager
    {
        User Get(string login, string password);

        bool FreeLogin(string login);

        User Create(User user);

        ICollection<User> GetAll();

        User Get(int Id);

        User Update(User user);

        User GetByLogin(string login);

    }
}
