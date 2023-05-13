using MySql.Data.MySqlClient;
using System.Data;
using System.Windows;

namespace Asgard.Repositories
{
    public class RepositoryBase
    {
        private static readonly string ConnectionString = "datasource=192.168.100.18;port=3306;username=eoverart;password=P3CZV4pgc7jtT4z;database=asgard";

        protected MySqlConnection GetConnection()
        {
            var connection = new MySqlConnection(ConnectionString);
            return connection;
        }

        public static MySqlConnection GetConnectionPublic()
        {
            var connection = new MySqlConnection(ConnectionString);
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
            }
            catch (MySqlException ex)
            {
                // Display the prompt
                CustomControls.Prompt dialog = new CustomControls.Prompt();
                dialog.Loaded += (s, ea) =>
                {
                    dialog.Title = "Eroare";
                    dialog.Status.Text = "MySQL Connection! \n" + ex.Message;
                    dialog.Descriere.Text = "Verifică conexiunea la VPN";
                };
                dialog.ShowDialog();
            }
            return connection;
        }


        public static void AddOrder(Models.Comenzi order)
        {
            string sql = "INSERT INTO comenzi VALUES (NULL, @Agent, @Telefon, @Model, @Semnare, NULL)";
            MySqlConnection con = GetConnectionPublic();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@Agent", MySqlDbType.VarChar).Value = order.Agent;
            cmd.Parameters.Add("@Telefon", MySqlDbType.VarChar).Value = order.Telefon;
            cmd.Parameters.Add("@Model", MySqlDbType.VarChar).Value = order.Model;
            cmd.Parameters.Add("@Semnare", MySqlDbType.VarChar).Value = order.Semnare;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Comanda nu a putut fi trimisa! \n" + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            con.Close();
        }
    }
}
