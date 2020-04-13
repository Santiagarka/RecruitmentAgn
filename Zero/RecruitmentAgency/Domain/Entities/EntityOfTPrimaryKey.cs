namespace RecruitmentAgency.Domain.Entities
{
    /// <summary>
    /// Сущность
    /// </summary>
    /// <typeparam name="TPrimaryKey">Тип первичного ключа</typeparam>
    public abstract class Entity<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        public virtual TPrimaryKey Id { get; set; }
    }
}
