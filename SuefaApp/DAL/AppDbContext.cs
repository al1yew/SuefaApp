﻿using Microsoft.EntityFrameworkCore;

namespace SuefaApp.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
