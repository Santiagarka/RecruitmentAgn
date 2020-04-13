using RecruitmentAgency.Core.Entities;

using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace RecruitmentAgency.NHibernate.EntityMappings
{
    /// <summary>
    /// Маппинг сущности <see cref="Vacancy"/>
    /// </summary>
    public class VacancyMap : ClassMapping<Vacancy>
    {
        public VacancyMap()
        {
            Id(property => property.Id, mapper =>
            {
                mapper.Generator(Generators.Increment);
                mapper.Type(NHibernateUtil.Int32);
                mapper.Column("Id");
            });

            Property(property => property.Name, mapping =>
            {
                mapping.Type(NHibernateUtil.String);
                mapping.NotNullable(true);
            });

            Property(property => property.Description, mapping =>
            {
                mapping.Type(NHibernateUtil.String);
                mapping.NotNullable(true);
            });

            Property(property => property.Term, mapping =>
            {
                mapping.Type(NHibernateUtil.DateTime);
                mapping.NotNullable(true);
            });

            Property(property => property.Company, mapping =>
            {
                mapping.Type(NHibernateUtil.String);
                mapping.NotNullable(true);
            });

            Property(property => property.Requirements, mapping =>
            {
                mapping.Type(NHibernateUtil.String);
                mapping.NotNullable(true);
            });

            Property(property => property.Salary, mapping =>
            {
                mapping.Type(NHibernateUtil.Decimal);
                mapping.NotNullable(false);
            });

            Property(property => property.IsActive, mapping =>
            {
                mapping.Type(NHibernateUtil.Boolean);
                mapping.NotNullable(false);
            });

            ManyToOne(property => property.Creator, mapping =>
            {
                mapping.Column("CreatorId");
                mapping.NotNullable(true);
            });

            Set(property => property.Skills, collectionMapping =>
            {
                collectionMapping.Key(k => k.Column("VacancyId"));
                collectionMapping.Table("Vacancies_Skills");
                collectionMapping.Cascade(Cascade.All);
            },
            mapping => {
                mapping.ManyToMany(m => m.Column("SkillId")); 
            }
            );

            Table(Vacancy.TableName);

        }
    }
}