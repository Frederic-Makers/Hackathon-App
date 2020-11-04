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
    /// Interaction logic for WindowAjout.xaml
    /// </summary>
    public partial class WindowAdd : Window
    {
        public MainWindow mw;
        public WindowAdd(MainWindow mw)
        {
            InitializeComponent();

            this.mw = mw;

        }

        private void AddPresta_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddClosePresta_Click(object sender, RoutedEventArgs e)
        {

        }


        
    }
}
