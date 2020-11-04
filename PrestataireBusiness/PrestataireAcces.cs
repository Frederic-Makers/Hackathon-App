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
            String connString = "Server=remotemysql.com;Database=qgO0M364Or;userid=sgroot;Pwd=7Hyomgetg3";
            connection = new MySqlConnection(connString);
        }
        public static void GetPrestataire()
        {
            String sql = "SELECT * FROM prestataire";
            using (MySqlCommand command = new MySqlCommand(sql, connection))
            {
                command.Connection.Open();
                using (System.Data.Common.DbDataReader dbReader = command.ExecuteReader())

                {
                    while (dbReader.Read())
                    {
                        int id = dbReader.GetInt32(0);
                        string nom = dbReader.GetString(1);
                        string url = dbReader.GetString(2);
                        string categorie = dbReader.GetString(3);
                        string contact = dbReader.GetString(4);
                        string adresse = dbReader.GetString(5);
                        string description = dbReader.GetString(6);
                        bool activation = dbReader.GetBoolean(7);
                        int prix = dbReader.GetInt32(8);

                        // attente de la création de la class business
                        Business.Prestataires.Add(new Prestataire(id, nom, url, categorie, contact, adresse, description, activation, prix));

                    }
                }
                command.Connection.Close();
            }
        }
        public static void GetUrlPrestataire()
        {
            String sql = "SELECT url FROM prestataire";
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
            string sql = "INSERT INTO prestataire(Id, Nom, Url, Categorie, Contact, Adresse, Description, Activation, Prix) " +
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
            string sql = "UPDATE prestataire SET Nom=@nom, Url=@url, Categorie=@categorie, Contact=@contact, Adresse=@adresse, Description=@description, Prix=@prix "
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
                cmd.Parameters.AddWithValue("@prix", p.Prix);

                bool result = cmd.ExecuteNonQuery() == 1;
                cmd.Connection.Close();
                return result;

            }
        }
    }
}
