namespace CentralitaDB_App.Controllers
{
    using CentralitaDB_App.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    public class LlamadasController : Controller
    {
        private readonly IConfiguration _configuration;

        public LlamadasController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            List<Llamada> llamadas = new List<Llamada>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                string sql = "SELECT Id, NumOrigen, NumDestino, Duracion, TipoLlamada, HorarioOrigen, HorarioDestino, TecnologiaMovil, Costo FROM Llamadas";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            llamadas.Add(new Llamada
                            {
                                Id = dataReader.GetInt32(0),
                                NumOrigen = dataReader.GetString(1),
                                NumDestino = dataReader.GetString(2),
                                Duracion = (float)dataReader.GetDouble(3),
                                TipoLlamada = dataReader.GetString(4),
                                HorarioOrigen = dataReader.GetString(5),
                                HorarioDestino = dataReader.GetString(6),
                                TecnologiaMovil = dataReader.GetString(7),
                                Costo = (float)dataReader.GetDouble(8)
                            });
                        }
                    }
                }
            }

            return View(llamadas);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Llamada llamada)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    string sql = "INSERT INTO Llamadas (NumOrigen, NumDestino, Duracion, TipoLlamada, HorarioOrigen, HorarioDestino, TecnologiaMovil, Costo) VALUES (@NumOrigen, @NumDestino, @Duracion, @TipoLlamada, @HorarioOrigen, @HorarioDestino, @TecnologiaMovil, @Costo)";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@NumOrigen", llamada.NumOrigen);
                        command.Parameters.AddWithValue("@NumDestino", llamada.NumDestino);
                        command.Parameters.AddWithValue("@Duracion", llamada.Duracion);
                        command.Parameters.AddWithValue("@TipoLlamada", llamada.TipoLlamada);
                        command.Parameters.AddWithValue("@HorarioOrigen", llamada.HorarioOrigen);
                        command.Parameters.AddWithValue("@HorarioDestino", llamada.HorarioDestino);
                        command.Parameters.AddWithValue("@TecnologiaMovil", llamada.TecnologiaMovil);
                        command.Parameters.AddWithValue("@Costo", llamada.Costo);

                        command.ExecuteNonQuery();
                    }
                }

                return RedirectToAction("Index");
            }

            return View(llamada);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Llamada llamada = GetLlamadaById(id);
            if (llamada == null)
            {
                return NotFound();
            }
            return View(llamada);
        }

        [HttpPost]
        public IActionResult Edit(Llamada llamada)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    string sql = "UPDATE Llamadas SET NumOrigen=@NumOrigen, NumDestino=@NumDestino, Duracion=@Duracion, TipoLlamada=@TipoLlamada, HorarioOrigen=@HorarioOrigen, HorarioDestino=@HorarioDestino, TecnologiaMovil=@TecnologiaMovil, Costo=@Costo WHERE Id=@Id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@NumOrigen", llamada.NumOrigen);
                        command.Parameters.AddWithValue("@NumDestino", llamada.NumDestino);
                        command.Parameters.AddWithValue("@Duracion", llamada.Duracion);
                        command.Parameters.AddWithValue("@TipoLlamada", llamada.TipoLlamada);
                        command.Parameters.AddWithValue("@HorarioOrigen", llamada.HorarioOrigen);
                        command.Parameters.AddWithValue("@HorarioDestino", llamada.HorarioDestino);
                        command.Parameters.AddWithValue("@TecnologiaMovil", llamada.TecnologiaMovil);
                        command.Parameters.AddWithValue("@Costo", llamada.Costo);
                        command.Parameters.AddWithValue("@Id", llamada.Id);

                        command.ExecuteNonQuery();
                    }
                }

                return RedirectToAction("Index");
            }

            return View(llamada);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Llamada llamada = GetLlamadaById(id);
            if (llamada == null)
            {
                return NotFound();
            }
            return View(llamada);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                string sql = "DELETE FROM Llamadas WHERE Id=@Id";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }

            return RedirectToAction("Index");
        }

        private Llamada GetLlamadaById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                string sql = "SELECT Id, NumOrigen, NumDestino, Duracion, TipoLlamada, HorarioOrigen, HorarioDestino, TecnologiaMovil, Costo FROM Llamadas WHERE Id=@Id";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            return new Llamada
                            {
                                Id = dataReader.GetInt32(0),
                                NumOrigen = dataReader.GetString(1),
                                NumDestino = dataReader.GetString(2),
                                Duracion = (float)dataReader.GetDouble(3),
                                TipoLlamada = dataReader.GetString(4),
                                HorarioOrigen = dataReader.GetString(5),
                                HorarioDestino = dataReader.GetString(6),
                                TecnologiaMovil = dataReader.GetString(7),
                                Costo = (float)dataReader.GetDouble(8)
                            };
                        }
                    }
                }
            }
            return null;
        }
    }


}
