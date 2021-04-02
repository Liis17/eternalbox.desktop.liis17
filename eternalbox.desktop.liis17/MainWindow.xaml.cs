using System;
using System.Collections.Generic;
using System.Linq;
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
using System.ComponentModel;
using System.Runtime.InteropServices;
using DiscordRPC;
using DiscordRPC.Logging;

namespace eternalbox.desktop.liis17
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
		#region customization

		public bool discordrpc = true;


        #endregion

        public DiscordRpcClient client;

        public MainWindow()
        {
            InitializeComponent();

			DebugWindow dw = new DebugWindow();
			dw.Show();

			Customization c = new Customization();
			c.Show();

			if (discordrpc == true)
            {
				InitializeDiscord();
			}
			

		}

		void InitializeDiscord()
		{
			client = new DiscordRpcClient("827472021759197194");

			client.Logger = new ConsoleLogger() { Level = LogLevel.Warning };

			client.OnReady += (sender, e) =>
			{
				Console.WriteLine("Received Ready from user {0}", e.User.Username);
			};

			client.OnPresenceUpdate += (sender, e) =>
			{
				Console.WriteLine("Received Update! {0}", e.Presence);
			};

			//Connect to the RPC
			client.Initialize();

			//Set the rich presence
			//Call this as many times as you want and anywhere in your code.
			client.SetPresence(new RichPresence()
			{
				Details = "Listens to Eternal Jukebox",
				State = "...",
				Assets = new Assets()
				{
					LargeImageKey = "eternal",
					LargeImageText = "The Eternal Jukebox",
					SmallImageKey = "image_small"
				}
			});
		} //discord

        private void Window_Closed(object sender, EventArgs e)
        {
			client.Dispose();
		} //closed window 

        private void Window_SizeChanger(object sender, SizeChangedEventArgs e)
        {
			int h = (int)WindowMain.Height;
			int w = (int)WindowMain.Width;

			DebugWindow.SizeChanger(h, w);
		}
    }
}
