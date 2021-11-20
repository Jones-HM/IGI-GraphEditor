
namespace IGI_GraphEditor
{
    partial class IGIGraphEditorUI
    {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IGIGraphEditorUI));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.graphAreaLbl = new System.Windows.Forms.TextBox();
            this.nodeCriteriaTxt = new System.Windows.Forms.TextBox();
            this.nodeZTxt = new System.Windows.Forms.TextBox();
            this.nodeZLbl = new System.Windows.Forms.Label();
            this.nodeYTxt = new System.Windows.Forms.TextBox();
            this.nodeYLbl = new System.Windows.Forms.Label();
            this.nodeXTxt = new System.Windows.Forms.TextBox();
            this.nodeXLbl = new System.Windows.Forms.Label();
            this.nodeIdDD = new System.Windows.Forms.ComboBox();
            this.nodeIdLbl = new System.Windows.Forms.Label();
            this.graphIdLbl = new System.Windows.Forms.Label();
            this.graphIdTxt = new System.Windows.Forms.TextBox();
            this.graphTotalNodesTxt = new System.Windows.Forms.TextBox();
            this.graphTotalNodesLbl = new System.Windows.Forms.Label();
            this.setOutputPathBtn = new System.Windows.Forms.Button();
            this.formMoverPanel = new System.Windows.Forms.Panel();
            this.aboutBtn = new System.Windows.Forms.Label();
            this.minimizeBtn = new System.Windows.Forms.Label();
            this.closeBtn = new System.Windows.Forms.Label();
            this.versionLbl = new System.Windows.Forms.Label();
            this.statusLbl = new System.Windows.Forms.Label();
            this.browseFile = new System.Windows.Forms.Button();
            this.resetGraphBtn = new System.Windows.Forms.Button();
            this.saveGraphBtn = new System.Windows.Forms.Button();
            this.title_lbl = new System.Windows.Forms.Label();
            this.overwriteCb = new System.Windows.Forms.CheckBox();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.AllowDrop = true;
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(35)))), ((int)(((byte)(54)))));
            this.mainPanel.Controls.Add(this.overwriteCb);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.graphAreaLbl);
            this.mainPanel.Controls.Add(this.nodeCriteriaTxt);
            this.mainPanel.Controls.Add(this.nodeZTxt);
            this.mainPanel.Controls.Add(this.nodeZLbl);
            this.mainPanel.Controls.Add(this.nodeYTxt);
            this.mainPanel.Controls.Add(this.nodeYLbl);
            this.mainPanel.Controls.Add(this.nodeXTxt);
            this.mainPanel.Controls.Add(this.nodeXLbl);
            this.mainPanel.Controls.Add(this.nodeIdDD);
            this.mainPanel.Controls.Add(this.nodeIdLbl);
            this.mainPanel.Controls.Add(this.graphIdLbl);
            this.mainPanel.Controls.Add(this.graphIdTxt);
            this.mainPanel.Controls.Add(this.graphTotalNodesTxt);
            this.mainPanel.Controls.Add(this.graphTotalNodesLbl);
            this.mainPanel.Controls.Add(this.setOutputPathBtn);
            this.mainPanel.Controls.Add(this.formMoverPanel);
            this.mainPanel.Controls.Add(this.aboutBtn);
            this.mainPanel.Controls.Add(this.minimizeBtn);
            this.mainPanel.Controls.Add(this.closeBtn);
            this.mainPanel.Controls.Add(this.versionLbl);
            this.mainPanel.Controls.Add(this.statusLbl);
            this.mainPanel.Controls.Add(this.browseFile);
            this.mainPanel.Controls.Add(this.resetGraphBtn);
            this.mainPanel.Controls.Add(this.saveGraphBtn);
            this.mainPanel.Controls.Add(this.title_lbl);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(4);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(828, 488);
            this.mainPanel.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.label1.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label1.Location = new System.Drawing.Point(242, 306);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 33);
            this.label1.TabIndex = 83;
            this.label1.Text = "X :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // graphAreaLbl
            // 
            this.graphAreaLbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(35)))), ((int)(((byte)(54)))));
            this.graphAreaLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.graphAreaLbl.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.graphAreaLbl.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.graphAreaLbl.Location = new System.Drawing.Point(294, 233);
            this.graphAreaLbl.Margin = new System.Windows.Forms.Padding(4);
            this.graphAreaLbl.Name = "graphAreaLbl";
            this.graphAreaLbl.ReadOnly = true;
            this.graphAreaLbl.Size = new System.Drawing.Size(196, 30);
            this.graphAreaLbl.TabIndex = 82;
            // 
            // nodeCriteriaTxt
            // 
            this.nodeCriteriaTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(35)))), ((int)(((byte)(54)))));
            this.nodeCriteriaTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nodeCriteriaTxt.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.nodeCriteriaTxt.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.nodeCriteriaTxt.Location = new System.Drawing.Point(461, 346);
            this.nodeCriteriaTxt.Margin = new System.Windows.Forms.Padding(4);
            this.nodeCriteriaTxt.Name = "nodeCriteriaTxt";
            this.nodeCriteriaTxt.ReadOnly = true;
            this.nodeCriteriaTxt.Size = new System.Drawing.Size(342, 30);
            this.nodeCriteriaTxt.TabIndex = 82;
            // 
            // nodeZTxt
            // 
            this.nodeZTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(35)))), ((int)(((byte)(54)))));
            this.nodeZTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nodeZTxt.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.nodeZTxt.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.nodeZTxt.Location = new System.Drawing.Point(686, 308);
            this.nodeZTxt.Margin = new System.Windows.Forms.Padding(4);
            this.nodeZTxt.Name = "nodeZTxt";
            this.nodeZTxt.Size = new System.Drawing.Size(120, 30);
            this.nodeZTxt.TabIndex = 81;
            this.nodeZTxt.Text = "0";
            // 
            // nodeZLbl
            // 
            this.nodeZLbl.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.nodeZLbl.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.nodeZLbl.Location = new System.Drawing.Point(634, 305);
            this.nodeZLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nodeZLbl.Name = "nodeZLbl";
            this.nodeZLbl.Size = new System.Drawing.Size(44, 33);
            this.nodeZLbl.TabIndex = 80;
            this.nodeZLbl.Text = "Z :";
            this.nodeZLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nodeYTxt
            // 
            this.nodeYTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(35)))), ((int)(((byte)(54)))));
            this.nodeYTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nodeYTxt.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.nodeYTxt.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.nodeYTxt.Location = new System.Drawing.Point(485, 308);
            this.nodeYTxt.Margin = new System.Windows.Forms.Padding(4);
            this.nodeYTxt.Name = "nodeYTxt";
            this.nodeYTxt.Size = new System.Drawing.Size(120, 30);
            this.nodeYTxt.TabIndex = 79;
            this.nodeYTxt.Text = "0";
            // 
            // nodeYLbl
            // 
            this.nodeYLbl.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.nodeYLbl.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.nodeYLbl.Location = new System.Drawing.Point(433, 305);
            this.nodeYLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nodeYLbl.Name = "nodeYLbl";
            this.nodeYLbl.Size = new System.Drawing.Size(44, 33);
            this.nodeYLbl.TabIndex = 78;
            this.nodeYLbl.Text = "Y :";
            this.nodeYLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nodeXTxt
            // 
            this.nodeXTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(35)))), ((int)(((byte)(54)))));
            this.nodeXTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nodeXTxt.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.nodeXTxt.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.nodeXTxt.Location = new System.Drawing.Point(294, 308);
            this.nodeXTxt.Margin = new System.Windows.Forms.Padding(4);
            this.nodeXTxt.Name = "nodeXTxt";
            this.nodeXTxt.Size = new System.Drawing.Size(120, 30);
            this.nodeXTxt.TabIndex = 77;
            this.nodeXTxt.Text = "0";
            // 
            // nodeXLbl
            // 
            this.nodeXLbl.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.nodeXLbl.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.nodeXLbl.Location = new System.Drawing.Point(515, 306);
            this.nodeXLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nodeXLbl.Name = "nodeXLbl";
            this.nodeXLbl.Size = new System.Drawing.Size(44, 33);
            this.nodeXLbl.TabIndex = 76;
            this.nodeXLbl.Text = "X :";
            this.nodeXLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nodeIdDD
            // 
            this.nodeIdDD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(35)))), ((int)(((byte)(54)))));
            this.nodeIdDD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nodeIdDD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nodeIdDD.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.nodeIdDD.FormattingEnabled = true;
            this.nodeIdDD.Location = new System.Drawing.Point(155, 311);
            this.nodeIdDD.Name = "nodeIdDD";
            this.nodeIdDD.Size = new System.Drawing.Size(73, 24);
            this.nodeIdDD.TabIndex = 75;
            this.nodeIdDD.SelectedIndexChanged += new System.EventHandler(this.nodeIdDD_SelectedIndexChanged);
            // 
            // nodeIdLbl
            // 
            this.nodeIdLbl.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.nodeIdLbl.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.nodeIdLbl.Location = new System.Drawing.Point(4, 304);
            this.nodeIdLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nodeIdLbl.Name = "nodeIdLbl";
            this.nodeIdLbl.Size = new System.Drawing.Size(173, 33);
            this.nodeIdLbl.TabIndex = 74;
            this.nodeIdLbl.Text = "Node Id :";
            this.nodeIdLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // graphIdLbl
            // 
            this.graphIdLbl.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.graphIdLbl.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.graphIdLbl.Location = new System.Drawing.Point(4, 231);
            this.graphIdLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.graphIdLbl.Name = "graphIdLbl";
            this.graphIdLbl.Size = new System.Drawing.Size(143, 33);
            this.graphIdLbl.TabIndex = 72;
            this.graphIdLbl.Text = "Graph Id :";
            this.graphIdLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // graphIdTxt
            // 
            this.graphIdTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(35)))), ((int)(((byte)(54)))));
            this.graphIdTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.graphIdTxt.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.graphIdTxt.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.graphIdTxt.Location = new System.Drawing.Point(155, 233);
            this.graphIdTxt.Margin = new System.Windows.Forms.Padding(4);
            this.graphIdTxt.Name = "graphIdTxt";
            this.graphIdTxt.ReadOnly = true;
            this.graphIdTxt.Size = new System.Drawing.Size(62, 30);
            this.graphIdTxt.TabIndex = 71;
            // 
            // graphTotalNodesTxt
            // 
            this.graphTotalNodesTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(35)))), ((int)(((byte)(54)))));
            this.graphTotalNodesTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.graphTotalNodesTxt.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.graphTotalNodesTxt.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.graphTotalNodesTxt.Location = new System.Drawing.Point(671, 235);
            this.graphTotalNodesTxt.Margin = new System.Windows.Forms.Padding(4);
            this.graphTotalNodesTxt.Name = "graphTotalNodesTxt";
            this.graphTotalNodesTxt.ReadOnly = true;
            this.graphTotalNodesTxt.Size = new System.Drawing.Size(62, 30);
            this.graphTotalNodesTxt.TabIndex = 71;
            // 
            // graphTotalNodesLbl
            // 
            this.graphTotalNodesLbl.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.graphTotalNodesLbl.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.graphTotalNodesLbl.Location = new System.Drawing.Point(498, 230);
            this.graphTotalNodesLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.graphTotalNodesLbl.Name = "graphTotalNodesLbl";
            this.graphTotalNodesLbl.Size = new System.Drawing.Size(165, 33);
            this.graphTotalNodesLbl.TabIndex = 70;
            this.graphTotalNodesLbl.Text = "Total Nodes:";
            this.graphTotalNodesLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // setOutputPathBtn
            // 
            this.setOutputPathBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.setOutputPathBtn.BackColor = System.Drawing.Color.Transparent;
            this.setOutputPathBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setOutputPathBtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setOutputPathBtn.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.setOutputPathBtn.Location = new System.Drawing.Point(63, 92);
            this.setOutputPathBtn.Margin = new System.Windows.Forms.Padding(4);
            this.setOutputPathBtn.Name = "setOutputPathBtn";
            this.setOutputPathBtn.Size = new System.Drawing.Size(666, 41);
            this.setOutputPathBtn.TabIndex = 58;
            this.setOutputPathBtn.Text = "Set Output Path";
            this.setOutputPathBtn.UseVisualStyleBackColor = false;
            this.setOutputPathBtn.Click += new System.EventHandler(this.setGamePathBtn_Click);
            // 
            // formMoverPanel
            // 
            this.formMoverPanel.BackColor = System.Drawing.Color.DodgerBlue;
            this.formMoverPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.formMoverPanel.Location = new System.Drawing.Point(0, 0);
            this.formMoverPanel.Margin = new System.Windows.Forms.Padding(4);
            this.formMoverPanel.Name = "formMoverPanel";
            this.formMoverPanel.Size = new System.Drawing.Size(828, 12);
            this.formMoverPanel.TabIndex = 51;
            // 
            // aboutBtn
            // 
            this.aboutBtn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.aboutBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aboutBtn.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Bold);
            this.aboutBtn.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.aboutBtn.Location = new System.Drawing.Point(652, 13);
            this.aboutBtn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.aboutBtn.Name = "aboutBtn";
            this.aboutBtn.Size = new System.Drawing.Size(52, 46);
            this.aboutBtn.TabIndex = 50;
            this.aboutBtn.Text = "?";
            this.aboutBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.aboutBtn.Click += new System.EventHandler(this.aboutBtn_Click);
            // 
            // minimizeBtn
            // 
            this.minimizeBtn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.minimizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.minimizeBtn.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Bold);
            this.minimizeBtn.ForeColor = System.Drawing.Color.White;
            this.minimizeBtn.Location = new System.Drawing.Point(712, 13);
            this.minimizeBtn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.minimizeBtn.Name = "minimizeBtn";
            this.minimizeBtn.Size = new System.Drawing.Size(52, 46);
            this.minimizeBtn.TabIndex = 49;
            this.minimizeBtn.Text = "_";
            this.minimizeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.minimizeBtn.Click += new System.EventHandler(this.minimizeBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeBtn.Font = new System.Drawing.Font("Century Gothic", 15F);
            this.closeBtn.ForeColor = System.Drawing.Color.Tomato;
            this.closeBtn.Location = new System.Drawing.Point(772, 15);
            this.closeBtn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(52, 46);
            this.closeBtn.TabIndex = 48;
            this.closeBtn.Text = "x";
            this.closeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // versionLbl
            // 
            this.versionLbl.AutoSize = true;
            this.versionLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionLbl.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.versionLbl.Location = new System.Drawing.Point(713, 456);
            this.versionLbl.Name = "versionLbl";
            this.versionLbl.Size = new System.Drawing.Size(89, 18);
            this.versionLbl.TabIndex = 47;
            this.versionLbl.Text = "Internal Tool";
            // 
            // statusLbl
            // 
            this.statusLbl.AutoSize = true;
            this.statusLbl.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.statusLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLbl.ForeColor = System.Drawing.Color.SkyBlue;
            this.statusLbl.Location = new System.Drawing.Point(289, 456);
            this.statusLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(68, 25);
            this.statusLbl.TabIndex = 8;
            this.statusLbl.Text = "Status";
            this.statusLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // browseFile
            // 
            this.browseFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.browseFile.BackColor = System.Drawing.Color.Transparent;
            this.browseFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browseFile.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browseFile.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.browseFile.Location = new System.Drawing.Point(63, 164);
            this.browseFile.Margin = new System.Windows.Forms.Padding(4);
            this.browseFile.Name = "browseFile";
            this.browseFile.Size = new System.Drawing.Size(666, 41);
            this.browseFile.TabIndex = 6;
            this.browseFile.Text = "Browse Graph File";
            this.browseFile.UseVisualStyleBackColor = false;
            this.browseFile.Click += new System.EventHandler(this.browseFile_Click);
            // 
            // resetGraphBtn
            // 
            this.resetGraphBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.resetGraphBtn.BackColor = System.Drawing.Color.Transparent;
            this.resetGraphBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resetGraphBtn.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.resetGraphBtn.ForeColor = System.Drawing.Color.Tomato;
            this.resetGraphBtn.Location = new System.Drawing.Point(417, 414);
            this.resetGraphBtn.Margin = new System.Windows.Forms.Padding(4);
            this.resetGraphBtn.Name = "resetGraphBtn";
            this.resetGraphBtn.Size = new System.Drawing.Size(312, 35);
            this.resetGraphBtn.TabIndex = 0;
            this.resetGraphBtn.Text = "Reset Graph";
            this.resetGraphBtn.UseVisualStyleBackColor = false;
            this.resetGraphBtn.Click += new System.EventHandler(this.resetGraphBtn_Click);
            // 
            // saveGraphBtn
            // 
            this.saveGraphBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveGraphBtn.BackColor = System.Drawing.Color.Transparent;
            this.saveGraphBtn.Enabled = false;
            this.saveGraphBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveGraphBtn.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.saveGraphBtn.ForeColor = System.Drawing.Color.SpringGreen;
            this.saveGraphBtn.Location = new System.Drawing.Point(63, 414);
            this.saveGraphBtn.Margin = new System.Windows.Forms.Padding(4);
            this.saveGraphBtn.Name = "saveGraphBtn";
            this.saveGraphBtn.Size = new System.Drawing.Size(346, 35);
            this.saveGraphBtn.TabIndex = 0;
            this.saveGraphBtn.Text = "Save Graph";
            this.saveGraphBtn.UseVisualStyleBackColor = false;
            this.saveGraphBtn.Click += new System.EventHandler(this.saveGraphBtn_Click);
            // 
            // title_lbl
            // 
            this.title_lbl.AutoSize = true;
            this.title_lbl.BackColor = System.Drawing.Color.Transparent;
            this.title_lbl.Font = new System.Drawing.Font("Harrington", 25F, System.Drawing.FontStyle.Bold);
            this.title_lbl.ForeColor = System.Drawing.Color.SkyBlue;
            this.title_lbl.Location = new System.Drawing.Point(98, 13);
            this.title_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.title_lbl.Name = "title_lbl";
            this.title_lbl.Size = new System.Drawing.Size(526, 50);
            this.title_lbl.TabIndex = 2;
            this.title_lbl.Text = "Project I.G.I IGraph Editor";
            // 
            // overwriteCb
            // 
            this.overwriteCb.AutoSize = true;
            this.overwriteCb.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.overwriteCb.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.overwriteCb.Location = new System.Drawing.Point(63, 451);
            this.overwriteCb.Margin = new System.Windows.Forms.Padding(4);
            this.overwriteCb.Name = "overwriteCb";
            this.overwriteCb.Size = new System.Drawing.Size(133, 30);
            this.overwriteCb.TabIndex = 86;
            this.overwriteCb.Text = "Overwrite";
            this.overwriteCb.UseVisualStyleBackColor = true;
            // 
            // IGIGraphEditorUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 488);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IGIGraphEditorUI";
            this.Text = "Project I.G.I Injector - HM";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button saveGraphBtn;
        private System.Windows.Forms.Label title_lbl;
        private System.Windows.Forms.Button resetGraphBtn;
        internal System.Windows.Forms.Label statusLbl;
        internal System.Windows.Forms.Button browseFile;
        private System.Windows.Forms.Label versionLbl;
        private System.Windows.Forms.Label aboutBtn;
        private System.Windows.Forms.Label minimizeBtn;
        private System.Windows.Forms.Label closeBtn;
        private System.Windows.Forms.Panel formMoverPanel;
        internal System.Windows.Forms.Button setOutputPathBtn;
        private System.Windows.Forms.TextBox graphTotalNodesTxt;
        private System.Windows.Forms.Label graphTotalNodesLbl;
        private System.Windows.Forms.ComboBox nodeIdDD;
        private System.Windows.Forms.Label nodeIdLbl;
        private System.Windows.Forms.Label graphIdLbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nodeCriteriaTxt;
        private System.Windows.Forms.TextBox nodeZTxt;
        private System.Windows.Forms.Label nodeZLbl;
        private System.Windows.Forms.TextBox nodeYTxt;
        private System.Windows.Forms.Label nodeYLbl;
        private System.Windows.Forms.TextBox nodeXTxt;
        private System.Windows.Forms.Label nodeXLbl;
        private System.Windows.Forms.TextBox graphAreaLbl;
        private System.Windows.Forms.TextBox graphIdTxt;
        private System.Windows.Forms.CheckBox overwriteCb;
    }
}

