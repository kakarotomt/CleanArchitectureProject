using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersApp.Domain.Abstractions;

namespace UsersApp.Domain.Users
{
    public static class UserErrors
    {
        public static Error NotFound = new Error("User.Find", "No existe el usuario consultado.");
    }
}
