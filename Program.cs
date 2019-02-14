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
                        new Movie {Title = "The Martian", Genre = "Sci-Fi"},
                    }
                };

                Studio studios2 = new Studio
                {
                    Name = "Universal Pictures"
                };
            }
            /*using (var db = new StudioContext())
            {
                Movie Movie = new Movie { Title = "Jurrasic Park", Genre = "Action"};
                Movie.Studio = db.Studios.Where();
                db.Add(post);
                db.SaveChanges();                   
            } */
        }
    }
}
