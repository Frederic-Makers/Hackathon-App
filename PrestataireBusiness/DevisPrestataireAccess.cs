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
    public class DevisPrestataireAccess
    {
        private static MySqlConnection connection;
        static DevisPrestataireAccess()
        {
            String connString = "Server=remotemysql.com;Database=qgO0M364Or;userid=qgO0M364Or;Pwd=7Hyomgetg3";
            connection = new MySqlConnection(connString);
        }
        public static void GetDevisPrestataire(Devis d)
        {

            String sql = "SELECT * FROM DevisPrestataire WHERE devisId=@devisId ";
            using (MySqlCommand command = new MySqlCommand(sql, connection))
            {

                command.Connection.Open();
                command.Parameters.AddWithValue("@devisid", d.Id);
                using (System.Data.Common.DbDataReader dbReader = command.ExecuteReader())

                {
                    while (dbReader.Read())
                    {
                        
                        int devisid = dbReader.GetInt32(0);
                        int prestataireid = dbReader.GetInt32(1);
                        int prix = dbReader.GetInt32(2);
                        DevisPrestataire dp = new DevisPrestataire(0, devisid, prestataireid, prix);
                        foreach (Prestataire p in Business.Prestataires) { 
                            if(p.Id == prestataireid)
                            {
                                dp.Nom = p.Nom;
                                break;
                            }
                        }

                        
                        d.DevisPrestataires.Add(dp);
                    }
                }
                command.Connection.Close();
            }
        }
        public static bool InsertDevisPrestataire(DevisPrestataire p)
        {
            string sql = "INSERT INTO DevisPrestataire(Id, DevisId, PrestataireId) " +
                         "VALUE (@id, @devisid, @prestataireid)";
            using (MySqlCommand cmd = new MySqlCommand(sql, connection))
            {
                cmd.Connection.Open();
                cmd.Parameters.AddWithValue("@id", null);
                cmd.Parameters.AddWithValue("@devisid", p.DevisId);
                cmd.Parameters.AddWithValue("@prestataireid", p.PrestataireId);

                bool result = cmd.ExecuteNonQuery() == 1;
                cmd.Connection.Close();
                return result;
            }
        }
        public static bool UpdateDevisPrestataire(DevisPrestataire p)
        {
            string sql = "UPDATE DevisPrestataire SET DevisId=@devisid, PrestataireId=@prestataireid"
                + " Where Id=@id ";

            using (MySqlCommand cmd = new MySqlCommand(sql, connection))
            {
                cmd.Connection.Open();

                cmd.Parameters.AddWithValue("@id", p.Id);
                cmd.Parameters.AddWithValue("@devisid", p.DevisId);
                cmd.Parameters.AddWithValue("@prestataireid", p.PrestataireId);

                bool result = cmd.ExecuteNonQuery() == 1;
                cmd.Connection.Close();
                return result;

            }
        }
    }
}
