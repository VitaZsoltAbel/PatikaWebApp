using MySql.Data.MySqlClient;
using PatikaWebApp.Models;

namespace PatikaWebApp.Services
{
    public class GyogyszerService
    {
        private readonly string _connectionString = "Server=localhost;Database=patika;Uid=root;Pwd=;";

        public List<Gyogyszer> GetAllGyogyszer()
        {
            var gyogyszerek = new List<Gyogyszer>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT Id, Nev, Hatoanyag, Venykoteles, kepnev FROM gyogyszer";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            gyogyszerek.Add(new Gyogyszer
                            {
                                Id = reader.GetInt32("Id"),
                                Nev = reader.GetString("Nev"),
                                Hatoanyag = reader.GetString("Hatoanyag"),
                                Venykoteles = reader.GetBoolean("Venykoteles"),
                                kepnev = reader.GetString("kepnev")
                            });
                        }
                    }
                }
            }

            return gyogyszerek;
        }

        public Gyogyszer? GetById(int id)
        {
            Gyogyszer? gyogyszer = null;

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT Id, Nev, Hatoanyag, Venykoteles, kepnev FROM gyogyszer WHERE Id = @Id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            gyogyszer = new Gyogyszer
                            {
                                Id = reader.GetInt32("Id"),
                                Nev = reader.GetString("Nev"),
                                Hatoanyag = reader.GetString("Hatoanyag"),
                                Venykoteles = reader.GetBoolean("Venykoteles"),
                                kepnev = reader.GetString("kepnev")
                            };
                        }
                    }
                }
            }

            return gyogyszer;
        }
    }
}