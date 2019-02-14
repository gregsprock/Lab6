using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new StudioContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();                   
            }
            
            using (var db = new StudioContext())
            {            
                Studio Studio = new Studio
                {
                    Name = "20th Century Fox",
                    Movies = new List<Movie> {
                        new Movie {Title = "Avatar", Genre = "Action"},
                        new Movie {Title = "Deadpool", Genre = "Action"},
                        new Movie {Title = "Apollo 13", Genre = "Drama"},
                        new Movie {Title = "The Martians", Genre = "Sci-Fi"},
                    }
                };

                Studio Studio2 = new Studio
                {
                    Name = "Universal Pictures"
                };

                db.Add(Studio);
                db.Add(Studio2); 
                db.SaveChanges(); 
            }

            using (var db = new StudioContext())
            {
                Movie Movie = new Movie {Title = "Jurrasic Park", Genre = "Action"};
                Movie.Studio = db.Studios.Where(s => s.Name == "Universal Pictures").First();
                db.Add(Movie);
                db.SaveChanges();                   
            }

            using (var db = new StudioContext())
            {
                Movie Movie = db.Movies.Where(m => m.Title == "Apollo 13").First();
                Movie.Studio = db.Studios.Where(s => s.Name == "Universal Pictures").First();
                db.SaveChanges();
            }

            using (var db = new StudioContext())
            {
                Movie Movie = db.Movies.Where(m => m.Title == "Deadpool").First();
                db.Remove(Movie);
                db.SaveChanges();                   
            }

            using (var db = new StudioContext())
            {
                var studios = db.Studios.Include(s => s.Movies);
                foreach (var s in studios)
                {
                    Console.WriteLine(s);
                    foreach (var p in s.Movies)
                    {
                       Console.WriteLine("\t" + p);
                    }
                }
            }
        }
    }
}
