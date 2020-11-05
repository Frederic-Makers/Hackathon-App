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

namespace Hackathon_App
{
    /// <summary>
    /// Interaction logic for WindowDevis.xaml
    /// </summary>
    public partial class WindowDevis : Window
    {
        MainWindow mw;
        public WindowDevis(MainWindow mw)
        {
            InitializeComponent();
            this.mw = mw;
         
        }

        private void ADDPresta_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
