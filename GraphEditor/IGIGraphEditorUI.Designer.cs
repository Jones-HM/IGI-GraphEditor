
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
            this.standaloneCb = new System.Windows.Forms.CheckBox();
            this.setOutputPathBtn = new System.Windows.Forms.Button();
            this.browseFile = new System.Windows.Forms.Button();
            this.editorTabs = new System.Windows.Forms.TabControl();
            this.graphEditor = new System.Windows.Forms.TabPage();
            this.maxNodesLbl = new System.Windows.Forms.Label();
            this.statusLbl = new System.Windows.Forms.Label();
            this.graphTotalNodesLbl = new System.Windows.Forms.Label();
            this.nodeCriteriaDD = new System.Windows.Forms.ComboBox();
            this.graphPosCb = new System.Windows.Forms.CheckBox();
            this.playerCurrPosCb = new System.Windows.Forms.CheckBox();
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
            this.graphMaxNodesTxt = new System.Windows.Forms.TextBox();
            this.graphTotalNodesTxt = new System.Windows.Forms.TextBox();
            this.resetLevelBtn = new System.Windows.Forms.Button();
            this.resetGraphBtn = new System.Windows.Forms.Button();
            this.saveGraphBtn = new System.Windows.Forms.Button();
            this.saveNodeBtn = new System.Windows.Forms.Button();
            this.graphHexEditor = new System.Windows.Forms.TabPage();
            this.elementHost = new System.Windows.Forms.Integration.ElementHost();
            this.hexEditor = new WpfHexaEditor.HexEditor();
            this.standardHexBoxCb = new System.Windows.Forms.CheckBox();
            this.graphHexFormatCb = new System.Windows.Forms.CheckBox();
            this.graphHexResetDataCb = new System.Windows.Forms.CheckBox();
            this.graphHexSaveBtn = new System.Windows.Forms.Button();
            this.graphHexNodeIdDD = new System.Windows.Forms.ComboBox();
            this.graphHexDataLbl = new System.Windows.Forms.Label();
            this.graphHexDataTxt = new System.Windows.Forms.TextBox();
            this.graphHexDataTypeLbl = new System.Windows.Forms.Label();
            this.graphHexDataTypeTxt = new System.Windows.Forms.TextBox();
            this.graphHexNodeIdLbl = new System.Windows.Forms.Label();
            this.graphHexSigLbl = new System.Windows.Forms.Label();
            this.graphHexColorsDD = new System.Windows.Forms.ComboBox();
            this.graphHexItemsDD = new System.Windows.Forms.ComboBox();
            this.graphHexSigTxt = new System.Windows.Forms.TextBox();
            this.customHexViewerTxt = new System.Windows.Forms.RichTextBox();
            this.levelLbl = new System.Windows.Forms.Label();
            this.formMoverPanel = new System.Windows.Forms.Panel();
            this.aboutBtn = new System.Windows.Forms.Label();
            this.enableLogsCb = new System.Windows.Forms.CheckBox();
            this.minimizeBtn = new System.Windows.Forms.Label();
            this.closeBtn = new System.Windows.Forms.Label();
            this.title_lbl = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.editorTabs.SuspendLayout();
            this.graphEditor.SuspendLayout();
            this.graphHexEditor.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.AllowDrop = true;
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(35)))), ((int)(((byte)(54)))));
            this.mainPanel.Controls.Add(this.standaloneCb);
            this.mainPanel.Controls.Add(this.statusLbl);
            this.mainPanel.Controls.Add(this.setOutputPathBtn);
            this.mainPanel.Controls.Add(this.browseFile);
            this.mainPanel.Controls.Add(this.editorTabs);
            this.mainPanel.Controls.Add(this.levelLbl);
            this.mainPanel.Controls.Add(this.formMoverPanel);
            this.mainPanel.Controls.Add(this.aboutBtn);
            this.mainPanel.Controls.Add(this.enableLogsCb);
            this.mainPanel.Controls.Add(this.minimizeBtn);
            this.mainPanel.Controls.Add(this.closeBtn);
            this.mainPanel.Controls.Add(this.title_lbl);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(4);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1147, 741);
            this.mainPanel.TabIndex = 5;
            // 
            // standaloneCb
            // 
            this.standaloneCb.AutoSize = true;
            this.standaloneCb.Checked = true;
            this.standaloneCb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.standaloneCb.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.standaloneCb.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.standaloneCb.Location = new System.Drawing.Point(1028, 68);
            this.standaloneCb.Margin = new System.Windows.Forms.Padding(4);
            this.standaloneCb.Name = "standaloneCb";
            this.standaloneCb.Size = new System.Drawing.Size(114, 24);
            this.standaloneCb.TabIndex = 115;
            this.standaloneCb.Text = "Standalone";
            this.standaloneCb.UseVisualStyleBackColor = true;
            this.standaloneCb.CheckedChanged += new System.EventHandler(this.standaloneCb_CheckedChanged);
            // 
            // setOutputPathBtn
            // 
            this.setOutputPathBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.setOutputPathBtn.BackColor = System.Drawing.Color.Transparent;
            this.setOutputPathBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setOutputPathBtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setOutputPathBtn.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.setOutputPathBtn.Location = new System.Drawing.Point(508, 66);
            this.setOutputPathBtn.Margin = new System.Windows.Forms.Padding(4);
            this.setOutputPathBtn.Name = "setOutputPathBtn";
            this.setOutputPathBtn.Size = new System.Drawing.Size(306, 38);
            this.setOutputPathBtn.TabIndex = 91;
            this.setOutputPathBtn.Text = "Set Output Path";
            this.setOutputPathBtn.UseVisualStyleBackColor = false;
            this.setOutputPathBtn.Click += new System.EventHandler(this.setGamePathBtn_Click);
            // 
            // browseFile
            // 
            this.browseFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.browseFile.BackColor = System.Drawing.Color.Transparent;
            this.browseFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browseFile.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browseFile.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.browseFile.Location = new System.Drawing.Point(194, 66);
            this.browseFile.Margin = new System.Windows.Forms.Padding(4);
            this.browseFile.Name = "browseFile";
            this.browseFile.Size = new System.Drawing.Size(306, 38);
            this.browseFile.TabIndex = 89;
            this.browseFile.Text = "Browse Graph File";
            this.browseFile.UseVisualStyleBackColor = false;
            this.browseFile.Click += new System.EventHandler(this.browseFile_Click);
            // 
            // editorTabs
            // 
            this.editorTabs.Controls.Add(this.graphEditor);
            this.editorTabs.Controls.Add(this.graphHexEditor);
            this.editorTabs.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.editorTabs.Location = new System.Drawing.Point(0, 123);
            this.editorTabs.Name = "editorTabs";
            this.editorTabs.SelectedIndex = 0;
            this.editorTabs.Size = new System.Drawing.Size(1147, 615);
            this.editorTabs.TabIndex = 88;
            this.editorTabs.Selected += new System.Windows.Forms.TabControlEventHandler(this.editorTabs_Selected);
            // 
            // graphEditor
            // 
            this.graphEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(35)))), ((int)(((byte)(54)))));
            this.graphEditor.Controls.Add(this.maxNodesLbl);
            this.graphEditor.Controls.Add(this.graphTotalNodesLbl);
            this.graphEditor.Controls.Add(this.nodeCriteriaDD);
            this.graphEditor.Controls.Add(this.graphPosCb);
            this.graphEditor.Controls.Add(this.playerCurrPosCb);
            this.graphEditor.Controls.Add(this.nodeCurrPosCb);
            this.graphEditor.Controls.Add(this.overwriteCb);
            this.graphEditor.Controls.Add(this.label1);
            this.graphEditor.Controls.Add(this.graphAreaLbl);
            this.graphEditor.Controls.Add(this.nodeZTxt);
            this.graphEditor.Controls.Add(this.nodeZLbl);
            this.graphEditor.Controls.Add(this.nodeYTxt);
            this.graphEditor.Controls.Add(this.nodeYLbl);
            this.graphEditor.Controls.Add(this.nodeXTxt);
            this.graphEditor.Controls.Add(this.nodeXLbl);
            this.graphEditor.Controls.Add(this.nodeIdDD);
            this.graphEditor.Controls.Add(this.nodeCriteriaLbl);
            this.graphEditor.Controls.Add(this.nodeIdLbl);
            this.graphEditor.Controls.Add(this.graphIdLbl);
            this.graphEditor.Controls.Add(this.graphMaxNodesTxt);
            this.graphEditor.Controls.Add(this.graphTotalNodesTxt);
            this.graphEditor.Controls.Add(this.resetLevelBtn);
            this.graphEditor.Controls.Add(this.resetGraphBtn);
            this.graphEditor.Controls.Add(this.saveGraphBtn);
            this.graphEditor.Controls.Add(this.saveNodeBtn);
            this.graphEditor.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.graphEditor.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.graphEditor.Location = new System.Drawing.Point(4, 30);
            this.graphEditor.Margin = new System.Windows.Forms.Padding(4);
            this.graphEditor.Name = "graphEditor";
            this.graphEditor.Padding = new System.Windows.Forms.Padding(3);
            this.graphEditor.Size = new System.Drawing.Size(1139, 581);
            this.graphEditor.TabIndex = 0;
            this.graphEditor.Text = "Graph Editor";
            // 
            // maxNodesLbl
            // 
            this.maxNodesLbl.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.maxNodesLbl.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.maxNodesLbl.Location = new System.Drawing.Point(476, 37);
            this.maxNodesLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.maxNodesLbl.Name = "maxNodesLbl";
            this.maxNodesLbl.Size = new System.Drawing.Size(134, 33);
            this.maxNodesLbl.TabIndex = 114;
            this.maxNodesLbl.Text = "Max Nodes:";
            this.maxNodesLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusLbl
            // 
            this.statusLbl.AutoSize = true;
            this.statusLbl.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.statusLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLbl.ForeColor = System.Drawing.Color.SkyBlue;
            this.statusLbl.Location = new System.Drawing.Point(358, 108);
            this.statusLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(68, 25);
            this.statusLbl.TabIndex = 90;
            this.statusLbl.Text = "Status";
            this.statusLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // graphTotalNodesLbl
            // 
            this.graphTotalNodesLbl.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.graphTotalNodesLbl.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.graphTotalNodesLbl.Location = new System.Drawing.Point(754, 37);
            this.graphTotalNodesLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.graphTotalNodesLbl.Name = "graphTotalNodesLbl";
            this.graphTotalNodesLbl.Size = new System.Drawing.Size(134, 33);
            this.graphTotalNodesLbl.TabIndex = 113;
            this.graphTotalNodesLbl.Text = "Total Nodes:";
            this.graphTotalNodesLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.nodeCriteriaDD.Location = new System.Drawing.Point(912, 163);
            this.nodeCriteriaDD.Name = "nodeCriteriaDD";
            this.nodeCriteriaDD.Size = new System.Drawing.Size(200, 29);
            this.nodeCriteriaDD.TabIndex = 112;
            this.nodeCriteriaDD.SelectedIndexChanged += new System.EventHandler(this.nodeIdDD_SelectedIndexChanged);
            // 
            // graphPosCb
            // 
            this.graphPosCb.AutoSize = true;
            this.graphPosCb.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.graphPosCb.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.graphPosCb.Location = new System.Drawing.Point(49, 469);
            this.graphPosCb.Margin = new System.Windows.Forms.Padding(4);
            this.graphPosCb.Name = "graphPosCb";
            this.graphPosCb.Size = new System.Drawing.Size(107, 24);
            this.graphPosCb.TabIndex = 111;
            this.graphPosCb.Text = "Graph Pos";
            this.graphPosCb.UseVisualStyleBackColor = true;
            this.graphPosCb.CheckedChanged += new System.EventHandler(this.graphPosCb_CheckedChanged);
            // 
            // playerCurrPosCb
            // 
            this.playerCurrPosCb.AutoSize = true;
            this.playerCurrPosCb.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.playerCurrPosCb.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.playerCurrPosCb.Location = new System.Drawing.Point(275, 201);
            this.playerCurrPosCb.Margin = new System.Windows.Forms.Padding(4);
            this.playerCurrPosCb.Name = "playerCurrPosCb";
            this.playerCurrPosCb.Size = new System.Drawing.Size(105, 24);
            this.playerCurrPosCb.TabIndex = 110;
            this.playerCurrPosCb.Text = "Player Pos";
            this.playerCurrPosCb.UseVisualStyleBackColor = true;
            this.playerCurrPosCb.CheckedChanged += new System.EventHandler(this.playerCurrPosCb_CheckedChanged);
            // 
            // nodeCurrPosCb
            // 
            this.nodeCurrPosCb.AutoSize = true;
            this.nodeCurrPosCb.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.nodeCurrPosCb.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.nodeCurrPosCb.Location = new System.Drawing.Point(281, 469);
            this.nodeCurrPosCb.Margin = new System.Windows.Forms.Padding(4);
            this.nodeCurrPosCb.Name = "nodeCurrPosCb";
            this.nodeCurrPosCb.Size = new System.Drawing.Size(101, 24);
            this.nodeCurrPosCb.TabIndex = 109;
            this.nodeCurrPosCb.Text = "Node Pos";
            this.nodeCurrPosCb.UseVisualStyleBackColor = true;
            this.nodeCurrPosCb.CheckedChanged += new System.EventHandler(this.nodeCurrPosCb_CheckedChanged);
            // 
            // overwriteCb
            // 
            this.overwriteCb.AutoSize = true;
            this.overwriteCb.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.overwriteCb.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.overwriteCb.Location = new System.Drawing.Point(49, 448);
            this.overwriteCb.Margin = new System.Windows.Forms.Padding(4);
            this.overwriteCb.Name = "overwriteCb";
            this.overwriteCb.Size = new System.Drawing.Size(106, 24);
            this.overwriteCb.TabIndex = 107;
            this.overwriteCb.Text = "Overwrite";
            this.overwriteCb.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.label1.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label1.Location = new System.Drawing.Point(223, 161);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 33);
            this.label1.TabIndex = 106;
            this.label1.Text = "X :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // graphAreaLbl
            // 
            this.graphAreaLbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(35)))), ((int)(((byte)(54)))));
            this.graphAreaLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.graphAreaLbl.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.graphAreaLbl.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.graphAreaLbl.Location = new System.Drawing.Point(188, 37);
            this.graphAreaLbl.Margin = new System.Windows.Forms.Padding(4);
            this.graphAreaLbl.Name = "graphAreaLbl";
            this.graphAreaLbl.ReadOnly = true;
            this.graphAreaLbl.Size = new System.Drawing.Size(196, 30);
            this.graphAreaLbl.TabIndex = 105;
            // 
            // nodeZTxt
            // 
            this.nodeZTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(35)))), ((int)(((byte)(54)))));
            this.nodeZTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nodeZTxt.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.nodeZTxt.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.nodeZTxt.Location = new System.Drawing.Point(667, 163);
            this.nodeZTxt.Margin = new System.Windows.Forms.Padding(4);
            this.nodeZTxt.Name = "nodeZTxt";
            this.nodeZTxt.Size = new System.Drawing.Size(120, 30);
            this.nodeZTxt.TabIndex = 104;
            this.nodeZTxt.Text = "0";
            // 
            // nodeZLbl
            // 
            this.nodeZLbl.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.nodeZLbl.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.nodeZLbl.Location = new System.Drawing.Point(615, 160);
            this.nodeZLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nodeZLbl.Name = "nodeZLbl";
            this.nodeZLbl.Size = new System.Drawing.Size(44, 33);
            this.nodeZLbl.TabIndex = 103;
            this.nodeZLbl.Text = "Z :";
            this.nodeZLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nodeYTxt
            // 
            this.nodeYTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(35)))), ((int)(((byte)(54)))));
            this.nodeYTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nodeYTxt.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.nodeYTxt.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.nodeYTxt.Location = new System.Drawing.Point(466, 163);
            this.nodeYTxt.Margin = new System.Windows.Forms.Padding(4);
            this.nodeYTxt.Name = "nodeYTxt";
            this.nodeYTxt.Size = new System.Drawing.Size(120, 30);
            this.nodeYTxt.TabIndex = 102;
            this.nodeYTxt.Text = "0";
            // 
            // nodeYLbl
            // 
            this.nodeYLbl.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.nodeYLbl.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.nodeYLbl.Location = new System.Drawing.Point(414, 160);
            this.nodeYLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nodeYLbl.Name = "nodeYLbl";
            this.nodeYLbl.Size = new System.Drawing.Size(44, 33);
            this.nodeYLbl.TabIndex = 101;
            this.nodeYLbl.Text = "Y :";
            this.nodeYLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nodeXTxt
            // 
            this.nodeXTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(35)))), ((int)(((byte)(54)))));
            this.nodeXTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nodeXTxt.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.nodeXTxt.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.nodeXTxt.Location = new System.Drawing.Point(275, 163);
            this.nodeXTxt.Margin = new System.Windows.Forms.Padding(4);
            this.nodeXTxt.Name = "nodeXTxt";
            this.nodeXTxt.Size = new System.Drawing.Size(120, 30);
            this.nodeXTxt.TabIndex = 100;
            this.nodeXTxt.Text = "0";
            // 
            // nodeXLbl
            // 
            this.nodeXLbl.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.nodeXLbl.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.nodeXLbl.Location = new System.Drawing.Point(496, 161);
            this.nodeXLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nodeXLbl.Name = "nodeXLbl";
            this.nodeXLbl.Size = new System.Drawing.Size(44, 33);
            this.nodeXLbl.TabIndex = 99;
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
            this.nodeIdDD.Location = new System.Drawing.Point(136, 166);
            this.nodeIdDD.Name = "nodeIdDD";
            this.nodeIdDD.Size = new System.Drawing.Size(73, 29);
            this.nodeIdDD.TabIndex = 98;
            this.nodeIdDD.SelectedIndexChanged += new System.EventHandler(this.nodeIdDD_SelectedIndexChanged);
            // 
            // nodeCriteriaLbl
            // 
            this.nodeCriteriaLbl.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.nodeCriteriaLbl.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.nodeCriteriaLbl.Location = new System.Drawing.Point(772, 163);
            this.nodeCriteriaLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nodeCriteriaLbl.Name = "nodeCriteriaLbl";
            this.nodeCriteriaLbl.Size = new System.Drawing.Size(143, 33);
            this.nodeCriteriaLbl.TabIndex = 97;
            this.nodeCriteriaLbl.Text = "Criteria:";
            this.nodeCriteriaLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nodeIdLbl
            // 
            this.nodeIdLbl.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.nodeIdLbl.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.nodeIdLbl.Location = new System.Drawing.Point(13, 160);
            this.nodeIdLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nodeIdLbl.Name = "nodeIdLbl";
            this.nodeIdLbl.Size = new System.Drawing.Size(116, 33);
            this.nodeIdLbl.TabIndex = 96;
            this.nodeIdLbl.Text = "Node Id :";
            this.nodeIdLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // graphIdLbl
            // 
            this.graphIdLbl.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.graphIdLbl.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.graphIdLbl.Location = new System.Drawing.Point(13, 37);
            this.graphIdLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.graphIdLbl.Name = "graphIdLbl";
            this.graphIdLbl.Size = new System.Drawing.Size(143, 33);
            this.graphIdLbl.TabIndex = 95;
            this.graphIdLbl.Text = "Graph Area:";
            this.graphIdLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // graphMaxNodesTxt
            // 
            this.graphMaxNodesTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(35)))), ((int)(((byte)(54)))));
            this.graphMaxNodesTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.graphMaxNodesTxt.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.graphMaxNodesTxt.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.graphMaxNodesTxt.Location = new System.Drawing.Point(923, 39);
            this.graphMaxNodesTxt.Margin = new System.Windows.Forms.Padding(4);
            this.graphMaxNodesTxt.Name = "graphMaxNodesTxt";
            this.graphMaxNodesTxt.Size = new System.Drawing.Size(62, 30);
            this.graphMaxNodesTxt.TabIndex = 93;
            // 
            // graphTotalNodesTxt
            // 
            this.graphTotalNodesTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(35)))), ((int)(((byte)(54)))));
            this.graphTotalNodesTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.graphTotalNodesTxt.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.graphTotalNodesTxt.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.graphTotalNodesTxt.Location = new System.Drawing.Point(652, 39);
            this.graphTotalNodesTxt.Margin = new System.Windows.Forms.Padding(4);
            this.graphTotalNodesTxt.Name = "graphTotalNodesTxt";
            this.graphTotalNodesTxt.Size = new System.Drawing.Size(62, 30);
            this.graphTotalNodesTxt.TabIndex = 92;
            // 
            // resetLevelBtn
            // 
            this.resetLevelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.resetLevelBtn.BackColor = System.Drawing.Color.Transparent;
            this.resetLevelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resetLevelBtn.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.resetLevelBtn.ForeColor = System.Drawing.Color.Tomato;
            this.resetLevelBtn.Location = new System.Drawing.Point(795, 500);
            this.resetLevelBtn.Margin = new System.Windows.Forms.Padding(4);
            this.resetLevelBtn.Name = "resetLevelBtn";
            this.resetLevelBtn.Size = new System.Drawing.Size(207, 35);
            this.resetLevelBtn.TabIndex = 90;
            this.resetLevelBtn.Text = "Reset Level";
            this.resetLevelBtn.UseVisualStyleBackColor = false;
            this.resetLevelBtn.Click += new System.EventHandler(this.resetLevelBtn_Click);
            // 
            // resetGraphBtn
            // 
            this.resetGraphBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.resetGraphBtn.BackColor = System.Drawing.Color.Transparent;
            this.resetGraphBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resetGraphBtn.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.resetGraphBtn.ForeColor = System.Drawing.Color.Tomato;
            this.resetGraphBtn.Location = new System.Drawing.Point(580, 501);
            this.resetGraphBtn.Margin = new System.Windows.Forms.Padding(4);
            this.resetGraphBtn.Name = "resetGraphBtn";
            this.resetGraphBtn.Size = new System.Drawing.Size(207, 35);
            this.resetGraphBtn.TabIndex = 89;
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
            this.saveGraphBtn.Location = new System.Drawing.Point(43, 501);
            this.saveGraphBtn.Margin = new System.Windows.Forms.Padding(4);
            this.saveGraphBtn.Name = "saveGraphBtn";
            this.saveGraphBtn.Size = new System.Drawing.Size(207, 35);
            this.saveGraphBtn.TabIndex = 91;
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
            this.saveNodeBtn.Location = new System.Drawing.Point(274, 501);
            this.saveNodeBtn.Margin = new System.Windows.Forms.Padding(4);
            this.saveNodeBtn.Name = "saveNodeBtn";
            this.saveNodeBtn.Size = new System.Drawing.Size(207, 35);
            this.saveNodeBtn.TabIndex = 88;
            this.saveNodeBtn.Text = "Save Node";
            this.saveNodeBtn.UseVisualStyleBackColor = false;
            this.saveNodeBtn.Click += new System.EventHandler(this.saveNodeBtn_Click);
            // 
            // graphHexEditor
            // 
            this.graphHexEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(35)))), ((int)(((byte)(54)))));
            this.graphHexEditor.Controls.Add(this.elementHost);
            this.graphHexEditor.Controls.Add(this.standardHexBoxCb);
            this.graphHexEditor.Controls.Add(this.graphHexFormatCb);
            this.graphHexEditor.Controls.Add(this.graphHexResetDataCb);
            this.graphHexEditor.Controls.Add(this.graphHexSaveBtn);
            this.graphHexEditor.Controls.Add(this.graphHexNodeIdDD);
            this.graphHexEditor.Controls.Add(this.graphHexDataLbl);
            this.graphHexEditor.Controls.Add(this.graphHexDataTxt);
            this.graphHexEditor.Controls.Add(this.graphHexDataTypeLbl);
            this.graphHexEditor.Controls.Add(this.graphHexDataTypeTxt);
            this.graphHexEditor.Controls.Add(this.graphHexNodeIdLbl);
            this.graphHexEditor.Controls.Add(this.graphHexSigLbl);
            this.graphHexEditor.Controls.Add(this.graphHexColorsDD);
            this.graphHexEditor.Controls.Add(this.graphHexItemsDD);
            this.graphHexEditor.Controls.Add(this.graphHexSigTxt);
            this.graphHexEditor.Controls.Add(this.customHexViewerTxt);
            this.graphHexEditor.Location = new System.Drawing.Point(4, 30);
            this.graphHexEditor.Margin = new System.Windows.Forms.Padding(4);
            this.graphHexEditor.Name = "graphHexEditor";
            this.graphHexEditor.Padding = new System.Windows.Forms.Padding(3);
            this.graphHexEditor.Size = new System.Drawing.Size(1139, 581);
            this.graphHexEditor.TabIndex = 1;
            this.graphHexEditor.Text = "Hex Editor";
            // 
            // elementHost
            // 
            this.elementHost.Location = new System.Drawing.Point(0, 0);
            this.elementHost.Name = "elementHost";
            this.elementHost.Size = new System.Drawing.Size(938, 581);
            this.elementHost.TabIndex = 123;
            this.elementHost.Text = "elementHost";
            this.elementHost.Visible = false;
            this.elementHost.Child = this.hexEditor;
            // 
            // standardHexBoxCb
            // 
            this.standardHexBoxCb.AutoSize = true;
            this.standardHexBoxCb.Checked = true;
            this.standardHexBoxCb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.standardHexBoxCb.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.standardHexBoxCb.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.standardHexBoxCb.Location = new System.Drawing.Point(945, 518);
            this.standardHexBoxCb.Margin = new System.Windows.Forms.Padding(4);
            this.standardHexBoxCb.Name = "standardHexBoxCb";
            this.standardHexBoxCb.Size = new System.Drawing.Size(163, 23);
            this.standardHexBoxCb.TabIndex = 120;
            this.standardHexBoxCb.Text = "Standard Hex View";
            this.standardHexBoxCb.UseVisualStyleBackColor = true;
            this.standardHexBoxCb.CheckedChanged += new System.EventHandler(this.standardHexBoxCb_CheckedChanged);
            // 
            // graphHexFormatCb
            // 
            this.graphHexFormatCb.AutoSize = true;
            this.graphHexFormatCb.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.graphHexFormatCb.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.graphHexFormatCb.Location = new System.Drawing.Point(945, 497);
            this.graphHexFormatCb.Margin = new System.Windows.Forms.Padding(4);
            this.graphHexFormatCb.Name = "graphHexFormatCb";
            this.graphHexFormatCb.Size = new System.Drawing.Size(115, 23);
            this.graphHexFormatCb.TabIndex = 120;
            this.graphHexFormatCb.Text = "Auto Format";
            this.graphHexFormatCb.UseVisualStyleBackColor = true;
            this.graphHexFormatCb.CheckedChanged += new System.EventHandler(this.graphHexFormatCb_CheckedChanged);
            // 
            // graphHexResetDataCb
            // 
            this.graphHexResetDataCb.AutoSize = true;
            this.graphHexResetDataCb.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.graphHexResetDataCb.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.graphHexResetDataCb.Location = new System.Drawing.Point(945, 478);
            this.graphHexResetDataCb.Margin = new System.Windows.Forms.Padding(4);
            this.graphHexResetDataCb.Name = "graphHexResetDataCb";
            this.graphHexResetDataCb.Size = new System.Drawing.Size(107, 23);
            this.graphHexResetDataCb.TabIndex = 119;
            this.graphHexResetDataCb.Text = "Reset Data";
            this.graphHexResetDataCb.UseVisualStyleBackColor = true;
            this.graphHexResetDataCb.CheckedChanged += new System.EventHandler(this.graphHexResetDataCb_CheckedChanged);
            // 
            // graphHexSaveBtn
            // 
            this.graphHexSaveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.graphHexSaveBtn.Font = new System.Drawing.Font("Century Gothic", 10.2F);
            this.graphHexSaveBtn.ForeColor = System.Drawing.Color.SpringGreen;
            this.graphHexSaveBtn.Location = new System.Drawing.Point(945, 437);
            this.graphHexSaveBtn.Margin = new System.Windows.Forms.Padding(4);
            this.graphHexSaveBtn.Name = "graphHexSaveBtn";
            this.graphHexSaveBtn.Size = new System.Drawing.Size(188, 33);
            this.graphHexSaveBtn.TabIndex = 118;
            this.graphHexSaveBtn.Text = "Save File";
            this.graphHexSaveBtn.UseVisualStyleBackColor = true;
            this.graphHexSaveBtn.Click += new System.EventHandler(this.graphHexSaveBtn_Click);
            // 
            // graphHexNodeIdDD
            // 
            this.graphHexNodeIdDD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(35)))), ((int)(((byte)(54)))));
            this.graphHexNodeIdDD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.graphHexNodeIdDD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.graphHexNodeIdDD.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.graphHexNodeIdDD.FormattingEnabled = true;
            this.graphHexNodeIdDD.Location = new System.Drawing.Point(945, 306);
            this.graphHexNodeIdDD.Name = "graphHexNodeIdDD";
            this.graphHexNodeIdDD.Size = new System.Drawing.Size(188, 29);
            this.graphHexNodeIdDD.TabIndex = 117;
            this.graphHexNodeIdDD.SelectedIndexChanged += new System.EventHandler(this.graphHexNodeIdDD_SelectedIndexChanged);
            // 
            // graphHexDataLbl
            // 
            this.graphHexDataLbl.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.graphHexDataLbl.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.graphHexDataLbl.Location = new System.Drawing.Point(945, 350);
            this.graphHexDataLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.graphHexDataLbl.Name = "graphHexDataLbl";
            this.graphHexDataLbl.Size = new System.Drawing.Size(189, 33);
            this.graphHexDataLbl.TabIndex = 116;
            this.graphHexDataLbl.Text = "Graph Data";
            this.graphHexDataLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // graphHexDataTxt
            // 
            this.graphHexDataTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(35)))), ((int)(((byte)(54)))));
            this.graphHexDataTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.graphHexDataTxt.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.graphHexDataTxt.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.graphHexDataTxt.Location = new System.Drawing.Point(945, 387);
            this.graphHexDataTxt.Margin = new System.Windows.Forms.Padding(4);
            this.graphHexDataTxt.Name = "graphHexDataTxt";
            this.graphHexDataTxt.ReadOnly = true;
            this.graphHexDataTxt.Size = new System.Drawing.Size(189, 30);
            this.graphHexDataTxt.TabIndex = 115;
            // 
            // graphHexDataTypeLbl
            // 
            this.graphHexDataTypeLbl.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.graphHexDataTypeLbl.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.graphHexDataTypeLbl.Location = new System.Drawing.Point(945, 166);
            this.graphHexDataTypeLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.graphHexDataTypeLbl.Name = "graphHexDataTypeLbl";
            this.graphHexDataTypeLbl.Size = new System.Drawing.Size(189, 33);
            this.graphHexDataTypeLbl.TabIndex = 116;
            this.graphHexDataTypeLbl.Text = "Data-Type";
            this.graphHexDataTypeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // graphHexDataTypeTxt
            // 
            this.graphHexDataTypeTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(35)))), ((int)(((byte)(54)))));
            this.graphHexDataTypeTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.graphHexDataTypeTxt.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.graphHexDataTypeTxt.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.graphHexDataTypeTxt.Location = new System.Drawing.Point(945, 203);
            this.graphHexDataTypeTxt.Margin = new System.Windows.Forms.Padding(4);
            this.graphHexDataTypeTxt.Name = "graphHexDataTypeTxt";
            this.graphHexDataTypeTxt.ReadOnly = true;
            this.graphHexDataTypeTxt.Size = new System.Drawing.Size(189, 30);
            this.graphHexDataTypeTxt.TabIndex = 115;
            // 
            // graphHexNodeIdLbl
            // 
            this.graphHexNodeIdLbl.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.graphHexNodeIdLbl.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.graphHexNodeIdLbl.Location = new System.Drawing.Point(945, 270);
            this.graphHexNodeIdLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.graphHexNodeIdLbl.Name = "graphHexNodeIdLbl";
            this.graphHexNodeIdLbl.Size = new System.Drawing.Size(189, 33);
            this.graphHexNodeIdLbl.TabIndex = 114;
            this.graphHexNodeIdLbl.Text = "Node #";
            this.graphHexNodeIdLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // graphHexSigLbl
            // 
            this.graphHexSigLbl.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.graphHexSigLbl.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.graphHexSigLbl.Location = new System.Drawing.Point(945, 73);
            this.graphHexSigLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.graphHexSigLbl.Name = "graphHexSigLbl";
            this.graphHexSigLbl.Size = new System.Drawing.Size(189, 33);
            this.graphHexSigLbl.TabIndex = 114;
            this.graphHexSigLbl.Text = "Signature";
            this.graphHexSigLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // graphHexColorsDD
            // 
            this.graphHexColorsDD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(35)))), ((int)(((byte)(54)))));
            this.graphHexColorsDD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.graphHexColorsDD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.graphHexColorsDD.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.graphHexColorsDD.FormattingEnabled = true;
            this.graphHexColorsDD.Items.AddRange(new object[] {
            "Red",
            "Cyan",
            "Blue",
            "Green",
            "Yellow",
            "Gray",
            "Indigo",
            "Khaki",
            "Olive",
            "SaddleBrown",
            "Salmon",
            "Snow",
            "Tomato",
            "Turquoise",
            "Violet",
            "DarkOrchid",
            "Gold",
            "Fuschia",
            "ForestGreen",
            "Honeydew",
            "Pink",
            "Purple",
            "Silver",
            "Teal",
            "Tan"});
            this.graphHexColorsDD.Location = new System.Drawing.Point(945, 41);
            this.graphHexColorsDD.Name = "graphHexColorsDD";
            this.graphHexColorsDD.Size = new System.Drawing.Size(188, 29);
            this.graphHexColorsDD.TabIndex = 113;
            this.graphHexColorsDD.SelectedIndexChanged += new System.EventHandler(this.graphHexItemsDD_SelectedIndexChanged);
            // 
            // graphHexItemsDD
            // 
            this.graphHexItemsDD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(35)))), ((int)(((byte)(54)))));
            this.graphHexItemsDD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.graphHexItemsDD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.graphHexItemsDD.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.graphHexItemsDD.FormattingEnabled = true;
            this.graphHexItemsDD.Location = new System.Drawing.Point(945, 6);
            this.graphHexItemsDD.Name = "graphHexItemsDD";
            this.graphHexItemsDD.Size = new System.Drawing.Size(188, 29);
            this.graphHexItemsDD.TabIndex = 113;
            this.graphHexItemsDD.SelectedIndexChanged += new System.EventHandler(this.graphHexItemsDD_SelectedIndexChanged);
            // 
            // graphHexSigTxt
            // 
            this.graphHexSigTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(35)))), ((int)(((byte)(54)))));
            this.graphHexSigTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.graphHexSigTxt.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.graphHexSigTxt.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.graphHexSigTxt.Location = new System.Drawing.Point(945, 110);
            this.graphHexSigTxt.Margin = new System.Windows.Forms.Padding(4);
            this.graphHexSigTxt.Name = "graphHexSigTxt";
            this.graphHexSigTxt.ReadOnly = true;
            this.graphHexSigTxt.Size = new System.Drawing.Size(189, 30);
            this.graphHexSigTxt.TabIndex = 56;
            // 
            // customHexViewerTxt
            // 
            this.customHexViewerTxt.AutoWordSelection = true;
            this.customHexViewerTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(35)))), ((int)(((byte)(54)))));
            this.customHexViewerTxt.ForeColor = System.Drawing.Color.White;
            this.customHexViewerTxt.Location = new System.Drawing.Point(3, 0);
            this.customHexViewerTxt.Name = "customHexViewerTxt";
            this.customHexViewerTxt.Size = new System.Drawing.Size(936, 581);
            this.customHexViewerTxt.TabIndex = 55;
            this.customHexViewerTxt.Text = "GRAPH HEX VIEW";
            this.customHexViewerTxt.MouseUp += new System.Windows.Forms.MouseEventHandler(this.customHexViewerTxt_MouseUp);
            // 
            // levelLbl
            // 
            this.levelLbl.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.levelLbl.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.levelLbl.Location = new System.Drawing.Point(919, 68);
            this.levelLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.levelLbl.Name = "levelLbl";
            this.levelLbl.Size = new System.Drawing.Size(103, 25);
            this.levelLbl.TabIndex = 70;
            this.levelLbl.Text = "Level:";
            this.levelLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // formMoverPanel
            // 
            this.formMoverPanel.BackColor = System.Drawing.Color.DodgerBlue;
            this.formMoverPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.formMoverPanel.Location = new System.Drawing.Point(0, 0);
            this.formMoverPanel.Margin = new System.Windows.Forms.Padding(4);
            this.formMoverPanel.Name = "formMoverPanel";
            this.formMoverPanel.Size = new System.Drawing.Size(1147, 12);
            this.formMoverPanel.TabIndex = 51;
            // 
            // aboutBtn
            // 
            this.aboutBtn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.aboutBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aboutBtn.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Bold);
            this.aboutBtn.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.aboutBtn.Location = new System.Drawing.Point(970, 16);
            this.aboutBtn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.aboutBtn.Name = "aboutBtn";
            this.aboutBtn.Size = new System.Drawing.Size(52, 46);
            this.aboutBtn.TabIndex = 50;
            this.aboutBtn.Text = "?";
            this.aboutBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.aboutBtn.Click += new System.EventHandler(this.aboutBtn_Click);
            // 
            // enableLogsCb
            // 
            this.enableLogsCb.AutoSize = true;
            this.enableLogsCb.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.enableLogsCb.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.enableLogsCb.Location = new System.Drawing.Point(1029, 92);
            this.enableLogsCb.Margin = new System.Windows.Forms.Padding(4);
            this.enableLogsCb.Name = "enableLogsCb";
            this.enableLogsCb.Size = new System.Drawing.Size(118, 24);
            this.enableLogsCb.TabIndex = 108;
            this.enableLogsCb.Text = "Enable Logs";
            this.enableLogsCb.UseVisualStyleBackColor = true;
            this.enableLogsCb.CheckedChanged += new System.EventHandler(this.enableLogsCb_CheckedChanged);
            // 
            // minimizeBtn
            // 
            this.minimizeBtn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.minimizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.minimizeBtn.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Bold);
            this.minimizeBtn.ForeColor = System.Drawing.Color.White;
            this.minimizeBtn.Location = new System.Drawing.Point(1030, 16);
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
            this.closeBtn.Location = new System.Drawing.Point(1090, 16);
            this.closeBtn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(52, 46);
            this.closeBtn.TabIndex = 48;
            this.closeBtn.Text = "x";
            this.closeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // title_lbl
            // 
            this.title_lbl.AutoSize = true;
            this.title_lbl.BackColor = System.Drawing.Color.Transparent;
            this.title_lbl.Font = new System.Drawing.Font("Harrington", 25F, System.Drawing.FontStyle.Bold);
            this.title_lbl.ForeColor = System.Drawing.Color.SkyBlue;
            this.title_lbl.Location = new System.Drawing.Point(269, 9);
            this.title_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.title_lbl.Name = "title_lbl";
            this.title_lbl.Size = new System.Drawing.Size(514, 50);
            this.title_lbl.TabIndex = 2;
            this.title_lbl.Text = "Project I.G.I Graph Editor";
            // 
            // IGIGraphEditorUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 741);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IGIGraphEditorUI";
            this.Text = "Project I.G.I Graph Editor- HM";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.editorTabs.ResumeLayout(false);
            this.graphEditor.ResumeLayout(false);
            this.graphEditor.PerformLayout();
            this.graphHexEditor.ResumeLayout(false);
            this.graphHexEditor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label title_lbl;
        private System.Windows.Forms.Label aboutBtn;
        private System.Windows.Forms.Label minimizeBtn;
        private System.Windows.Forms.Label closeBtn;
        private System.Windows.Forms.Panel formMoverPanel;
        private System.Windows.Forms.Label levelLbl;
        private System.Windows.Forms.TabControl editorTabs;
        private System.Windows.Forms.TabPage graphEditor;
        private System.Windows.Forms.Label maxNodesLbl;
        private System.Windows.Forms.Label graphTotalNodesLbl;
        private System.Windows.Forms.ComboBox nodeCriteriaDD;
        private System.Windows.Forms.CheckBox graphPosCb;
        private System.Windows.Forms.CheckBox playerCurrPosCb;
        private System.Windows.Forms.CheckBox nodeCurrPosCb;
        private System.Windows.Forms.CheckBox enableLogsCb;
        private System.Windows.Forms.CheckBox overwriteCb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox graphAreaLbl;
        private System.Windows.Forms.TextBox nodeZTxt;
        private System.Windows.Forms.Label nodeZLbl;
        private System.Windows.Forms.TextBox nodeYTxt;
        private System.Windows.Forms.Label nodeYLbl;
        private System.Windows.Forms.TextBox nodeXTxt;
        private System.Windows.Forms.Label nodeXLbl;
        private System.Windows.Forms.ComboBox nodeIdDD;
        private System.Windows.Forms.Label nodeCriteriaLbl;
        private System.Windows.Forms.Label nodeIdLbl;
        private System.Windows.Forms.Label graphIdLbl;
        private System.Windows.Forms.TextBox graphMaxNodesTxt;
        private System.Windows.Forms.TextBox graphTotalNodesTxt;
        private System.Windows.Forms.Button resetLevelBtn;
        private System.Windows.Forms.Button resetGraphBtn;
        private System.Windows.Forms.Button saveGraphBtn;
        private System.Windows.Forms.Button saveNodeBtn;
        private System.Windows.Forms.TabPage graphHexEditor;
        internal System.Windows.Forms.Button setOutputPathBtn;
        internal System.Windows.Forms.Label statusLbl;
        internal System.Windows.Forms.Button browseFile;
        private System.Windows.Forms.RichTextBox customHexViewerTxt;
        private System.Windows.Forms.TextBox graphHexSigTxt;
        private System.Windows.Forms.ComboBox graphHexItemsDD;
        private System.Windows.Forms.Label graphHexSigLbl;
        private System.Windows.Forms.Label graphHexDataTypeLbl;
        private System.Windows.Forms.TextBox graphHexDataTypeTxt;
        private System.Windows.Forms.ComboBox graphHexColorsDD;
        private System.Windows.Forms.ComboBox graphHexNodeIdDD;
        private System.Windows.Forms.Label graphHexNodeIdLbl;
        private System.Windows.Forms.Label graphHexDataLbl;
        private System.Windows.Forms.TextBox graphHexDataTxt;
        private System.Windows.Forms.CheckBox graphHexFormatCb;
        private System.Windows.Forms.CheckBox graphHexResetDataCb;
        private System.Windows.Forms.Button graphHexSaveBtn;
        private System.Windows.Forms.Integration.ElementHost elementHost;
        private WpfHexaEditor.HexEditor hexEditor;
        private System.Windows.Forms.CheckBox standardHexBoxCb;
        private System.Windows.Forms.CheckBox standaloneCb;
    }
}

