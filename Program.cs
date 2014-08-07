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
using System.Windows.Forms;

namespace eac3toGUI
{
    static class Program
    {
        /// <summary>The main entry point for the application.</summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string eac3toPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "eac3to.exe");

            if (!System.IO.File.Exists(eac3toPath))
            {
                MessageBox.Show("HD-DVD/Blu-Ray Stream Extractor must be run from the eac3to folder. Please restart the application in the correct location",
                    "Startup folder", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
#if !DEBUG
                return;
#endif
            }

            try
            {
                Application.Run(new HdBrStreamExtractor());
            }
            catch (Exception ex)
            {
                using (System.IO.StreamWriter SW = new System.IO.StreamWriter(System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "HdBrStreamExtractor.txt"), true))
                {
                    SW.WriteLine(string.Format("[{0}] {1}{2}", DateTime.Now.ToString("HH:mm:ss"), ex.Message, Environment.NewLine));
                    SW.WriteLine(string.Format("[{0}] {1}{2}", DateTime.Now.ToString("HH:mm:ss"), ex.TargetSite.Name, Environment.NewLine));
                    SW.WriteLine(string.Format("[{0}] {1}{2}", DateTime.Now.ToString("HH:mm:ss"), ex.Source, Environment.NewLine));
                    SW.WriteLine(string.Format("[{0}] {1}{2}", DateTime.Now.ToString("HH:mm:ss"), ex.StackTrace, Environment.NewLine));
                    SW.Close();
                }

                MessageBox.Show(string.Format("Message: {0}\r\nSource: {1}\r\nStack Trace: {2}", ex.Message, ex.Source, ex.StackTrace),
                    "Application Exception", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                if(Cursor.Current != Cursors.Default)
                    Cursor.Current = Cursors.Default;
            }
        }
    }
}