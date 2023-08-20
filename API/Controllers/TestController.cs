using API.Database;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class TestController : ControllerBase
    {
        private readonly DataContext _db;
        public TestController(DataContext db)
        {
            _db = db;   
        }
        [HttpDelete("test")]
        public async Task<IActionResult> Test (int id)
        {
            var test = await _db.Test.FindAsync(id);
            _db.Test.Remove(test);
            await _db.SaveChangesAsync();
            return new JsonResult("ok");
        }
    }
}
