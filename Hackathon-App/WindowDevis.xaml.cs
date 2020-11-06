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
            ApercuDevis.IsEnabled = false;
        }

        private void LoadAllDevis_Click(object sender, RoutedEventArgs e)
        {

            DevisBusiness.DevisAccess.GetDevis();
            Business.AllDevis = Business.Devis;
            MyGridDevis.ItemsSource = Business.AllDevis;
            //MyGridDevis.ItemsSource = Business.Devis;

        }

        public void LoadAllDevis()
        {
            DevisBusiness.DevisAccess.GetDevis();
            MyGridDevis.ItemsSource = Business.Devis;
        }

        private void AllDevis_Click(object sender, RoutedEventArgs e)
        {
            Business.AllDevis = Business.Devis;
            Business.DevisWork.Clear();
            Business.DevisFinish.Clear();
            MyGridDevis.ItemsSource = Business.AllDevis;
        }

        private void GetWorkDevis_Click(object sender, RoutedEventArgs e)
        {
            //DevisBusiness.DevisAccess.GetDevis();
            

            foreach (var item in Business.AllDevis)
            {
                if (item.isTraite != true)
                {
                    try
                    {
                        Boolean devisFinish = (item.isTraite);
                        if (devisFinish == false)
                        {
                            Business.DevisWork.Add(item);
                        }
                    }
                    catch (Exception) { }
                }
            }
                   
            Business.DevisFinish.Clear();
            MyGridDevis.ItemsSource = Business.DevisWork;
        }

        private void GetFinishDevis_Click(object sender, RoutedEventArgs e)
        {
            //DevisBusiness.DevisAccess.GetDevis();

            foreach (var item in Business.AllDevis)
            {
                if (item.isTraite != false)
                {
                    try
                    {
                        Boolean devisFinish = (item.isTraite);
                        if (devisFinish == true)
                        {
                            Business.DevisFinish.Add(item);
                        }
                    }
                    catch (Exception) { }
                }
            }
            
            Business.DevisWork.Clear();
            MyGridDevis.ItemsSource = Business.DevisFinish;
        }

        private void ApercuDevis_Click(object sender, RoutedEventArgs e)
        {
            if (Business.d.isTraite == true)
            {
            Formulaire fw = new Formulaire(this);
            fw.Show();
            }
            else
            {
                ApercuDevis.IsEnabled = true;
                MessageBox.Show("Veillez selectionné un devis traité!");
            }


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

            if (Business.d != null)
            {
            wd.Show();
            wd.labelTitre.Content = "EDITER LE DEVIS N° " + Business.d.Id;

            wd.Nom.Text = d2.Nom;
            wd.Prenom.Text = d2.Prenom;
            wd.Date.Text = d2.Date.ToString("yyyy-MM-dd");
            wd.Email.Text = d2.Email;
            wd.Exigence.Text = d2.Exigence;
            wd.Numero.Text = d2.Numero;
            wd.isTraite.IsChecked = d2.isTraite;

            wd.LoadPrestataireSelected.ItemsSource = d.DevisPrestataires;
            }
            else
            {
                MessageBox.Show("Ne pas double cliquer dans 'Prestataire Choisi'");
            }


        }

        private void MyGridDevis_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Devis d = (Devis)this.MyGridDevis.SelectedItem;
            ApercuDevis.IsEnabled = true;
            Business.d = d;
        }

        
    }
}
