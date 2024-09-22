using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersApp.Domain.Abstractions;

namespace UserApp.Application.Abstractions.Messaging
{
    internal interface IQuery<TResopnse> : IRequest<Result<TResopnse>>
    {

    }
}
