using Microsoft.EntityFrameworkCore;
namespace UWS.Shared

{
    public class Movie : DbContext
    {
        public DbSet<Actor> Actors {get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)  {

           //string path = System.IO.Path.Combine(System.Environment.CurrentDirectory, "Movie.db");
           string currentDir = System.Environment.CurrentDirectory;
           string parentDir = System.IO.Directory.GetParent(currentDir).FullName;
           string path = System.IO.Path.Combine(parentDir, "Movie.db");
            optionsBuilder.UseSqlite($"Filename={path}");

        }
    }
}