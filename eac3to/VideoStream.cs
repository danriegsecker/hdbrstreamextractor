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
    /// <summary>A Stream of StreamType Video</summary>
    public class VideoStream : Stream
    {
        public VideoStreamType VideoType { get; set; }
        public string Resolution { get; set; }
        public bool IsProgerssive { get; set; }
        public double Framerate { get; set; }
        public double Ratio { get; set; }

        public override object[] ExtractTypes
        {
            get
            {
                switch (VideoType)
                {
                    case VideoStreamType.AVC:
                        return new object[] { "MKV", "H264" };
                    case VideoStreamType.VC1:
                        return new object[] { "MKV", "VC1" };
                    case VideoStreamType.MPEG:
                        return new object[] { "MKV", "M2V" };
                    case VideoStreamType.THEORA:
                        return new object[] { "MKV", "OGG" };
                    case VideoStreamType.DIRAC:
                        return new object[] { "MKV", "DRC" };
                    default:
                        return new object[] { "MKV" };
                }
            }
        }

        public VideoStream(string s) : base(s)
        {
            if (string.IsNullOrEmpty(s))
                throw new ArgumentNullException("s", "The string 's' cannot be null or empty.");

            base.Type = StreamType.Video;
        }

        new public static Stream Parse(string s)
        {
            //3: VC-1, 1080p24 /1.001 (16:9) with pulldown flags

            if (string.IsNullOrEmpty(s))
                throw new ArgumentNullException("s", "The string 's' cannot be null or empty.");

            VideoStream videoStream = new VideoStream(s);

            switch (videoStream.Name.ToUpper())
            {
                case "AVC":
                    videoStream.VideoType = VideoStreamType.AVC;
                    break;
                case "VC-1":
                    videoStream.VideoType = VideoStreamType.VC1;
                    break;
                case "MPEG":
                case "MPEG2":
                    videoStream.VideoType = VideoStreamType.MPEG;
                    break;
                case "THEORA":
                    videoStream.VideoType = VideoStreamType.THEORA;
                    break;
                case "DIRAC":
                    videoStream.VideoType = VideoStreamType.DIRAC;
                    break;
            }

            return videoStream;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}