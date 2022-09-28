using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaUnit.Models
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext() { }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public virtual DbSet<Invoices> Invoices { get; set; }

    }
}

