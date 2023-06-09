﻿using WriteDownOnlineApi.Domain.Entities;
using WriteDownOnlineApi.Domain.Interface.Core;

namespace WriteDownOnlineApi.Domain.Interface
{
    public interface IUsersRepository : IRepository<UsersEntity, long>
    {
        UsersEntity FindUserByEmail(string email);
    }
}
