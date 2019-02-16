using Microsoft.EntityFrameworkCore;
using Classes;

namespace AspNetCore.Controllers {
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }

    public DbSet<Classes.reviewList.FoodReview> FoodReviews { get; set; }
  }
}