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

namespace eac3to
{
    /// <summary>A Stream of StreamType Subtitle</summary>
    public class SubtitleStream : Stream
    {
        public SubtitleStreamType SubtitleType { get; set; }
        public bool IsForced { get; set; }
        public bool IsSDH { get; set; }

        public override object[] ExtractTypes
        {
            get
            {
                switch (SubtitleType)
                {
                    case SubtitleStreamType.ASS:
                        return new object[] { "ASS" };
                    case SubtitleStreamType.SSA:
                        return new object[] { "SSA" };
                    case SubtitleStreamType.SRT:
                        return new object[] { "SRT" };
                    case SubtitleStreamType.SUB:
                        return new object[] { "IDX" };
                    case SubtitleStreamType.SUP:
                    default:
                        return new object[] { "SUP" };
                }
            }
        }

        public SubtitleStream(string s) : base(s)
        {
            if (string.IsNullOrEmpty(s))
                throw new ArgumentNullException("s", "The string 's' cannot be null or empty.");

            base.Type = StreamType.Subtitle;
        }

        new public static Stream Parse(string s)
        {
            //5: Subtitle, English, "SDH"
            //6: Subtitle, French
            //7: Subtitle, Spanish

            if (string.IsNullOrEmpty(s))
                throw new ArgumentNullException("s", "The string 's' cannot be null or empty.");

            SubtitleStream subtitleStream = new SubtitleStream(s);

            switch (subtitleStream.Description.ToUpper().Substring(subtitleStream.Description.IndexOf('(') + 1, 3))
            {
                case "ASS":
                    subtitleStream.SubtitleType = SubtitleStreamType.ASS;
                    break;
                case "SSA":
                    subtitleStream.SubtitleType = SubtitleStreamType.SSA;
                    break;
                case "SRT":
                    subtitleStream.SubtitleType = SubtitleStreamType.SRT;
                    break;
                case "VOB":
                    subtitleStream.SubtitleType = SubtitleStreamType.SUB;
                    break;
                case "SUP":
                default:
                    subtitleStream.SubtitleType = SubtitleStreamType.SUP;
                    break;
            }

            subtitleStream.Language = (s.IndexOf(',') == s.LastIndexOf(',')) ? s.Substring(s.IndexOf(',') + 1).Trim() : s.Substring(s.IndexOf(',') + 1, s.LastIndexOf(',') - s.IndexOf(',') - 1).Trim();
            subtitleStream.IsSDH = s.Contains("\"SDH\"");

            return subtitleStream;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}