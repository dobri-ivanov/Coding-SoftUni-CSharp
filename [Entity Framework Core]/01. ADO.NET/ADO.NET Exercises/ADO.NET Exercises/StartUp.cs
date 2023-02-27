namespace ADO.NET_Exercises
{
    using Microsoft.Data.SqlClient;
    using System.Text;

    internal class StartUp
    {
        static void Main(string[] args)
        {
            using SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);
            sqlConnection.Open();

            Console.WriteLine(GetVillainsWithMinions(sqlConnection));
        }
        static string GetVillainsWithMinions(SqlConnection sqlConnection)
        {
            StringBuilder sb = new StringBuilder();
            SqlCommand sqlCommand = new SqlCommand(Queries.Problem2, sqlConnection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                string name = (string)sqlDataReader["Name"];
                int count = (int)sqlDataReader["MinionsCount"];
                
                sb.AppendLine($"{name} - {count}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}