using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersApp.Domain.Users
{
    public record Name
    {
        private Name(string first, string? second)
        {
            Fisrt = first;
            Second = second;
        }

        public string Fisrt { get; private set; }
        public string? Second { get; private set; }


        public static Name Create(string first, string? second)
        {
            if (first == null) 
                throw new ArgumentNullException("El primer nombre no puede ser nulo");

            return new Name(first, second);

        }
    }
}
