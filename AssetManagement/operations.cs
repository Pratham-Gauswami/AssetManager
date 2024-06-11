using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;

public class Operations
{

    private static string ConnectionString;
    private SqlDataAdapter adp = null;
    private DataSet ds = null;
    private SqlCommand cmd = null;
    private SqlConnection conn = null;
    public static string dbname = ""; public static string username = ""; public static string password = ""; public static string servAdd = "";
    public static string Dbname = "";
    public static string Username = "";
    public static string Password = "";
    public static string ServAdd = "";

    public Operations()
    {

        SqlConnection conn = new SqlConnection();
        conn.ConnectionString =
        "Data Source=localhost;" +
        "Initial Catalog=Tempus_UnderDev_2.1.3;" +
        "User id=sa;" +
        "Password=Pratham72;";
        conn.Open();
        //Establihing an connection with the database       
    }

    //property to access the connection for testing purpose
    public SqlConnection Connection => conn;

    //* NEED TO CHECK IF THE CONNECTION WAS ESTABLISHED OR NOT 

    public DataSet ExecuteProcedureSelect(string strproc, SqlParameter[] param)
    {

        //Need to check if the connection has been established or not.
        using (conn = new SqlConnection(ConnectionString)) ;
        {
            try
            {
                conn.Open();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = strproc;

                //Adding the parameters to the command if needed
                if (param != null)
                {
                    cmd.Parameters.AddRange(param);
                }

                ds = new DataSet();
                adp = new SqlDataAdapter();
                adp.Fill(ds);

                //Atlast return the filled Dataset
                return ds;
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }

    public int ExecuteProcedureIUD(string strproc, SqlParameter[] param)
    {

        //Need to check if the connection has been established or not.
        using (conn = new SqlConnection(ConnectionString)) ;
        {
            try
            {
                conn.Open();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = strproc;

                //Adding the parameters to the command if needed
                if (param != null)
                {
                    cmd.Parameters.AddRange(param);
                }

                return cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                return 0;
            }
        }

    }

    //ADD ANOTHER METHOD IF YOU NEED AN ID RETURNED

     public object ExecuteScalar(string strproc, SqlParameter[] param)
        {
            
            //Need to check if the connection has been established or not
            using (conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = strproc;
                if (param != null)
                {
                    cmd.Parameters.AddRange(param);
                }
                return cmd.ExecuteScalar();
            }
        }


    public DataTable ExecuteTable(string strproc, SqlParameter[] param, string Dbname)
    {
        try
        {
            using (conn = new SqlConnection(ConnectionString));
            {
                conn.Open();
                cmd = new SqlCommand();
//sets or returns the number of seconds to wait while attempting to execute a command, before canceling the attempt and generate an error. 
                cmd.CommandTimeout = 900;
                ds = new DataSet();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = strproc;
                if(param != null) {
                    cmd.Parameters.AddRange(param);
                }
                adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                DataTable dt = new DataTable();
                dt = null;
                dt = ds.Tables[0];
                return dt;
            }
        }
        catch(Exception e){
            return null;
        }
    }


}
