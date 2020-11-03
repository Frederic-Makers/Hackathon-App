using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

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



    }
}
