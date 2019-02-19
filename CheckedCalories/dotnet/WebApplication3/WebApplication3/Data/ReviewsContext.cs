using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Data
{
    public class ReviewsContext : DbContext
    {
        public ReviewsContext(DbContextOptions<ReviewsContext> options) : base(options)
        {

        }

        public DbSet<Reviews> Reviews {get; set;}
    }
}
