using Oracle.ManagedDataAccess.Client;

namespace Spr.Oracle;

public class OracleDBConnection
{
    public void Connect()
    {
        // This sample demonstrates how to use ODP.NET Core Configuration API

        // Add connect descriptors and net service names entries.
        OracleConfiguration.OracleDataSources.Add("orclpdb", "(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=FREE)(SERVER=dedicated)))");

        // Set default statement cache size to be used by all connections.
        OracleConfiguration.StatementCacheSize = 25;

        // Disable self tuning by default.
        OracleConfiguration.SelfTuning = false;

        // Bind all parameters by name.
        OracleConfiguration.BindByName = true;

        // Set default timeout to 60 seconds.
        OracleConfiguration.CommandTimeout = 60;

        // Set default fetch size as 1 MB.
        OracleConfiguration.FetchSize = 1024 * 1024;

        // Set tracing options
        OracleConfiguration.TraceOption = 1;
        OracleConfiguration.TraceFileLocation = @"D:\traces";
        // Uncomment below to generate trace files
        //OracleConfiguration.TraceLevel = 7;

        // Set network properties
        OracleConfiguration.SendBufferSize = 8192;
        OracleConfiguration.ReceiveBufferSize = 8192;
        OracleConfiguration.DisableOOB = true;

        OracleConnection orclCon = null;

        try
        {
            // Open a connection
            orclCon = new OracleConnection("user id=sys; password=admin; data source=orclpdb");
            orclCon.Open();

            // Execute simple select statement that returns first 10 names from EMPLOYEES table
            OracleCommand orclCmd = orclCon.CreateCommand();
            orclCmd.CommandText = "select first_name from employees where rownum <= 10 ";
            OracleDataReader rdr = orclCmd.ExecuteReader();

            while (rdr.Read())
            {
                Console.WriteLine("Employee Name: " + rdr.GetString(0));
            }

            Console.ReadLine();

            rdr.Dispose();
            orclCmd.Dispose();
        }
        finally
        {
            // Close the connection
            if (orclCon != null)
            {
                orclCon.Close();
            }
        }
    }
}
