using Beadando.Models.Records;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando.Models.Manager
{
    class GitarokTabla
    {
        OracleConnection GetOracleConnection()
        {
            OracleConnection oc = new OracleConnection();
            
            string connectionString = @"Data Source=193.225.33.71; User Id=L5M9Q7; Password=EKE2020;";
            oc.ConnectionString = connectionString;
            return oc;
        }

        public List<Gitar> Select()
        {
            List<Gitar> records = new List<Gitar>();
            OracleConnection oc = GetOracleConnection();


            oc.Open();

            OracleCommand command = new OracleCommand()
            {
                CommandType = System.Data.CommandType.Text,
                CommandText = "SELECT g.sorozatszam, gy.nev, g.tipus, g.gyartas_datum, g.balkezes, g.erintok_szama FROM " +
                " gitarok g INNER JOIN gyartok gy ON gy.id = g.gyarto_id"
            };

            command.Connection = oc;

            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Gitar gitar = new Gitar();
                gitar.Sorozatszam = reader["sorozatszam"].ToString();
                gitar.Tipus = reader["tipus"].ToString();
                gitar.Gyarto = reader["nev"].ToString();
                gitar.GyartasDatum = DateTime.Parse(reader["gyartas_datum"].ToString());
                if (reader["balkezes"].ToString() == "1")
                {
                    gitar.Balkezes = true;
                }
                else
                {
                    gitar.Balkezes = false;
                }

                gitar.ErintokSzama = int.Parse(reader["erintok_szama"].ToString());

                records.Add(gitar);
            }
            oc.Close();



            return records;
        }

        public int Delete(Gitar gitar)
        {
            OracleConnection oc = GetOracleConnection();
            oc.Open();

            OracleTransaction ot = oc.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

            OracleCommand command = new OracleCommand()
            {
                CommandType = System.Data.CommandType.Text,
                CommandText = "DELETE FROM gitarok WHERE sorozatszam = :sorozatszam"
            };

            OracleParameter sorozatszamParameter = new OracleParameter()
            {
                DbType = System.Data.DbType.String,
                ParameterName = ":sorozatszam",
                Direction = System.Data.ParameterDirection.Input,
                Value = gitar.Sorozatszam
            };
            command.Parameters.Add(sorozatszamParameter);

            command.Connection = oc;
            command.Transaction = ot;

            int affectedRows = 0;
            try
            {
                affectedRows = command.ExecuteNonQuery();
                ot.Commit();
            }
            catch (Exception e)
            {
                ot.Rollback();
            }
            oc.Close();

            return affectedRows;
        }

        public int Insert(Gitar gitar)
        {
            OracleConnection oc = GetOracleConnection();
            oc.Open();

            OracleTransaction ot = oc.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

            OracleCommand command = new OracleCommand()
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = "sp_Insertgitarok"
            };

            OracleParameter sorozatszamParameter = new OracleParameter()
            {
                DbType = System.Data.DbType.String,
                ParameterName = "p_sorozatszam",
                Direction = System.Data.ParameterDirection.Input,
                Value = gitar.Sorozatszam
            };
            command.Parameters.Add(sorozatszamParameter);

            OracleParameter tipusParameter = new OracleParameter()
            {
                DbType = System.Data.DbType.String,
                ParameterName = "p_tipus",
                Direction = System.Data.ParameterDirection.Input,
                Value = gitar.Tipus
            };
            command.Parameters.Add(tipusParameter);

            OracleParameter gyartoParameter = new OracleParameter()
            {
                DbType = System.Data.DbType.String,
                ParameterName = "p_gyarto",
                Direction = System.Data.ParameterDirection.Input,
                Value = gitar.Gyarto
            };
            command.Parameters.Add(gyartoParameter);

            OracleParameter gyartasDatumParameter = new OracleParameter()
            {
                DbType = System.Data.DbType.Date,
                ParameterName = "p_gyartas_datum",
                Direction = System.Data.ParameterDirection.Input,
                Value = gitar.GyartasDatum
            };
            command.Parameters.Add(gyartasDatumParameter);

            OracleParameter balkezesParameter = new OracleParameter()
            {
                DbType = System.Data.DbType.Int32,
                ParameterName = "p_balkezes",
                Direction = System.Data.ParameterDirection.Input
            };
            if (gitar.Balkezes)
            {
                balkezesParameter.Value = 1;
            }
            else
            {
                balkezesParameter.Value = 0;
            }

            command.Parameters.Add(balkezesParameter);

            OracleParameter erintokSzamaParameter = new OracleParameter()
            {
                DbType = System.Data.DbType.Int32,
                ParameterName = "p_erintok_szama",
                Direction = System.Data.ParameterDirection.Input,
                Value = gitar.ErintokSzama
            };
            command.Parameters.Add(erintokSzamaParameter);

            OracleParameter hangszedokParameter = new OracleParameter()
            {
                DbType = System.Data.DbType.String,
                ParameterName = "p_hangszedok",
                Direction = System.Data.ParameterDirection.Input,
                Value = gitar.Hangszedok
            };
            command.Parameters.Add(hangszedokParameter);

            OracleParameter rowcountParameter = new OracleParameter()
            {
                DbType = System.Data.DbType.Int32,
                ParameterName = "p_out_rowcnt",
                Direction = System.Data.ParameterDirection.Output
            };
            command.Parameters.Add(rowcountParameter);


            command.Connection = oc;
            command.Transaction = ot;


            try
            {
                command.ExecuteNonQuery();
                int affectedRows = int.Parse(rowcountParameter.Value.ToString());
                ot.Commit();
                oc.Close();
                return affectedRows;
            }
            catch (Exception e)
            {

                ot.Rollback();
                oc.Close();
                return 0;
            }
        }


        public bool CheckSorozatszam (string sorozatszam)
        {
            OracleConnection oc = GetOracleConnection();
            oc.Open();

            OracleCommand command = new OracleCommand()
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = "sf_checksorozatszam"
            };

            OracleParameter correct = new OracleParameter()
            {
                 OracleDbType = OracleDbType.Int32,
                 Direction = System.Data.ParameterDirection.ReturnValue
            }; 

            command.Parameters.Add(correct);

            OracleParameter sorozatszamParameter = new OracleParameter()
            {
                OracleDbType = OracleDbType.Varchar2,
                DbType = System.Data.DbType.String,
                ParameterName = "p_sorozatszam",
                Direction = System.Data.ParameterDirection.Input,
                Value = sorozatszam
            };

            command.Parameters.Add(sorozatszamParameter);

            command.Connection = oc;
            command.ExecuteNonQuery();

            oc.Close();

            try
            {
                int succesful = int.Parse(correct.Value.ToString());

                return succesful != 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
        

    }
}
