using Homework21.Data;
using Microsoft.EntityFrameworkCore;

namespace Homework21
{
	public class App
	{
		private readonly ApplicationDbContext _dbContext;

		public App(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}
        public async Task Start()
        {
            var data = await _dbContext.Categories.ToListAsync();
        }
    }
}

