﻿using System.Data.SQLite;

public class GestorEmpleados
{
    private string connectionString;

    public GestorEmpleados(string databasePath)
    {
        connectionString = $"Data Source={databasePath};Version=3;";
    }

    //estoy usando sqlite y la libreria System.Data.SQLite
    public void CrearTabla()
    {
        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            string sql = "CREATE TABLE IF NOT EXISTS Empleados (Id INTEGER PRIMARY KEY AUTOINCREMENT, Nombre VARCHAR(100), Apellido VARCHAR(100), Edad INTEGER, Cargo VARCHAR(100), Sueldo INTEGER)";
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }

    public void AgregarEmpleado(Empleado empleado)
    {
        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        {
            connection.Open();

            string query = "INSERT INTO Empleados (Nombre, Apellido, Edad, Cargo, Sueldo) " +
                           "VALUES (@Nombre, @Apellido, @Edad, @Cargo, @Sueldo)";

            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                command.Parameters.AddWithValue("@Apellido", empleado.Apellido);
                command.Parameters.AddWithValue("@Edad", empleado.Edad);
                command.Parameters.AddWithValue("@Cargo", empleado.Cargo);
                command.Parameters.AddWithValue("@Sueldo", empleado.Sueldo);

                command.ExecuteNonQuery();
            }
        }
    }

    public List<Empleado> ObtenerEmpleados()
    {
        List<Empleado> empleados = new List<Empleado>();
        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT * FROM Empleados";
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string nombre = reader.GetString(1);
                        string apellido = reader.GetString(2);
                        int edad = reader.GetInt32(3);
                        string cargo = reader.GetString(4);
                        int sueldo = reader.GetInt32(5);
                        Empleado empleado = new Empleado(id, nombre, apellido, edad, cargo, sueldo);
                        empleados.Add(empleado);
                    }
                }
            }
        }
        return empleados;
    }








}