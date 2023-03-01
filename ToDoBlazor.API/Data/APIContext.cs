using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoBlazor.Shared.Entities;

namespace ToDoBlazor.API.Data
{
    public class APIContext : DbContext
    {
        public APIContext (DbContextOptions<APIContext> options)
            : base(options)
        {
        }

        public DbSet<ToDoBlazor.Shared.Entities.Item> Item { get; set; } = default!;
    }
}
