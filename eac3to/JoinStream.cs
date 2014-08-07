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
    /// <summary>A Stream of StreamType Join</summary>
    public class JoinStream : Stream
    {
        public JoinStreamType JoinType { get; set; }

        public override object[] ExtractTypes
        {
            get
            {
                switch (JoinType)
                {
                    case JoinStreamType.EVO:
                        return new object[] { "EVO" };
                    case JoinStreamType.VOB:
                        return new object[] { "VOB" };
                    default:
                        return new object[] { string.Empty };
                }
            }
        }

        public JoinStream(string s) : base(s)
        {
            if (string.IsNullOrEmpty(s))
                throw new ArgumentNullException("s", "The string 's' cannot be null or empty.");

            base.Type = StreamType.Join;
        }

        new public static Stream Parse(string s)
        {
            //1: Joined EVO file

            if (string.IsNullOrEmpty(s))
                throw new ArgumentNullException("s", "The string 's' cannot be null or empty.");

            JoinStream joinStream = new JoinStream(s);

            //TODO: Are there other join types? (i.e. M2TS)
            switch(joinStream.Name.ToUpper())
            {
                case "EVO":
                    joinStream.JoinType = JoinStreamType.EVO;
                    break;
                case "VOB":
                    joinStream.JoinType = JoinStreamType.VOB;
                    break;
            }

            return joinStream;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}