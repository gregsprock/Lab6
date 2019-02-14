using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Lab6
{
     public class StudioContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=database.db");
        }
        public DbSet<Studio> Studios { get; set; }
        public DbSet<Movie> Movies { get; set; }

    }
    
    public class Studio
    {
        public int StudioID {get; set;}
        public string Name {get; set;}
        public List<Movie> Movies {get; set;}        

        public override string ToString()
        {
            return $"{StudioID} - {Name}";
        }
    }

    public class Movie
    {
        public int MovieID {get; set;}
        public string Title {get; set;}
        public string Genre {get; set;}
        public int StudioID {get; set;}
        public Studio Studio {get; set;}      

        public override string ToString()
        {
            return $"{MovieID} {Title} {Genre}";
        }
    }
}