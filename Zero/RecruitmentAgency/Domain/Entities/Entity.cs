namespace RecruitmentAgency.Domain.Entities
{
    /// <summary>
    /// Сущность, с первичным ключом типа <see cref="int"/>
    /// </summary>
    public abstract class Entity: Entity<int>, IEntity
    {
    }
}
