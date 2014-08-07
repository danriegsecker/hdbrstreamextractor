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
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using eac3to;
using System.Drawing;

namespace eac3toGUI
{
    public class HdBrStreamExtractor : System.Windows.Forms.Form
    {
        List<Feature> features;
        BackgroundWorker backgroundWorker;
        string eac3toPath;

        #region Windows Form Designer generated code
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.BindingSource FeatureBindingSource;
        private System.Windows.Forms.BindingSource StreamsBindingSource;
        private System.Windows.Forms.TextBox LogTextBox;
        private System.Windows.Forms.LinkLabel Eac3toLinkLabel;
        private System.Windows.Forms.Button ExtractButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar ToolStripProgressBar;
        private OpenFileDialog openFileDialog1;
        private ToolTip toolTip1;
        private DataGridViewTextBoxColumn numberDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn Column1;
        private LinkLabel HelpLinkLabel;
        private SplitContainer splitContainer1;
        private GroupBox InputGroupBox;
        private Button FileInputSourceButton;
        private Button FolderInputSourceButton;
        private TextBox InputSourceTextBox;
        private GroupBox OutputGroupBox;
        private Button FolderOutputSourceButton;
        private TextBox FolderOutputTextBox;
        private SplitContainer splitContainer2;
        private GroupBox FeatureGroupBox;
        private LinkLabel FeatureLinkLabel;
        private CustomDataGridView FeatureDataGridView;
        private GroupBox StreamGroupBox;
        private CustomDataGridView StreamDataGridView;
        private DataGridViewTextBoxColumn FeatureNumberDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn FeatureNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn FeatureDescriptionDataGridViewTextBoxColumn;
        private DataGridViewComboBoxColumn FeatureFileDataGridViewComboBoxColumn;
        private DataGridViewTextBoxColumn FeatureDurationDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn StreamExtractCheckBox;
        private DataGridViewTextBoxColumn StreamNumberTextBox;
        private DataGridViewTextBoxColumn StreamTypeTextBox;
        private DataGridViewTextBoxColumn StreamDescriptionTextBox;
        private DataGridViewComboBoxColumn StreamExtractAsComboBox;
        private DataGridViewTextBoxColumn StreamAddOptionsTextBox;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HdBrStreamExtractor));
            this.LogTextBox = new System.Windows.Forms.TextBox();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.ToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.ExtractButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.Eac3toLinkLabel = new System.Windows.Forms.LinkLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.FileInputSourceButton = new System.Windows.Forms.Button();
            this.FolderInputSourceButton = new System.Windows.Forms.Button();
            this.FolderOutputSourceButton = new System.Windows.Forms.Button();
            this.FeatureLinkLabel = new System.Windows.Forms.LinkLabel();
            this.HelpLinkLabel = new System.Windows.Forms.LinkLabel();
            this.numberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.InputGroupBox = new System.Windows.Forms.GroupBox();
            this.InputSourceTextBox = new System.Windows.Forms.TextBox();
            this.OutputGroupBox = new System.Windows.Forms.GroupBox();
            this.FolderOutputTextBox = new System.Windows.Forms.TextBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.FeatureGroupBox = new System.Windows.Forms.GroupBox();
            this.StreamGroupBox = new System.Windows.Forms.GroupBox();
            this.FeatureDataGridView = new eac3toGUI.CustomDataGridView();
            this.FeatureNumberDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FeatureNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FeatureDescriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FeatureFileDataGridViewComboBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.FeatureDurationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FeatureBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.StreamDataGridView = new eac3toGUI.CustomDataGridView();
            this.StreamsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.StreamExtractCheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.StreamNumberTextBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StreamTypeTextBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StreamDescriptionTextBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StreamExtractAsComboBox = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.StreamAddOptionsTextBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.InputGroupBox.SuspendLayout();
            this.OutputGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.FeatureGroupBox.SuspendLayout();
            this.StreamGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FeatureDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FeatureBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StreamDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StreamsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // LogTextBox
            // 
            this.LogTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogTextBox.Location = new System.Drawing.Point(12, 357);
            this.LogTextBox.Multiline = true;
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.ReadOnly = true;
            this.LogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogTextBox.Size = new System.Drawing.Size(560, 51);
            this.LogTextBox.TabIndex = 7;
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripStatusLabel,
            this.ToolStripProgressBar});
            this.StatusStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.StatusStrip.Location = new System.Drawing.Point(0, 440);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.ShowItemToolTips = true;
            this.StatusStrip.Size = new System.Drawing.Size(584, 22);
            this.StatusStrip.SizingGrip = false;
            this.StatusStrip.TabIndex = 11;
            // 
            // ToolStripStatusLabel
            // 
            this.ToolStripStatusLabel.AutoSize = false;
            this.ToolStripStatusLabel.Name = "ToolStripStatusLabel";
            this.ToolStripStatusLabel.Size = new System.Drawing.Size(358, 17);
            this.ToolStripStatusLabel.Text = "Ready";
            this.ToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolStripStatusLabel.ToolTipText = "Status";
            // 
            // ToolStripProgressBar
            // 
            this.ToolStripProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ToolStripProgressBar.Name = "ToolStripProgressBar";
            this.ToolStripProgressBar.Size = new System.Drawing.Size(200, 16);
            this.ToolStripProgressBar.ToolTipText = "Progress";
            // 
            // ExtractButton
            // 
            this.ExtractButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ExtractButton.Location = new System.Drawing.Point(416, 414);
            this.ExtractButton.Name = "ExtractButton";
            this.ExtractButton.Size = new System.Drawing.Size(75, 23);
            this.ExtractButton.TabIndex = 9;
            this.ExtractButton.Text = "Extract";
            this.toolTip1.SetToolTip(this.ExtractButton, "Click to extract selected streams");
            this.ExtractButton.UseVisualStyleBackColor = true;
            this.ExtractButton.Click += new System.EventHandler(this.ExtractButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Enabled = false;
            this.CancelButton.Location = new System.Drawing.Point(497, 414);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 10;
            this.CancelButton.Text = "Cancel";
            this.toolTip1.SetToolTip(this.CancelButton, "Click to cancel");
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // Eac3toLinkLabel
            // 
            this.Eac3toLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Eac3toLinkLabel.AutoSize = true;
            this.Eac3toLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Eac3toLinkLabel.Location = new System.Drawing.Point(51, 417);
            this.Eac3toLinkLabel.Name = "Eac3toLinkLabel";
            this.Eac3toLinkLabel.Size = new System.Drawing.Size(44, 15);
            this.Eac3toLinkLabel.TabIndex = 13;
            this.Eac3toLinkLabel.TabStop = true;
            this.Eac3toLinkLabel.Text = "eac3to";
            this.toolTip1.SetToolTip(this.Eac3toLinkLabel, "Click to visit eac3to thread on Doom9 forum");
            this.Eac3toLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Eac3toLinkLabel_LinkClicked);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "All files|*.*|EVO files|*.evo|VOB files|*.vob|(M2)TS files|*.mts;*.m2ts;*.ts|MPLS" +
    " Playlist|*.mpls|Matroska Video file|*.mkv";
            this.openFileDialog1.FilterIndex = 0;
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.SupportMultiDottedExtensions = true;
            this.openFileDialog1.Title = "Choose the input file(s)";
            // 
            // FileInputSourceButton
            // 
            this.FileInputSourceButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FileInputSourceButton.AutoSize = true;
            this.FileInputSourceButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FileInputSourceButton.BackgroundImage = global::HdBrStreamExtractor.Properties.Resources.copy_24;
            this.FileInputSourceButton.Location = new System.Drawing.Point(219, 14);
            this.FileInputSourceButton.Name = "FileInputSourceButton";
            this.FileInputSourceButton.Size = new System.Drawing.Size(26, 23);
            this.FileInputSourceButton.TabIndex = 13;
            this.FileInputSourceButton.Text = "   ";
            this.toolTip1.SetToolTip(this.FileInputSourceButton, "Select Input File(s)");
            this.FileInputSourceButton.UseVisualStyleBackColor = false;
            this.FileInputSourceButton.Click += new System.EventHandler(this.FileInputSourceButton_Click);
            // 
            // FolderInputSourceButton
            // 
            this.FolderInputSourceButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FolderInputSourceButton.AutoSize = true;
            this.FolderInputSourceButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FolderInputSourceButton.BackgroundImage = global::HdBrStreamExtractor.Properties.Resources.folder_24;
            this.FolderInputSourceButton.Location = new System.Drawing.Point(251, 14);
            this.FolderInputSourceButton.Name = "FolderInputSourceButton";
            this.FolderInputSourceButton.Size = new System.Drawing.Size(26, 23);
            this.FolderInputSourceButton.TabIndex = 12;
            this.FolderInputSourceButton.Text = "   ";
            this.toolTip1.SetToolTip(this.FolderInputSourceButton, "Select Input Folder");
            this.FolderInputSourceButton.UseVisualStyleBackColor = true;
            this.FolderInputSourceButton.Click += new System.EventHandler(this.FolderInputSourceButton_Click);
            // 
            // FolderOutputSourceButton
            // 
            this.FolderOutputSourceButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FolderOutputSourceButton.AutoSize = true;
            this.FolderOutputSourceButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FolderOutputSourceButton.BackgroundImage = global::HdBrStreamExtractor.Properties.Resources.folder_24;
            this.FolderOutputSourceButton.Location = new System.Drawing.Point(250, 14);
            this.FolderOutputSourceButton.Name = "FolderOutputSourceButton";
            this.FolderOutputSourceButton.Size = new System.Drawing.Size(26, 23);
            this.FolderOutputSourceButton.TabIndex = 13;
            this.FolderOutputSourceButton.Text = "   ";
            this.toolTip1.SetToolTip(this.FolderOutputSourceButton, "Select Output Folder");
            this.FolderOutputSourceButton.UseVisualStyleBackColor = true;
            this.FolderOutputSourceButton.Click += new System.EventHandler(this.FolderOutputSourceButton_Click);
            // 
            // FeatureLinkLabel
            // 
            this.FeatureLinkLabel.AutoSize = true;
            this.FeatureLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FeatureLinkLabel.Location = new System.Drawing.Point(6, -2);
            this.FeatureLinkLabel.Name = "FeatureLinkLabel";
            this.FeatureLinkLabel.Size = new System.Drawing.Size(63, 15);
            this.FeatureLinkLabel.TabIndex = 16;
            this.FeatureLinkLabel.TabStop = true;
            this.FeatureLinkLabel.Text = "Feature(s)";
            this.toolTip1.SetToolTip(this.FeatureLinkLabel, "Click to retrieve Feature(s)");
            this.FeatureLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.FeatureLinkLabel_LinkClicked);
            // 
            // HelpLinkLabel
            // 
            this.HelpLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.HelpLinkLabel.AutoSize = true;
            this.HelpLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpLinkLabel.Location = new System.Drawing.Point(12, 417);
            this.HelpLinkLabel.Name = "HelpLinkLabel";
            this.HelpLinkLabel.Size = new System.Drawing.Size(33, 15);
            this.HelpLinkLabel.TabIndex = 13;
            this.HelpLinkLabel.TabStop = true;
            this.HelpLinkLabel.Text = "Help";
            this.toolTip1.SetToolTip(this.HelpLinkLabel, "Click to visit HdBrStreamExtractor thread on Doom9 forum");
            this.HelpLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.HelpLinkLabel_LinkClicked);
            // 
            // numberDataGridViewTextBoxColumn
            // 
            this.numberDataGridViewTextBoxColumn.DataPropertyName = "Number";
            this.numberDataGridViewTextBoxColumn.HeaderText = "Number";
            this.numberDataGridViewTextBoxColumn.Name = "numberDataGridViewTextBoxColumn";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // typeDataGridViewTextBoxColumn
            // 
            this.typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
            this.typeDataGridViewTextBoxColumn.HeaderText = "Type";
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Number";
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(9, 9);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.InputGroupBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.OutputGroupBox);
            this.splitContainer1.Size = new System.Drawing.Size(566, 49);
            this.splitContainer1.SplitterDistance = 283;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 16;
            // 
            // InputGroupBox
            // 
            this.InputGroupBox.Controls.Add(this.FileInputSourceButton);
            this.InputGroupBox.Controls.Add(this.FolderInputSourceButton);
            this.InputGroupBox.Controls.Add(this.InputSourceTextBox);
            this.InputGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InputGroupBox.Location = new System.Drawing.Point(0, 0);
            this.InputGroupBox.Name = "InputGroupBox";
            this.InputGroupBox.Size = new System.Drawing.Size(283, 49);
            this.InputGroupBox.TabIndex = 18;
            this.InputGroupBox.TabStop = false;
            this.InputGroupBox.Text = "Input";
            // 
            // InputSourceTextBox
            // 
            this.InputSourceTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputSourceTextBox.Location = new System.Drawing.Point(6, 16);
            this.InputSourceTextBox.Name = "InputSourceTextBox";
            this.InputSourceTextBox.Size = new System.Drawing.Size(207, 20);
            this.InputSourceTextBox.TabIndex = 0;
            // 
            // OutputGroupBox
            // 
            this.OutputGroupBox.Controls.Add(this.FolderOutputSourceButton);
            this.OutputGroupBox.Controls.Add(this.FolderOutputTextBox);
            this.OutputGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OutputGroupBox.Location = new System.Drawing.Point(0, 0);
            this.OutputGroupBox.Name = "OutputGroupBox";
            this.OutputGroupBox.Size = new System.Drawing.Size(282, 49);
            this.OutputGroupBox.TabIndex = 19;
            this.OutputGroupBox.TabStop = false;
            this.OutputGroupBox.Text = "Output";
            // 
            // FolderOutputTextBox
            // 
            this.FolderOutputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FolderOutputTextBox.Location = new System.Drawing.Point(6, 16);
            this.FolderOutputTextBox.Name = "FolderOutputTextBox";
            this.FolderOutputTextBox.Size = new System.Drawing.Size(238, 20);
            this.FolderOutputTextBox.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.Location = new System.Drawing.Point(9, 58);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.FeatureGroupBox);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.StreamGroupBox);
            this.splitContainer2.Size = new System.Drawing.Size(566, 296);
            this.splitContainer2.SplitterDistance = 110;
            this.splitContainer2.SplitterWidth = 1;
            this.splitContainer2.TabIndex = 17;
            // 
            // FeatureGroupBox
            // 
            this.FeatureGroupBox.Controls.Add(this.FeatureLinkLabel);
            this.FeatureGroupBox.Controls.Add(this.FeatureDataGridView);
            this.FeatureGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FeatureGroupBox.Location = new System.Drawing.Point(0, 0);
            this.FeatureGroupBox.Name = "FeatureGroupBox";
            this.FeatureGroupBox.Size = new System.Drawing.Size(566, 110);
            this.FeatureGroupBox.TabIndex = 15;
            this.FeatureGroupBox.TabStop = false;
            // 
            // StreamGroupBox
            // 
            this.StreamGroupBox.Controls.Add(this.StreamDataGridView);
            this.StreamGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StreamGroupBox.Location = new System.Drawing.Point(0, 0);
            this.StreamGroupBox.Name = "StreamGroupBox";
            this.StreamGroupBox.Size = new System.Drawing.Size(566, 185);
            this.StreamGroupBox.TabIndex = 16;
            this.StreamGroupBox.TabStop = false;
            this.StreamGroupBox.Text = "Stream(s)";
            // 
            // FeatureDataGridView
            // 
            this.FeatureDataGridView.AllowUserToAddRows = false;
            this.FeatureDataGridView.AllowUserToDeleteRows = false;
            this.FeatureDataGridView.AllowUserToResizeColumns = false;
            this.FeatureDataGridView.AllowUserToResizeRows = false;
            this.FeatureDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FeatureDataGridView.AutoGenerateColumns = false;
            this.FeatureDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.FeatureDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.FeatureDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FeatureDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FeatureNumberDataGridViewTextBoxColumn1,
            this.FeatureNameDataGridViewTextBoxColumn,
            this.FeatureDescriptionDataGridViewTextBoxColumn,
            this.FeatureFileDataGridViewComboBoxColumn,
            this.FeatureDurationDataGridViewTextBoxColumn});
            this.FeatureDataGridView.DataSource = this.FeatureBindingSource;
            this.FeatureDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.FeatureDataGridView.Location = new System.Drawing.Point(6, 16);
            this.FeatureDataGridView.MultiSelect = false;
            this.FeatureDataGridView.Name = "FeatureDataGridView";
            this.FeatureDataGridView.RowHeadersVisible = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.FeatureDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.FeatureDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.FeatureDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.FeatureDataGridView.ShowEditingIcon = false;
            this.FeatureDataGridView.Size = new System.Drawing.Size(554, 88);
            this.FeatureDataGridView.TabIndex = 13;
            this.FeatureDataGridView.Tag = "0";
            this.FeatureDataGridView.DataSourceChanged += new System.EventHandler(this.FeatureDataGridView_DataSourceChanged);
            this.FeatureDataGridView.SelectionChanged += new System.EventHandler(this.FeatureDataGridView_SelectionChanged);
            // 
            // FeatureNumberDataGridViewTextBoxColumn1
            // 
            this.FeatureNumberDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FeatureNumberDataGridViewTextBoxColumn1.DataPropertyName = "Number";
            this.FeatureNumberDataGridViewTextBoxColumn1.FillWeight = 5F;
            this.FeatureNumberDataGridViewTextBoxColumn1.HeaderText = "#";
            this.FeatureNumberDataGridViewTextBoxColumn1.MinimumWidth = 26;
            this.FeatureNumberDataGridViewTextBoxColumn1.Name = "FeatureNumberDataGridViewTextBoxColumn1";
            this.FeatureNumberDataGridViewTextBoxColumn1.ReadOnly = true;
            this.FeatureNumberDataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.FeatureNumberDataGridViewTextBoxColumn1.ToolTipText = "Feature number";
            // 
            // FeatureNameDataGridViewTextBoxColumn
            // 
            this.FeatureNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FeatureNameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.FeatureNameDataGridViewTextBoxColumn.FillWeight = 20F;
            this.FeatureNameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.FeatureNameDataGridViewTextBoxColumn.MinimumWidth = 125;
            this.FeatureNameDataGridViewTextBoxColumn.Name = "FeatureNameDataGridViewTextBoxColumn";
            this.FeatureNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.FeatureNameDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.FeatureNameDataGridViewTextBoxColumn.ToolTipText = "Feature name";
            // 
            // FeatureDescriptionDataGridViewTextBoxColumn
            // 
            this.FeatureDescriptionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FeatureDescriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.FeatureDescriptionDataGridViewTextBoxColumn.FillWeight = 50F;
            this.FeatureDescriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.FeatureDescriptionDataGridViewTextBoxColumn.MinimumWidth = 244;
            this.FeatureDescriptionDataGridViewTextBoxColumn.Name = "FeatureDescriptionDataGridViewTextBoxColumn";
            this.FeatureDescriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.FeatureDescriptionDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.FeatureDescriptionDataGridViewTextBoxColumn.ToolTipText = "Feature description";
            // 
            // FeatureFileDataGridViewComboBoxColumn
            // 
            this.FeatureFileDataGridViewComboBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FeatureFileDataGridViewComboBoxColumn.FillWeight = 15F;
            this.FeatureFileDataGridViewComboBoxColumn.HeaderText = "File(s)";
            this.FeatureFileDataGridViewComboBoxColumn.MinimumWidth = 90;
            this.FeatureFileDataGridViewComboBoxColumn.Name = "FeatureFileDataGridViewComboBoxColumn";
            this.FeatureFileDataGridViewComboBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.FeatureFileDataGridViewComboBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.FeatureFileDataGridViewComboBoxColumn.ToolTipText = "Feature File(s)";
            // 
            // FeatureDurationDataGridViewTextBoxColumn
            // 
            this.FeatureDurationDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FeatureDurationDataGridViewTextBoxColumn.DataPropertyName = "Duration";
            this.FeatureDurationDataGridViewTextBoxColumn.FillWeight = 10F;
            this.FeatureDurationDataGridViewTextBoxColumn.HeaderText = "Duration";
            this.FeatureDurationDataGridViewTextBoxColumn.MinimumWidth = 52;
            this.FeatureDurationDataGridViewTextBoxColumn.Name = "FeatureDurationDataGridViewTextBoxColumn";
            this.FeatureDurationDataGridViewTextBoxColumn.ReadOnly = true;
            this.FeatureDurationDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // FeatureBindingSource
            // 
            this.FeatureBindingSource.AllowNew = false;
            this.FeatureBindingSource.DataSource = typeof(eac3to.Feature);
            // 
            // StreamDataGridView
            // 
            this.StreamDataGridView.AllowUserToAddRows = false;
            this.StreamDataGridView.AllowUserToDeleteRows = false;
            this.StreamDataGridView.AllowUserToResizeColumns = false;
            this.StreamDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            this.StreamDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.StreamDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StreamDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.StreamDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.StreamDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StreamDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StreamExtractCheckBox,
            this.StreamNumberTextBox,
            this.StreamTypeTextBox,
            this.StreamDescriptionTextBox,
            this.StreamExtractAsComboBox,
            this.StreamAddOptionsTextBox});
            this.StreamDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.StreamDataGridView.Location = new System.Drawing.Point(6, 18);
            this.StreamDataGridView.MultiSelect = false;
            this.StreamDataGridView.Name = "StreamDataGridView";
            this.StreamDataGridView.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.StreamDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.StreamDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.StreamDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.StreamDataGridView.ShowEditingIcon = false;
            this.StreamDataGridView.Size = new System.Drawing.Size(554, 160);
            this.StreamDataGridView.TabIndex = 7;
            this.StreamDataGridView.DataSourceChanged += new System.EventHandler(this.StreamDataGridView_DataSourceChanged);
            // 
            // StreamsBindingSource
            // 
            this.StreamsBindingSource.AllowNew = false;
            this.StreamsBindingSource.DataSource = typeof(eac3to.Stream);
            // 
            // StreamExtractCheckBox
            // 
            this.StreamExtractCheckBox.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.StreamExtractCheckBox.FalseValue = "0";
            this.StreamExtractCheckBox.FillWeight = 10F;
            this.StreamExtractCheckBox.HeaderText = "Extract?";
            this.StreamExtractCheckBox.IndeterminateValue = "-1";
            this.StreamExtractCheckBox.MinimumWidth = 55;
            this.StreamExtractCheckBox.Name = "StreamExtractCheckBox";
            this.StreamExtractCheckBox.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.StreamExtractCheckBox.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.StreamExtractCheckBox.ToolTipText = "Extract stream?";
            this.StreamExtractCheckBox.TrueValue = "1";
            // 
            // StreamNumberTextBox
            // 
            this.StreamNumberTextBox.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.StreamNumberTextBox.DataPropertyName = "Number";
            this.StreamNumberTextBox.FillWeight = 5F;
            this.StreamNumberTextBox.HeaderText = "#";
            this.StreamNumberTextBox.MinimumWidth = 28;
            this.StreamNumberTextBox.Name = "StreamNumberTextBox";
            this.StreamNumberTextBox.ReadOnly = true;
            this.StreamNumberTextBox.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.StreamNumberTextBox.ToolTipText = "Stream Number";
            // 
            // StreamTypeTextBox
            // 
            this.StreamTypeTextBox.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.StreamTypeTextBox.DataPropertyName = "Type";
            this.StreamTypeTextBox.FillWeight = 10F;
            this.StreamTypeTextBox.HeaderText = "Type";
            this.StreamTypeTextBox.MinimumWidth = 55;
            this.StreamTypeTextBox.Name = "StreamTypeTextBox";
            this.StreamTypeTextBox.ReadOnly = true;
            this.StreamTypeTextBox.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.StreamTypeTextBox.ToolTipText = "Stream type";
            // 
            // StreamDescriptionTextBox
            // 
            this.StreamDescriptionTextBox.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.StreamDescriptionTextBox.DataPropertyName = "Description";
            this.StreamDescriptionTextBox.FillWeight = 45F;
            this.StreamDescriptionTextBox.HeaderText = "Description";
            this.StreamDescriptionTextBox.MinimumWidth = 250;
            this.StreamDescriptionTextBox.Name = "StreamDescriptionTextBox";
            this.StreamDescriptionTextBox.ReadOnly = true;
            this.StreamDescriptionTextBox.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.StreamDescriptionTextBox.ToolTipText = "Stream description";
            // 
            // StreamExtractAsComboBox
            // 
            this.StreamExtractAsComboBox.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.StreamExtractAsComboBox.FillWeight = 12F;
            this.StreamExtractAsComboBox.HeaderText = "Extract As";
            this.StreamExtractAsComboBox.MinimumWidth = 72;
            this.StreamExtractAsComboBox.Name = "StreamExtractAsComboBox";
            this.StreamExtractAsComboBox.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.StreamExtractAsComboBox.ToolTipText = "Stream extract type";
            // 
            // StreamAddOptionsTextBox
            // 
            this.StreamAddOptionsTextBox.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.StreamAddOptionsTextBox.FillWeight = 13F;
            this.StreamAddOptionsTextBox.HeaderText = "+ Options";
            this.StreamAddOptionsTextBox.MinimumWidth = 65;
            this.StreamAddOptionsTextBox.Name = "StreamAddOptionsTextBox";
            this.StreamAddOptionsTextBox.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.StreamAddOptionsTextBox.ToolTipText = "Stream extract additional options";
            // 
            // HdBrStreamExtractor
            // 
            this.AcceptButton = this.ExtractButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 462);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.HelpLinkLabel);
            this.Controls.Add(this.Eac3toLinkLabel);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.ExtractButton);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.LogTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 500);
            this.Name = "HdBrStreamExtractor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HD-DVD/Blu-ray Stream Extractor ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HdBrStreamExtractor_FormClosing);
            this.Load += new System.EventHandler(this.HdBrStreamExtractor_Load);
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.InputGroupBox.ResumeLayout(false);
            this.InputGroupBox.PerformLayout();
            this.OutputGroupBox.ResumeLayout(false);
            this.OutputGroupBox.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.FeatureGroupBox.ResumeLayout(false);
            this.FeatureGroupBox.PerformLayout();
            this.StreamGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FeatureDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FeatureBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StreamDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StreamsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        public HdBrStreamExtractor()
        {
            InitializeComponent();

            eac3toPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "eac3to.exe");

            /*TODO: Use undocumented argument '-neroaacenc="[path to neroaacenc.exe]"'
             * Need to check if file exists prior, if not, state an update is reqiuired.
            */
        }

        struct eac3toArgs
        {
            public string eac3toPath { get; set; }
            public string inputPath { get; set; }
            public string workingFolder { get; set; }
            public string featureNumber { get; set; }
            public string args { get; set; }
            public ResultState resultState { get; set; }

            public eac3toArgs(string eac3toPath, string inputPath, string args) : this()
            {
                this.eac3toPath = eac3toPath;
                this.inputPath = inputPath;
                this.args = args;
            }
        }

        public enum ResultState
        {
            [StringValue("Feature Retrieval Completed")]
            FeatureCompleted,
            [StringValue("Stream Retrieval Completed")]
            StreamCompleted,
            [StringValue("Stream Extraction Completed")]
            ExtractCompleted
        }

        #region backgroundWorker
        void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            eac3toArgs args = (eac3toArgs)e.Argument;

            using (Process process = new Process())
            {
                process.StartInfo.FileName = args.eac3toPath;
                process.StartInfo.FileName = @"C:\Users\mgriffor\Documents\Visual Studio 2012\Projects\HdBrStreamExtractor\trunk\Tester\bin\Debug\Tester.exe";

                switch (args.resultState)
                {
                    case ResultState.FeatureCompleted:
                        process.StartInfo.Arguments = string.Format("\"{0}\"", args.inputPath);
                        process.StartInfo.Arguments = string.Concat("\"", System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "feature.txt"), "\"");
                        break;
                    case ResultState.StreamCompleted:
                        process.StartInfo.Arguments = string.Format("\"{0}\" {1}) {2}", args.inputPath, args.args, "-progressnumbers");
                        process.StartInfo.Arguments = string.Concat("\"", System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "stream.txt"), "\"");
                        break;
                    case ResultState.ExtractCompleted:
                        if (InputSourceTextBox.Tag.ToString() == "File")
                            process.StartInfo.Arguments = string.Format("\"{0}\" {1}", args.inputPath, args.args + " -progressnumbers");
                        else
                            process.StartInfo.Arguments = string.Format("\"{0}\" {1}) {2}", args.inputPath, args.featureNumber, args.args + " -progressnumbers");

                        string value = process.StartInfo.Arguments;

                        if (Control.ModifierKeys == Keys.Control)
                            if (InputBox("Arguments", "Review or modify arguments:", ref value) == DialogResult.OK)
                                process.StartInfo.Arguments = value;
                        break;
                }

                WriteToLog(string.Format("Arguments: {0}", process.StartInfo.Arguments));

                process.StartInfo.WorkingDirectory = args.workingFolder;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.ErrorDialog = false;
                process.EnableRaisingEvents = true;
                process.EnableRaisingEvents = true;
                process.Exited += new EventHandler(backgroundWorker_Exited);
                process.ErrorDataReceived += new DataReceivedEventHandler(backgroundWorker_ErrorDataReceived);
                process.OutputDataReceived += new DataReceivedEventHandler(backgroundWorker_OutputDataReceived);

                try
                {
                    process.Start();
                    process.PriorityBoostEnabled = true;
                    process.BeginErrorReadLine();
                    process.BeginOutputReadLine();

                    while (!process.HasExited)
                    {
                        if (backgroundWorker.CancellationPending)
                            process.Kill();

                        // Do not monopolize resource, relinquish some time
                        Thread.Sleep(250);
                    }

                    process.WaitForExit();
                }
                catch (Exception ex)
                {
                    //e.Cancel = true;
                    //e.Result = ex.Message;
                    WriteToLog(ex.Message);
                }
                finally
                {
                    process.ErrorDataReceived -= new DataReceivedEventHandler(backgroundWorker_ErrorDataReceived);
                    process.OutputDataReceived -= new DataReceivedEventHandler(backgroundWorker_OutputDataReceived);
                }
            }

            e.Result = args.resultState;
        }

        void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            SetProgress(e.ProgressPercentage);

            if (e.UserState != null)
                ToolStripStatusLabel.Text = e.UserState.ToString();
        }

        void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CancelButton.Enabled = false;

            if (e.Cancelled)
                WriteToLog("Work was cancelled");

            if (e.Error != null)
            {
                WriteToLog(e.Error.Message);
                WriteToLog(e.Error.TargetSite.Name);
                WriteToLog(e.Error.Source);
                WriteToLog(e.Error.StackTrace);
            }

            SetProgress(0);
            ToolStripStatusLabel.Text = Extensions.GetStringValue(((ResultState)e.Result));

            if (e.Result != null)
            {
                WriteToLog(Extensions.GetStringValue(((ResultState)e.Result)));

                switch ((ResultState)e.Result)
                {
                    case ResultState.FeatureCompleted:
                        FeatureDataGridView.DataSource = features;
                        FeatureLinkLabel.Enabled = true;
                        FeatureDataGridView.SelectionChanged += new System.EventHandler(FeatureDataGridView_SelectionChanged);
                        StreamDataGridView.DataSourceChanged += new System.EventHandler(StreamDataGridView_DataSourceChanged);
                        if (features.Count == 1) FeatureDataGridView.Rows[0].Selected = true;
                        break;
                    case ResultState.StreamCompleted:
                        FeatureDataGridView.SelectionChanged += new System.EventHandler(this.FeatureDataGridView_SelectionChanged);
                        StreamDataGridView.DataSource = ((Feature)FeatureDataGridView.SelectedRows[0].DataBoundItem).Streams;
                        break;
                    case ResultState.ExtractCompleted:
                        ExtractButton.Enabled = FileInputSourceButton.Enabled = FolderInputSourceButton.Enabled = FolderOutputSourceButton.Enabled
                            = FeatureLinkLabel.Enabled = FeatureDataGridView.Enabled = StreamDataGridView.Enabled = true;
                        break;
                }
            }
        }

        void backgroundWorker_Exited(object sender, EventArgs e)
        {
            ResetCursor(Cursors.Default);
        }

        void backgroundWorker_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            string data;

            if (!String.IsNullOrEmpty(e.Data))
            {
                data = e.Data.TrimStart('\b').Trim();

                if (!string.IsNullOrEmpty(data))
                    WriteToLog("Error: " + e.Data);
            }
        }

        void backgroundWorker_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            string data;

            if (!string.IsNullOrEmpty(e.Data))
            {
                data = e.Data.Substring(e.Data.LastIndexOf('\b') + 1).Trim();

                if (!string.IsNullOrEmpty(data))
                    ProcessLine(data);
            }
        }

        void ProcessLine(string data)
        {
            // Analyzing|Processing|Progress
            // analyze: 100%
            if (Regex.IsMatch(data, @"^\b(analyze|process|progress)\b: [0-9]{1,3}%$", RegexOptions.Compiled))
            {
                if (backgroundWorker.IsBusy)
                    backgroundWorker.ReportProgress(int.Parse(Regex.Match(data, "[0-9]{1,3}").Value),
                        string.Format("{0} ({1}%)", data.Substring(0, data.IndexOf(":")), int.Parse(Regex.Match(data, "[0-9]{1,3}").Value)));

                return;
            }

            // Feature line
            // 2) 00216.mpls, 0:50:19
            else if (Regex.IsMatch(data, @"^[0-99]+\).+$", RegexOptions.Compiled))
            {
                try
                {
                    features.Add(Feature.Parse(data));
                }
                catch (Exception ex)
                {
                    WriteToLog(string.Format("{0}, {{1}}", ex.Message, data));
                }

                return;
            }

            // File input, Feature line
            // MKV, 1 video track, 1 audio track, 1 subtitle track, 1:47:18, 24p /1.001
            else if (Regex.IsMatch(data, @"^[A-Za-z0-9]{3,}, .*$", RegexOptions.Compiled))
            {
                if (InputSourceTextBox.Tag.ToString() == "File")
                {
                    try
                    {
                        Feature f = new Feature();
                        f.Name = System.IO.Path.GetFileNameWithoutExtension(InputSourceTextBox.Text);
                        f.Number = features.Count + 1;
                        f.Description = data;
                        f.Files.Add(new File(System.IO.Path.GetFileName(InputSourceTextBox.Text), 1));

                        if (data.Contains(":"))
                            f.Duration = TimeSpan.Parse(data.Substring(data.IndexOf(":") - 2, (data.LastIndexOf(":") + 3) - (data.IndexOf(":") - 2)).Trim());

                        features.Add(f);
                    }
                    catch (Exception ex)
                    {
                        WriteToLog(string.Format("{0}, {{1}}", ex.Message, data));
                    }
                }

                return;
            }

            // Feature name
            // "Feature Name"
            else if (Regex.IsMatch(data, "^\".+\"$", RegexOptions.Compiled))
            {
                if (InputSourceTextBox.Tag.ToString() == "File")
                {
                    features[features.Count - 1].Streams[features[features.Count - 1].Streams.Count - 1].Name = Extensions.CapitalizeAll(data.Trim("\" .".ToCharArray()));
                }
                else
                {
                    features[features.Count - 1].Name = Extensions.CapitalizeAll(data.Trim("\" .".ToCharArray()));
                }

                return;
            }

            // Stream line on feature listing
            // - h264/AVC, 1080p24 /1.001 (16:9)
            else if (Regex.IsMatch(data, @"^-.+$", RegexOptions.Compiled))
            {
                features[features.Count - 1].ToolTip.Add(data.Trim());
                return;
            }

            // Core information for audio stream
            // (core: DTS, 5.1 channels, 16 bits, 1509kbps, 48khz)
            else if (Regex.IsMatch(data, @"^\(core: .*\)$", RegexOptions.Compiled))
            {
                //TODO: Add core info to stream
                //features[features.Count - 1].Streams[features[features.Count - 1].Streams.Count - 1].ToolTip.Add(data);
                return;
            }

            // Stream embedded audio
            // (embedded: AC3, 5.1 channels, 640kbps, 48khz, dialnorm: -27dB)
            else if (Regex.IsMatch(data, @"^\(embedded: .+\)$", RegexOptions.Compiled))
            {
                //TODO: Add embedded info to stream
                //((Feature)FeatureDataGridView.SelectedRows[0].DataBoundItem).Streams.Count[Streams.Count - 1].ToolTip.Add(data);
                return;
            }

            // Playlist file listing
            // [99+100+101+102+103+104+105+106+114].m2ts (blueray playlist *.mpls)
            else if (Regex.IsMatch(data, @"^\[.+\].m2ts$", RegexOptions.Compiled))
            {
                foreach (string file in Regex.Match(data, @"\[.+\]").Value.Trim("[]".ToCharArray()).Split("+".ToCharArray()))
                    features[features.Count - 1].Files.Add(new File(file + ".m2ts", features[features.Count - 1].Files.Count + 1));

                return;
            }

            // Stream listing feature header
            // M2TS, 1 video track, 6 audio tracks, 9 subtitle tracks, 1:53:06
            // EVO, 2 video tracks, 4 audio tracks, 8 subtitle tracks, 2:20:02
            else if (Regex.IsMatch(data, @"^\b(M2TS|EVO|TS|VOB|MKV|MKA)\b, .+$", RegexOptions.Compiled))
            {
                WriteToLog(data);
                return;
            }

            // Stream line
            // 8: AC3, English, 2.0 channels, 192kbps, 48khz, dialnorm: -27dB
            else if (Regex.IsMatch(data, @"^[0-99]+:.+$", RegexOptions.Compiled))
            {
                if (InputSourceTextBox.Tag.ToString() == "File")
                {
                    try
                    {
                        features[features.Count - 1].Streams.Add(eac3to.Stream.Parse(data));
                    }
                    catch (Exception ex)
                    {
                        WriteToLog(ex.Message);
                        WriteToLog(ex.Source);
                        WriteToLog(ex.StackTrace);
                    }
                }
                else ((Feature)FeatureDataGridView.SelectedRows[0].DataBoundItem).Streams.Add(Stream.Parse(data));


                return;
            }

            // Information line
            // [a03] Creating file "audio.ac3"...
            else if (Regex.IsMatch(data, @"^\[.+\] .+\.{3}$", RegexOptions.Compiled))
            {
                WriteToLog(data);
                return;
            }

            // Creating file
            // Creating file "C:\1_1_chapter.txt"...
            else if (Regex.IsMatch(data, "^Creating file \".+\"\\.{3}$", RegexOptions.Compiled))
            {
                WriteToLog(data);
                return;
            }

            // Done
            // Done.
            else if (data.Equals("Done."))
            {
                WriteToLog(data);
                return;
            }

            #region Errors
            // Source file not found
            // Source file "x:\" not found.
            else if (Regex.IsMatch(data, "^Source file \".*\" not found.$", RegexOptions.Compiled))
            {
                //MessageBox.Show(data, "Source", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                WriteToLog(data);
                return;
            }

            // Format of Source file not detected
            // The format of the source file could not be detected.
            else if (data.Equals("The format of the source file could not be detected."))
            {
                //MessageBox.Show(data, "Source File Format", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                WriteToLog(data);
                return;
            }

            // Audio conversion not supported
            // This audio conversion is not supported.
            else if (data.Equals("This audio conversion is not supported."))
            {
                //MessageBox.Show(data, "Audio Conversion", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                WriteToLog(data);
                return;
            }
            #endregion

            // Unknown line
            else
            {
                WriteToLog(string.Format("{0}", data));
            }
        }
        #endregion

        #region GUI
        delegate void SetProgressCallback(int value);
        void SetProgress(int value)
        {
            lock (this)
            {
                if (this.InvokeRequired)
                    this.BeginInvoke(new SetProgressCallback(SetProgress), value);
                else
                    this.ToolStripProgressBar.Value = value;
            }
        }

        delegate void ResetCursorCallback(System.Windows.Forms.Cursor cursor);
        void ResetCursor(System.Windows.Forms.Cursor cursor)
        {
            lock (this)
            {
                if (this.InvokeRequired)
                    this.BeginInvoke(new ResetCursorCallback(ResetCursor), cursor);
                else
                    this.Cursor = cursor;
            }
        }

        delegate void WriteToLogCallback(string text);
        void WriteToLog(string text)
        {
            if (LogTextBox.InvokeRequired)
                LogTextBox.BeginInvoke(new WriteToLogCallback(WriteToLog), text);
            else
            {
                lock (this)
                {
                    LogTextBox.AppendText(string.Format("[{0}] {1}{2}", DateTime.Now.ToString("HH:mm:ss"), text, Environment.NewLine));

                    using (System.IO.StreamWriter SW = new System.IO.StreamWriter(System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "HdBrStreamExtractor.txt"), true))
                    {
                        SW.WriteLine(string.Format("[{0}] {1}{2}", DateTime.Now.ToString("HH:mm:ss"), text, Environment.NewLine));
                        SW.Close();
                    }
                }
            }
        }

        void FileInputSourceButton_Click(object sender, EventArgs e)
        {
            InputSourceTextBox.Tag = "File";

            openFileDialog1.FileName = string.Empty;
            //openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            DialogResult dr = openFileDialog1.ShowDialog();

            if (dr == DialogResult.OK)
            {
                StringBuilder sb = new StringBuilder();

                foreach (string s in openFileDialog1.FileNames)
                    sb.AppendFormat("{0}+", s);

                sb.Remove(sb.Length - 1, 1);

                InputSourceTextBox.Text = sb.ToString();

                if (IsLocalDisk(InputSourceTextBox.Text))
                    FolderOutputTextBox.Text = System.IO.Path.GetDirectoryName(InputSourceTextBox.Text);
            }
        }

        void FolderInputSourceButton_Click(object sender, EventArgs e)
        {
            InputSourceTextBox.Tag = "Folder";

            folderBrowserDialog1.Description = "Choose an input directory";
            folderBrowserDialog1.ShowNewFolderButton = false;
            DialogResult dr = folderBrowserDialog1.ShowDialog();

            if (dr == DialogResult.OK)
            {
                InputSourceTextBox.Text = folderBrowserDialog1.SelectedPath;

                if (IsLocalDisk(InputSourceTextBox.Text))
                    FolderOutputTextBox.Text = InputSourceTextBox.Text;
            }
        }

        bool IsLocalDisk(string path)
        {
            bool retVal = false;

            foreach (System.IO.DriveInfo d in System.IO.DriveInfo.GetDrives())
                if (d.DriveType == System.IO.DriveType.Fixed || d.DriveType == System.IO.DriveType.Network || d.DriveType == System.IO.DriveType.Removable)
                    if (System.IO.Path.GetPathRoot(InputSourceTextBox.Text) == System.IO.Path.GetPathRoot(d.RootDirectory.FullName))
                        return true;

            return retVal;
        }

        void FolderOutputSourceButton_Click(object sender, EventArgs e)
        {
            //folderBrowserDialog1.SelectedPath = string.Empty;
            folderBrowserDialog1.Description = "Choose an output directory";
            folderBrowserDialog1.ShowNewFolderButton = true;
            DialogResult dr = folderBrowserDialog1.ShowDialog();

            if (dr == DialogResult.OK)
                FolderOutputTextBox.Text = folderBrowserDialog1.SelectedPath;
        }

        void StreamDataGridView_DataSourceChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in StreamDataGridView.Rows)
            {
                Stream s = row.DataBoundItem as Stream;
                DataGridViewComboBoxCell comboBox = row.Cells["StreamExtractAsComboBox"] as DataGridViewComboBoxCell;
                comboBox.Items.Clear();
                comboBox.Items.AddRange(s.ExtractTypes);
                if (comboBox.Items.Count == 1)
                    comboBox.Value = comboBox.Items[0];
            }
        }

        void InitBackgroundWorker()
        {
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker_ProgressChanged);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
        }

        void ExtractButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FolderOutputTextBox.Text))
            {
                MessageBox.Show("Configure output target folder.", "Extract", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }

            if (FeatureDataGridView.Rows.Count == 0)
            {
                MessageBox.Show("Retrieve features prior to extracting.", "Extract", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }

            if (StreamDataGridView.Rows.Count == 0)
            {
                MessageBox.Show("Retrieve streams prior to extracting.", "Extract", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }

            if (!IsStreamCheckedForExtract())
            {
                MessageBox.Show("Select stream(s) to extract.", "Extract", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }

            eac3toArgs args = new eac3toArgs();

            args.eac3toPath = eac3toPath;
            args.inputPath = InputSourceTextBox.Text;
            args.featureNumber = ((Feature)FeatureDataGridView.SelectedRows[0].DataBoundItem).Number.ToString();
            args.workingFolder = string.IsNullOrEmpty(FolderOutputTextBox.Text) ? FolderOutputTextBox.Text : System.IO.Path.GetDirectoryName(args.eac3toPath);
            args.resultState = ResultState.ExtractCompleted;

            try
            {
                args.args = GenerateArguments();
            }
            catch (ApplicationException ex)
            {
                MessageBox.Show(ex.Message, "Stream Extract", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }

            InitBackgroundWorker();
            backgroundWorker.ReportProgress(0, "Extracting streams");
            WriteToLog("Extracting streams");
            ExtractButton.Enabled = FileInputSourceButton.Enabled = FolderInputSourceButton.Enabled = FolderOutputSourceButton.Enabled
                = FeatureLinkLabel.Enabled = FeatureDataGridView.Enabled = StreamDataGridView.Enabled = false;
            CancelButton.Enabled = true;
            Cursor = Cursors.WaitCursor;
            
            backgroundWorker.RunWorkerAsync(args);
        }

        string GenerateArguments()
        {
            StringBuilder sb = new StringBuilder();

            foreach (DataGridViewRow row in StreamDataGridView.Rows)
            {
                Stream stream = row.DataBoundItem as Stream;
                DataGridViewCheckBoxCell extractStream = row.Cells["StreamExtractCheckBox"] as DataGridViewCheckBoxCell;

                if (extractStream.Value != null && int.Parse(extractStream.Value.ToString()) == 1)
                {
                    if (row.Cells["StreamExtractAsComboBox"].Value == null)
                        throw new ApplicationException(string.Format("Specify an extraction type for stream:\r\n\n\t{0}: {1}", stream.Number, stream.Name));

                    sb.Append(string.Format("{0}:\"{1}\" {2} ", stream.Number,
                        System.IO.Path.Combine(FolderOutputTextBox.Text, string.Format("{0}_{1}_{2}.{3}", ((Feature)FeatureDataGridView.SelectedRows[0].DataBoundItem).Number, stream.Number, Extensions.GetStringValue(stream.Type), row.Cells["StreamExtractAsComboBox"].Value).ToLower()),
                        row.Cells["StreamAddOptionsTextBox"].Value).Trim());

                    sb.Append(" ");
                }
            }

            return sb.ToString();
        }

        void CancelButton_Click(object sender, EventArgs e)
        {
            if (backgroundWorker != null)
            {
                if (backgroundWorker.IsBusy)
                    if (MessageBox.Show("A process is still running. Do you want to cancel it?", "Cancel process?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        backgroundWorker.CancelAsync();

                if (backgroundWorker.CancellationPending)
                    backgroundWorker.Dispose();
            }
        }

        void HdBrStreamExtractor_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (backgroundWorker != null)
            {
                if (backgroundWorker.IsBusy)
                    if (MessageBox.Show("A process is still running. Do you want to cancel it?", "Cancel process?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        backgroundWorker.CancelAsync();

                if (backgroundWorker.CancellationPending)
                    backgroundWorker.Dispose();
            }
        }

        bool IsStreamCheckedForExtract()
        {
            bool enableExtract = false;

            foreach (DataGridViewRow row in StreamDataGridView.Rows)
                if (row.Cells["StreamExtractCheckBox"].Value != null && int.Parse(row.Cells["StreamExtractCheckBox"].Value.ToString()) == 1)
                    enableExtract = true;

            return enableExtract;
        }

        void HelpLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://forum.doom9.org/showthread.php?t=141829");
        }

        void Eac3toLinkLabel_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://forum.doom9.org/showthread.php?t=125966");
        }

        void FeatureDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            // only fire after the Databind has completed on grid and a row is selected
            if (FeatureDataGridView.Rows.Count == features.Count && FeatureDataGridView.SelectedRows.Count == 1)
            {
                if (backgroundWorker.IsBusy) // disallow selection change
                {
                    //TODO: Disable selection change on processing
                    //this.FeatureDataGridView.SelectionChanged -= new System.EventHandler(this.FeatureDataGridView_SelectionChanged);

                    //FeatureDataGridView.CurrentRow.Selected = false;
                    //FeatureDataGridView.Rows[int.Parse(FeatureDataGridView.Tag.ToString())].Selected = true;

                    //this.FeatureDataGridView.SelectionChanged += new System.EventHandler(this.FeatureDataGridView_SelectionChanged);
                }
                else // backgroundworker is not busy, allow selection change
                {
                    Feature feature = FeatureDataGridView.SelectedRows[0].DataBoundItem as Feature;

                    // Check for Streams
                    if (feature.Streams == null || feature.Streams.Count == 0)
                    {
                        InitBackgroundWorker();
                        eac3toArgs args = new eac3toArgs();

                        args.eac3toPath = eac3toPath;
                        args.inputPath = InputSourceTextBox.Text;
                        args.workingFolder = string.IsNullOrEmpty(FolderOutputTextBox.Text) ? FolderOutputTextBox.Text : System.IO.Path.GetDirectoryName(args.eac3toPath);
                        args.resultState = ResultState.StreamCompleted;
                        args.args = ((Feature)FeatureDataGridView.SelectedRows[0].DataBoundItem).Number.ToString();

                        backgroundWorker.ReportProgress(0, "Retrieving streams");
                        WriteToLog("Retrieving streams");
                        Cursor = Cursors.WaitCursor;

                        backgroundWorker.RunWorkerAsync(args);
                    }
                    else // use already collected streams
                    {
                        StreamDataGridView.DataSource = feature.Streams;
                    }
                }
            }
        }

        void FeatureDataGridView_DataBindingComplete(object sender, System.Windows.Forms.DataGridViewBindingCompleteEventArgs e)
        {
            FeatureDataGridView.ClearSelection();
        }

        void FeatureDataGridView_RowLeave(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            FeatureDataGridView.Tag = e.RowIndex;
        }

        void FeatureDataGridView_DataSourceChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in FeatureDataGridView.Rows)
            {
                Feature feature = row.DataBoundItem as Feature;
                DataGridViewComboBoxCell comboBox = row.Cells["FeatureFileDataGridViewComboBoxColumn"] as DataGridViewComboBoxCell;

                if (feature != null)
                {
                    if (feature.Files != null || feature.Files.Count > 0)
                    {
                        foreach (File file in feature.Files)
                        {
                            comboBox.Items.Add(file.FullName);

                            if (file.Index == 1)
                                comboBox.Value = file.FullName;
                        }
                    }
                }
            }
        }

        void FeatureDataGridView_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if(e.RowIndex != -1 && FeatureDataGridView.DataSource != null && FeatureDataGridView.Rows.Count > 0)
            {
                StringBuilder toolTip = new StringBuilder();

                foreach (string s in features[e.RowIndex].ToolTip)
                    toolTip.AppendFormat("{0}\r\n", s);

                e.ToolTipText = toolTip.ToString();
            }
        }

        void StreamDataGridView_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.RowIndex != -1 && StreamDataGridView.DataSource != null && StreamDataGridView.Rows.Count > 0)
            {
                StringBuilder toolTip = new StringBuilder();

                foreach (string s in ((Feature)FeatureDataGridView.SelectedRows[0].DataBoundItem).Streams[e.RowIndex].ToolTip)
                    toolTip.AppendFormat("{0}\r\n", s);

                e.ToolTipText = toolTip.ToString();
            }
        }

        void FeatureLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (string.IsNullOrEmpty(InputSourceTextBox.Text))
            {
                MessageBox.Show("Configure input source prior to retrieving features.", "Feature Retrieval", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            else
            {
                InitBackgroundWorker();
                eac3toArgs args = new eac3toArgs();
                features = new List<Feature>();
                FeatureDataGridView.DataSource = null;
                StreamDataGridView.DataSource = null;

                args.eac3toPath = eac3toPath;
                args.inputPath = InputSourceTextBox.Text;
                args.workingFolder = string.IsNullOrEmpty(FolderOutputTextBox.Text) ? FolderOutputTextBox.Text : System.IO.Path.GetDirectoryName(args.eac3toPath);
                args.resultState = ResultState.FeatureCompleted;
                args.args = string.Empty;

                backgroundWorker.ReportProgress(0, "Retrieving features");
                WriteToLog("Retrieving features");
                FeatureLinkLabel.Enabled = false;
                Cursor = Cursors.WaitCursor;

                backgroundWorker.RunWorkerAsync(args);
            }
        }

        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }
        #endregion

        void HdBrStreamExtractor_Load(object sender, EventArgs e)
        {
            Version ver = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            this.Text += string.Format("v{0}.{1}.{2}", ver.Major, ver.Minor, ver.Build);
            StreamDataGridView.DataSource = StreamsBindingSource;
        }
    }
}