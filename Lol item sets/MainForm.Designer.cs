namespace Lol_item_sets
{
	partial class MainForm
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.cbMinimizeOnClose = new MetroFramework.Controls.MetroCheckBox();
			this.pnlMain = new MetroFramework.Controls.MetroPanel();
			this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
			this.tlpWebsites = new System.Windows.Forms.TableLayoutPanel();
			this.lkGitHub = new MetroFramework.Controls.MetroLink();
			this.lkGoToWebsite = new MetroFramework.Controls.MetroLink();
			this.cbAutoLaunch = new MetroFramework.Controls.MetroCheckBox();
			this.cbAutoUpdate = new MetroFramework.Controls.MetroCheckBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.lblRefreshSeconds = new MetroFramework.Controls.MetroLabel();
			this.lblRefreshMinutes = new MetroFramework.Controls.MetroLabel();
			this.nudRefreshHours = new System.Windows.Forms.NumericUpDown();
			this.nudRefreshMinutes = new System.Windows.Forms.NumericUpDown();
			this.nudRefreshSeconds = new System.Windows.Forms.NumericUpDown();
			this.lblRefreshHours = new MetroFramework.Controls.MetroLabel();
			this.tlpAbout = new System.Windows.Forms.TableLayoutPanel();
			this.lblAbout = new MetroFramework.Controls.MetroLabel();
			this.lblDownloading = new MetroFramework.Controls.MetroLabel();
			this.tlpNextRefresh = new System.Windows.Forms.TableLayoutPanel();
			this.lblNextRefresh = new MetroFramework.Controls.MetroLabel();
			this.lblNextRefreshCooldown = new MetroFramework.Controls.MetroLabel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.btnDownload = new MetroFramework.Controls.MetroButton();
			this.btnChoosePath = new MetroFramework.Controls.MetroButton();
			this.niInTray = new System.Windows.Forms.NotifyIcon(this.components);
			this.cmInTray = new MetroFramework.Controls.MetroContextMenu(this.components);
			this.tsiShow = new System.Windows.Forms.ToolStripMenuItem();
			this.tsiQuit = new System.Windows.Forms.ToolStripMenuItem();
			this.tmRefreshCooldown = new System.Windows.Forms.Timer(this.components);
			this.pnlMain.SuspendLayout();
			this.tlpMain.SuspendLayout();
			this.tlpWebsites.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudRefreshHours)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudRefreshMinutes)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudRefreshSeconds)).BeginInit();
			this.tlpAbout.SuspendLayout();
			this.tlpNextRefresh.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.cmInTray.SuspendLayout();
			this.SuspendLayout();
			// 
			// cbMinimizeOnClose
			// 
			this.cbMinimizeOnClose.AutoSize = true;
			this.cbMinimizeOnClose.Location = new System.Drawing.Point(3, 33);
			this.cbMinimizeOnClose.Name = "cbMinimizeOnClose";
			this.cbMinimizeOnClose.Size = new System.Drawing.Size(119, 14);
			this.cbMinimizeOnClose.TabIndex = 2;
			this.cbMinimizeOnClose.Text = "Minimize on close";
			this.cbMinimizeOnClose.UseSelectable = true;
			this.cbMinimizeOnClose.CheckedChanged += new System.EventHandler(this.cbMinimizeOnClose_CheckedChanged);
			// 
			// pnlMain
			// 
			this.pnlMain.Controls.Add(this.tlpMain);
			this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlMain.HorizontalScrollbarBarColor = true;
			this.pnlMain.HorizontalScrollbarHighlightOnWheel = false;
			this.pnlMain.HorizontalScrollbarSize = 10;
			this.pnlMain.Location = new System.Drawing.Point(20, 60);
			this.pnlMain.Name = "pnlMain";
			this.pnlMain.Size = new System.Drawing.Size(260, 220);
			this.pnlMain.TabIndex = 1;
			this.pnlMain.VerticalScrollbarBarColor = true;
			this.pnlMain.VerticalScrollbarHighlightOnWheel = false;
			this.pnlMain.VerticalScrollbarSize = 10;
			// 
			// tlpMain
			// 
			this.tlpMain.ColumnCount = 1;
			this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpMain.Controls.Add(this.tlpWebsites, 0, 8);
			this.tlpMain.Controls.Add(this.cbAutoLaunch, 0, 1);
			this.tlpMain.Controls.Add(this.cbMinimizeOnClose, 0, 2);
			this.tlpMain.Controls.Add(this.cbAutoUpdate, 0, 4);
			this.tlpMain.Controls.Add(this.tableLayoutPanel1, 0, 5);
			this.tlpMain.Controls.Add(this.tlpAbout, 0, 9);
			this.tlpMain.Controls.Add(this.tlpNextRefresh, 0, 6);
			this.tlpMain.Controls.Add(this.tableLayoutPanel2, 0, 7);
			this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpMain.Location = new System.Drawing.Point(0, 0);
			this.tlpMain.Name = "tlpMain";
			this.tlpMain.RowCount = 10;
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpMain.Size = new System.Drawing.Size(260, 220);
			this.tlpMain.TabIndex = 3;
			// 
			// tlpWebsites
			// 
			this.tlpWebsites.ColumnCount = 2;
			this.tlpWebsites.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpWebsites.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpWebsites.Controls.Add(this.lkGitHub, 1, 0);
			this.tlpWebsites.Controls.Add(this.lkGoToWebsite, 0, 0);
			this.tlpWebsites.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpWebsites.Location = new System.Drawing.Point(0, 170);
			this.tlpWebsites.Margin = new System.Windows.Forms.Padding(0);
			this.tlpWebsites.Name = "tlpWebsites";
			this.tlpWebsites.RowCount = 1;
			this.tlpWebsites.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpWebsites.Size = new System.Drawing.Size(260, 20);
			this.tlpWebsites.TabIndex = 2;
			// 
			// lkGitHub
			// 
			this.lkGitHub.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lkGitHub.DisplayFocus = true;
			this.lkGitHub.Location = new System.Drawing.Point(135, 3);
			this.lkGitHub.Name = "lkGitHub";
			this.lkGitHub.Size = new System.Drawing.Size(119, 14);
			this.lkGitHub.Style = MetroFramework.MetroColorStyle.Blue;
			this.lkGitHub.TabIndex = 11;
			this.lkGitHub.Text = "GitHub repository";
			this.lkGitHub.UseSelectable = true;
			this.lkGitHub.UseStyleColors = true;
			this.lkGitHub.Click += new System.EventHandler(this.lkGitHub_Click);
			// 
			// lkGoToWebsite
			// 
			this.lkGoToWebsite.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lkGoToWebsite.DisplayFocus = true;
			this.lkGoToWebsite.Location = new System.Drawing.Point(5, 3);
			this.lkGoToWebsite.Name = "lkGoToWebsite";
			this.lkGoToWebsite.Size = new System.Drawing.Size(119, 14);
			this.lkGoToWebsite.Style = MetroFramework.MetroColorStyle.Blue;
			this.lkGoToWebsite.TabIndex = 10;
			this.lkGoToWebsite.Text = "Go to the website";
			this.lkGoToWebsite.UseSelectable = true;
			this.lkGoToWebsite.UseStyleColors = true;
			this.lkGoToWebsite.Click += new System.EventHandler(this.lkGoToWebsite_Click);
			// 
			// cbAutoLaunch
			// 
			this.cbAutoLaunch.AutoSize = true;
			this.cbAutoLaunch.Location = new System.Drawing.Point(3, 13);
			this.cbAutoLaunch.Name = "cbAutoLaunch";
			this.cbAutoLaunch.Size = new System.Drawing.Size(157, 14);
			this.cbAutoLaunch.TabIndex = 1;
			this.cbAutoLaunch.Text = "Launch on Windows start";
			this.cbAutoLaunch.UseSelectable = true;
			this.cbAutoLaunch.CheckedChanged += new System.EventHandler(this.cbAutoLaunch_CheckedChanged);
			// 
			// cbAutoUpdate
			// 
			this.cbAutoUpdate.AutoSize = true;
			this.cbAutoUpdate.Location = new System.Drawing.Point(3, 58);
			this.cbAutoUpdate.Name = "cbAutoUpdate";
			this.cbAutoUpdate.Size = new System.Drawing.Size(144, 14);
			this.cbAutoUpdate.TabIndex = 3;
			this.cbAutoUpdate.Text = "Auto update (min. 60s)";
			this.cbAutoUpdate.UseSelectable = true;
			this.cbAutoUpdate.CheckedChanged += new System.EventHandler(this.cbAutoUpdate_CheckedChanged);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 6;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.875F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.45833F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.875F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.45833F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.875F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.45833F));
			this.tableLayoutPanel1.Controls.Add(this.lblRefreshSeconds, 5, 0);
			this.tableLayoutPanel1.Controls.Add(this.lblRefreshMinutes, 3, 0);
			this.tableLayoutPanel1.Controls.Add(this.nudRefreshHours, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.nudRefreshMinutes, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.nudRefreshSeconds, 4, 0);
			this.tableLayoutPanel1.Controls.Add(this.lblRefreshHours, 1, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 75);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(260, 35);
			this.tableLayoutPanel1.TabIndex = 5;
			// 
			// lblRefreshSeconds
			// 
			this.lblRefreshSeconds.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblRefreshSeconds.Location = new System.Drawing.Point(229, 0);
			this.lblRefreshSeconds.Name = "lblRefreshSeconds";
			this.lblRefreshSeconds.Size = new System.Drawing.Size(28, 35);
			this.lblRefreshSeconds.TabIndex = 9;
			this.lblRefreshSeconds.Text = "s";
			this.lblRefreshSeconds.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblRefreshMinutes
			// 
			this.lblRefreshMinutes.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblRefreshMinutes.Location = new System.Drawing.Point(144, 0);
			this.lblRefreshMinutes.Name = "lblRefreshMinutes";
			this.lblRefreshMinutes.Size = new System.Drawing.Size(23, 35);
			this.lblRefreshMinutes.TabIndex = 7;
			this.lblRefreshMinutes.Text = "m";
			this.lblRefreshMinutes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// nudRefreshHours
			// 
			this.nudRefreshHours.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.nudRefreshHours.Location = new System.Drawing.Point(3, 7);
			this.nudRefreshHours.Name = "nudRefreshHours";
			this.nudRefreshHours.Size = new System.Drawing.Size(50, 20);
			this.nudRefreshHours.TabIndex = 4;
			this.nudRefreshHours.ValueChanged += new System.EventHandler(this.nudRefreshHours_ValueChanged);
			// 
			// nudRefreshMinutes
			// 
			this.nudRefreshMinutes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.nudRefreshMinutes.Location = new System.Drawing.Point(88, 7);
			this.nudRefreshMinutes.Name = "nudRefreshMinutes";
			this.nudRefreshMinutes.Size = new System.Drawing.Size(50, 20);
			this.nudRefreshMinutes.TabIndex = 6;
			this.nudRefreshMinutes.ValueChanged += new System.EventHandler(this.nudRefreshMinutes_ValueChanged);
			// 
			// nudRefreshSeconds
			// 
			this.nudRefreshSeconds.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.nudRefreshSeconds.Location = new System.Drawing.Point(173, 7);
			this.nudRefreshSeconds.Name = "nudRefreshSeconds";
			this.nudRefreshSeconds.Size = new System.Drawing.Size(50, 20);
			this.nudRefreshSeconds.TabIndex = 8;
			this.nudRefreshSeconds.ValueChanged += new System.EventHandler(this.nudRefreshSeconds_ValueChanged);
			// 
			// lblRefreshHours
			// 
			this.lblRefreshHours.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblRefreshHours.Location = new System.Drawing.Point(59, 0);
			this.lblRefreshHours.Name = "lblRefreshHours";
			this.lblRefreshHours.Size = new System.Drawing.Size(23, 35);
			this.lblRefreshHours.TabIndex = 5;
			this.lblRefreshHours.Text = "h";
			this.lblRefreshHours.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tlpAbout
			// 
			this.tlpAbout.ColumnCount = 2;
			this.tlpAbout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.23077F));
			this.tlpAbout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.76923F));
			this.tlpAbout.Controls.Add(this.lblAbout, 1, 0);
			this.tlpAbout.Controls.Add(this.lblDownloading, 0, 0);
			this.tlpAbout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpAbout.Location = new System.Drawing.Point(0, 190);
			this.tlpAbout.Margin = new System.Windows.Forms.Padding(0);
			this.tlpAbout.Name = "tlpAbout";
			this.tlpAbout.RowCount = 1;
			this.tlpAbout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpAbout.Size = new System.Drawing.Size(260, 30);
			this.tlpAbout.TabIndex = 11;
			// 
			// lblAbout
			// 
			this.lblAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblAbout.AutoSize = true;
			this.lblAbout.Location = new System.Drawing.Point(189, 11);
			this.lblAbout.Name = "lblAbout";
			this.lblAbout.Size = new System.Drawing.Size(68, 19);
			this.lblAbout.TabIndex = 0;
			this.lblAbout.Text = "by Ilshidur";
			// 
			// lblDownloading
			// 
			this.lblDownloading.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblDownloading.AutoSize = true;
			this.lblDownloading.Location = new System.Drawing.Point(3, 11);
			this.lblDownloading.Name = "lblDownloading";
			this.lblDownloading.Size = new System.Drawing.Size(54, 19);
			this.lblDownloading.Style = MetroFramework.MetroColorStyle.Red;
			this.lblDownloading.TabIndex = 1;
			this.lblDownloading.Text = "<state>";
			this.lblDownloading.UseStyleColors = true;
			this.lblDownloading.Visible = false;
			// 
			// tlpNextRefresh
			// 
			this.tlpNextRefresh.ColumnCount = 2;
			this.tlpNextRefresh.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.76923F));
			this.tlpNextRefresh.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.23077F));
			this.tlpNextRefresh.Controls.Add(this.lblNextRefresh, 0, 0);
			this.tlpNextRefresh.Controls.Add(this.lblNextRefreshCooldown, 1, 0);
			this.tlpNextRefresh.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlpNextRefresh.Location = new System.Drawing.Point(0, 110);
			this.tlpNextRefresh.Margin = new System.Windows.Forms.Padding(0);
			this.tlpNextRefresh.Name = "tlpNextRefresh";
			this.tlpNextRefresh.RowCount = 1;
			this.tlpNextRefresh.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpNextRefresh.Size = new System.Drawing.Size(260, 20);
			this.tlpNextRefresh.TabIndex = 12;
			// 
			// lblNextRefresh
			// 
			this.lblNextRefresh.AutoSize = true;
			this.lblNextRefresh.Location = new System.Drawing.Point(3, 0);
			this.lblNextRefresh.Name = "lblNextRefresh";
			this.lblNextRefresh.Size = new System.Drawing.Size(149, 19);
			this.lblNextRefresh.TabIndex = 0;
			this.lblNextRefresh.Text = "Next auto download in :";
			// 
			// lblNextRefreshCooldown
			// 
			this.lblNextRefreshCooldown.AutoSize = true;
			this.lblNextRefreshCooldown.Location = new System.Drawing.Point(160, 0);
			this.lblNextRefreshCooldown.Name = "lblNextRefreshCooldown";
			this.lblNextRefreshCooldown.Size = new System.Drawing.Size(57, 19);
			this.lblNextRefreshCooldown.TabIndex = 1;
			this.lblNextRefreshCooldown.Text = "00:00:00";
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.07692F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.92308F));
			this.tableLayoutPanel2.Controls.Add(this.btnDownload, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.btnChoosePath, 1, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 130);
			this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(260, 40);
			this.tableLayoutPanel2.TabIndex = 13;
			// 
			// btnDownload
			// 
			this.btnDownload.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnDownload.Location = new System.Drawing.Point(8, 8);
			this.btnDownload.Name = "btnDownload";
			this.btnDownload.Size = new System.Drawing.Size(199, 23);
			this.btnDownload.Style = MetroFramework.MetroColorStyle.Orange;
			this.btnDownload.TabIndex = 0;
			this.btnDownload.Text = "Download and install the sets";
			this.btnDownload.Theme = MetroFramework.MetroThemeStyle.Light;
			this.btnDownload.UseSelectable = true;
			this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
			// 
			// btnChoosePath
			// 
			this.btnChoosePath.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnChoosePath.BackgroundImage = global::LoL_item_sets.Properties.Resources.folder;
			this.btnChoosePath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnChoosePath.Location = new System.Drawing.Point(218, 8);
			this.btnChoosePath.Name = "btnChoosePath";
			this.btnChoosePath.Size = new System.Drawing.Size(39, 23);
			this.btnChoosePath.TabIndex = 1;
			this.btnChoosePath.UseSelectable = true;
			this.btnChoosePath.Click += new System.EventHandler(this.btnChoosePath_Click);
			// 
			// niInTray
			// 
			this.niInTray.BalloonTipText = "I\'m minimized in your system tray :)";
			this.niInTray.BalloonTipTitle = "LoL item sets";
			this.niInTray.ContextMenuStrip = this.cmInTray;
			this.niInTray.Text = "LoL Item sets";
			this.niInTray.Click += new System.EventHandler(this.niInTray_Click);
			this.niInTray.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.niInTray_MouseDoubleClick);
			// 
			// cmInTray
			// 
			this.cmInTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiShow,
            this.tsiQuit});
			this.cmInTray.Name = "cmInTray";
			this.cmInTray.Size = new System.Drawing.Size(104, 48);
			// 
			// tsiShow
			// 
			this.tsiShow.Name = "tsiShow";
			this.tsiShow.Size = new System.Drawing.Size(103, 22);
			this.tsiShow.Text = "Show";
			this.tsiShow.Click += new System.EventHandler(this.tsiShow_Click);
			// 
			// tsiQuit
			// 
			this.tsiQuit.Name = "tsiQuit";
			this.tsiQuit.Size = new System.Drawing.Size(103, 22);
			this.tsiQuit.Text = "Quit";
			this.tsiQuit.Click += new System.EventHandler(this.tsiQuit_Click);
			// 
			// tmRefreshCooldown
			// 
			this.tmRefreshCooldown.Enabled = true;
			this.tmRefreshCooldown.Interval = 1000;
			this.tmRefreshCooldown.Tick += new System.EventHandler(this.tmRefreshCooldown_Tick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
			this.ClientSize = new System.Drawing.Size(300, 300);
			this.Controls.Add(this.pnlMain);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Resizable = false;
			this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Style = MetroFramework.MetroColorStyle.Orange;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.pnlMain.ResumeLayout(false);
			this.tlpMain.ResumeLayout(false);
			this.tlpMain.PerformLayout();
			this.tlpWebsites.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nudRefreshHours)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudRefreshMinutes)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudRefreshSeconds)).EndInit();
			this.tlpAbout.ResumeLayout(false);
			this.tlpAbout.PerformLayout();
			this.tlpNextRefresh.ResumeLayout(false);
			this.tlpNextRefresh.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.cmInTray.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private MetroFramework.Controls.MetroCheckBox cbMinimizeOnClose;
		private MetroFramework.Controls.MetroPanel pnlMain;
		private MetroFramework.Controls.MetroCheckBox cbAutoUpdate;
		private System.Windows.Forms.TableLayoutPanel tlpMain;
		private MetroFramework.Controls.MetroButton btnDownload;
		private MetroFramework.Controls.MetroCheckBox cbAutoLaunch;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.NumericUpDown nudRefreshHours;
		private System.Windows.Forms.NumericUpDown nudRefreshMinutes;
		private System.Windows.Forms.NumericUpDown nudRefreshSeconds;
		private MetroFramework.Controls.MetroLabel lblRefreshSeconds;
		private MetroFramework.Controls.MetroLabel lblRefreshMinutes;
		private MetroFramework.Controls.MetroLabel lblRefreshHours;
		private System.Windows.Forms.NotifyIcon niInTray;
		private MetroFramework.Controls.MetroLink lkGoToWebsite;
		private System.Windows.Forms.TableLayoutPanel tlpAbout;
		private MetroFramework.Controls.MetroLabel lblAbout;
		private System.Windows.Forms.TableLayoutPanel tlpNextRefresh;
		private MetroFramework.Controls.MetroLabel lblNextRefresh;
		private MetroFramework.Controls.MetroLabel lblNextRefreshCooldown;
		private System.Windows.Forms.Timer tmRefreshCooldown;
		private MetroFramework.Controls.MetroLabel lblDownloading;
		private System.Windows.Forms.TableLayoutPanel tlpWebsites;
		private MetroFramework.Controls.MetroLink lkGitHub;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private MetroFramework.Controls.MetroButton btnChoosePath;
		private MetroFramework.Controls.MetroContextMenu cmInTray;
		private System.Windows.Forms.ToolStripMenuItem tsiShow;
		private System.Windows.Forms.ToolStripMenuItem tsiQuit;
	}
}

