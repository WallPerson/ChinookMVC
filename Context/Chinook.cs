using Microsoft.EntityFrameworkCore;
namespace project

{
    public class Chinook : DbContext
    {
        public DbSet<Album> Albums {get;set;}
        public DbSet<Track> Tracks {get;set;}

    public DbSet<Artist> Artists {get;set;}



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)  {

           //string path = System.IO.Path.Combine(System.Environment.CurrentDirectory, "Chinook.db");
           string currentDir = System.Environment.CurrentDirectory;
           string parentDir = System.IO.Directory.GetParent(currentDir).FullName;
           string path = System.IO.Path.Combine(parentDir, "chinook.db");
            optionsBuilder.UseSqlite($"Filename={path}");





        }
         protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
    }
}

