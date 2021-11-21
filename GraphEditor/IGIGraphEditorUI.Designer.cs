
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
            this.nodeCriteriaDD = new System.Windows.Forms.ComboBox();
            this.graphPosCb = new System.Windows.Forms.CheckBox();
            this.nodeCurrPosCb = new System.Windows.Forms.CheckBox();
            this.overwriteCb = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.graphAreaLbl = new System.Windows.Forms.TextBox();
            this.nodeZTxt = new System.Windows.Forms.TextBox();
            this.nodeZLbl = new System.Windows.Forms.Label();
            this.nodeYTxt = new System.Windows.Forms.TextBox();
            this.nodeYLbl = new System.Windows.Forms.Label();
            this.nodeXTxt = new System.Windows.Forms.TextBox();
            this.nodeXLbl = new System.Windows.Forms.Label();
            this.nodeIdDD = new System.Windows.Forms.ComboBox();
            this.nodeCriteriaLbl = new System.Windows.Forms.Label();
            this.nodeIdLbl = new System.Windows.Forms.Label();
            this.graphIdLbl = new System.Windows.Forms.Label();
            this.graphIdTxt = new System.Windows.Forms.TextBox();
            this.graphMaxNodesTxt = new System.Windows.Forms.TextBox();
            this.graphTotalNodesTxt = new System.Windows.Forms.TextBox();
            this.maxNodesLbl = new System.Windows.Forms.Label();
            this.graphTotalNodesLbl = new System.Windows.Forms.Label();
            this.setOutputPathBtn = new System.Windows.Forms.Button();
            this.formMoverPanel = new System.Windows.Forms.Panel();
            this.aboutBtn = new System.Windows.Forms.Label();
            this.minimizeBtn = new System.Windows.Forms.Label();
            this.closeBtn = new System.Windows.Forms.Label();
            this.statusLbl = new System.Windows.Forms.Label();
            this.browseFile = new System.Windows.Forms.Button();
            this.resetGraphBtn = new System.Windows.Forms.Button();
            this.saveGraphBtn = new System.Windows.Forms.Button();
            this.saveNodeBtn = new System.Windows.Forms.Button();
            this.title_lbl = new System.Windows.Forms.Label();
            this.resetLevelBtn = new System.Windows.Forms.Button();
            this.levelLbl = new System.Windows.Forms.Label();
            this.playerCurrPosCb = new System.Windows.Forms.CheckBox();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.AllowDrop = true;
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(35)))), ((int)(((byte)(54)))));
            this.mainPanel.Controls.Add(this.nodeCriteriaDD);
            this.mainPanel.Controls.Add(this.graphPosCb);
            this.mainPanel.Controls.Add(this.playerCurrPosCb);
            this.mainPanel.Controls.Add(this.nodeCurrPosCb);
            this.mainPanel.Controls.Add(this.overwriteCb);
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.graphAreaLbl);
            this.mainPanel.Controls.Add(this.nodeZTxt);
            this.mainPanel.Controls.Add(this.nodeZLbl);
            this.mainPanel.Controls.Add(this.nodeYTxt);
            this.mainPanel.Controls.Add(this.nodeYLbl);
            this.mainPanel.Controls.Add(this.nodeXTxt);
            this.mainPanel.Controls.Add(this.nodeXLbl);
            this.mainPanel.Controls.Add(this.nodeIdDD);
            this.mainPanel.Controls.Add(this.nodeCriteriaLbl);
            this.mainPanel.Controls.Add(this.nodeIdLbl);
            this.mainPanel.Controls.Add(this.graphIdLbl);
            this.mainPanel.Controls.Add(this.graphIdTxt);
            this.mainPanel.Controls.Add(this.graphMaxNodesTxt);
            this.mainPanel.Controls.Add(this.graphTotalNodesTxt);
            this.mainPanel.Controls.Add(this.maxNodesLbl);
            this.mainPanel.Controls.Add(this.levelLbl);
            this.mainPanel.Controls.Add(this.graphTotalNodesLbl);
            this.mainPanel.Controls.Add(this.setOutputPathBtn);
            this.mainPanel.Controls.Add(this.formMoverPanel);
            this.mainPanel.Controls.Add(this.aboutBtn);
            this.mainPanel.Controls.Add(this.minimizeBtn);
            this.mainPanel.Controls.Add(this.closeBtn);
            this.mainPanel.Controls.Add(this.statusLbl);
            this.mainPanel.Controls.Add(this.browseFile);
            this.mainPanel.Controls.Add(this.resetLevelBtn);
            this.mainPanel.Controls.Add(this.resetGraphBtn);
            this.mainPanel.Controls.Add(this.saveGraphBtn);
            this.mainPanel.Controls.Add(this.saveNodeBtn);
            this.mainPanel.Controls.Add(this.title_lbl);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(4);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(828, 488);
            this.mainPanel.TabIndex = 5;
            // 
            // nodeCriteriaDD
            // 
            this.nodeCriteriaDD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(35)))), ((int)(((byte)(54)))));
            this.nodeCriteriaDD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nodeCriteriaDD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nodeCriteriaDD.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.nodeCriteriaDD.FormattingEnabled = true;
            this.nodeCriteriaDD.Items.AddRange(new object[] {
            "NODECRITERIA_NONE",
            "NODECRITERIA_STAIR",
            "NODECRITERIA_VIEW",
            "NODECRITERIA_DOOR"});
            this.nodeCriteriaDD.Location = new System.Drawing.Point(563, 358);
            this.nodeCriteriaDD.Name = "nodeCriteriaDD";
            this.nodeCriteriaDD.Size = new System.Drawing.Size(243, 24);
            this.nodeCriteriaDD.TabIndex = 87;
            this.nodeCriteriaDD.SelectedIndexChanged += new System.EventHandler(this.nodeCriteriaDD_SelectedIndexChanged);
            // 
            // graphPosCb
            // 
            this.graphPosCb.AutoSize = true;
            this.graphPosCb.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.graphPosCb.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.graphPosCb.Location = new System.Drawing.Point(62, 413);
            this.graphPosCb.Margin = new System.Windows.Forms.Padding(4);
            this.graphPosCb.Name = "graphPosCb";
            this.graphPosCb.Size = new System.Drawing.Size(107, 24);
            this.graphPosCb.TabIndex = 86;
            this.graphPosCb.Text = "Graph Pos";
            this.graphPosCb.UseVisualStyleBackColor = true;
            this.graphPosCb.CheckedChanged += new System.EventHandler(this.graphPosCb_CheckedChanged);
            // 
            // nodeCurrPosCb
            // 
            this.nodeCurrPosCb.AutoSize = true;
            this.nodeCurrPosCb.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.nodeCurrPosCb.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.nodeCurrPosCb.Location = new System.Drawing.Point(294, 413);
            this.nodeCurrPosCb.Margin = new System.Windows.Forms.Padding(4);
            this.nodeCurrPosCb.Name = "nodeCurrPosCb";
            this.nodeCurrPosCb.Size = new System.Drawing.Size(101, 24);
            this.nodeCurrPosCb.TabIndex = 86;
            this.nodeCurrPosCb.Text = "Node Pos";
            this.nodeCurrPosCb.UseVisualStyleBackColor = true;
            this.nodeCurrPosCb.CheckedChanged += new System.EventHandler(this.currPosCb_CheckedChanged);
            // 
            // overwriteCb
            // 
            this.overwriteCb.AutoSize = true;
            this.overwriteCb.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.overwriteCb.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.overwriteCb.Location = new System.Drawing.Point(62, 392);
            this.overwriteCb.Margin = new System.Windows.Forms.Padding(4);
            this.overwriteCb.Name = "overwriteCb";
            this.overwriteCb.Size = new System.Drawing.Size(106, 24);
            this.overwriteCb.TabIndex = 86;
            this.overwriteCb.Text = "Overwrite";
            this.overwriteCb.UseVisualStyleBackColor = true;
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
            this.graphAreaLbl.Location = new System.Drawing.Point(246, 233);
            this.graphAreaLbl.Margin = new System.Windows.Forms.Padding(4);
            this.graphAreaLbl.Name = "graphAreaLbl";
            this.graphAreaLbl.ReadOnly = true;
            this.graphAreaLbl.Size = new System.Drawing.Size(196, 30);
            this.graphAreaLbl.TabIndex = 82;
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
            // nodeCriteriaLbl
            // 
            this.nodeCriteriaLbl.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nodeCriteriaLbl.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.nodeCriteriaLbl.Location = new System.Drawing.Point(413, 358);
            this.nodeCriteriaLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nodeCriteriaLbl.Name = "nodeCriteriaLbl";
            this.nodeCriteriaLbl.Size = new System.Drawing.Size(143, 33);
            this.nodeCriteriaLbl.TabIndex = 74;
            this.nodeCriteriaLbl.Text = "Criteria:";
            this.nodeCriteriaLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nodeIdLbl
            // 
            this.nodeIdLbl.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.nodeIdLbl.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.nodeIdLbl.Location = new System.Drawing.Point(4, 304);
            this.nodeIdLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nodeIdLbl.Name = "nodeIdLbl";
            this.nodeIdLbl.Size = new System.Drawing.Size(143, 33);
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
            // graphMaxNodesTxt
            // 
            this.graphMaxNodesTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(35)))), ((int)(((byte)(54)))));
            this.graphMaxNodesTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.graphMaxNodesTxt.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.graphMaxNodesTxt.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.graphMaxNodesTxt.Location = new System.Drawing.Point(667, 235);
            this.graphMaxNodesTxt.Margin = new System.Windows.Forms.Padding(4);
            this.graphMaxNodesTxt.Name = "graphMaxNodesTxt";
            this.graphMaxNodesTxt.Size = new System.Drawing.Size(62, 30);
            this.graphMaxNodesTxt.TabIndex = 71;
            // 
            // graphTotalNodesTxt
            // 
            this.graphTotalNodesTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(35)))), ((int)(((byte)(54)))));
            this.graphTotalNodesTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.graphTotalNodesTxt.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.graphTotalNodesTxt.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.graphTotalNodesTxt.Location = new System.Drawing.Point(526, 235);
            this.graphTotalNodesTxt.Margin = new System.Windows.Forms.Padding(4);
            this.graphTotalNodesTxt.Name = "graphTotalNodesTxt";
            this.graphTotalNodesTxt.Size = new System.Drawing.Size(62, 30);
            this.graphTotalNodesTxt.TabIndex = 71;
            // 
            // maxNodesLbl
            // 
            this.maxNodesLbl.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxNodesLbl.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.maxNodesLbl.Location = new System.Drawing.Point(634, 198);
            this.maxNodesLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.maxNodesLbl.Name = "maxNodesLbl";
            this.maxNodesLbl.Size = new System.Drawing.Size(134, 33);
            this.maxNodesLbl.TabIndex = 70;
            this.maxNodesLbl.Text = "Max Nodes:";
            this.maxNodesLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // graphTotalNodesLbl
            // 
            this.graphTotalNodesLbl.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.graphTotalNodesLbl.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.graphTotalNodesLbl.Location = new System.Drawing.Point(498, 198);
            this.graphTotalNodesLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.graphTotalNodesLbl.Name = "graphTotalNodesLbl";
            this.graphTotalNodesLbl.Size = new System.Drawing.Size(134, 33);
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
            this.setOutputPathBtn.Location = new System.Drawing.Point(67, 67);
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
            // statusLbl
            // 
            this.statusLbl.AutoSize = true;
            this.statusLbl.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.statusLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLbl.ForeColor = System.Drawing.Color.SkyBlue;
            this.statusLbl.Location = new System.Drawing.Point(241, 170);
            this.statusLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(68, 25);
            this.statusLbl.TabIndex = 8;
            this.statusLbl.Text = "Status";
            this.statusLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.statusLbl.DoubleClick += new System.EventHandler(this.statusLbl_DoubleClick);
            // 
            // browseFile
            // 
            this.browseFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.browseFile.BackColor = System.Drawing.Color.Transparent;
            this.browseFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browseFile.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browseFile.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.browseFile.Location = new System.Drawing.Point(63, 125);
            this.browseFile.Margin = new System.Windows.Forms.Padding(4);
            this.browseFile.Name = "browseFile";
            this.browseFile.Size = new System.Drawing.Size(670, 41);
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
            this.resetGraphBtn.Location = new System.Drawing.Point(599, 440);
            this.resetGraphBtn.Margin = new System.Windows.Forms.Padding(4);
            this.resetGraphBtn.Name = "resetGraphBtn";
            this.resetGraphBtn.Size = new System.Drawing.Size(207, 35);
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
            this.saveGraphBtn.Location = new System.Drawing.Point(62, 440);
            this.saveGraphBtn.Margin = new System.Windows.Forms.Padding(4);
            this.saveGraphBtn.Name = "saveGraphBtn";
            this.saveGraphBtn.Size = new System.Drawing.Size(207, 35);
            this.saveGraphBtn.TabIndex = 0;
            this.saveGraphBtn.Text = "Save Graph";
            this.saveGraphBtn.UseVisualStyleBackColor = false;
            this.saveGraphBtn.Click += new System.EventHandler(this.saveGraphBtn_Click);
            // 
            // saveNodeBtn
            // 
            this.saveNodeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveNodeBtn.BackColor = System.Drawing.Color.Transparent;
            this.saveNodeBtn.Enabled = false;
            this.saveNodeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveNodeBtn.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.saveNodeBtn.ForeColor = System.Drawing.Color.SpringGreen;
            this.saveNodeBtn.Location = new System.Drawing.Point(293, 440);
            this.saveNodeBtn.Margin = new System.Windows.Forms.Padding(4);
            this.saveNodeBtn.Name = "saveNodeBtn";
            this.saveNodeBtn.Size = new System.Drawing.Size(207, 35);
            this.saveNodeBtn.TabIndex = 0;
            this.saveNodeBtn.Text = "Save Node";
            this.saveNodeBtn.UseVisualStyleBackColor = false;
            this.saveNodeBtn.Click += new System.EventHandler(this.saveNodeBtn_Click);
            // 
            // title_lbl
            // 
            this.title_lbl.AutoSize = true;
            this.title_lbl.BackColor = System.Drawing.Color.Transparent;
            this.title_lbl.Font = new System.Drawing.Font("Harrington", 25F, System.Drawing.FontStyle.Bold);
            this.title_lbl.ForeColor = System.Drawing.Color.SkyBlue;
            this.title_lbl.Location = new System.Drawing.Point(188, 9);
            this.title_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.title_lbl.Name = "title_lbl";
            this.title_lbl.Size = new System.Drawing.Size(373, 50);
            this.title_lbl.TabIndex = 2;
            this.title_lbl.Text = "I.G.I IGraph Editor";
            // 
            // resetLevelBtn
            // 
            this.resetLevelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.resetLevelBtn.BackColor = System.Drawing.Color.Transparent;
            this.resetLevelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resetLevelBtn.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.resetLevelBtn.ForeColor = System.Drawing.Color.Tomato;
            this.resetLevelBtn.Location = new System.Drawing.Point(599, 406);
            this.resetLevelBtn.Margin = new System.Windows.Forms.Padding(4);
            this.resetLevelBtn.Name = "resetLevelBtn";
            this.resetLevelBtn.Size = new System.Drawing.Size(207, 35);
            this.resetLevelBtn.TabIndex = 0;
            this.resetLevelBtn.Text = "Reset Level";
            this.resetLevelBtn.UseVisualStyleBackColor = false;
            this.resetLevelBtn.Click += new System.EventHandler(this.resetLevelBtn_Click);
            // 
            // levelLbl
            // 
            this.levelLbl.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.levelLbl.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.levelLbl.Location = new System.Drawing.Point(569, 34);
            this.levelLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.levelLbl.Name = "levelLbl";
            this.levelLbl.Size = new System.Drawing.Size(75, 25);
            this.levelLbl.TabIndex = 70;
            this.levelLbl.Text = "Level:";
            this.levelLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // playerCurrPosCb
            // 
            this.playerCurrPosCb.AutoSize = true;
            this.playerCurrPosCb.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.playerCurrPosCb.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.playerCurrPosCb.Location = new System.Drawing.Point(290, 346);
            this.playerCurrPosCb.Margin = new System.Windows.Forms.Padding(4);
            this.playerCurrPosCb.Name = "playerCurrPosCb";
            this.playerCurrPosCb.Size = new System.Drawing.Size(105, 24);
            this.playerCurrPosCb.TabIndex = 86;
            this.playerCurrPosCb.Text = "Player Pos";
            this.playerCurrPosCb.UseVisualStyleBackColor = true;
            this.playerCurrPosCb.CheckedChanged += new System.EventHandler(this.currPosCb_CheckedChanged);
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
        private System.Windows.Forms.Button saveNodeBtn;
        private System.Windows.Forms.Label title_lbl;
        private System.Windows.Forms.Button resetGraphBtn;
        internal System.Windows.Forms.Label statusLbl;
        internal System.Windows.Forms.Button browseFile;
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
        private System.Windows.Forms.TextBox nodeZTxt;
        private System.Windows.Forms.Label nodeZLbl;
        private System.Windows.Forms.TextBox nodeYTxt;
        private System.Windows.Forms.Label nodeYLbl;
        private System.Windows.Forms.TextBox nodeXTxt;
        private System.Windows.Forms.Label nodeXLbl;
        private System.Windows.Forms.TextBox graphAreaLbl;
        private System.Windows.Forms.TextBox graphIdTxt;
        private System.Windows.Forms.CheckBox overwriteCb;
        private System.Windows.Forms.CheckBox nodeCurrPosCb;
        private System.Windows.Forms.Button saveGraphBtn;
        private System.Windows.Forms.CheckBox graphPosCb;
        private System.Windows.Forms.TextBox graphMaxNodesTxt;
        private System.Windows.Forms.Label maxNodesLbl;
        private System.Windows.Forms.ComboBox nodeCriteriaDD;
        private System.Windows.Forms.Label nodeCriteriaLbl;
        private System.Windows.Forms.Button resetLevelBtn;
        private System.Windows.Forms.Label levelLbl;
        private System.Windows.Forms.CheckBox playerCurrPosCb;
    }
}

