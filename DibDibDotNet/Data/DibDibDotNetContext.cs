using System;
using Microsoft.EntityFrameworkCore;
using DibDibDotNet.Models;
namespace DibDibDotNet.Data
{
    public class DibDibDotNetContext:DbContext
    {
        public DibDibDotNetContext(DbContextOptions<DibDibDotNetContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
    }
}
