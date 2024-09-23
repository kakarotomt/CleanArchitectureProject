using UsersApp.Domain.Abstractions;
using UsersApp.Domain.Users.Events;

namespace UsersApp.Domain.Users
{
    public sealed class User : Entity
    {
        public User()
        {
            
        }
        private User(Guid id,
            FirstName firstName, 
            SecondName secondName, 
            FirstLastname firstLastname, 
            SecondLastname secondLastname, 
            Birthday birthday, 
            Salary salary, 
            CreateDate createDate, 
            ModifiedDate modifiedDate
            ) : base(id)
        {
            FirstNames = firstName;
            SecondNames = secondName;
            FirstLastNames = firstLastname;
            SecondLastNames = secondLastname;
            Birthdays = birthday;
            Salarys = salary;
            CreateDates = createDate;
            ModifiedDates = modifiedDate;
        }

        public FirstName FirstNames { get; set; }
        public SecondName? SecondNames { get; set; }
        public FirstLastname FirstLastNames { get; set; }
        public SecondLastname? SecondLastNames { get; set; }
        public Birthday Birthdays { get; private set; }
        public Salary? Salarys{ get; private set; }
        public CreateDate? CreateDates { get; private set; }
        public ModifiedDate? ModifiedDates { get; private set; }

        public static User Create(FirstName firstName,
            SecondName secondName,
            FirstLastname firstLastname,
            SecondLastname secondLastname,
            Birthday birthday,
            Salary salary,
            CreateDate createDate,
            ModifiedDate modifiedDate)
        {
            var user = new User(
                  Guid.NewGuid(),
                  firstName, 
                  secondName, 
                  firstLastname, 
                  secondLastname, 
                  birthday, 
                  salary, 
                  createDate, 
                  modifiedDate);

            user.RiseDomainEvent(new UserCreatedDomainEvent(user.Id));

            return user;
        }

    }



}
