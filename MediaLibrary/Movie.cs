using System;
using System.Collections.Generic;

namespace MediaLibrary
{
    public class Movie : Media
    {
        public List<string> genre { get; set; }
        
        public Movie(){}

        public Movie(int Id, string title, List<string> genre)
        {
            this.Id = Id;
            this.title = title;
            this.genre = genre;
        }
        
        public Movie(List<string> genre)
        {
            this.genre = genre;
        }

        public override void Display()
        {
            Console.WriteLine($"Id: {Id}\nTitle: {title}\nGenres: {string.Join(", ", genre)}\n");
        }
    }
}