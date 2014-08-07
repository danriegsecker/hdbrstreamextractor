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
using eac3toGUI;

namespace eac3to
{
    /// <summary>An enumeration of Audio Stream types</summary>
    [Flags]
    public enum AudioStreamType
    {
        [StringValue("AAC")]
        AAC,
        [StringValue("AC3")]
        AC3,
        [StringValue("E-AC3")]
        EAC3,
        [StringValue("DTS")]
        DTS,
        [StringValue("TrueHD")]
        TrueHD,
        [StringValue("RAW")]
        RAW,
        [StringValue("PCM")]
        PCM,
        [StringValue("WAV")]
        WAV,
        [StringValue("Multi-Channel WAV")]
        WAVS,
        [StringValue("MP2")]
        MP2,
        [StringValue("MP3")]
        MP3,
        [StringValue("FLAC")]
        FLAC,
        [StringValue("TTA1")]
        TTA,
        [StringValue("WAVPACK4")]
        WAVPACK,
        [StringValue("VORBIS")]
        VORBIS
    }
}