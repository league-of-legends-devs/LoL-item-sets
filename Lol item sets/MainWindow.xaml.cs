using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

using System.Windows.Forms;
using System.Diagnostics;

using MahApps.Metro.Controls;

// TODO: Add ClickOnce support

namespace LoL_item_sets_XAML
{
	/// <summary>
	/// Logique d'interaction pour MainWindow.xaml
	/// </summary>
	public partial class MainWindow
	{
		// The path to the key where Windows looks for startup applications
		private RegistryKey rkApp;
		private string registryAppName = "LoL-item-sets-generator";
		private string saveFolder = "Champions";

		private bool loadingRefreshTime = false;
		private bool updatingCooldown = false;
        private TimeSpan refreshCooldown = new TimeSpan(1, 0, 0);

		private bool downloading = false;

		private const int MIN_SECONDS = 60;

		private DispatcherTimer tmRefreshCooldown;
		private NotifyIcon niInTray;

		#region Constructor

		public MainWindow()
		{
			InitializeComponent();
			init();
			updateCooldown(true);
		}

		private void init()
		{
			Trace.Listeners.Add(new TextWriterTraceListener("errors.log"));
			tmRefreshCooldown = new DispatcherTimer();
			niInTray = new NotifyIcon();
			niInTray.MouseDoubleClick += NiInTray_MouseDoubleClick;
            LoL_item_sets.Properties.Settings.Default.Reload();
			this.Title = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + " " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
			try
			{
				rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
				this.cbAutoLaunch.IsChecked = LoL_item_sets.Properties.Settings.Default.Launch_On_Windows_Start;
			}
			catch (Exception e)
			{
				Trace.TraceError(e.Message);
				System.Windows.MessageBox.Show("Error when loading the key in the registry. Be sure to run the application as administrator.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				this.cbAutoLaunch.IsChecked = false;
			}
			this.cbMinimizeOnClose.IsChecked = LoL_item_sets.Properties.Settings.Default.Minimize_When_Closed;

			try
			{
				using (WebClient client = new WebClient())
				{
					string currentPatchVersion = client.DownloadString("http://www.lol-item-sets-generator.org/?version");
					this.lblCurrentPatchVersion.Content = String.Format("Current patch : {0}", currentPatchVersion);
				}
			}
			catch (WebException e)
			{
				Trace.TraceError(e.Message);
				System.Windows.MessageBox.Show("The website appears to be down.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}
			catch (Exception e)
			{
				Trace.TraceError(e.Message);
				System.Windows.MessageBox.Show("Unknown error : " + e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}

            updateRefresh();
		}

		private void NiInTray_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			throw new NotImplementedException();
		}

		#endregion

		#region Events

		private void cbAutoLaunch_Checked(object sender, RoutedEventArgs e)
		{
			if (this.cbAutoLaunch.IsChecked == true)
			{
				// Add the value in the registry so that the application runs at startup
				rkApp.SetValue(registryAppName, AppDomain.CurrentDomain.BaseDirectory);
			}
			else
			{
				// Remove the value from the registry so that the application doesn't start
				rkApp.DeleteValue(registryAppName, false);
			}
			LoL_item_sets.Properties.Settings.Default.Launch_On_Windows_Start = this.cbAutoLaunch.IsChecked == true;
			LoL_item_sets.Properties.Settings.Default.Save();
		}

		private void cbMinimizeOnClose_Checked(object sender, RoutedEventArgs e)
		{
			LoL_item_sets.Properties.Settings.Default.Minimize_When_Closed = this.cbMinimizeOnClose.IsChecked == true;
			LoL_item_sets.Properties.Settings.Default.Save();
		}

		private void cbAutoUpdate_Checked(object sender, RoutedEventArgs e)
		{
			saveRefreshTime();
			updateRefreshTime();
			updateCooldown(true);
		}

		private void cooldown_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
		{
			if (!updatingCooldown)
			{
				saveRefreshTime();
				updateCooldown(true);
			}
		}

		private void btnDownload_Click(object sender, RoutedEventArgs e)
		{
			downloadAndInstallSets();
		}

		private void btnChoosePath_Click(object sender, RoutedEventArgs e)
		{
			var fbdSavePath = new FolderBrowserDialog();
			fbdSavePath.ShowNewFolderButton = false;
			fbdSavePath.SelectedPath = LoL_item_sets.Properties.Settings.Default.Save_Folder;
			if (fbdSavePath.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				if (!fbdSavePath.SelectedPath.EndsWith(@"\" + saveFolder))
				{
					Trace.TraceError("Invalid : " + saveFolder);
					System.Windows.MessageBox.Show(this, "This path seems to be invalid. The folder must be named '" + saveFolder + "'.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
					return;
				}
				LoL_item_sets.Properties.Settings.Default.Save_Folder = fbdSavePath.SelectedPath;
				LoL_item_sets.Properties.Settings.Default.Save();
			}
		}

		private void lkGoToWebsite_Click(object sender, EventArgs e)
		{
			Process.Start("https://lol-item-sets-generator.org/");
		}

		private void lkGoToChangelog_Click(object sender, EventArgs e)
		{
			Process.Start("https://github.com/Ilshidur/LoL-item-sets/blob/master/CHANGELOG.md");
		}

		private void lkGitHub_Click(object sender, EventArgs e)
		{
			Process.Start("https://github.com/Ilshidur/LoL-item-sets");
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

		private void niInTray_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
		{

		}

		private void tsiShow_Click(object sender, EventArgs e)
		{
			this.Show();
		}

		private void tsiQuit_Click(object sender, EventArgs e)
		{
			System.Windows.Application.Current.Shutdown();
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing && this.cbMinimizeOnClose.IsChecked == true)
			{
				niInTray.Visible = true;
				niInTray.ShowBalloonTip(500);
				this.Hide();
				e.Cancel = true;
			}
		}

		#endregion

		#region Update

		/// <summary>
		/// Updates the initial refresh values of the timer by importing the values from the settings.
		/// </summary>
		private void updateRefresh()
		{
			loadingRefreshTime = true;
			this.cbAutoUpdate.IsChecked = LoL_item_sets.Properties.Settings.Default.Refresh_Time.TotalSeconds != 0;
			this.cooldown.Value = LoL_item_sets.Properties.Settings.Default.Refresh_Time;
			loadingRefreshTime = false;
			updateRefreshTime();
		}

		/// <summary>
		/// Updates the refresh time 'Enabled' state.
		/// </summary>
		private void updateRefreshTime()
		{
			this.cooldown.IsEnabled = this.cbAutoUpdate.IsChecked == true;
			this.lblNextRefreshCooldown.IsEnabled = this.cbAutoUpdate.IsChecked == true;
		}

		/// <summary>
		/// Updates the shown cooldown.
		/// </summary>
		/// <param name="reset">Set to 'true' to reset the cooldown to its usual time.</param>
		private void updateCooldown(bool reset)
		{
			// TODO : Fix visual bug when launching => if "Auto update" is unchecked and we check it, the timer does "1:00:00" and then "0:00:59".
			this.lblNextRefreshCooldown.Content = refreshCooldown.ToString();
			if (this.cbAutoUpdate.IsChecked == true)
			{
				if (this.cooldown.Value?.TotalSeconds <= MIN_SECONDS) // Minimum 60 seconds
				{
					updatingCooldown = true;
                    this.cooldown.Value = this.cooldown.Value.GetValueOrDefault().Add(new TimeSpan(0, 0, MIN_SECONDS));
					updatingCooldown = false;
				}
				if (this.tmRefreshCooldown.IsEnabled == false)
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
					refreshCooldown = this.cooldown.Value.GetValueOrDefault();
				}
			}
			else
			{
				if (this.tmRefreshCooldown != null)
				{
					this.tmRefreshCooldown.Stop();
				}
			}
		}

		#endregion

		#region Function

		private void saveRefreshTime()
		{
			if (loadingRefreshTime)
				return;
			LoL_item_sets.Properties.Settings.Default.Refresh_Time =
				(this.cbAutoUpdate.IsChecked == true)
				? this.cooldown.Value.GetValueOrDefault()
				: new TimeSpan(0, 0, 0);
			LoL_item_sets.Properties.Settings.Default.Save();
		}

		private void downloadAndInstallSets()
		{
			// Preventing infinite loop.
			if (downloading)
				return;
			downloading = true;

			this.lblDownloading.Visibility = Visibility.Visible;

			var tempName = "ItemSets.zip";
			var savePath = LoL_item_sets.Properties.Settings.Default.Save_Folder + @"\" + tempName;
			// Download the .zip archive with the item sets
			this.lblDownloading.Content = "Downloading archive ...";
			try
			{
				using (var client = new WebClient())
				{
					client.DownloadFile("http://www.lol-item-sets-generator.org/clicks/click.php?id=dl_sets_from_application", savePath);
					// This link is a redirection. It helps to count the downloads.
				}
			}
			catch (WebException e)
			{
				Trace.TraceError(e.Message);
				System.Windows.MessageBox.Show("Error when downloading the file to " + savePath + ". Either the website appears to be down or your sets location is incorrect.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				this.lblDownloading.Visibility = Visibility.Hidden;
				downloading = false;
				return;
			}
            catch (Exception e)
			{
				Trace.TraceError(e.Message);
				System.Windows.MessageBox.Show("Error when downloading the file to " + savePath + ". Be sure to run the application as administrator or reconfigure the item sets path.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				this.lblDownloading.Visibility = Visibility.Hidden;
				downloading = false;
                return;
			}

			// Delete all the directories => delete the previous item sets
			this.lblDownloading.Content = "Deleting sets ...";
			foreach (System.IO.DirectoryInfo dir in new System.IO.DirectoryInfo(LoL_item_sets.Properties.Settings.Default.Save_Folder).GetDirectories())
			{
				dir.Delete(true);
			}

			// Unzipping the .zip archive
			this.lblDownloading.Content = "Unzipping sets ...";

			Shell32.Folder destinationFolder = GetShell32NameSpaceFolder(LoL_item_sets.Properties.Settings.Default.Save_Folder);
			Shell32.Folder sourceFile = GetShell32NameSpaceFolder(savePath);
			if (sourceFile == null)
			{
				Trace.TraceError("The downloaded .zip archive could not be found.");
				System.Windows.MessageBox.Show("Error when unzipping the file. The downloaded .zip archive could not be found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				this.lblDownloading.Visibility = Visibility.Hidden;
				downloading = false;
				return;
			}
            if (sourceFile.Items().Item(0)?.Name != "ItemSets")
			{
				Trace.TraceError("The 'ItemSets' folder could not be found in the .zip archive.");
				System.Windows.MessageBox.Show("Error when unzipping the file. The 'ItemSets' folder could not be found in the .zip archive.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				System.IO.File.Delete(savePath);
				this.lblDownloading.Visibility = Visibility.Hidden;
				downloading = false;
				return;
			}
			var items = GetShell32NameSpaceFolder(sourceFile.Items().Item(0).Path).Items();
			for (int i = 0; i < items.Count; i++)
			{
				var file = items.Item(i);
				this.lblDownloading.Content = "Unzipping '" + items.Item(i).Name + "' ...";
				destinationFolder.CopyHere(file, 4 | 16 | 64);
			}

			// Deleting the .zip archive
			this.lblDownloading.Content = "Deleting archive ...";
			System.IO.File.Delete(savePath);

			this.lblDownloading.Visibility = Visibility.Hidden;

			downloading = false;
		}

		// Resolves compatibility issues through Windows versions.
		public Shell32.Folder GetShell32NameSpaceFolder(Object folder)
		{
			Type shellAppType = Type.GetTypeFromProgID("Shell.Application");
			Object shell = Activator.CreateInstance(shellAppType);
			return (Shell32.Folder)shellAppType.InvokeMember("NameSpace", System.Reflection.BindingFlags.InvokeMethod, null, shell, new object[] { folder });
		}

		#endregion

	}
}
