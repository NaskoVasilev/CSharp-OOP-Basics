using RadioDatabase.Exceptions;

namespace RadioDatabase
{
    public class Song
    {
        private string artistName;
        private string songName;
        private int minites;
        private int seconds;

        public Song(string songName, string artistName, int minutes, int seconds)
        {
            ArtistName = artistName;
            SongName = songName;
            Minutes = minutes;
            Seconds = seconds;
        }

        public string SongName
        {
            get { return songName; }
            set
            {
                if (value.Length < 3 || value.Length > 20)
                {
                    throw new InvalidSongNameException();
                }
                songName = value;
            }
        }

        public string ArtistName
        {
            get { return artistName; }
            set
            {
                if (value.Length < 3 || value.Length > 20)
                {
                    throw new InvalidArtistNameException();
                }
                artistName = value;
            }
        }

        public int Minutes
        {
            get { return minites; }
            set
            {
                if (value < 0 || value > 14)
                {
                    throw new InvalidSongMinutesException();
                }
                minites = value;
            }
        }

        public int Seconds
        {
            get { return seconds; }
            set
            {
                if (value < 0 || value > 59)
                {
                    throw new InvalidSongSecondsException();
                }
                seconds = value;
            }
        }
    }
}
