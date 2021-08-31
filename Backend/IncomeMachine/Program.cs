using System;
using Npgsql;

namespace IncomeMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            var cs = "Host=localhost;Username=postgres;Password=postgres;Database=risk";

            using var con = new NpgsqlConnection(cs);
            con.Open();

            string sql = "SELECT * from Player";
            using var cmd = new NpgsqlCommand(sql, con);

            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read()){
                Console.WriteLine(rdr.Read());
            }
        }
    }
}
