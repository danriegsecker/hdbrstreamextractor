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
using System.Windows.Forms;
using System.Drawing;

namespace eac3toGUI
{
    /// <summary>A custom DataGridView with VerticalScrollBar always shown</summary>
    public class CustomDataGridView : DataGridView
    {
        public CustomDataGridView() : base()
        {
            AutoGenerateColumns = false;
            VerticalScrollBar.Visible = true;
            VerticalScrollBar.VisibleChanged += new EventHandler(VerticalScrollBar_VisibleChanged);
        }

        void VerticalScrollBar_VisibleChanged(object sender, EventArgs e)
        {
            if (!VerticalScrollBar.Visible)
            {
                VerticalScrollBar.Location = new Point(ClientRectangle.Width - VerticalScrollBar.Width, 1);
                VerticalScrollBar.Size = new Size(VerticalScrollBar.Width, ClientRectangle.Height - 1);// - HorizontalScrollBar.Height);
                VerticalScrollBar.Show();
            }

            VerticalScrollBar.Visible = true;
        }
    }
}