// ****************************************************************************
// 
// HdBrStreamExtractor - A GUI front-end for eac3to
// Copyright (C) 2010-2012 Matthew Griffore
// 
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program; if not, see <http://www.gnu.org/licenses/>.
// 
// ****************************************************************************

using System;
using System.Collections.Generic;

namespace eac3to
{
    /// <summary>A Stream</summary>
    public abstract class Stream
    {
        virtual public int Number { get; set; }
        virtual public string Name { get; set; }
        virtual public StreamType Type { get; set; }
        virtual public string Description { get; set; }
        virtual public string Language { get; set; }
        virtual public IList<string> ToolTip { get; set; }
        abstract public object[] ExtractTypes { get; }

        protected Stream() { }

        protected Stream(string s)
        {
            if (string.IsNullOrEmpty(s))
                throw new ArgumentNullException("s", "The string 's' cannot be null or empty.");

            Number = int.Parse(s.Substring(0, s.IndexOf(":")));
            Description = s.Substring(s.IndexOf(":") + 1).Trim();
            ToolTip = new List<string>();

            if (s.Contains("Joined EVO"))            
                Name = "Joined EVO";
            else if (s.Contains("Joined VOB"))
                Name = "Joined VOB";
            else if (s.Contains("Subtitle"))
                Name = s.Substring(s.LastIndexOf(",") + 1);
            else if (s.Contains(","))
                Name = s.Substring(s.IndexOf(":") + 1, s.IndexOf(',') - s.IndexOf(":") - 1).Trim();
            else
                Name = s.Substring(s.IndexOf(":") + 1).Trim();
        }

        public static Stream Parse(string s)
        {
            //EVO, 1 video track, 1 audio track, 3 subtitle tracks, 1:43:54
            //"director"

            if (string.IsNullOrEmpty(s))
                throw new ArgumentNullException("s", "The string 's' cannot be null or empty.");

            Stream stream = null;

            if (s.Contains("AVC") || s.Contains("VC-1") || s.Contains("MPEG") || s.Contains("DIRAC") || s.Contains("THEORA"))
                stream = VideoStream.Parse(s);
            else if (s.Contains("AC3") || s.Contains("TrueHD") || s.Contains("DTS") ||
                     s.Contains("RAW") || s.Contains("PCM") || s.Contains("MP") || s.Contains("AAC") ||
                     s.Contains("FLAC") || s.Contains("WAVPACK") || s.Contains("TTA") || s.Contains("VORBIS"))
                stream = AudioStream.Parse(s);
            else if (s.Contains("Subtitle"))
                stream = SubtitleStream.Parse(s);
            else if (s.Contains("Chapters"))
                stream = ChapterStream.Parse(s);
            else if (s.Contains("Joined"))
                stream = JoinStream.Parse(s);

            return stream;
        }

        public override string ToString()
        {
            //TODO: Increase context on filename
            /*
             * 1. When u extract say a sound track it comes of as ex: 1_8_audio.ac3 (thats a Swedish track),
             *    cant u add so it will auto write when extracted so it look something like ex: "1_8_Swedish_AC3_5.1ch_audio.ac3" insted
             * 2. Same goes for all the other extract:able chooices like subtitle now gets ex: 1_17_subtitle.sup,
             *    but better to get it direct to ex: 1_17_Swedish_subtitle.sup , add IF forced say ex: 1_17_Swedish_Forced_subtitle.sup
            */
            return string.Format("{0}: {1}", Number, Description);
        }
    }
}