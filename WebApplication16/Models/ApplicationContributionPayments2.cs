using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication16.Models
{
    public class ApplicationContributionPayments2 : DbContext
    {
        public ApplicationContributionPayments2(DbContextOptions<ApplicationContributionPayments2> options) : base(options)
        {

        }

        public DbSet<AddNewPayment> ContributionPayments { get; set; }

    }
}
