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
            wa.modeEdit = false;
            wa.Title = "Ajouter un Prestataire";
        }

        private void EDITPresta_Click(object sender, RoutedEventArgs e)
        {
            WindowAdd wa = new WindowAdd(this);
            Prestataire p = Business.p;
            


            if (Business.p != null)
            {
                wa.modeEdit = true;
                wa.Show();
                wa.labelTitre.Content = "Editer le prestataire Id" + Business.p.Id;
                wa.button2.Visibility = Visibility.Hidden;
                wa.button1.Content = "Editer et fermer";
                wa.Title = "Editer Prestataire";
                wa.Nom.Text = p.Nom;
                wa.Url.Text = p.Url;
                wa.MyfilterCategorie.Header = "_" + p.Categorie;
                wa.Contact.Text = p.Contact;
                wa.Adresse.Text = p.Adresse;
                wa.Description.Text = p.Description;
                wa.Activation.IsChecked = p.Activation;
                wa.Prix.Text = p.Prix;
            }
            else
            {
                EDITPresta.IsEnabled = false;
                MessageBox.Show("Aucun prestataire selectionner");
               
            }    
        }

        private void LOADPresta_Click(object sender, RoutedEventArgs e)
        {
            Business.Prestataires.Clear();
            Listfiltre.Clear();
            PrestataireAcces.GetPrestataire();
            Mygrid.ItemsSource = Business.Prestataires;
        }

        public void Filter()
        {
            Listfiltre.Clear();
            if (MyfilterCategorie.Header.ToString() != "_Tous les Catégories")
            {
                foreach (var item in Business.Prestataires)
                {
                    if (item.Categorie != "")
                    {
                        try
                        {
                            String categorie = (item.Categorie);
                            if (categorie == MyfilterCategorie.Header.ToString().Replace("_",""))
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

        public void FILTERPresta_Click(object sender, RoutedEventArgs e)
        {
            if (MyfilterCategorie.Header.ToString() != "_Tous les Catégories")
            {
                foreach (var item in Business.Prestataires)
                {
                    if (item.Categorie != "")
                    {
                        try
                        {
                            String categorie = (item.Categorie);
                            if (categorie == MyfilterCategorie.Header.ToString())
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
                    MyfilterCategorie.Header = "_Tous les Catégories";
                    Business.Prestataires.Clear();
                    break;
                case MessageBoxResult.Cancel:
                    break;
            }
            EDITPresta.IsEnabled = false;
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
            Business.Prestataires.Clear();
            Listfiltre.Clear();
            PrestataireAcces.GetPrestataire();
            Mygrid.ItemsSource = Business.Prestataires;
        }

        private void Mygrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Prestataire p = (Prestataire)this.Mygrid.SelectedItem;
            EDITPresta.IsEnabled = true;
            Business.p = p;
        }


        private void Mygrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Prestataire p = (Prestataire)this.Mygrid.SelectedItem;
            EDITPresta.IsEnabled = true;
            Business.p = p;

            WindowAdd wa = new WindowAdd(this);
            Prestataire p2 = Business.p;
            wa.modeEdit = true;
            wa.Show();
            wa.labelTitre.Content = "Editer le prestataire Id" + Business.p.Id;
            wa.button2.Visibility = Visibility.Hidden;
            wa.button1.Content = "Editer et fermer";
            wa.Title = "Editer Prestataire";
            wa.Nom.Text = p2.Nom;
            wa.Url.Text = p2.Url;
            wa.MyfilterCategorie.Header = "_" + p2.Categorie;
            wa.Contact.Text = p2.Contact;
            wa.Adresse.Text = p2.Adresse;
            wa.Description.Text = p2.Description;
            wa.Activation.IsChecked = p2.Activation;
            wa.Prix.Text = p2.Prix;
        }
        private void AllCategories_Click(object sender, RoutedEventArgs e)
        {
            MyfilterCategorie.Header = "_Tous les Catégories";
            Filter();
        }
        private void Decorateur_Click(object sender, RoutedEventArgs e)
        {
            MyfilterCategorie.Header = "_Décorateur";
            Filter();
        }

        private void Musique_Click(object sender, RoutedEventArgs e)
        {
            MyfilterCategorie.Header = "_Musique";
            Filter();
        }
    }
}
