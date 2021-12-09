﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockMarket.AccountAPI.Entities;
using StockMarket.AccountAPI.Models;

namespace StockMarket.AccountAPI.Repositories
{
    public interface IUserRepository
    {
        int Register(User user);
        User Login(Login login);

    }
}

