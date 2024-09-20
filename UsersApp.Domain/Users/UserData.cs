using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace UsersApp.Domain.Users
{
    public record UserData
    {
        private UserData() {}
        
        public DateOnly Birthday { get; private set; }
        public decimal Salary { get; private set; }
        
        public static UserData Create(DateOnly birthday, decimal salary) {

            if (birthday.Year > DateTime.Now.Year)
            {
                throw new InvalidOperationException("la fecha de nacimiento no puede ser mayor a la actual");
            }

            if (salary < 0 )
            {
                throw new InvalidOperationException("no puede haber un salario negativo");
            }

            return new UserData() 
            { Birthday = birthday
            , Salary = salary };
        }
    }
}
