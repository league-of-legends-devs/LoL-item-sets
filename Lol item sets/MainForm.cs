using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;

namespace Lol_item_sets
{
	public partial class MainForm : MetroFramework.Forms.MetroForm
	{
		// The path to the key where Windows looks for startup applications
		private RegistryKey rkApp;
		private string registryAppName = "LoL-item-sets-generator";
		private string saveFolder = "Champions";

		private bool loadingRefreshTime = false;
		private TimeSpan refreshCooldown = new TimeSpan(1, 0, 0);

		private bool downloading = false;

		private const int MIN_SECONDS = 60;

		#region Constructor

		public MainForm()
		{
			InitializeComponent();
			init();
			updateCooldown(true);
		}

		private void init()
		{
			LoL_item_sets.Properties.Settings.Default.Reload();
			this.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + " " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
			try
			{
				rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
				this.cbAutoLaunch.Checked = LoL_item_sets.Properties.Settings.Default.Launch_On_Windows_Start;
			}
			catch (Exception e)
			{
				MetroFramework.MetroMessageBox.Show(this, "Error when loading the key in the registry. Be sure to run the application as administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				this.cbAutoLaunch.Checked = false;
			}
			this.cbMinimizeOnClose.Checked = LoL_item_sets.Properties.Settings.Default.Minimize_When_Closed;
			updateRefresh();
		}

		#endregion

		#region Update

		private void updateRefresh()
		{
			loadingRefreshTime = true;
			this.cbAutoUpdate.Checked = LoL_item_sets.Properties.Settings.Default.Refresh_Time.TotalSeconds != 0;
			this.nudRefreshHours.Value   = LoL_item_sets.Properties.Settings.Default.Refresh_Time.Hours;
			this.nudRefreshMinutes.Value = LoL_item_sets.Properties.Settings.Default.Refresh_Time.Minutes;
			this.nudRefreshSeconds.Value = LoL_item_sets.Properties.Settings.Default.Refresh_Time.Seconds;
			loadingRefreshTime = false;
			updateRefreshTime();
		}

		private void updateRefreshTime()
		{
			this.lblRefreshHours  .Enabled		= this.cbAutoUpdate.Checked;
			this.lblRefreshMinutes.Enabled		= this.cbAutoUpdate.Checked;
			this.lblRefreshSeconds.Enabled		= this.cbAutoUpdate.Checked;
			this.nudRefreshHours  .Enabled		= this.cbAutoUpdate.Checked;
			this.nudRefreshMinutes.Enabled		= this.cbAutoUpdate.Checked;
			this.nudRefreshSeconds.Enabled		= this.cbAutoUpdate.Checked;
			this.lblNextRefresh.Enabled			= this.cbAutoUpdate.Checked;
			this.lblNextRefreshCooldown.Enabled = this.cbAutoUpdate.Checked;
		}

		private void updateCooldown(bool reset)
		{
			// TODO : Fix visual bug when launching => if "Auto update" is unchecked and we check it, the timer does "1:00:00" and then "0:00:59".
			TimeSpan tempCooldown = new TimeSpan((int)this.nudRefreshHours.Value, (int)this.nudRefreshMinutes.Value, (int)this.nudRefreshSeconds.Value);
			this.lblNextRefreshCooldown.Text = refreshCooldown.ToString();
			if (this.cbAutoUpdate.Checked)
			{
				if (tempCooldown.TotalSeconds <= MIN_SECONDS) // Minimum 60 seconds
				{
					tempCooldown = tempCooldown.Add(new TimeSpan(0, 0, MIN_SECONDS));
					this.nudRefreshMinutes.Value = MIN_SECONDS;
				}
				if (this.tmRefreshCooldown.Enabled == false)
				{
					this.tmRefreshCooldown.Start();
				}
				if (refreshCooldown.TotalSeconds <= 0)
				{
					reset = true;
					downloadAndInstallSets();
				}
				if (reset)
				{
					refreshCooldown = tempCooldown;
				}
			}
			else
			{
				this.tmRefreshCooldown.Stop();
			}
		}

		#endregion

		#region Events

		private void cbAutoLaunch_CheckedChanged(object sender, EventArgs e)
		{
			if (this.cbAutoLaunch.Checked)
			{
				// Add the value in the registry so that the application runs at startup
				rkApp.SetValue(registryAppName, Application.ExecutablePath.ToString());
			}
			else
			{
				// Remove the value from the registry so that the application doesn't start
				rkApp.DeleteValue(registryAppName, false);
			}
			LoL_item_sets.Properties.Settings.Default.Launch_On_Windows_Start = this.cbAutoLaunch.Checked;
			LoL_item_sets.Properties.Settings.Default.Save();
		}

		private void cbMinimizeOnClose_CheckedChanged(object sender, EventArgs e)
		{
			LoL_item_sets.Properties.Settings.Default.Minimize_When_Closed = this.cbMinimizeOnClose.Checked;
			LoL_item_sets.Properties.Settings.Default.Save();
		}

		private void cbAutoUpdate_CheckedChanged(object sender, EventArgs e)
		{
			saveRefreshTime();
			updateRefreshTime();
			updateCooldown(true);
		}

		private void nudRefreshHours_ValueChanged(object sender, EventArgs e)
		{
			saveRefreshTime();
			updateCooldown(true);
		}

		private void nudRefreshMinutes_ValueChanged(object sender, EventArgs e)
		{
			saveRefreshTime();
			updateCooldown(true);
		}

		private void nudRefreshSeconds_ValueChanged(object sender, EventArgs e)
		{
			saveRefreshTime();
			updateCooldown(true);
		}

		private void btnDownload_Click(object sender, EventArgs e)
		{
			downloadAndInstallSets();
		}

		private void btnChoosePath_Click(object sender, EventArgs e)
		{
			var fbdSavePath = new FolderBrowserDialog();
			fbdSavePath.ShowNewFolderButton = false;
			fbdSavePath.SelectedPath = LoL_item_sets.Properties.Settings.Default.Save_Folder;
			if (fbdSavePath.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				if (!fbdSavePath.SelectedPath.EndsWith(@"\" + saveFolder))
				{
					MetroFramework.MetroMessageBox.Show(this, "This path seems to be invalid. The folder must be named '" + saveFolder + "'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				LoL_item_sets.Properties.Settings.Default.Save_Folder = fbdSavePath.SelectedPath;
				LoL_item_sets.Properties.Settings.Default.Save();
			}
		}

		private void lkGoToWebsite_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("http://www.item-sets-generator.org/clicks/click.php?id=access_from_application");
		}

		private void lkGitHub_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("https://github.com/Ilshidur/LoL-item-sets");
		}

		private void tmRefreshCooldown_Tick(object sender, EventArgs e)
		{
			refreshCooldown = refreshCooldown.Subtract(new TimeSpan(0, 0, 1));
			updateCooldown(false);
		}

		private void niInTray_Click(object sender, EventArgs e)
		{
			// Do nothing
		}

		private void niInTray_MouseDoubleClick(object sender, MouseEventArgs e)
		{

		}

		private void tsiShow_Click(object sender, EventArgs e)
		{
			this.Show();
		}

		private void tsiQuit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing && this.cbMinimizeOnClose.Checked)
			{
				niInTray.Visible = true;
				niInTray.Icon = Icon;
				niInTray.ShowBalloonTip(500);
				this.Hide();
				e.Cancel = true;
			}
		}

		#endregion

		#region Function

		private void saveRefreshTime()
		{
			if (loadingRefreshTime)
				return;
			LoL_item_sets.Properties.Settings.Default.Refresh_Time =
				(this.cbAutoUpdate.Checked)
				? new TimeSpan((int)this.nudRefreshHours.Value, (int)this.nudRefreshMinutes.Value, (int)this.nudRefreshSeconds.Value)
				: new TimeSpan(0, 0, 0);
			LoL_item_sets.Properties.Settings.Default.Save();
		}

		private void downloadAndInstallSets()
		{
			if (downloading)
				return;
			downloading = true;

			this.lblDownloading.Visible = true;

			var tempName = "ItemSets.zip";
			var savePath = LoL_item_sets.Properties.Settings.Default.Save_Folder + @"\" + tempName;
			// Download the .zip archive with the item sets
			this.lblDownloading.Text = "Downloading archive ...";
			this.Refresh();
			try
			{
				using (var client = new System.Net.WebClient())
				{
					client.DownloadFile("http://www.lol-item-sets-generator.org/clicks/click.php?id=dl_sets_from_application", savePath);
					// This link is a redirection. It helps to count the downloads.
				}
			}
			catch (Exception e)
			{
				MetroFramework.MetroMessageBox.Show(this, "Error when downloading the file to " + savePath + ". Be sure to run the application as administrator or reconfigure the item sets path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// Delete all the directories => delete the previous item sets
			this.lblDownloading.Text = "Deleting sets ...";
			this.Refresh();
			foreach (System.IO.DirectoryInfo dir in new System.IO.DirectoryInfo(LoL_item_sets.Properties.Settings.Default.Save_Folder).GetDirectories())
			{
				dir.Delete(true);
			}

			// Unzipping the .zip archive
			this.lblDownloading.Text = "Unzipping sets ...";
			this.Refresh();


			Shell32.Folder destinationFolder = GetShell32NameSpaceFolder(LoL_item_sets.Properties.Settings.Default.Save_Folder);
			Shell32.Folder sourceFile = GetShell32NameSpaceFolder(savePath);
			if (sourceFile == null)
			{
				MetroFramework.MetroMessageBox.Show(this, "Error when downloading the file. The downloaded .zip archive could not be found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (sourceFile.Items().Item(0).Name != "ItemSets")
			{
				MetroFramework.MetroMessageBox.Show(this, "Error when downloading the file. The 'ItemSets' folder could not be found in the .zip archive.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				System.IO.File.Delete(savePath);
				return;
			}
            		var items = GetShell32NameSpaceFolder(sourceFile.Items().Item(0).Path).Items();
			for (int i = 0; i < items.Count; i++)
			{
				var file = items.Item(i);
				this.lblDownloading.Text = "Unzipping '" + items.Item(i).Name + "' ...";
				this.Refresh();
				destinationFolder.CopyHere(file, 4 | 16 | 64);
			}

			// Deleting the .zip archive
			this.lblDownloading.Text = "Deleting archive ...";
			this.Refresh();
			System.IO.File.Delete(savePath);

			//this.lblDownloading.Text = "Done ! :)";
			//this.Refresh();
			//System.Threading.Thread.Sleep(2000);
			this.lblDownloading.Visible = false;
			this.Refresh();

			downloading = false;
		}

	        public Shell32.Folder GetShell32NameSpaceFolder(Object folder)
	        {
	            Type shellAppType = Type.GetTypeFromProgID("Shell.Application");
	
	            Object shell = Activator.CreateInstance(shellAppType);
	            return (Shell32.Folder)shellAppType.InvokeMember("NameSpace",
	            System.Reflection.BindingFlags.InvokeMethod, null, shell, new object[] { folder });
	        }


		#endregion
	}
}
