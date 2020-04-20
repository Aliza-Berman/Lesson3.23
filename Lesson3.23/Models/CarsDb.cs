using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson3._23.Models
{
    public class CarsDb
    {
        private string _connectionString;
        public CarsDb(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<Car> GetCars()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = @"SELECT * FROM Cars";
            connection.Open();
            List<Car> result = new List<Car>();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Add(FromReader(reader)); 
            }

            connection.Close();
            connection.Dispose();
            return result;
        }
        public void AddCar(Car car)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO Cars " +
                            " VALUES(@make,@model,@year,@price,@carType,@hasLeatherSeats)";
            cmd.Parameters.AddWithValue("@make", car.Make);
            cmd.Parameters.AddWithValue("@model", car.Model);
            cmd.Parameters.AddWithValue("@year", car.Year);
            cmd.Parameters.AddWithValue("@price", car.Price);
            cmd.Parameters.AddWithValue("@carType", car.CarType);
            cmd.Parameters.AddWithValue("@hasLeatherSeats", car.HasLeatherSeats);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();
        }
        public List<Car> Ascending()
        {
            return Sort(false);
        }
        public List<Car> Descending()
        {
            return Sort(true);
        }
        public List<Car> Sort(bool ascending)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM Cars " +
                             " ORDER BY Year ";
            if (!ascending)
            {
                cmd.CommandText += "DESC";
            }
            else {
                cmd.CommandText += "ASC";
            }
            connection.Open();
            List<Car> result = new List<Car>();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Add(FromReader(reader));
                
            }
            connection.Close();
            connection.Dispose();
            return result;
        }

        private Car FromReader(SqlDataReader reader)
        {
            var car = new Car()
            {
                Make = (string)reader["Make"],
                Model = (string)reader["Model"],
                Year = (int)reader["Year"],
                Price = (decimal)reader["Price"],
                CarType = (CarType)reader["CarType"],
                HasLeatherSeats = (bool)reader["HasLeatherSeats"]
            };

            return car;
        }
    }

}