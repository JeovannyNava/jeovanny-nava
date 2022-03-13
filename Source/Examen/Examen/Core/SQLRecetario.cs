using Examen.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.Data.SqlClient.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Core
{
    public class SQLRecetario
    {

        private readonly DBContext _context;

        public SQLRecetario(DBContext context)
        {
            _context = context;
        }
        public List<Receta> GetRecetas()
        {


            List<Receta> recetas = new List<Receta>();

            return recetas;

        }

        public bool PostReceta(Receta receta)
        {
            try
            {

                using (var command = _context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "SP_INSERT_RECETA";

                    DbParameter paramName = command.CreateParameter();
                    paramName.ParameterName = "@Nombre";
                    paramName.Value = receta.Nombre;
                    command.Parameters.Add(paramName);

                    DbParameter paramDescripcion = command.CreateParameter();
                    paramDescripcion.ParameterName = "@Descripcion";
                    paramDescripcion.Value = receta.Descripcion;
                    command.Parameters.Add(paramDescripcion);

                    DbParameter paramFechaCreacion = command.CreateParameter();
                    paramFechaCreacion.ParameterName = "@FechaCreacion";
                    paramFechaCreacion.Value = DateTime.Now;
                    command.Parameters.Add(paramFechaCreacion);

                    DbParameter paramFechaActualizacion = command.CreateParameter();
                    paramFechaActualizacion.ParameterName = "@FechaActualizacion";
                    paramFechaActualizacion.Value = DateTime.Now;
                    command.Parameters.Add(paramFechaActualizacion);


                    DbParameter paramImagen = command.CreateParameter();
                    paramImagen.ParameterName = "@Imagen";
                    paramImagen.Value = receta.Imagen;
                    command.Parameters.Add(paramImagen);

                    var outputParameter = new SqlParameter
                    {
                        ParameterName = "@IdReceta",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(outputParameter);
                    command.CommandType = CommandType.StoredProcedure;
                    _context.Database.OpenConnection();
                    command.ExecuteNonQuery();
                    var result = outputParameter.Value.ToString();
                    if (result.ToString() != "0")
                    {
                        var ingredientesReceta = receta.Ingredientes.ToList();

                        ingredientesReceta.ForEach(ingrediente =>
                        {
                            ingrediente.FechaActualizacion = DateTime.Now;
                            ingrediente.FechaCreacion = DateTime.Now;
                            ingrediente.IdReceta = Int32.Parse(result); 
                        });


                        return postIngredientes(ingredientesReceta);
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {

                return false;
            }
            finally
            {
                _context.Database.CloseConnection();
            }

          
        }

        public bool postIngredientes(List<Ingrediente> ingredientes)
        {
            try
            {
                using (var command = _context.Database.GetDbConnection().CreateCommand())
                {

                    command.CommandText = "SP_INSERT_INGREDIENTES";

                    command.Parameters.Clear();
                    List<SqlDataRecord> datatable = new List<SqlDataRecord>();

                    var ingredientesParam =
                         new SqlParameter("@Ingredientes", SqlDbType.Structured)
                         {
                             TypeName = "dbo.IngredientesReceta",
                             Value = GetSqlDataRecordsContactsList(ingredientes)
                         };
                    command.Parameters.Add(ingredientesParam);

                    var outputParameter = new SqlParameter
                    {
                        ParameterName = "@Result",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(outputParameter);
                    command.CommandType = CommandType.StoredProcedure;
                    _context.Database.OpenConnection();
                    command.ExecuteNonQuery();
                    var result = outputParameter.Value.ToString();
                    return result == "1";
                }



            }
            catch (Exception ex)
            {

                return false;
            }

        }

        public bool UpdateReceta(Receta receta)
        {
            try
            {

                using (var command = _context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "SP_UPDATE_RECETA";

                    DbParameter paramId = command.CreateParameter();
                    paramId.ParameterName = "@Id";
                    paramId.Value = receta.IdReceta;
                    command.Parameters.Add(paramId); 

                    DbParameter paramName = command.CreateParameter();
                    paramName.ParameterName = "@Nombre";
                    paramName.Value = receta.Nombre;
                    command.Parameters.Add(paramName);

                    DbParameter paramDescripcion = command.CreateParameter();
                    paramDescripcion.ParameterName = "@Descripcion";
                    paramDescripcion.Value = receta.Descripcion;
                    command.Parameters.Add(paramDescripcion);

                    DbParameter paramFechaActualizacion = command.CreateParameter();
                    paramFechaActualizacion.ParameterName = "@FechaActualizacion";
                    paramFechaActualizacion.Value = DateTime.Now;
                    command.Parameters.Add(paramFechaActualizacion);


                    DbParameter paramImagen = command.CreateParameter();
                    paramImagen.ParameterName = "@Imagen";
                    paramImagen.Value = receta.Imagen;
                    command.Parameters.Add(paramImagen);

                    var outputParameter = new SqlParameter
                    {
                        ParameterName = "@Result",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(outputParameter);
                    command.CommandType = CommandType.StoredProcedure;
                    _context.Database.OpenConnection();
                    command.ExecuteNonQuery();
                    var result = outputParameter.Value.ToString();
                    if (result.ToString() == "1")
                    {
                        var ingredientesReceta = receta.Ingredientes.ToList();

                        ingredientesReceta.ForEach(ingrediente =>
                        {
                            ingrediente.FechaActualizacion = DateTime.Now;
                            ingrediente.FechaCreacion = DateTime.Now;
                            ingrediente.IdReceta = receta.IdReceta;
                        });


                        return postIngredientes(ingredientesReceta);
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {

                return false;
            }
            finally
            {
                _context.Database.CloseConnection();
            }
        }

        public bool deleteReceta(int IdReceta)
        {
            try
            {

                using (var command = _context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "SP_DELETE_RECETA";

                    DbParameter paramId = command.CreateParameter();
                    paramId.ParameterName = "@IdReceta";
                    paramId.Value = IdReceta;
                    command.Parameters.Add(paramId);


                    var outputParameter = new SqlParameter
                    {
                        ParameterName = "@Result",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(outputParameter);
                    command.CommandType = CommandType.StoredProcedure;
                    _context.Database.OpenConnection();
                    command.ExecuteNonQuery();
                    var result = outputParameter.Value.ToString();

                    return result == "1";
                }
            }
            catch (Exception ex)
            {

                return false;
            }
            finally
            {
                _context.Database.CloseConnection();
            }
        }

        public List<Receta> getRecetas()
        {
            var query = _context.Recetas.FromSqlRaw("SP_GET_RECETAS" ).ToList();

            return query;
        }

        private static List<SqlDataRecord> GetSqlDataRecordsContactsList(List<Ingrediente> ingredientes)
        {
            try
            {
                List<SqlDataRecord> datatable = new List<SqlDataRecord>();
                SqlMetaData[] sqlMetaData = new SqlMetaData[5];
                sqlMetaData[0] = new SqlMetaData("Nombre", SqlDbType.NVarChar, 512);
                sqlMetaData[1] = new SqlMetaData("Porcion", SqlDbType.NVarChar, 512);
                sqlMetaData[2] = new SqlMetaData("IdReceta", SqlDbType.Int);
                sqlMetaData[3] = new SqlMetaData("FechaActualizacion", SqlDbType.DateTime);
                sqlMetaData[4] = new SqlMetaData("FechaCreacion", SqlDbType.DateTime);

                foreach (var ingrediente in ingredientes)
                {
                    SqlDataRecord row = new SqlDataRecord(sqlMetaData);
                    row.SetValues(ingrediente.Nombre, ingrediente.Porcion, ingrediente.IdReceta, ingrediente.FechaActualizacion, ingrediente.FechaCreacion);
                    datatable.Add(row);
                }

                return datatable;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
