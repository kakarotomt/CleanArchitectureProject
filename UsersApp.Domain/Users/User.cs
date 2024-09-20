using UsersApp.Domain.Abstractions;
using UsersApp.Domain.Users.Events;

namespace UsersApp.Domain.Users
{
    public sealed class User : Entity
    {
        private User(Guid id,
            Name names,
            Lastname lastNames,
            UserData data,
            AuditData auditData,
            DocumentType documentType
            ) : base(id)
        {
            Names = names;
            LastNames = lastNames;
            Data = data;
            AuditData = auditData;
            DocumentType = documentType;
        }

        public Name? Names { get; set; }
        public Lastname? LastNames { get; set; }
        public UserData? Data { get; private set; }
        public AuditData? AuditData { get; private set; }
        public DocumentType DocumentType { get; private set; }


        public static User Create(
            Name names,
            Lastname lastNames,
            UserData data,
            AuditData auditData,
            DocumentType documentType)
        {
            var user = new User(
                  Guid.NewGuid()
                , names
                , lastNames
                , data
                , auditData
                , documentType);
            user.RiseDomainEvent(new UserCreatedDomainEvent(user.Id));
            return user;
        }

    }



}
