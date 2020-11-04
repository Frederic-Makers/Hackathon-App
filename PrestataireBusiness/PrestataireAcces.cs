using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;


namespace PrestataireBusiness
{
    public class PrestataireAcces
    {
        private static MySqlConnection connection;
        static PrestataireAcces()
        {
            String connString = "Server=remotemysql.com;Database=qgO0M364Or;userid=qgO0M364Or;Pwd=7Hyomgetg3";
            connection = new MySqlConnection(connString);
        }
        public static void GetPrestataire()
        {
            String sql = "SELECT * FROM Prestataire";
            using (MySqlCommand command = new MySqlCommand(sql, connection))
            {
                command.Connection.Open();
                using (System.Data.Common.DbDataReader dbReader = command.ExecuteReader())

                {
                    while (dbReader.Read())
                    {
                        int Id = dbReader.GetInt32(0);
                        String Nom = dbReader.GetString(1);
                        String Url = dbReader.GetString(2);
                        String Categorie = dbReader.GetString(3);
                        String Contact = dbReader.GetString(4);
                        String Adresse = dbReader.GetString(5);
                        String Description = dbReader.GetString(6);
                        Boolean Activation = dbReader.GetBoolean(7);
                        String Prix = dbReader.GetString(8);

                        // attente de la création de la class business
                        Business.Prestataires.Add(new Prestataire(Id, Nom, Url, Categorie, Contact, Adresse, Description, Activation, Prix));

                    }
                }
                command.Connection.Close();
            }
        }
        public static void GetUrlPrestataire()
        {
            String sql = "SELECT url FROM Prestataire";
            using (MySqlCommand command = new MySqlCommand(sql, connection))
            {
                command.Connection.Open();
                using (DbDataReader dbReader = command.ExecuteReader())
                {
                    string url = dbReader.GetString(3);
                    Business.Prestataires.Add(new Prestataire(url));
                }
                command.Connection.Close();
            }
        }
        public static bool InsertPrestataire(Prestataire p)
        {
            string sql = "INSERT INTO Prestataire(Id, Nom, Url, Categorie, Contact, Adresse, Description, Activation, Prix) " +
                         "VALUE (@id, @nom, @url, @categorie, @contact, @adresse, @description, @activation, @prix)";
            using (MySqlCommand cmd = new MySqlCommand(sql, connection))
            {
                cmd.Connection.Open();
                cmd.Parameters.AddWithValue("@id", null);
                cmd.Parameters.AddWithValue("@nom", p.Nom);
                cmd.Parameters.AddWithValue("@url", p.Url);
                cmd.Parameters.AddWithValue("@categorie", p.Categorie);
                cmd.Parameters.AddWithValue("@contact", p.Contact);
                cmd.Parameters.AddWithValue("@adresse", p.Adresse);
                cmd.Parameters.AddWithValue("@description", p.Description);
                cmd.Parameters.AddWithValue("@activation", p.Activation);
                cmd.Parameters.AddWithValue("@prix", p.Prix);

                bool result = cmd.ExecuteNonQuery() == 1;
                cmd.Connection.Close();
                return result;
            }
        }
        public static bool UpdatePrestataire(Prestataire p)
        {
            string sql = "UPDATE Prestataire SET Nom=@nom, Url=@url, Categorie=@categorie, Contact=@contact, Adresse=@adresse, Description=@description, Activation=@activation, Prix=@prix "
                + " Where id=@id ";

            using (MySqlCommand cmd = new MySqlCommand(sql, connection))
            {
                cmd.Connection.Open();

                cmd.Parameters.AddWithValue("@id", p.Id);
                cmd.Parameters.AddWithValue("@nom", p.Nom);
                cmd.Parameters.AddWithValue("@url", p.Url);
                cmd.Parameters.AddWithValue("@categorie", p.Categorie);
                cmd.Parameters.AddWithValue("@contact", p.Contact);
                cmd.Parameters.AddWithValue("@adresse", p.Adresse);
                cmd.Parameters.AddWithValue("@description", p.Description);
                cmd.Parameters.AddWithValue("@activation", p.Activation);
                cmd.Parameters.AddWithValue("@prix", p.Prix);

                bool result = cmd.ExecuteNonQuery() == 1;
                cmd.Connection.Close();
                return result;

            }
        }
    } 
}
