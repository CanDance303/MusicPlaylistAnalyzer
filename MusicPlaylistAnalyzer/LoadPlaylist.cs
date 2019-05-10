using System;
using System.Collections.Generic;
using System.IO;

namespace MusicPlaylistAnalyzer
{
    class LoadPlaylist
    {
        static int NumItemsInRow = 8;

        public static List<PlaylistInfo> Load(string musicFile)
        {
            List<PlaylistInfo> Playlist = new List<PlaylistInfo>();

            try
            {
                using (StreamReader reader = new StreamReader(musicFile))
                {
                    int row = 0;

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();

                        row++;

                        var values = line.Split('\t');

                        if (values.Length != NumItemsInRow)
                        {
                            throw new Exception($"Row {row} contains {values.Length} values. Row should contain {NumItemsInRow} values.");
                        }

                        try
                        {
                            string name = values[0];
                            string artist = values[1];
                            string album = values[2];
                            string genre = values[3];
                            int size = Int32.Parse(values[4]);
                            int time = Int32.Parse(values[5]);
                            int year = Int32.Parse(values[6]);
                            int plays = Int32.Parse(values[7]);
                            PlaylistInfo playlistInfo = new PlaylistInfo(name, artist, album, genre, size, time, year, plays);
                            Playlist.Add(playlistInfo);
                        }

                        catch (FormatException c)
                        {
                            throw new Exception($"Row {row} contains invalid data." + c.Message);
                        }
                    }
                }
            }

            catch (Exception d)
            {
                throw new Exception($"The file {musicFile} could not be opened." + d.Message);
            }

            return Playlist;
        }
    }
}

