using System.Reflection;
using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repositories.EFCore.Config;

namespace Repositories;

public class RepositoryContext : IdentityDbContext<User>
{

    public RepositoryContext(DbContextOptions context) : base(context)
    {

    }
  
    //  public DbSet<User> Users { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<WordNote> WordNotes { get; set; }
    
        protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        //builder.ApplyConfiguration(new UserConfig());
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); 
        //söylentilere göre tüm config dosyalarını tek satırda işlemek için

    }
}