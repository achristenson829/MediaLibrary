using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MediaLibrary;

namespace MediaLibrary
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            PrintMenu();
        }

        public static void PrintMenu()
        {
            var choice = "";
            do
            {
                Console.WriteLine("What would you like to do?\n1. Display\n2. Add\n3. Exit");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        List();
                        break;
                    case "2":
                        Add();
                        break;
                    case "3":
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            } while (choice != "3");
        }

        public static void List()
        {

            var choice = "";
            do
            {
                Console.WriteLine("What do you want to display?\n1. Movie\n2. Show\n3. Video\n4. Exit");
                choice = Console.ReadLine();
                Media media = null;
                switch (choice)
                {

                    case "1":
                        media = new Movie(1, "Toy Story", new List<string> {"Action","Horror"});
                        break;
                    case "2":
                        media = new Show(1, "Supernatural", 12, 2, new List<string>{"Kripke"});
                        break;
                    case "3":
                        media = new Video(1, "Lethal Weapon 3", "VHS,DVD,BluRay", 100, new List<int>{0,2});
                        break;
                    case "4":
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
                media?.Display();
            } while (choice != "4");

        }

        public static void Add()
        {

            var choice = "";
            do
            {
                Console.WriteLine("What do you want to add?\n1. Movie\n2. Show\n3. Video\n4. Exit");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddMovie();
                        break;
                    case "2":
                        AddShow();
                        break;
                    case "3":
                        AddVideo();
                        break;
                    case "4":
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            } while (choice != "4");
        }
        public static void AddMovie()
        {
            try
            {
                List<Movie> movies = new List<Movie>();
                string file = "Files/movies.csv";
                using (var reader = new StreamReader(file))
                {
                    Movie movie = new Movie();

                    while (!reader.EndOfStream)
                    {
                        var headerline = reader.ReadLine();
                        var line = reader.ReadLine();

                        if (line != null)
                        {
                            var values = line.Split(',');
                            movie.Id = Int32.Parse(values[0]);
                            movie.title = values[1];
                            movie.genre = values[2].Split('|').ToList();
                        }

                        movies.Add(movie);
                    }

                    reader.Close();


                    StreamWriter sw = new StreamWriter(file, true);
                    string resp = "";
                    do
                    {
                        movie.Id = movies.Max(m => m.Id) + 1;

                        Console.WriteLine("Enter movie title");
                        string title = Console.ReadLine();
                        if (movie.title.Contains(title))
                        {
                            Console.WriteLine("Movie already exists");
                            Console.WriteLine("Enter different movie title");
                            title = Console.ReadLine();
                            if (title.Contains(','))
                            {
                                title = $"\"{title}\"";
                            }
                        }


                        var choice = "";
                        movie.genre = new List<string>();
                        do
                        {
                            Console.WriteLine("Enter movie genre");
                            movie.genre.Add(Console.ReadLine());
                            Console.WriteLine("Is there another genre to add? Y/N ");
                            choice = Console.ReadLine().ToUpper();
                        } while (choice != "N");

                        sw.WriteLine($"{movie.Id},{title},{string.Join("|", movie.genre)},");
                        Console.WriteLine("Do you want to add another movie (Y/N)?");
                        resp = Console.ReadLine().ToUpper();
                    } while (resp != "N");

                    sw.Close();

                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File not found");
            }
        }

        public static void AddShow()
        {
            try
            {
                List<Show> shows = new List<Show>();
                string file = "Files/shows.csv";
                using (var reader = new StreamReader(file))
                {
                    Show show = new Show();
                   
                    while (!reader.EndOfStream)
                    {
                        reader.ReadLine();
                        var line = reader.ReadLine();

                        if (line != null)
                        {
                            var values = line.Split(',');
                            show.Id = Int32.Parse(values[0]);
                            show.title = values[1];
                            show.season = Int32.Parse(values[2]);
                            show.episode = Int32.Parse(values[3]);
                            show.writers = values[4].Split('|').ToList();
                        }

                        shows.Add(show);
                    }

                    reader.Close();


                    StreamWriter sw = new StreamWriter(file, true);
                    string resp = "";
                    do
                    {
                        show.Id = shows.Max(m => m.Id) + 1;

                        Console.WriteLine("Enter show title");
                        string title = Console.ReadLine();
                        if (show.title.Contains(title))
                        {
                            Console.WriteLine("Show already exists");
                            Console.WriteLine("Enter different show title");
                            title = Console.ReadLine();
                            if (title.Contains(','))
                            {
                                title = $"\"{title}\"";
                            }
                        }

                        Console.WriteLine("Enter show season");
                        show.season = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Enter show episode");
                        show.episode = Int32.Parse(Console.ReadLine());
                        
                        var choice = "";
                        show.writers = new List<string>();
                        do
                        {
                            Console.WriteLine("Enter show writer");
                            show.writers.Add(Console.ReadLine());
                            Console.WriteLine("Is there another writer to add? Y/N ");
                            choice = Console.ReadLine().ToUpper();
                        } while (choice != "N");

                        sw.WriteLine($"{show.Id},{title},{show.season},{show.episode}{string.Join("|", show.writers)},");
                        Console.WriteLine("Do you want to add another show (Y/N)?");
                        resp = Console.ReadLine().ToUpper();
                    } while (resp != "N");

                    sw.Close();

                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File not found");
            }
        }
        
        public static void AddVideo()
        {
            try
            {
                List<Video> videos = new List<Video>();
                string file = "Files/videos.csv";
                using (var reader = new StreamReader(file))
                {
                    Video video = new Video();

                    while (!reader.EndOfStream)
                    {
                        reader.ReadLine();
                        var line = reader.ReadLine();

                        if (line != null)
                        {
                            var values = line.Split(',');
                            video.Id = Int32.Parse(values[0]);
                            video.title = values[1];
                            video.format = values[2];
                            video.length = Int32.Parse(values[3]);
                            video.regions = values[4].Split('|').Select(Int32.Parse).ToList();
                        }

                        videos.Add(video);
                    }

                    reader.Close();


                    StreamWriter sw = new StreamWriter(file, true);
                    string resp = "";
                    do
                    {
                        video.Id = videos.Max(m => m.Id) + 1;

                        Console.WriteLine("Enter video title");
                        string title = Console.ReadLine();
                        if (video.title.Contains(title))
                        {
                            Console.WriteLine("Show already exists");
                            Console.WriteLine("Enter different show title");
                            title = Console.ReadLine();
                            if (title.Contains(','))
                            {
                                title = $"\"{title}\"";
                            }
                        }

                        Console.WriteLine("Enter video formats");
                        video.format = Console.ReadLine();
                        Console.WriteLine("Enter video length");
                        video.length = Int32.Parse(Console.ReadLine());

                        
                        var choice = "";
                        video.regions = new List<int>();
                        do
                        {
                            Console.WriteLine("Enter movie genre");
                            video.regions.Add(Int32.Parse(Console.ReadLine()));
                            Console.WriteLine("Is there another genre to add? Y/N ");
                            choice = Console.ReadLine().ToUpper();
                        } while (choice != "N");

                        sw.WriteLine($"{video.Id},{title},{video.format},{video.length}{string.Join("|", video.regions)},");
                        Console.WriteLine("Do you want to add another show (Y/N)?");
                        resp = Console.ReadLine().ToUpper();
                    } while (resp != "N");

                    sw.Close();

                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File not found");
            }
        }

    }
}