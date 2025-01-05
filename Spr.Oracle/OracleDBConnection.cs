using Oracle.ManagedDataAccess.Client;
using Spr.Core;
using Spr.Oracle.Models;
using System.Diagnostics;

namespace Spr.Oracle
{
    public class OracleDBConnection : BaseConnection<OracleContext>
    {
        public override void Connect()
        {
            this._client = new OracleContext();

            var sw = new Stopwatch();

            for (int recordCount = 1; recordCount <= 6; recordCount++)
            {
                var objList = new List<CategoryRecord>();
                for (int i = 0; i < Math.Pow(10, recordCount); i++)
                {
                    objList.Add(new CategoryRecord(Guid.NewGuid().ToString(), Guid.NewGuid().ToString()));
                    //  objList.Add(new CategoryRecord(i, Guid.NewGuid().ToString(), Guid.NewGuid().ToString()));
                }

                // create
                sw.Restart();
                this._client.Category.AddRange(objList);
                this._client.SaveChanges();
                sw.Stop();

                Console.WriteLine($"Time to insert {Math.Pow(10, recordCount)} records: {sw.ElapsedMilliseconds} ms");

                // read
                sw.Restart();
                var records = this._client.Category.ToList();
                sw.Stop();

                Console.WriteLine($"Time to read {Math.Pow(10, recordCount)} records: {sw.ElapsedMilliseconds} ms");

                // delete
                sw.Restart();
                this._client.Category.RemoveRange(objList);
                this._client.SaveChanges();
                sw.Stop();

                Console.WriteLine($"Time to delete {Math.Pow(10, recordCount)} records: {sw.ElapsedMilliseconds} ms");

                objList.Clear();
            }
        }

        public void Connect2()
        {
            // Set Oracle Configuration
            ConfigureOracleSettings();

            try
            {
                using (OracleConnection orclCon = new OracleConnection(GetConnectionString()))
                {
                    // Open the connection
                    orclCon.Open();
                    Console.WriteLine("Connected to the database successfully.");

                    // Execute query and display results
                    using (OracleCommand orclCmd = orclCon.CreateCommand())
                    {
                        orclCmd.CommandText = "SELECT first_name FROM employees WHERE rownum <= 10";

                        using (OracleDataReader rdr = orclCmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                Console.WriteLine("Employee Name: " + rdr.GetString(0));
                            }
                        }
                    }
                }
            }
            catch (OracleException ex)
            {
                Console.WriteLine($"Oracle error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General error: {ex.Message}");
            }
        }

        private static void ConfigureOracleSettings()
        {
            //OracleConfiguration.OracleDataSources.Add("orclpdb", "(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=172.17.0.1)(PORT=1521))(CONNECT_DATA=(SID=FREE)(SERVER=dedicated)))");

            OracleConfiguration.StatementCacheSize = 25;
            OracleConfiguration.SelfTuning = false;
            OracleConfiguration.BindByName = true;
            OracleConfiguration.CommandTimeout = 60;
            OracleConfiguration.FetchSize = 1024 * 1024;
            OracleConfiguration.TraceOption = 1;
            OracleConfiguration.SendBufferSize = 8192;
            OracleConfiguration.ReceiveBufferSize = 8192;
            OracleConfiguration.DisableOOB = true;
            OracleConfiguration.TraceFileLocation = "D:\\traces"; // Adjust path
            OracleConfiguration.TraceOption = 1;
            OracleConfiguration.TraceLevel = 7;

        }

        private static string GetConnectionString()
        {
            // Retrieve connection string from a secure source
            return "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SID=free)));User Id=system;Password=admin;";
        }
    }
}
