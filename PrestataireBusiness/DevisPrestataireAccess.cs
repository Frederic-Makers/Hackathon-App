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
            String connString = "Server=remotemysql.com/phpmyadmin/sql.php?server=1&db=qgO0M364Or&table=Prestataire&pos=0;Database=qgO0M364Or;userid=sgroot;Pwd=7Hyomgetg3";
            connection = new MySqlConnection(connString);
        }
        public static void GetDevisPrestataire()
        {
            String sql = "SELECT * FROM devisprestataire";
            using (MySqlCommand command = new MySqlCommand(sql, connection))
            {
                command.Connection.Open();
                using (System.Data.Common.DbDataReader dbReader = command.ExecuteReader())

                {
                    while (dbReader.Read())
                    {
                        int id = dbReader.GetInt32(0);
                        int devisid = dbReader.GetInt32(1);
                        int prestataireid = dbReader.GetInt32(2);
                        int prixid = dbReader.GetInt32(3);

                        Business.DevisPrestataire.Add(new DevisPrestataire(id, devisid, prestataireid, prixid));

                    }
                }
                command.Connection.Close();
            }

        }
        public static bool InsertDevisPrestataire(DevisPrestataire p)
        {
            string sql = "INSERT INTO prestataire(Id, DevisId, PrestataireId) " +
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
            string sql = "UPDATE devisprestataire SET DevisId=@devisid, PrestataireId=@prestataireid"
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
