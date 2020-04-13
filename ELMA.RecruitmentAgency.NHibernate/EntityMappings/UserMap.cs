using RecruitmentAgency.Core.Entities;

using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace RecruitmentAgency.NHibernate.EntityMappings
{
    /// <summary>
    /// Маппинг сущности <see cref="User"/>
    /// </summary>
    public class UserMap : ClassMapping<User>
    {
        public UserMap()
        {
            Id(property => property.Id, mapper =>
            {
                mapper.Generator(Generators.Increment);
                mapper.Type(NHibernateUtil.Int32);
                mapper.Column("Id");
            });

            Property(property => property.Login, mapping =>
            {
                mapping.Type(NHibernateUtil.String);
                mapping.NotNullable(true);
            });

            Property(property => property.Email, mapping =>
            {
                mapping.Type(NHibernateUtil.String);
                mapping.NotNullable(true);
            });

            Property(property => property.Password, mapping =>
            {
                mapping.Type(NHibernateUtil.String);
                mapping.NotNullable(true);
            });

            ManyToOne(property => property.Role, mapping =>
            {
                mapping.Column("RoleId");
                mapping.Cascade(Cascade.All);
            });

            Table(User.TableName);
        }
    }
}
