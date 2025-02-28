﻿using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using Spr.Core;
using Spr.Oracle.Models;
using System.Diagnostics;

namespace Spr.Oracle
{
    public class OracleDBConnection : BaseConnection<OracleContext>
    {

        public OracleDBConnection()
            : base("Oracle")
        {
            this._client = new OracleContext();
        }

        /// <inheritdoc />
        protected override IEnumerable<object> CreateSamples(int count)
        {
            var categories = new List<CategoryRecord>();
            for (int i = 0; i <count; i++)
            {
                categories.Add(new CategoryRecord(Guid.NewGuid().ToString(), Guid.NewGuid().ToString()));
            }

            return categories;
        }

        /// <inheritdoc />
        protected override void TestInsert(IEnumerable<object> samples)
        {
            this._client.Category.AddRange((IEnumerable<CategoryRecord>)samples);
            this._client.SaveChanges();
        }

        /// <inheritdoc />
        protected override void TestReadAll()
        {
            this._client.Category.ToList();
        }

        /// <inheritdoc />
        protected override void TestUpdate(IEnumerable<object> samples)
        {
            this._client.Category.ExecuteUpdate(x => x.SetProperty(p => p.Description, "Test update"));
            this._client.SaveChanges();
        }

        /// <inheritdoc />
        protected override void TestDelete(IEnumerable<object> samples)
        {
            this._client.Category.RemoveRange((IEnumerable<CategoryRecord>)samples);
            this._client.SaveChanges();
        }

        protected override void TestReadFiltered(object obj)
        {
            this._client.Category.Where(x => x.Name == ((CategoryRecord)obj).Name).ToList();
        }

        protected override void CreateIndex()
        {
            this._client.Database.ExecuteSqlRaw("CREATE INDEX IX_CATEGORY_NAME ON \"Category\"(\"Name\")");
        }

        protected override void DropIndexes()
        {
            this._client.Database.ExecuteSqlRaw("DROP INDEX IX_CATEGORY_NAME");
        }

        /// <inheritdoc />
        public override void TestOperation()
        {
            this._client = new OracleContext();

            var sw = new Stopwatch();

            for (int recordCount = 1; recordCount <= 6; recordCount++)
            {
                var objList = new List<CategoryRecord>();
                for (int i = 0; i < Math.Pow(10, recordCount); i++)
                {
                    objList.Add(new CategoryRecord(Guid.NewGuid().ToString(), Guid.NewGuid().ToString()));
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
