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
    /// <summary>A Stream of StreamType Chapters</summary>
    public class ChapterStream : Stream
    {
        /// <summary> A list of chapters</summary>
        public IList<Chapter> Chapters { get; set; }

        public override object[] ExtractTypes
        {
            get
            {
                return new object[] { "TXT" };
            }
        }

        public ChapterStream(string s) : base(s)
        {
            if (string.IsNullOrEmpty(s))
                throw new ArgumentNullException("s", "The string 's' cannot be null or empty.");

            base.Type = StreamType.Chapter;
        }

        new public static Stream Parse(string s)
        {
            //2: Chapters, 27 chapters without names

            if (string.IsNullOrEmpty(s))
                throw new ArgumentNullException("s", "The string 's' cannot be null or empty.");

            return new ChapterStream(s);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}