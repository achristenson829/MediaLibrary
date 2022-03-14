using System;
using System.Collections.Generic;

namespace MediaLibrary
{
    public class Video: Media
    {
      
        public string format { get; set; }
        public int length { get; set; }
        public List<int> regions { get; set; }

        public Video(int Id, string title, string format, int length, List<int> regions)
        {
            this.Id = Id;
            this.title = title;
            this.format = format;
            this.length = length;
            this.regions = regions;
        }

        public Video(string format, int length, List<int> regions)
        {
            this.format = format;
            this.length = length;
            this.regions = regions;
        }

        public Video() { }

        public override void Display()
        {
            Console.WriteLine($"Id: {Id}\nTitle: {title}\nFormat: {format}\nLength: {length}\n" +
                              $"Regions: {string.Join(", ", regions)}\n");
        }
    }
}