﻿using MySql.Data.MySqlClient;
using PrestataireBusiness;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;

namespace DevisBusiness
{
    public class DevisAccess
    {
        public static MySqlConnection connection;

        static DevisAccess()
        {
            String connString = "Server=remotemysql.com;Database=qgO0M364Or;userid=sgroot;Pwd=7Hyomgetg3";
            connection = new MySqlConnection(connString);
        }
    
        public static void GetDevis()
        {
            String sql = "SELECT * FROM devis";
            using (MySqlCommand command = new MySqlCommand(sql, connection))
            {
                command.Connection.Open();
                using (DbDataReader dbReader = command.ExecuteReader())
                {
                    while (dbReader.Read())
                    {
                        int id = dbReader.GetInt32(0);
                        string nom = dbReader.GetString(1);
                        string prenom = dbReader.GetString(2);
                        string email = dbReader.GetString(3);
                        string exigence = dbReader.GetString(4);
                        int numero = dbReader.GetInt32(5);
                   
                        Business.Devis.Add(new Devis(id, nom, prenom, email, exigence, numero));
                    }
                }
                command.Connection.Close();
            }
        }
        public static bool InsertDevis(Devis d)
        {
            string sql = "INSERT INTO prestataire(Id, Nom, Prenom, Email, Exigence, Numero) " +
                         "VALUE (@id, @nom, @prenom, @email, @exigence, @numero)";
            using (MySqlCommand cmd = new MySqlCommand(sql, connection))
            {
                cmd.Connection.Open();
                cmd.Parameters.AddWithValue("@id", null);
                cmd.Parameters.AddWithValue("@nom", d.Nom);
                cmd.Parameters.AddWithValue("@prenom", d.Prenom);
                cmd.Parameters.AddWithValue("@email", d.Email);
                cmd.Parameters.AddWithValue("@exigence", d.Exigence);
                cmd.Parameters.AddWithValue("@numero", d.Numero);  

                bool result = cmd.ExecuteNonQuery() == 1;
                cmd.Connection.Close();
                return result;
            }
        }
        public static bool UpdateDevis(Devis d)
        {
            string sql = "UPDATE devis SET Nom=@nom, Prenom=@prenom, Email=@email, Exigence=@exigence, Numero=@numero" + 
                         "Where id=@id";
            using (MySqlCommand cmd = new MySqlCommand(sql, connection))
            {
                cmd.Connection.Open();

                cmd.Parameters.AddWithValue("@id", d.Id);
                cmd.Parameters.AddWithValue("@nom", d.Nom);
                cmd.Parameters.AddWithValue("@prenom", d.Prenom);
                cmd.Parameters.AddWithValue("@email", d.Email);
                cmd.Parameters.AddWithValue("@exigence", d.Exigence);
                cmd.Parameters.AddWithValue("@numero", d.Numero);
                
                bool result = cmd.ExecuteNonQuery() == 1;
                cmd.Connection.Close();
                return result;
            }
        }
    }
}