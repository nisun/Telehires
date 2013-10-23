using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Telehire.BusinessLogic.Domain
{
    public class PersonalInformation: BaseEntity<long>
    {
        public virtual Guid UserId { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string MiddleName { get; set; }
        public virtual string Surname { get; set; }
        public virtual string Email { get; set; }
        public virtual bool EmailVerified { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual string UserRole { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual string FullName
        {
            get
            {
                return this.Surname + ", " + this.FirstName +" "+ this.MiddleName;

            }
        }

    }

    public class PersonalInformationMap : ClassMapping<PersonalInformation>
    {
        public PersonalInformationMap()
        {
            this.Table("PersonalInformations");
            this.Lazy(true);
            this.Id<long>(x => x.Id, mp => { mp.Column("Id"); mp.Generator(Generators.Native); mp.UnsavedValue(0); });
            this.Property<Guid>(x => x.UserId, mp => { mp.NotNullable(true); mp.Column("UserId"); });
            this.Property<string>(x => x.FirstName, mp => { mp.NotNullable(true); mp.Column("FirstName"); });
            this.Property<string>(x => x.MiddleName, mp => { mp.Column("MiddleName"); });
            this.Property<string>(x => x.Surname, mp => { mp.NotNullable(true); mp.Column("LastName"); });
            this.Property<string>(x => x.UserRole, mp => { mp.NotNullable(true); mp.Column("UserRole"); });
            this.Property<string>(x => x.Email, mp => { mp.NotNullable(true); mp.Column("Email"); });
            this.Property<bool>(x => x.EmailVerified, mp => { mp.NotNullable(true); mp.Column("EmailVerified"); });
            this.Property<bool>(x => x.IsActive, mp => { mp.NotNullable(true); mp.Column("IsActive"); });
            this.Property<string>(x => x.PhoneNumber, mp => { mp.NotNullable(true); mp.Column("PhoneNumber"); });

        }

    }
}
