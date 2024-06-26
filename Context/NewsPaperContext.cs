using CQRS_MediatR.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRS_MediatR.Context
{
    public class NewsPaperContext:DbContext
    {
        public NewsPaperContext() { }
        public NewsPaperContext(DbContextOptions<NewsPaperContext> options) : base(options) { }

        public DbSet<News> News { get; set; }

    }
}
