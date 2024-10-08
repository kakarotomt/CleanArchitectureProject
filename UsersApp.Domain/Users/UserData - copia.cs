﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace UsersApp.Domain.Users
{
    public record UserData2
    {
        private UserData2() {}
        
        public DateOnly Birthday { get; private set; }
        public decimal Salary { get; private set; }
        
        public static UserData2 Create(DateOnly birthday, decimal salary) {

            if (birthday.Year > DateTime.Now.Year)
            {
                throw new InvalidOperationException("la fecha de nacimiento no puede ser mayor a la actual");
            }

            if (salary < 0 )
            {
                throw new InvalidOperationException("no puede haber un salario negativo");
            }

            return new UserData2() 
            { Birthday = birthday
            , Salary = salary };
        }
    }
}
