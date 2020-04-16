using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication16.Models
{
    public class ApplicationResource : DbContext
    {
        public ApplicationResource(DbContextOptions<ApplicationResource> options) : base(options)
        {

        }
        public DbSet<Resource> Resource { get; set; }
    }
}
