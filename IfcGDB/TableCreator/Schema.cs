using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace IfcGDB.TableCreator
{

        //This class create the Geometry schema in database and enable postgis
        public class Schema
        {
            private bool createNewSchema = true;
            private string schemaName = "Geometry";

            public void Create()
            {
                //var conn = new NpgsqlConnection(connString);
                //conn.Open();

                using (var creatSchemaCommand = new NpgsqlCommand())
                {
                    creatSchemaCommand.Connection = dbConnnection;
                    creatSchemaCommand.CommandText = "DROP SCHEMA IF EXISTS (@p); Create SCHEMA (@p)" +
                                                     "SET search_path = public,geometry;";
                    creatSchemaCommand.Parameters.AddWithValue(schemaName);
                    creatSchemaCommand.ExecuteNonQuery();
                }
            }

            public void InstallPostgis()
            {
                using (var installPostgisCommand = new NpgsqlCommand())
                {
                    installPostgisCommand.Connection = dbConnnection;
                    installPostgisCommand.CommandText = "CREATE EXTENSION postgis;" + //Enable PostGIS (includes raster)
                                                        "CREATE EXTENSION postgis_topology;" + //Enable Topology
                                                        "CREATE EXTENSION postgis_sfcgal;"; //Enable PostGIS Advanced 3D & other geoprocessing algorithms
                    installPostgisCommand.ExecuteNonQuery();
                }
            }
        }
   
}
