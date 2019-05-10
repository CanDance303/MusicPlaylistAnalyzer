using System;
using System.Collections.Generic;
using System.IO;

namespace MusicPlaylistAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" **** Music Playlist Analyzer **** ");

            if (args.Length != 2)
            {
                Console.WriteLine("MusicPlaylistAnalyzer <Music_Playlist_File_Path> <Output_File_Path>");
                Environment.Exit(1);
            }

            string musicFile = args[0];
            string reportFile = args[1];


            List<PlaylistInfo> Playlist = null;

            try
            {
                Playlist = LoadPlaylist.Load(musicFile);
            }
            catch (Exception a)
            {
                Console.WriteLine(a.Message);
                Environment.Exit(2);
            }

            var report = Report.CreateReport(Playlist);

            try
            {
                StreamWriter sw = new StreamWriter(reportFile);
                sw.WriteLine(report);
            }

            catch (Exception b)
            {
                Console.WriteLine(b.Message);
                Environment.Exit(3);
            }
        }
    }
}
