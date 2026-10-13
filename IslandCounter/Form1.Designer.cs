namespace IslandCounter
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dgvHeaderStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dgvRowStyle = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.grpParams = new System.Windows.Forms.GroupBox();
            this.lblMinArea = new System.Windows.Forms.Label();
            this.numMinArea = new System.Windows.Forms.NumericUpDown();
            this.lblGroups = new System.Windows.Forms.Label();
            this.numGroups = new System.Windows.Forms.NumericUpDown();
            this.btnAnalyze = new System.Windows.Forms.Button();
            this.pnlSummary = new System.Windows.Forms.Panel();
            this.lblSummaryCoins = new System.Windows.Forms.Label();
            this.lblSummaryValue = new System.Windows.Forms.Label();
            this.lblSummaryTime = new System.Windows.Forms.Label();
            this.lblSummaryBaseColor = new System.Windows.Forms.Label();
            this.grpBreakdown = new System.Windows.Forms.GroupBox();
            this.dgvGroups = new System.Windows.Forms.DataGridView();
            this.colColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDenomination = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAvgArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpDisplay = new System.Windows.Forms.GroupBox();
            this.chkShowBounding = new System.Windows.Forms.CheckBox();
            this.chkShowLabels = new System.Windows.Forms.CheckBox();
            this.chkShowCentroids = new System.Windows.Forms.CheckBox();
            this.chkShowNumbers = new System.Windows.Forms.CheckBox();
            this.pnlImageViewer = new System.Windows.Forms.Panel();
            this.pnlImageToolbar = new System.Windows.Forms.Panel();
            this.lblViewMode = new System.Windows.Forms.Label();
            this.cmbViewMode = new System.Windows.Forms.ComboBox();
            this.lblImageInfo = new System.Windows.Forms.Label();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusHoverInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip();

            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.pnlSidebar.SuspendLayout();
            this.grpParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMinArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGroups)).BeginInit();
            this.pnlSummary.SuspendLayout();
            this.grpBreakdown.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroups)).BeginInit();
            this.grpDisplay.SuspendLayout();
            this.pnlImageViewer.SuspendLayout();
            this.pnlImageToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.lblSubtitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1180, 64);
            this.pnlTop.TabIndex = 0;

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(16, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(268, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Coin Counter && Classifier";

            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblSubtitle.Location = new System.Drawing.Point(18, 38);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(350, 15);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "DIP Island Counter • BFS Component Search && Gap Classification";

            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 64);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.pnlSidebar);
            this.splitContainerMain.Panel1MinSize = 360;
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.pnlImageViewer);
            this.splitContainerMain.Panel2MinSize = 400;
            this.splitContainerMain.Size = new System.Drawing.Size(1180, 690);
            this.splitContainerMain.SplitterDistance = 420;
            this.splitContainerMain.SplitterWidth = 6;
            this.splitContainerMain.TabIndex = 1;

            // 
            // pnlSidebar
            // 
            this.pnlSidebar.AutoScroll = true;
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.pnlSidebar.Controls.Add(this.pnlSummary);
            this.pnlSidebar.Controls.Add(this.grpBreakdown);
            this.pnlSidebar.Controls.Add(this.grpDisplay);
            this.pnlSidebar.Controls.Add(this.grpParams);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Padding = new System.Windows.Forms.Padding(12);
            this.pnlSidebar.Size = new System.Drawing.Size(420, 690);
            this.pnlSidebar.TabIndex = 0;

            // 
            // grpParams
            // 
            this.grpParams.Controls.Add(this.lblMinArea);
            this.grpParams.Controls.Add(this.numMinArea);
            this.grpParams.Controls.Add(this.lblGroups);
            this.grpParams.Controls.Add(this.numGroups);
            this.grpParams.Controls.Add(this.btnAnalyze);
            this.grpParams.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpParams.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.grpParams.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.grpParams.Location = new System.Drawing.Point(12, 12);
            this.grpParams.Name = "grpParams";
            this.grpParams.Size = new System.Drawing.Size(396, 116);
            this.grpParams.TabIndex = 0;
            this.grpParams.TabStop = false;
            this.grpParams.Text = "Detection Settings";

            // 
            // lblMinArea
            // 
            this.lblMinArea.AutoSize = true;
            this.lblMinArea.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMinArea.Location = new System.Drawing.Point(12, 26);
            this.lblMinArea.Name = "lblMinArea";
            this.lblMinArea.Size = new System.Drawing.Size(109, 15);
            this.lblMinArea.TabIndex = 0;
            this.lblMinArea.Text = "Min Coin Area (px):";

            // 
            // numMinArea
            // 
            this.numMinArea.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numMinArea.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            this.numMinArea.Location = new System.Drawing.Point(128, 23);
            this.numMinArea.Maximum = new decimal(new int[] { 50000, 0, 0, 0 });
            this.numMinArea.Minimum = new decimal(new int[] { 50, 0, 0, 0 });
            this.numMinArea.Name = "numMinArea";
            this.numMinArea.Size = new System.Drawing.Size(76, 23);
            this.numMinArea.TabIndex = 1;
            this.numMinArea.Value = new decimal(new int[] { 1000, 0, 0, 0 });

            // 
            // lblGroups
            // 
            this.lblGroups.AutoSize = true;
            this.lblGroups.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblGroups.Location = new System.Drawing.Point(218, 26);
            this.lblGroups.Name = "lblGroups";
            this.lblGroups.Size = new System.Drawing.Size(89, 15);
            this.lblGroups.TabIndex = 2;
            this.lblGroups.Text = "Denominations:";

            // 
            // numGroups
            // 
            this.numGroups.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numGroups.Location = new System.Drawing.Point(313, 23);
            this.numGroups.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            this.numGroups.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numGroups.Name = "numGroups";
            this.numGroups.Size = new System.Drawing.Size(65, 23);
            this.numGroups.TabIndex = 3;
            this.numGroups.Value = new decimal(new int[] { 5, 0, 0, 0 });

            // 
            // btnAnalyze
            // 
            this.btnAnalyze.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnAnalyze.FlatAppearance.BorderSize = 0;
            this.btnAnalyze.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnalyze.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAnalyze.ForeColor = System.Drawing.Color.White;
            this.btnAnalyze.Location = new System.Drawing.Point(12, 60);
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(366, 42);
            this.btnAnalyze.TabIndex = 4;
            this.btnAnalyze.Text = "🔍 Analyze && Count Coins (BFS)";
            this.btnAnalyze.UseVisualStyleBackColor = false;
            this.btnAnalyze.Click += new System.EventHandler(this.BtnAnalyze_Click);

            // 
            // pnlSummary
            // 
            this.pnlSummary.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.pnlSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSummary.Controls.Add(this.lblSummaryCoins);
            this.pnlSummary.Controls.Add(this.lblSummaryValue);
            this.pnlSummary.Controls.Add(this.lblSummaryTime);
            this.pnlSummary.Controls.Add(this.lblSummaryBaseColor);
            this.pnlSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSummary.Location = new System.Drawing.Point(12, 128);
            this.pnlSummary.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.pnlSummary.Size = new System.Drawing.Size(396, 78);
            this.pnlSummary.TabIndex = 1;

            // 
            // lblSummaryCoins
            // 
            this.lblSummaryCoins.AutoSize = true;
            this.lblSummaryCoins.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSummaryCoins.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblSummaryCoins.Location = new System.Drawing.Point(10, 8);
            this.lblSummaryCoins.Name = "lblSummaryCoins";
            this.lblSummaryCoins.Size = new System.Drawing.Size(164, 30);
            this.lblSummaryCoins.TabIndex = 0;
            this.lblSummaryCoins.Text = "64 Total Coins";

            // 
            // lblSummaryValue
            // 
            this.lblSummaryValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSummaryValue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSummaryValue.ForeColor = System.Drawing.Color.FromArgb(5, 150, 105);
            this.lblSummaryValue.Location = new System.Drawing.Point(180, 11);
            this.lblSummaryValue.Name = "lblSummaryValue";
            this.lblSummaryValue.Size = new System.Drawing.Size(200, 25);
            this.lblSummaryValue.TabIndex = 1;
            this.lblSummaryValue.Text = "₱46.45 Total";
            this.lblSummaryValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // 
            // lblSummaryTime
            // 
            this.lblSummaryTime.AutoSize = true;
            this.lblSummaryTime.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSummaryTime.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblSummaryTime.Location = new System.Drawing.Point(12, 48);
            this.lblSummaryTime.Name = "lblSummaryTime";
            this.lblSummaryTime.Size = new System.Drawing.Size(111, 13);
            this.lblSummaryTime.TabIndex = 2;
            this.lblSummaryTime.Text = "BFS Runtime: ~18 ms";

            // 
            // lblSummaryBaseColor
            // 
            this.lblSummaryBaseColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSummaryBaseColor.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSummaryBaseColor.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblSummaryBaseColor.Location = new System.Drawing.Point(170, 48);
            this.lblSummaryBaseColor.Name = "lblSummaryBaseColor";
            this.lblSummaryBaseColor.Size = new System.Drawing.Size(210, 13);
            this.lblSummaryBaseColor.TabIndex = 3;
            this.lblSummaryBaseColor.Text = "Background: RGB(255, 255, 255)";
            this.lblSummaryBaseColor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // 
            // grpBreakdown
            // 
            this.grpBreakdown.Controls.Add(this.dgvGroups);
            this.grpBreakdown.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpBreakdown.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.grpBreakdown.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.grpBreakdown.Location = new System.Drawing.Point(12, 206);
            this.grpBreakdown.Name = "grpBreakdown";
            this.grpBreakdown.Padding = new System.Windows.Forms.Padding(6);
            this.grpBreakdown.Size = new System.Drawing.Size(396, 220);
            this.grpBreakdown.TabIndex = 2;
            this.grpBreakdown.TabStop = false;
            this.grpBreakdown.Text = "Denomination Breakdown";

            // 
            // dgvGroups
            // 
            this.dgvGroups.AllowUserToAddRows = false;
            this.dgvGroups.AllowUserToDeleteRows = false;
            this.dgvGroups.AllowUserToResizeRows = false;
            this.dgvGroups.BackgroundColor = System.Drawing.Color.White;
            this.dgvGroups.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvGroups.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvGroups.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dgvHeaderStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dgvHeaderStyle.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            dgvHeaderStyle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dgvHeaderStyle.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            dgvHeaderStyle.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
            dgvHeaderStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvGroups.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            this.dgvGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroups.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colColor,
            this.colDenomination,
            this.colCount,
            this.colAvgArea,
            this.colUnitValue,
            this.colTotalValue});
            dgvRowStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dgvRowStyle.BackColor = System.Drawing.Color.White;
            dgvRowStyle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dgvRowStyle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            dgvRowStyle.SelectionBackColor = System.Drawing.Color.FromArgb(224, 231, 255);
            dgvRowStyle.SelectionForeColor = System.Drawing.Color.FromArgb(30, 58, 138);
            this.dgvGroups.DefaultCellStyle = dgvRowStyle;
            this.dgvGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGroups.EnableHeadersVisualStyles = false;
            this.dgvGroups.GridColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.dgvGroups.Location = new System.Drawing.Point(6, 22);
            this.dgvGroups.MultiSelect = false;
            this.dgvGroups.Name = "dgvGroups";
            this.dgvGroups.ReadOnly = true;
            this.dgvGroups.RowHeadersVisible = false;
            this.dgvGroups.RowTemplate.Height = 26;
            this.dgvGroups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGroups.Size = new System.Drawing.Size(384, 192);
            this.dgvGroups.TabIndex = 0;
            this.dgvGroups.SelectionChanged += new System.EventHandler(this.DgvGroups_SelectionChanged);
            this.dgvGroups.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DgvGroups_CellPainting);

            // 
            // colColor
            // 
            this.colColor.HeaderText = "";
            this.colColor.Name = "colColor";
            this.colColor.ReadOnly = true;
            this.colColor.Width = 24;

            // 
            // colDenomination
            // 
            this.colDenomination.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDenomination.HeaderText = "Denom";
            this.colDenomination.Name = "colDenomination";
            this.colDenomination.ReadOnly = true;

            // 
            // colCount
            // 
            this.colCount.HeaderText = "Count";
            this.colCount.Name = "colCount";
            this.colCount.ReadOnly = true;
            this.colCount.Width = 50;

            // 
            // colAvgArea
            // 
            this.colAvgArea.HeaderText = "Avg Area";
            this.colAvgArea.Name = "colAvgArea";
            this.colAvgArea.ReadOnly = true;
            this.colAvgArea.Width = 72;

            // 
            // colUnitValue
            // 
            this.colUnitValue.HeaderText = "Unit";
            this.colUnitValue.Name = "colUnitValue";
            this.colUnitValue.ReadOnly = true;
            this.colUnitValue.Width = 50;

            // 
            // colTotalValue
            // 
            this.colTotalValue.HeaderText = "Total";
            this.colTotalValue.Name = "colTotalValue";
            this.colTotalValue.ReadOnly = true;
            this.colTotalValue.Width = 56;

            // 
            // grpDisplay
            // 
            this.grpDisplay.Controls.Add(this.chkShowBounding);
            this.grpDisplay.Controls.Add(this.chkShowLabels);
            this.grpDisplay.Controls.Add(this.chkShowCentroids);
            this.grpDisplay.Controls.Add(this.chkShowNumbers);
            this.grpDisplay.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpDisplay.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.grpDisplay.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.grpDisplay.Location = new System.Drawing.Point(12, 426);
            this.grpDisplay.Name = "grpDisplay";
            this.grpDisplay.Size = new System.Drawing.Size(396, 88);
            this.grpDisplay.TabIndex = 3;
            this.grpDisplay.TabStop = false;
            this.grpDisplay.Text = "Display Options";

            // 
            // chkShowBounding
            // 
            this.chkShowBounding.AutoSize = true;
            this.chkShowBounding.Checked = true;
            this.chkShowBounding.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowBounding.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkShowBounding.Location = new System.Drawing.Point(14, 25);
            this.chkShowBounding.Name = "chkShowBounding";
            this.chkShowBounding.Size = new System.Drawing.Size(155, 19);
            this.chkShowBounding.TabIndex = 0;
            this.chkShowBounding.Text = "Highlight Coins (Circles)";
            this.chkShowBounding.UseVisualStyleBackColor = true;
            this.chkShowBounding.CheckedChanged += new System.EventHandler(this.OverlaySetting_Changed);

            // 
            // chkShowLabels
            // 
            this.chkShowLabels.AutoSize = true;
            this.chkShowLabels.Checked = true;
            this.chkShowLabels.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowLabels.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkShowLabels.Location = new System.Drawing.Point(190, 25);
            this.chkShowLabels.Name = "chkShowLabels";
            this.chkShowLabels.Size = new System.Drawing.Size(175, 19);
            this.chkShowLabels.TabIndex = 1;
            this.chkShowLabels.Text = "Denomination Badges (₱/¢)";
            this.chkShowLabels.UseVisualStyleBackColor = true;
            this.chkShowLabels.CheckedChanged += new System.EventHandler(this.OverlaySetting_Changed);

            // 
            // chkShowCentroids
            // 
            this.chkShowCentroids.AutoSize = true;
            this.chkShowCentroids.Checked = true;
            this.chkShowCentroids.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowCentroids.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkShowCentroids.Location = new System.Drawing.Point(14, 52);
            this.chkShowCentroids.Name = "chkShowCentroids";
            this.chkShowCentroids.Size = new System.Drawing.Size(117, 19);
            this.chkShowCentroids.TabIndex = 2;
            this.chkShowCentroids.Text = "Centroid Markers";
            this.chkShowCentroids.UseVisualStyleBackColor = true;
            this.chkShowCentroids.CheckedChanged += new System.EventHandler(this.OverlaySetting_Changed);

            // 
            // chkShowNumbers
            // 
            this.chkShowNumbers.AutoSize = true;
            this.chkShowNumbers.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkShowNumbers.Location = new System.Drawing.Point(190, 52);
            this.chkShowNumbers.Name = "chkShowNumbers";
            this.chkShowNumbers.Size = new System.Drawing.Size(155, 19);
            this.chkShowNumbers.TabIndex = 3;
            this.chkShowNumbers.Text = "Coin Numbers (#1..#64)";
            this.chkShowNumbers.UseVisualStyleBackColor = true;
            this.chkShowNumbers.CheckedChanged += new System.EventHandler(this.OverlaySetting_Changed);

            // 
            // pnlImageViewer
            // 
            this.pnlImageViewer.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.pnlImageViewer.Controls.Add(this.picPreview);
            this.pnlImageViewer.Controls.Add(this.pnlImageToolbar);
            this.pnlImageViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlImageViewer.Location = new System.Drawing.Point(0, 0);
            this.pnlImageViewer.Name = "pnlImageViewer";
            this.pnlImageViewer.Size = new System.Drawing.Size(754, 690);
            this.pnlImageViewer.TabIndex = 0;

            // 
            // pnlImageToolbar
            // 
            this.pnlImageToolbar.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.pnlImageToolbar.Controls.Add(this.lblViewMode);
            this.pnlImageToolbar.Controls.Add(this.cmbViewMode);
            this.pnlImageToolbar.Controls.Add(this.lblImageInfo);
            this.pnlImageToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlImageToolbar.Location = new System.Drawing.Point(0, 0);
            this.pnlImageToolbar.Name = "pnlImageToolbar";
            this.pnlImageToolbar.Size = new System.Drawing.Size(754, 38);
            this.pnlImageToolbar.TabIndex = 0;

            // 
            // lblViewMode
            // 
            this.lblViewMode.AutoSize = true;
            this.lblViewMode.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblViewMode.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblViewMode.Location = new System.Drawing.Point(12, 11);
            this.lblViewMode.Name = "lblViewMode";
            this.lblViewMode.Size = new System.Drawing.Size(68, 15);
            this.lblViewMode.TabIndex = 0;
            this.lblViewMode.Text = "View Mode:";

            // 
            // cmbViewMode
            // 
            this.cmbViewMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbViewMode.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbViewMode.FormattingEnabled = true;
            this.cmbViewMode.Items.AddRange(new object[] {
            "Annotated Overlay (Detected Coins)",
            "Clean Flattened Image (Blue Coins)",
            "Original Raw Image (coins.jpeg)"});
            this.cmbViewMode.Location = new System.Drawing.Point(86, 7);
            this.cmbViewMode.Name = "cmbViewMode";
            this.cmbViewMode.Size = new System.Drawing.Size(240, 21);
            this.cmbViewMode.TabIndex = 1;
            this.cmbViewMode.SelectedIndexChanged += new System.EventHandler(this.CmbViewMode_SelectedIndexChanged);

            // 
            // lblImageInfo
            // 
            this.lblImageInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblImageInfo.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblImageInfo.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblImageInfo.Location = new System.Drawing.Point(340, 10);
            this.lblImageInfo.Name = "lblImageInfo";
            this.lblImageInfo.Size = new System.Drawing.Size(400, 18);
            this.lblImageInfo.TabIndex = 2;
            this.lblImageInfo.Text = "Click or hover over any coin to inspect details";
            this.lblImageInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // 
            // picPreview
            // 
            this.picPreview.BackColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.picPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picPreview.Location = new System.Drawing.Point(0, 38);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(754, 652);
            this.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPreview.TabIndex = 1;
            this.picPreview.TabStop = false;
            this.picPreview.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PicPreview_MouseMove);
            this.picPreview.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PicPreview_MouseClick);

            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.White;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.statusHoverInfo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 754);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1180, 24);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";

            // 
            // statusLabel
            // 
            this.statusLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.statusLabel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(39, 19);
            this.statusLabel.Text = "Ready";

            // 
            // statusHoverInfo
            // 
            this.statusHoverInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.statusHoverInfo.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.statusHoverInfo.Name = "statusHoverInfo";
            this.statusHoverInfo.Size = new System.Drawing.Size(1126, 19);
            this.statusHoverInfo.Spring = true;
            this.statusHoverInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 778);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MinimumSize = new System.Drawing.Size(1000, 680);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Coin Counter & Classifier — DIP Island Counter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.pnlSidebar.ResumeLayout(false);
            this.grpParams.ResumeLayout(false);
            this.grpParams.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMinArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGroups)).EndInit();
            this.pnlSummary.ResumeLayout(false);
            this.pnlSummary.PerformLayout();
            this.grpBreakdown.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroups)).EndInit();
            this.grpDisplay.ResumeLayout(false);
            this.grpDisplay.PerformLayout();
            this.pnlImageViewer.ResumeLayout(false);
            this.pnlImageToolbar.ResumeLayout(false);
            this.pnlImageToolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.GroupBox grpParams;
        private System.Windows.Forms.Label lblMinArea;
        private System.Windows.Forms.NumericUpDown numMinArea;
        private System.Windows.Forms.Label lblGroups;
        private System.Windows.Forms.NumericUpDown numGroups;
        private System.Windows.Forms.Button btnAnalyze;
        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.Label lblSummaryCoins;
        private System.Windows.Forms.Label lblSummaryValue;
        private System.Windows.Forms.Label lblSummaryTime;
        private System.Windows.Forms.Label lblSummaryBaseColor;
        private System.Windows.Forms.GroupBox grpBreakdown;
        private System.Windows.Forms.DataGridView dgvGroups;
        private System.Windows.Forms.DataGridViewTextBoxColumn colColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDenomination;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAvgArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalValue;
        private System.Windows.Forms.GroupBox grpDisplay;
        private System.Windows.Forms.CheckBox chkShowBounding;
        private System.Windows.Forms.CheckBox chkShowLabels;
        private System.Windows.Forms.CheckBox chkShowCentroids;
        private System.Windows.Forms.CheckBox chkShowNumbers;
        private System.Windows.Forms.Panel pnlImageViewer;
        private System.Windows.Forms.Panel pnlImageToolbar;
        private System.Windows.Forms.Label lblViewMode;
        private System.Windows.Forms.ComboBox cmbViewMode;
        private System.Windows.Forms.Label lblImageInfo;
        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripStatusLabel statusHoverInfo;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
