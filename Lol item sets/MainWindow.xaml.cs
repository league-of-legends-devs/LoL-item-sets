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
using MahApps.Metro.Controls.Dialogs;
using LoL_item_sets.models;

// TODO: Add ClickOnce support

namespace LoL_item_sets_XAML
{
	public partial class MainWindow : MetroWindow
	{
		// The path to the key where Windows looks for startup applications
		private RegistryKey rkApp;
		private string registryAppName = "LoL-item-sets-generator";
		private string saveFolder = "Champions";

		private bool loadingRefreshTime = false;
		private bool updatingCooldown = false;
        private TimeSpan refreshCooldown = new TimeSpan(1, 0, 0);

		private const int MIN_SECONDS = 60;

		private DispatcherTimer tmRefreshCooldown;
		private NotifyIcon niInTray;

		private bool isInit = false;
		private bool manualClosing = true;
		private bool downloading = false;

		#region Constructor

		public MainWindow()
		{
			InitializeComponent();
			init();
			isInit = true;
			updateCooldown(true);
		}

		private async void init()
		{
			Trace.Listeners.Add(new TextWriterTraceListener("errors.log"));

			tmRefreshCooldown = new DispatcherTimer();
			tmRefreshCooldown.Tick += new EventHandler(tmRefreshCooldown_Tick);
			tmRefreshCooldown.Interval = new TimeSpan(0, 0, 1);

			niInTray = new NotifyIcon();
			niInTray.Icon = new System.Drawing.Icon(LoL_item_sets.Properties.Resources.iconIco, new System.Drawing.Size(32, 32));
			niInTray.BalloonTipText = "I am minimized in your tray ;-)";
			niInTray.Text = "LoL item sets generator";
			niInTray.BalloonTipIcon = ToolTipIcon.Info;
			niInTray.ContextMenu = new System.Windows.Forms.ContextMenu();
			var tsiShow = new System.Windows.Forms.MenuItem("Show");
			tsiShow.Click += tsiShow_Click;
            niInTray.ContextMenu.MenuItems.Add(tsiShow);
			var tsiQuit = new System.Windows.Forms.MenuItem("Quit");
			tsiQuit.Click += tsiQuit_Click;
            niInTray.ContextMenu.MenuItems.Add(tsiQuit);

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
				await this.ShowMessageAsync("Error", "Error when loading the key in the registry. Be sure to run the application as administrator.");
				this.cbAutoLaunch.IsChecked = false;
			}
			this.cbMinimizeOnClose.IsChecked = LoL_item_sets.Properties.Settings.Default.Minimize_When_Closed;

			try
			{
				using (WebClient client = new WebClient())
				{
					string response = client.DownloadString("https://lol-item-sets-generator.org/api/patch");
					CurrentPatch patch = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<CurrentPatch>(response);
					if (patch.err == null)
					{
						this.lblCurrentPatchVersion.Content = String.Format("Current patch : {0}", patch.version);
					}
					else
					{
						this.lblCurrentPatchVersion.Content = String.Format("Patch not found : {0}", patch.err);
					}
				}
			}
			catch (WebException e)
			{
				Trace.TraceError(e.Message);
				await this.ShowMessageAsync("Error", "The website appears to be down.");
				return;
			}
			catch (Exception e)
			{
				Trace.TraceError(e.Message);
				await this.ShowMessageAsync("Error", "Unknown error : " + e.Message);
				return;
			}

			try
			{
				using (WebClient client = new WebClient())
				{
					string response = client.DownloadString("https://lol-item-sets-generator.org/api/news");
					News news = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<News>(response);
					if (news.text != "")
					{
						this.lblNews.Text = news.text;
					}
					else
					{
						this.lblNews.Text = "Follow us on Twitter for more updates !";
					}
				}
			}
			catch (WebException e)
			{
				Trace.TraceError(e.Message);
				await this.ShowMessageAsync("Error", "The website appears to be down.");
				return;
			}
			catch (Exception e)
			{
				Trace.TraceError(e.Message);
				await this.ShowMessageAsync("Error", "Unknown error : " + e.Message);
				return;
			}

			updateRefresh();
		}

		#endregion

		#region Events

		private async void btnUpdate_Click(object sender, RoutedEventArgs e)
		{
			await this.ShowMessageAsync("Nawp", "The update module is not implemented yet but it will be soon !");
		}

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
			if (!updatingCooldown && isInit)
			{
				saveRefreshTime();
				updateCooldown(true);
			}
		}

		private void btnDownload_Click(object sender, RoutedEventArgs e)
		{
			downloadAndInstallSets();
		}

		private async void btnChoosePath_Click(object sender, RoutedEventArgs e)
		{
			var fbdSavePath = new FolderBrowserDialog();
			fbdSavePath.ShowNewFolderButton = false;
			fbdSavePath.SelectedPath = LoL_item_sets.Properties.Settings.Default.Save_Folder;
			if (fbdSavePath.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				if (!fbdSavePath.SelectedPath.EndsWith(@"\" + saveFolder))
				{
					Trace.TraceError("Invalid : " + saveFolder);
					await this.ShowMessageAsync("Error", "This path seems to be invalid. The folder must be named '" + saveFolder + "'.");
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

		private void tsiShow_Click(object sender, EventArgs e)
		{
			this.Show();
		}

		private void tsiQuit_Click(object sender, EventArgs e)
		{
			this.manualClosing = false;
			System.Windows.Application.Current.Shutdown();
		}

		private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (this.manualClosing && this.cbMinimizeOnClose.IsChecked == true)
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
			this.lblNextRefreshCooldown.Content = refreshCooldown.ToString();
			if (this.cbAutoUpdate.IsChecked == true)
			{
				// Minimum 60 seconds
				if (this.cooldown.Value?.TotalSeconds < MIN_SECONDS)
				{
					updatingCooldown = true;
					this.cooldown.Value = new TimeSpan(0, 0, MIN_SECONDS);
					saveRefreshTime();
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

		private async void downloadAndInstallSets()
		{
			// TODO: Show progression using a "Progress Dialog" control and :
			// https://github.com/100GPing100/LoadingIndicators.WPF

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
					client.DownloadFile("https://lol-item-sets-generator.org/downloads/sets-from-app", savePath);
				}
			}
			catch (WebException e)
			{
				Trace.TraceError(e.Message);
				await this.ShowMessageAsync("Error", "Error when downloading the file to " + savePath + ". Either the website appears to be down or your sets location is incorrect.");
				this.lblDownloading.Visibility = Visibility.Hidden;
				downloading = false;
				return;
			}
            catch (Exception e)
			{
				Trace.TraceError(e.Message);
				await this.ShowMessageAsync("Error", "Error when downloading the file to " + savePath + ". Be sure to run the application as administrator or reconfigure the item sets path.");
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
				await this.ShowMessageAsync("Error", "Error when unzipping the file. The downloaded .zip archive could not be found.");
				this.lblDownloading.Visibility = Visibility.Hidden;
				downloading = false;
				return;
			}
            if (sourceFile.Items().Item(0)?.Name != "ItemSets")
			{
				Trace.TraceError("The 'ItemSets' folder could not be found in the .zip archive.");
				await this.ShowMessageAsync("Error", "Error when unzipping the file. The 'ItemSets' folder could not be found in the .zip archive.");
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

			this.lblDownloading.Content = "Done !";

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
