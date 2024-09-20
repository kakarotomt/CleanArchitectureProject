﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersApp.Domain.Users
{
    public record AuditData(
        DateTime CreateDate,
        DateTime ModifiedDate
        );
}
