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
    /// Interaction logic for WindowAjout.xaml
    /// </summary>
    public partial class WindowAdd : Window
    {
        public MainWindow mw;
        public Boolean modeEdit;
        public WindowAdd(MainWindow mw)
        {
            InitializeComponent();

            this.mw = mw;
            this.modeEdit = false;

        }

        private void AddPresta_Click(object sender, RoutedEventArgs e)
        {
            if (modeEdit)
            {
                Prestataire p = Business.p;               
                p.Nom = Nom.Text;
                p.Url = Url.Text;
                p.Categorie = Categorie.Text;
                p.Contact = Contact.Text;
                p.Adresse = Adresse.Text;
                p.Description = Description.Text;
                p.Activation = Activation.IsChecked.Value;
                p.Prix = Prix.Text;
            
                if (PrestataireAcces.UpdatePrestataire(p))
                {
                    MessageBox.Show("Le prestataire Id: " + p.Id + " a bien était mis à jour");
                }
                else
                {
                    MessageBox.Show(" Une Erreur c'est produite [UPDATE Methode] ");
                }
            }
            else
            {
                Prestataire p = new Prestataire(0, Nom.Text, Url.Text, Categorie.Text, Contact.Text, Adresse.Text, Description.Text, Activation.IsChecked.Value, Prix.Text);            ;
                if (PrestataireAcces.InsertPrestataire(p))
                {
                    MessageBox.Show(" Les infos client ont bien été envoyés ");
                }
                else
                {
                    MessageBox.Show(" Erreur, les infos client n'ont pas pu été envoyées ");
                }
            }
        }

        private void AddClosePresta_Click(object sender, RoutedEventArgs e)
        {
            Prestataire p = new Prestataire(0, Nom.Text, Url.Text, Categorie.Text, Contact.Text, Adresse.Text, Description.Text, Activation.IsChecked.Value, Prix.Text); ;
            if (PrestataireAcces.InsertPrestataire(p))
            {
                MessageBox.Show(" Les infos client ont bien été envoyés ");
            }
            else
            {
                MessageBox.Show(" Erreur, les infos client n'ont pas pu été envoyées ");
            }
            this.Close();
        }


        
    }
}
