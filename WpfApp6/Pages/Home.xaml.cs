using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Policy;
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
using WpfApp6.Services;
using WpfApp6.Services.Launch;

namespace WpfApp6.Pages
{
	/// <summary>
	/// Interaction logic for Home.xaml
	/// </summary>
	public partial class Home : UserControl
	{
		public Home()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				string Path69 = UpdateINI.ReadValue("Auth", "Path");
				if (Path69 != "NONE") // NONE THE BEST RESPONSE!
				{
					//MessageBox.Show(Path69);
					if (File.Exists(System.IO.Path.Join(Path69, "FortniteGame\\Binaries\\Win64\\FortniteClient-Win64-Shipping.exe")))
					{
						if (UpdateINI.ReadValue("Auth", "Email") == "NONE" || UpdateINI.ReadValue("Auth", "Password") == "NONE")
						{
							MessageBox.Show("Please Add Your Exit Info In Settings");
							return;
						}
						WebClient OMG = new WebClient();
						OMG.DownloadFile("https://cdn.discordapp.com/attachments/1327478320123744276/1338741870074920980/Aurora.Runtime.dll?ex=67ac3006&is=67aade86&hm=ae202b3e08bca587a5eb0f544ca989d7a97f09c5acb0aa38e900640d0c58b94d&", Path.Combine(Path69, "Engine\\Binaries\\ThirdParty\\NVIDIA\\NVaftermath\\Win64", "GFSDK_Aftermath_Lib.x64.dll"));  //Your curl thing here!
						//AntiCheat.Start(Path69);
						PSBasics.Start(Path69, "-epicapp=Fortnite -epicenv=Prod -epiclocale=en-us -epicportal -noeac -fromfl=be -fltoken=h1cdhchd10150221h130eB56 -skippatchcheck", UpdateINI.ReadValue("Auth", "Email"), UpdateINI.ReadValue("Auth", "Password"));
						FakeAC.Start(Path69, "FortniteClient-Win64-Shipping_BE.exe", $"-epicapp=Fortnite -epicenv=Prod -epiclocale=en-us -epicportal -noeac -fromfl=be -fltoken=h1cdhchd10150221h130eB56 -skippatchcheck", "r");
						FakeAC.Start(Path69, "FortniteLauncher.exe", $"-epicapp=Fortnite -epicenv=Prod -epiclocale=en-us -epicportal -noeac -fromfl=be -fltoken=h1cdhchd10150221h130eB56 -skippatchcheck", "dsf");
						PSBasics._FortniteProcess.WaitForExit();
						try
						{
							FakeAC._FNLauncherProcess.Close();
							FakeAC._FNAntiCheatProcess.Close();
						}
						catch (Exception ex)
						{
							MessageBox.Show("There Been A Error Closing");
						}



						//Injector.Start(PSBasics._FortniteProcess.Id, Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "EonCurl.dll"));
					}
					else
					{
						MessageBox.Show("Please Add Your Exit Info In Settings"); // INV
					}
				}
			}catch (Exception ex)
			{
				MessageBox.Show("ERROR, SERVERS OFFLINE!");
			}
			
		}

        private void Discord_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://public.simplyblk.xyz/Fortnite%2012.41.zip") { UseShellExecute = true }); //your build here!
        }
    }
}

