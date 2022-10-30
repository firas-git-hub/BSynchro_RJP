﻿using BSynchro_RJP.Models.Entities;

namespace BSynchro_RJP.Services.Customers
{
    public interface ICustomersContextService
    {
        void AddUserAccount(int userId, double initialCredit);
        UserInfo? GetUserInfo(int userId);
    }
}
