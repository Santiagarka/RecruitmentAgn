using RecruitmentAgency.Core.Entities;
using RecruitmentAgency.Core.Repositories;
using System.Collections.Generic;

namespace RecruitmentAgency.Core.Managers.Impls
{
    /// <summary>
    /// Менеджер сущности <see cref="User"/>
    /// </summary>
    public class UserManager : IUserManager
    {
        private readonly IUserRepository userRepository;

        public UserManager(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public User Get(string login, string password)
        {
            var entity = userRepository.FirstOrDefault(e => e.Login == login && e.Password == password);
            return entity;
        }

        public bool FreeLogin(string login)
        {
            var entity = userRepository.FirstOrDefault(e => e.Login == login);
            return entity == null;
        }

        public User Create(User user)
        {
            return userRepository.Create(user);
        }

        public ICollection<User> GetAll()
        {
            return userRepository.GetAllList();
        }

        public User Get(int Id)
        {
            var entity = userRepository.FirstOrDefault(e => e.Id == Id);
            return entity;
        }

        public User Update(User user)
        {
            return userRepository.Update(user);
        }

        public User GetByLogin(string login)
        {
            var entity = userRepository.FirstOrDefault(e => e.Login == login);
            return entity;
        }

    }
}