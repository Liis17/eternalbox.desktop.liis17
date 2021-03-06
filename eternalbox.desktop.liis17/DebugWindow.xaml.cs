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
using System.Windows.Shapes;

namespace eternalbox.desktop.liis17
{
    /// <summary>
    /// Логика взаимодействия для DebugWindow.xaml
    /// </summary>
    public partial class DebugWindow : Window
    {
        public static int WidthWindow = 0;
        public static int HeightWindow = 0;

        public static TextBlock HMW;
        public static TextBlock WMW;

        public DebugWindow()
        {
            InitializeComponent();
            HMW = HeightMainWindow;
            WMW = WidthMainWindow;
        }

        public static void SizeChanger(int h, int w)
        {
            WidthWindow = h;
            HeightWindow = w;

            HMW.Text = "Height=" + h;
            WMW.Text = "Width=" + w;
        }
    }
}
