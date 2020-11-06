using PrestataireBusiness;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for WindowEditDevis.xaml
    /// </summary>
    public partial class WindowEditDevis : Window
    {
        WindowDevis wd;
        public WindowEditDevis(WindowDevis wd)
        {
            InitializeComponent();
            this.wd = wd;
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Devis d = Business.d;
            d.Nom = Nom.Text;
            d.Prenom = Prenom.Text;

            CultureInfo culture = CultureInfo.CreateSpecificCulture("fr-FR");
            d.Date = DateTime.Parse(Date.Text, culture);

            d.Email = Email.Text;
            d.Exigence = Exigence.Text;
            d.Numero = Numero.Text;
            d.isTraite = isTraite.IsEnabled;

            if (DevisBusiness.DevisAccess.UpdateDevis(d))
            {
                MessageBox.Show("Le Devis Id:" + d.Id + ", nommé " + d.Nom + " a bien était mis à jour");
                wd.LoadAllDevis();
            }
            else
            {
                MessageBox.Show(" Une Erreur c'est produite [UPDATE Methode] ");
            }
            this.Close();
        }

        
    }
}
