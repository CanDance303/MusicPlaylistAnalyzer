using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicPlaylistAnalyzer
{
    class Report
    {
        public static string CreateReport(List<PlaylistInfo> Playlist)
        {
            string answer = " **** Report Results **** ";

            if (Playlist.Count() < 1)
            {
                answer += "No information is available. ";

                return answer;
            }

            //Stuff to get answers

            var numPlays = from PlaylistInfo in Playlist where PlaylistInfo.Plays >= 200 select PlaylistInfo.Plays;

            var alt = from PlaylistInfo in Playlist where PlaylistInfo.Genre == "Alternative" select PlaylistInfo.Genre;

            var rap = from PlaylistInfo in Playlist where PlaylistInfo.Genre == "Hip-Hop/Rap" select PlaylistInfo.Genre;

            var Fishbowl = from PlaylistInfo in Playlist where PlaylistInfo.Album == "Welcome to the Fishbowl" select PlaylistInfo.Name;

            var oldSongs = from PlaylistInfo in Playlist where PlaylistInfo.Year < 1970 select PlaylistInfo.Name;

            var longestNames = from PlaylistInfo in Playlist where PlaylistInfo.Name.Length > 85 select PlaylistInfo.Name;

            int longestTune = Playlist.Max(PlaylistInfo => PlaylistInfo.Time);
            var duration = from PlaylistInfo in Playlist where PlaylistInfo.Time == longestTune select PlaylistInfo.Name;


            //Results 

            answer += "Number of songs that received 200+ plays: " + numPlays.Count();
            answer += Environment.NewLine;

            answer += "Number of Alternative songs in the playlist: " + alt.Count();
            answer += Environment.NewLine;

            answer += "Number of Hip-Hop/Rap songs in the playlist: " + rap.Count();
            answer += Environment.NewLine;

            answer += "Songs from the album 'Welcome to the Fishbowl': ";
            foreach (var song in Fishbowl) answer += song;
            answer += Environment.NewLine;

            answer += "Songs from before 1970: ";
            foreach (var old in oldSongs) answer += old;
            answer += Environment.NewLine;

            answer += "Song names that have more than 85 characters: ";
            foreach (var longNames in longestNames) answer += longNames;
            answer += Environment.NewLine;

            answer += "The longest song by time is: ";
            foreach (var longestSong in duration) answer += longestSong;
            answer += Environment.NewLine;

            return answer;

        }
    }
}
