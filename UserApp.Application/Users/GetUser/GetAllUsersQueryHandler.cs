using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApp.Application.Abstractions.Data;
using UserApp.Application.Abstractions.Messaging;
using UsersApp.Domain.Abstractions;

namespace UserApp.Application.Users.GetUser
{
    internal sealed class GetAllUsersQueryHandler : IQueryHandler<GetAllUsersQuery, IReadOnlyList<UserResponse>>
    {

        private readonly ISqlConnectionFactory _connectionFactory;

        public GetAllUsersQueryHandler(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<Result<IReadOnlyList<UserResponse>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            using var cn = _connectionFactory.dbConnection();

            var sql = """ 
                    SELECT
                        Id, 
                        FirstNames,
                        SecondNames,
                        SecondLastNames,
                        FirstLastNames,
                        Birthdays,
                        Salarys,
                        CreateDates,
                        ModifiedDates
                    FROM Users 
                    """;

            var users = await cn.QueryAsync<UserResponse>(sql);

            return users.ToList();
        }
    }
}
