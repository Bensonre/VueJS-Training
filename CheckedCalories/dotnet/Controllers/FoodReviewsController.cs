using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Classes;

namespace AspNetCore.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class FoodReviewsController : ControllerBase
  {
    private readonly ApplicationDbContext _dbContext;

    public FoodReviewsController(ApplicationDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    // GET api/foodReviews
    [HttpGet]
    public async Task<ActionResult<List<Classes.reviewList.FoodReview>>> Get()
    {
      return await _dbContext.FoodReviews.ToListAsync();
    }

    // POST api/foodReviews
    [HttpPost]
    public async Task Post(string id, Classes.reviews.singleReview model)
    {

            await _dbContext.AddAsync(model);

            await _dbContext.SaveChangesAsync();
        }

    // PUT api/foodReviews/5
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(string id, Classes.reviewList.FoodReview model)
    {
      var exists = await _dbContext.FoodReviews.AnyAsync(f => f.Id == id);
      if (!exists)
      {
        return NotFound();
      }

      _dbContext.FoodReviews.Update(model);
      
      await _dbContext.SaveChangesAsync();

      return Ok();

    }

    // DELETE api/foodReviews/5
    [HttpDelete("/")]
    public async Task<ActionResult> Delete(string id, int index)
    {
      var entity = await _dbContext.FoodReviews.FindAsync(id);

      entity.reviews.RemoveAt(index);
      
      await _dbContext.SaveChangesAsync();
      
      return Ok();
    }
  }
}