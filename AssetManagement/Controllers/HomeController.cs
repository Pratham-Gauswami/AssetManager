using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AssetManagement.Models;
using System.Data.SqlClient;

namespace AssetManagement.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult DatabaseConnectionPrivate(){
        return View();
    }

    
    private SqlCommand cmd = null;
    private SqlConnection conn = null;

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

/*  DON'T NEED IT IF CONNECTING THE DATABSE STRING DIRECTLY.

        public bool ReadDBFile()
        {

            string connectionStr = "none";
            string File_Name = System.AppDomain.CurrentDomain.BaseDirectory + "\\dbEngine.pdb";
            // string File_Name = "wwwroot\\Connection\\dbEngine.pdb";
            try

            {
                System.IO.StreamReader objReader = new System.IO.StreamReader(File_Name);
                int counter;
                string dbname = "", username = "", password = "", servAdd = "";
                counter = 1;
                do
                {
                    if (counter == 1)
                    {
                        dbname = objReader.ReadLine();
                    }
                    else if (counter == 2)
                    {
                        username = objReader.ReadLine();
                    }
                    else if (counter == 3)
                    {
                        password = objReader.ReadLine();
                    }
                    else if (counter == 4)
                    {
                        servAdd = objReader.ReadLine();
                    }
                    counter = counter + 1;
                } while (objReader.Peek() != -1);
                objReader.ReadToEnd();
                objReader.Dispose();
                objReader.Close();
                objReader.DiscardBufferedData();
                string Dbname = "";
                string Username = "";
                string Password = "";
                string ServAdd = "";
                Dbname = EncryptString(10, dbname);
                Username = EncryptString(10, username);
                Password = EncryptString(10, password);
                ServAdd = EncryptString(10, servAdd);
                //dbname = HttpContext.Session.GetString("DataBaseName");
                //connectionStr = "Data Source=" + ServAdd + ";Initial Catalog=" + Dbname + ";User ID=" + Username + ";Pwd=" + Password + "";
                //conn = null;
                //conn = new SqlConnection(connectionStr);
                //conn.Open();
                //Company obj = new Company();
                //obj.CmdName = "Select";
                //DataSet ds = new DataSet();
                //ds = obj.SelectCompany(dbname);
                return true;
            }
            catch (System.Data.SqlClient.SqlException sqlEx)
            {
                return false;
                //return RedirectToAction("DatabaseConnection", "Home");
                //throw sqlEx;
            }
            catch (System.IO.IOException iEx)
            {
                return false;
                // return RedirectToAction("DatabaseConnection", "Home");
                throw iEx;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
*/