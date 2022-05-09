using Microsoft.EntityFrameworkCore;

namespace Truper.Services
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }
    }
}
