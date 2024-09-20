using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersApp.Domain.Users
{
    public record Lastname
    {
        private Lastname(string first, string? second)
        {
            Fisrt = first;
            Second = second;
        }

        public string Fisrt { get; private set; }
        public string? Second { get; private set; }


        public static Lastname Create(string first, string? second)
        {
            if (first == null)
                throw new ArgumentNullException("El primer apellido no puede ser nulo");

            return new Lastname(first, second);

        }
    }
}
