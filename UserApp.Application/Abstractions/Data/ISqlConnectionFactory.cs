﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserApp.Application.Abstractions.Data
{
    public interface ISqlConnectionFactory
    {
        IDbConnection dbConnection();
    }
}
