using BankSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace BankSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(login loginModel)
        {
            Session["loginSession"] = null;
            return View();
        }


        public ActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection fc)
        {
            login l = new login();
            l.username = fc["username"];
            l.password = fc["password"];

            if (Session["loginSession"] == null)
            {
                Session["loginSession"] = l.username;
            }

            SqlConnection con = null;
            SqlDataReader dr = null;
            try
            {
                string connectionString = GetConnectionString();

                con = new SqlConnection(connectionString);

                con.Open();
                string str = $"select * from Customer where Username = " + $" '{l.username}' and Password = '{l.password}'";
                SqlCommand cmd = new SqlCommand(str, con);

                dr = cmd.ExecuteReader();

                if (ModelState.IsValid)
                {
                    if (dr.HasRows)
                    {
                        TempData["message"] = "Login Successful, Welcome!";
                        TempData.Keep("message");
                        return RedirectToAction("BankPage", l);
                    }
                    else
                    {
                        ViewBag.attempt = "Login Failed. Please try again or if you are new then please Register";
                        return View("Login", l);
                    }
                }
                else
                {
                    ViewBag.Message = "Incorrect Username or Passowrd";
                }
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "An error occurred: " + ex.Message;
                return View("Login");
            }

            finally
            {
                // close reader
                if (dr != null)
                {
                    dr.Close();
                }
                // close connection
                if (con != null)
                {
                    con.Close();
                }
            }

        }
        protected string GetConnectionString()
        {

            string connString = "Server=tcp:banksoftwarengineering.database.windows.net,1433;Initial Catalog=BankSystem;Persist Security Info=False;User ID=Joni;Password=Soft_En20;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;\r\n";

            return connString;
        }
        public ActionResult Register()
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            SqlDataAdapter _da = new SqlDataAdapter("Select * From Branch", con);
            DataTable _dt = new DataTable();
            _da.Fill(_dt);
            ViewBag.BranchList = ToSelectList(_dt, "Id", "Name");

            return View();
        }



        [HttpPost]
        public ActionResult Register(login l)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.attempt = "Please fill out all the required fields";
                return View();
            }

            try
            {
                return RedirectToAction("BankPage");
            }
            catch (Exception)
            {
                ViewBag.attempt = "An error occurred while processing your request";
                return View("Register");
            }
        }

        private dynamic ToSelectList(DataTable dt, string v1, string v2)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(new SelectListItem()
                    {
                        Text = row[v2].ToString(),
                        Value = row[v1].ToString()
                    });
                }
                return new SelectList(list, "Value", "Text");
            }
            catch
            {
                throw new NotImplementedException();
            }

        }

        public ActionResult BankPage(login LogIN)
        {

            try
            {
                if (Session["loginSession"] == null)
                {
                    Session["loginSession"] = LogIN.username;
                }

                string constring = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlConnection con = new SqlConnection(constring);
                con.Open();


                if (LogIN.Name != null)
                {
                    SqlCommand Cmd = new SqlCommand("INSERT_INTO_BANK_TABLES", con);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@name", LogIN.Name);
                    Cmd.Parameters.AddWithValue("@dob", LogIN.DOB);
                    Cmd.Parameters.AddWithValue("@phone", LogIN.Phone);
                    Cmd.Parameters.AddWithValue("@email", LogIN.Email);
                    Cmd.Parameters.AddWithValue("@address", LogIN.Address);
                    Cmd.Parameters.AddWithValue("@username", LogIN.username);
                    Cmd.Parameters.AddWithValue("@password", LogIN.password);
                    Cmd.Parameters.AddWithValue("@pin", LogIN.PIN);
                    Cmd.Parameters.AddWithValue("@accType", LogIN.AccountType);
                    Cmd.Parameters.AddWithValue("@branchId", LogIN.Branch);

                    Cmd.ExecuteNonQuery();

                    TempData["message"] = "Registration Successful";
                    TempData.Keep("message");
                }

                //Contact
                SqlDataAdapter _da = new SqlDataAdapter("Select B.Name, B.Address, B.CUSIP, B.Phone From Branch B Inner Join Account A on B.Id = A.BranchId Inner Join Customer C on A.CustId = C.Id  Where C.Username = " + $" '{Session["loginSession"]}'", con);
                DataTable dt = new DataTable();
                _da.Fill(dt);

                List<Branches> br = new List<Branches>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Branches brs = new Branches();
                    brs.Name = dt.Rows[i]["Name"].ToString();
                    brs.Address = dt.Rows[i]["Address"].ToString();
                    brs.CUSIP = dt.Rows[i]["CUSIP"].ToString();
                    brs.Contact = dt.Rows[i]["Phone"].ToString();
                    br.Add(brs);
                }
                LogIN.Branchs = br;

                con.Close();

                return View(LogIN);
            }
            catch (Exception)
            {
                throw;
            }

        }


        public ActionResult Statement()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Statement(Statement statement)
        {
            statement.StatementList = tranrecord(statement.StartDate, statement.EndDate);

            return View(statement);
        }

        public List<Statemomentum> tranrecord(DateTime startDate, DateTime endDate)
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            con.Open();

            SqlDataAdapter _da = new SqlDataAdapter("Select T.TranDate, T.TranType, T.Amount From Transactions T Inner Join Account A On T.AccId = A.Id Inner Join Customer C On A.CustId = C.Id Where C.Username = " + $" '{Session["loginSession"]}'", con);
            DataTable dt = new DataTable();
            _da.Fill(dt);

            List<Statemomentum> st = new List<Statemomentum>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Statemomentum s = new Statemomentum();
                s.TranDate = Convert.ToDateTime(dt.Rows[i]["TranDate"]);
                s.TranType = dt.Rows[i]["TranType"].ToString();
                s.Amount = Convert.ToInt32(dt.Rows[i]["Amount"]);
                st.Add(s);
            }
            con.Close();

            return st;
        }

        public ActionResult Balance()
        {
            login l = new login();
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            SqlDataAdapter _da = new SqlDataAdapter("Select A.Balance From Account A Inner Join Customer C On A.CustId = C.Id Where C.Username = " + $" '{Session["loginSession"]}'", con);
            DataTable dt = new DataTable();
            _da.Fill(dt);

            string bal = dt.Rows[0]["Balance"].ToString();

            TempData["balance"] = bal;
            TempData.Keep("balance");

            return RedirectToAction("BankPage");
        }

        public ActionResult Transfer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Transfer(string AccountNumber, string CUSIP, string AccountHolder, float Amount)
        {
            string constring = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            con.Open();

            //Check Valid Account Details
            SqlDataAdapter _da = new SqlDataAdapter("Select * From Customer C Inner Join Account A on C.Id = A.CustId Inner Join Branch B on A.BranchId = B.Id  Where A.AccNumber = " + $" '{AccountNumber}' and B.CUSIP = '{CUSIP}' and C.Name = '{AccountHolder}'", con);
            DataSet ds = new DataSet();
            _da.Fill(ds);

            if (ds != null && ds.Tables[0].Rows.Count != 0)
            {
                //Balance check
                SqlCommand oCmd = new SqlCommand("Select Balance from Account A Inner Join Customer C on C.Id = A.CustId Where C.Username = @username", con);
                oCmd.Parameters.AddWithValue("@username", Session["loginSession"]);
                SqlDataReader dr = oCmd.ExecuteReader();
                if (dr.Read())
                {
                    int bal = Convert.ToInt32(dr["Balance"]);

                    if (bal >= Amount)
                    {
                        dr.Close();

                        SqlCommand Cmd = new SqlCommand("UPDATE_TRANSACTION", con);
                        Cmd.CommandType = CommandType.StoredProcedure;
                        Cmd.Parameters.AddWithValue("@Username", Session["loginSession"]);
                        Cmd.Parameters.AddWithValue("@AccNumber", AccountNumber);
                        Cmd.Parameters.AddWithValue("@CUSIP", CUSIP);
                        Cmd.Parameters.AddWithValue("@AccHolder", AccountHolder);
                        Cmd.Parameters.AddWithValue("@Amount", Amount);
                        Cmd.Parameters.Add("@text", SqlDbType.Char, 500);
                        Cmd.Parameters["@text"].Direction = ParameterDirection.Output;

                        Cmd.ExecuteNonQuery();
                        //ViewBag.text = (string)Cmd.Parameters["@text"].Value; //first check whether it is null or not then use this line

                        if (ViewBag.text == null)
                        {
                            SqlCommand cmds = new SqlCommand("ADD_TRANSACTION_RECORD", con);
                            cmds.CommandType = CommandType.StoredProcedure;
                            cmds.Parameters.AddWithValue("@Username", Session["loginSession"]);
                            cmds.Parameters.AddWithValue("@AccNumber", AccountNumber);
                            cmds.Parameters.AddWithValue("@Amount", Amount);

                            cmds.ExecuteNonQuery();

                            ViewBag.text = "Transaction Successful.";
                        }
                    }
                    else
                    {
                        ViewBag.text = "You don't have enough Balance !";
                    }
                }

            }
            else
            {
                ViewBag.text = "Please Check User Credentials !!!";
            }

            con.Close();

            return View();
        }

    }
}
