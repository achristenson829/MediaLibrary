using System;
using System.Collections.Generic;

namespace MediaLibrary
{
    public class Show : Media
    {
        public int episode { get; set; }
        public int season { get; set; }
        public List<string> writers { get; set; }


        public Show(int episode, int season, List<string> writers)
        {
            this.episode = episode;
            this.season = season;
            this.writers = writers;
        }
        public Show(int Id, string title, int episode, int season, List<string> writers)
        {
            this.Id = Id;
            this.title = title;
            this.episode = episode;
            this.season = season;
            this.writers = writers;
        }

        public Show() { }
        
        public override void Display()
        {
            Console.WriteLine($"Id: {Id}\nTitle: {title}\nEpisode: {episode}\nSeason: {season}\n" +
                              $"Writers: {string.Join(", ", writers)}\n");        }
    }
}