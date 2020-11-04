using PrestataireBusiness;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        ObservableCollection<Prestataire> Listfiltre = new ObservableCollection<Prestataire>();
        //private Prestataire p;
        public MainWindow()
        {
            InitializeComponent();
            EDITPresta.IsEnabled = false;
        }

        private void ADDPresta_Click(object sender, RoutedEventArgs e)
        {
            WindowAdd wa = new WindowAdd(this);
            wa.Show();
            wa.Title = "Ajouter un Prestataire";
        }

        private void EDITPresta_Click(object sender, RoutedEventArgs e)
        {
            WindowAdd wa = new WindowAdd(this);
            wa.Show();
            wa.labelTitre.Content = "Editer le prestataire Id" + Business.p.Id;
            wa.button2.Visibility = Visibility.Hidden;
            wa.button1.Content = "Editer et fermer";
            wa.Title = "Editer Prestataire";
            wa.Nom.Text = Business.p.Nom;
            wa.Url.Text = Business.p.Url;
            wa.Categorie.Text = Business.p.Categorie;
            wa.Contact.Text = Business.p.Contact;
            wa.Adresse.Text = Business.p.Adresse;
            wa.Description.Text = Business.p.Description;
            wa.Activation.IsChecked = Business.p.Activation;

        }

        private void LOADPresta_Click(object sender, RoutedEventArgs e)
        {
            Business.Prestataires.Clear();
            Listfiltre.Clear();
            PrestataireAcces.GetPrestataire();
            Mygrid.ItemsSource = Business.Prestataires;
        }

        private void FILTERPresta_Click(object sender, RoutedEventArgs e)
        {
            if (MyfilterCategorie.Text != "")
            {
                foreach (var item in Business.Prestataires)
                {
                    if (item.Categorie != "")
                    {
                        try
                        {
                            String categorie = (item.Categorie);
                            if (categorie == MyfilterCategorie.Text)
                            {
                                Listfiltre.Add(item);
                            }
                        }
                        catch (Exception) { }
                    }
                }
                Mygrid.ItemsSource = Listfiltre;
            }
            else
            {
                Mygrid.ItemsSource = Business.Prestataires;
            }
        }

        private void UnfinishedDevis_Click(object sender, RoutedEventArgs e)
        {

        }

        private void finishedDevis_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NEW_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Effacer toute les listes [?] cela n'affectera pas la Base de donnée", "Marquises Wedding", MessageBoxButton.OKCancel);
            switch (result)
            {
                case MessageBoxResult.OK:
                    Listfiltre.Clear();
                    Business.Prestataires.Clear();
                    break;
                case MessageBoxResult.Cancel:
                    break;
            }
            
        }

        private void PRINT_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EXIT_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Fermer le programme [?]", "Marquises Wedding", MessageBoxButton.OKCancel);
            switch (result)
            {
                case MessageBoxResult.OK:
                    Application.Current.Shutdown();
                    break;
                case MessageBoxResult.Cancel:
                    break;
            }
            
        }

        private void LOADPrestaMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Mygrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Prestataire p = (Prestataire)this.Mygrid.SelectedItem;
            EDITPresta.IsEnabled = true;
            Business.p = p;
        }
    }
}
