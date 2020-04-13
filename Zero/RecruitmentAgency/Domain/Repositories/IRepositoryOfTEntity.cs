using RecruitmentAgency.Domain.Entities;

namespace RecruitmentAgency.Domain.Repositories
{
    public interface IRepository<TEntity>: IRepository<TEntity, int>
        where TEntity: class, IEntity<int>
    {
    }
}
