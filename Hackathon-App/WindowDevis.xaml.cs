using PrestataireBusiness;
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

        private void LoadAllDevis_Click(object sender, RoutedEventArgs e)
        {

            DevisBusiness.DevisAccess.GetDevis();
            MyGridDevis.ItemsSource = Business.Devis;

            DevisPrestataireAccess.GetDevisPrestataire();

        }

        public void 

        public void LoadAllDevis()
        {
            DevisBusiness.DevisAccess.GetDevis();
            MyGridDevis.ItemsSource = Business.Devis;
        }

        private void GetWorkDevis_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GetFinishDevis_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CalculTotalDevis_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GetOutPrestaDevis_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ApercuDevis_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SendFinalDevis_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MyGridDevis_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Devis d = (Devis)this.MyGridDevis.SelectedItem;
            Business.d = d;

            WindowEditDevis wd = new WindowEditDevis(this);
            Devis d2 = Business.d;

            wd.Show();
            wd.labelTitre.Content = "EDITER LE DEVIS N° " + Business.d.Id;

            wd.Nom.Text = d2.Nom;
            wd.Prenom.Text = d2.Prenom;
            wd.Date.Text = d2.Date.ToString("yyyy-MM-dd");
            wd.Email.Text = d2.Email;
            wd.Exigence.Text = d2.Exigence;
            wd.Numero.Text = d2.Numero;


            wd.LoadPrestataireSelected.ItemsSource = Business.DevisPrestataire;


        }


    }
}
