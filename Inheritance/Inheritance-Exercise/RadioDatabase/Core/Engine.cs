using RadioDatabase.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RadioDatabase.Core
{
    public class Engine
    {
        private List<Song> songs;

        public Engine()
        {
            this.songs = new List<Song>();
        }

        public void Run()
        {
            int numberOfSongs = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfSongs; i++)
            {
                string[] songInfo = Console.ReadLine().Split(';');

                try
                {
                    if (songInfo.Length != 3)
                    {
                        throw new InvalidSongException();
                    }

                    string artistName = songInfo[0];
                    string songName = songInfo[1];
                    string[] length = songInfo[2].Split(':');
                    bool isMinutes = int.TryParse(length[0], out int minutes);
                    bool isSeconds = int.TryParse(length[1], out int seconds);

                    if (!isMinutes || !isSeconds)
                    {
                        throw new InvalidSongLengthException();
                    }

                    Song song = new Song(songName, artistName, minutes, seconds);
                    songs.Add(song);
                    Console.WriteLine("Song added.");
                }
                catch (FormatException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }

            Console.WriteLine($"Songs added: {songs.Count}");
            int playlistDurationInSeconds = songs.Sum(s => s.Minutes * 60 + s.Seconds);
            TimeSpan duration = TimeSpan.FromSeconds(playlistDurationInSeconds);

            Console.WriteLine($"Playlist length: {duration.Hours}h {duration.Minutes}m {duration.Seconds}s");
        }
    }
}
