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
    internal sealed class GetUserQueryHandler : IQueryHandler<GetUserQuery, UserResponse>
    {

        private readonly ISqlConnectionFactory _connectionFactory;

        public GetUserQueryHandler(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<Result<UserResponse>> Handle(GetUserQuery request, CancellationToken cancellationToken)
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
                        where Id = @UserId
                    """;

            if(request.userId == null)
                sql = """ 
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
                    """;

            var user = await cn.QueryFirstOrDefaultAsync<UserResponse>(sql
                , new
                {
                    request.userId
                });

            return user!;
        }
    }
}
