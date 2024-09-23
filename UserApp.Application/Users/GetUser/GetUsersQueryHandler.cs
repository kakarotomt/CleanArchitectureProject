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
    internal sealed class GetUsersQueryHandler : IQueryHandler<GetUsersQuery, IReadOnlyList<UserResponse>>
    {

        private readonly ISqlConnectionFactory _connectionFactory;

        public GetUsersQueryHandler(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<Result<IReadOnlyList<UserResponse>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
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
                        where FirstNames = @firstName
                        or FirstLastnames = @firstLastname
                    order by Id
                    OFFSET (3 * (@page - 1)) rows
                    fetch next 3 rows only
                    """;


            var users = await cn.QueryAsync<UserResponse>(sql
                ,new { 
                request.firstName,
                request.firstLastname,
                request.page
                });

            return users.ToList();
        }
    }
}
