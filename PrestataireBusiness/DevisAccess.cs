using Microsoft.OData.Edm;
using MySql.Data.MySqlClient;
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
            String connString = "Server=remotemysql.com;Database=qgO0M364Or;userid=qgO0M364Or;Pwd=7Hyomgetg3";
            connection = new MySqlConnection(connString);
        }
    
        public static void GetDevis()
        {
            String sql = "SELECT * FROM Devis";
            using (MySqlCommand command = new MySqlCommand(sql, connection))
            {
                command.Connection.Open();
                using (DbDataReader dbReader = command.ExecuteReader())
                {
                    while (dbReader.Read())
                    {
                        int Id = dbReader.GetInt32(0);
                        string Nom = dbReader.GetString(1);
                        string Prenom = dbReader.GetString(2);
                        DateTime Date = dbReader.GetDateTime(3);
                        string Email = dbReader.GetString(4);
                        string Exigence = dbReader.GetString(5);
                        string Numero = dbReader.GetString(6);
                        Devis d = new Devis(Id, Nom, Prenom, Date, Email, Exigence, Numero);
                        DevisPrestataireAccess.GetDevisPrestataire(d);
                        Business.Devis.Add(d);
                    }
                }
                command.Connection.Close();
            }
        }
        public static bool InsertDevis(Devis d)
        {
            string sql = "INSERT INTO Devis(Id, Nom, Prenom, Date, Email, Exigence, Numero) " +
                         "VALUE (@id, @nom, @prenom, @date, @email, @exigence, @numero)";
            using (MySqlCommand cmd = new MySqlCommand(sql, connection))
            {
                cmd.Connection.Open();
                cmd.Parameters.AddWithValue("@id", null);
                cmd.Parameters.AddWithValue("@nom", d.Nom);
                cmd.Parameters.AddWithValue("@prenom", d.Prenom);
                cmd.Parameters.AddWithValue("@date", d.Date);
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
            string sql = "UPDATE Devis SET Nom=@nom, Prenom=@prenom, Date=@date, Email=@email, Exigence=@exigence, Numero=@numero " + 
                         "Where id=@id";
            using (MySqlCommand cmd = new MySqlCommand(sql, connection))
            {
                cmd.Connection.Open();

                cmd.Parameters.AddWithValue("@id", d.Id);
                cmd.Parameters.AddWithValue("@nom", d.Nom);
                cmd.Parameters.AddWithValue("@prenom", d.Prenom);
                cmd.Parameters.AddWithValue("@date", d.Date);
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
