﻿using PrestataireBusiness;
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
    /// Interaction logic for Formulaire.xaml
    /// </summary>
    public partial class Formulaire : Window
    {
        WindowDevis wd;
        public Formulaire(WindowDevis wd)
        {
            InitializeComponent();
            this.wd = wd;
            Devis d = Business.d;
            Prix.Content = "Prix TOTAL: " + d.Total;
            Nom.Content = "Nom/Prénom : " + d.Nom;
            Email.Content = "Email : " + d.Email;
            Adresse.Content = "Adresse : NUKU-HIVA Taiohae";
            Numero.Content = "Contact : " + d.Numero; 
            Id.Content = "DEVIS N° : " + d.Id;
        }
    }
}
