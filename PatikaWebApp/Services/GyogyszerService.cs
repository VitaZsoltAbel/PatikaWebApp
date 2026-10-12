using MySql.Data.MySqlClient;
using PatikaWebApp.Models;

namespace PatikaWebApp.Services
{
    public class GyogyszerService
    {
        private readonly string connectionString = "SERVER=localhost;DATABASE=patika;UID=root;PASSWORD=;SSL MODE=none;";


        public string Create(Gyogyszer gyogyszer)
        {
            string connectionString = "SERVER = localhost;" +
                          "DATABASE= patika;" +
                          "UID = root;" +
                          "PASSWORD =;" ;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO gyogyszer (Id, Nev, Hatoanyag, Venykoteles, kepnev) VALUES (@Id, @Nev, @Hatoanyag, @Venykoteles, @kepnev)";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", gyogyszer.Id);
                    cmd.Parameters.AddWithValue("@Nev", gyogyszer.Nev);
                    cmd.Parameters.AddWithValue("@Hatoanyag", gyogyszer.Hatoanyag);
                    cmd.Parameters.AddWithValue("@Venykoteles", gyogyszer.Venykoteles);
                    cmd.Parameters.AddWithValue("@kepnev", gyogyszer.kepnev);

                    int sorokszama = cmd.ExecuteNonQuery();

                    if (sorokszama > 0)
                    {
                        return "Sikeres beszúrás";
                    }
                    else
                    {
                        return "Sikertelen beszúrás";
                    }
                }
            }
        }


        public List<Gyogyszer> GetAllGyogyszer()
        {
            List<Gyogyszer> gyogyszerek = new List<Gyogyszer>();

            string connectionString = "SERVER = localhost;" +
                          "DATABASE= patika;" +
                          "UID = root;" +
                          "PASSWORD =;" ;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT Id, Nev, Hatoanyag, Venykoteles, kepnev FROM gyogyszer";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Gyogyszer gyogyszer = new Gyogyszer
                        {
                            Id = reader.GetInt32("Id"),
                            Nev = reader.GetString("Nev"),
                            Hatoanyag = reader.GetString("Hatoanyag"),
                            Venykoteles = reader.GetBoolean("Venykoteles"),
                            kepnev = reader.GetString("Kepnev"),

                        };
                        gyogyszerek.Add(gyogyszer);
                    }
                }
            }
            return gyogyszerek;
        }

        public Gyogyszer GetById(int id)
        {
            Gyogyszer gyogyszer = null;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT Id, Nev, Hatoanyag, Venykoteles, kepnev FROM vasarlo WHERE Id = @Id";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            gyogyszer = new Gyogyszer
                            {
                                Id = reader.GetInt32("Id"),
                                Nev = reader.GetString("Nev"),
                                Hatoanyag = reader.GetString("Hatoanyag"),
                                Venykoteles = reader.GetBoolean("Venykoteles"),
                                kepnev = reader.GetString("Kepnev"),
                            };
                        }
                    }
                }
            }
            return gyogyszer;
        }

    }
}