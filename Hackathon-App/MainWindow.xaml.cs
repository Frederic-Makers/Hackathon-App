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

namespace Hackathon_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            WindowAjout wa = new WindowAjout(this);
            wa.Show();
        }

        private void ADDPresta_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EDITPresta_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LOADPresta_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FILTERPresta_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UnfinishedDevis_Click(object sender, RoutedEventArgs e)
        {

        }

        private void finishedDevis_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NEW_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PRINT_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EXIT_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LOADPrestaMenu_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
