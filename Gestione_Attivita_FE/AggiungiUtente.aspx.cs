using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gestione_Attivita_FE
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            aggiuntoDa.Value = "Aggiunto/Mod Da '" + Environment.UserName + "' ";
        }

        protected void aggiungi_utente_Click(object sender, EventArgs e)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["GestioneAttivitaConn"].ConnectionString;
            string utente = nome.Value + "." + cognome.Value;

            //Check if user exists
            string queryCheck = "SELECT * FROM Utenti where Utente='" + utente + "' ";
            SqlConnection conn = new SqlConnection(mainconn);
            
                SqlCommand command = new SqlCommand(queryCheck, conn);
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                //reader.Read();
                if (reader.Read()) {

                    Response.Write("<script>alert('Questo utente " + reader["Utente"] + " e stato gia aggiunto prima come " + reader["security"]+" !')</script>");

                } else {

                    //Aggiungi un nuovo user
                    SqlConnection connection = new SqlConnection(mainconn);
                    string queryInsert = "Insert into Utenti (Utente, Security, Nome, Cognome, creato_da) Values (@utente, @security, @Nome, @Cognome, @creato_da)";
                    SqlConnection sqlConIns = new SqlConnection(mainconn);
                    SqlCommand sqlcomm = new SqlCommand(queryInsert, sqlConIns);

                    sqlcomm.Parameters.AddWithValue("@utente", utente.ToLower());
                    sqlcomm.Parameters.AddWithValue("@Security", livelloDiAccesso.Text);
                    sqlcomm.Parameters.AddWithValue("@Nome", nome.Value);
                    sqlcomm.Parameters.AddWithValue("@Cognome", cognome.Value);
                    sqlcomm.Parameters.AddWithValue("@creato_da", Environment.UserName);

                    sqlConIns.Open();
                    sqlcomm.ExecuteNonQuery();
                    sqlConIns.Close();

                    Response.Write("<script>alert('Hai registrato un nuovo utente!')</script>");
                    Response.Redirect("AggiungiUtente.aspx");

                }
                //End Check if user exists
                    
        }

        protected void modifica_utente_Click(object sender, EventArgs e)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["GestioneAttivitaConn"].ConnectionString;
            SqlConnection connection = new SqlConnection(mainconn);

            string utenteVal = nome.Value + "." + cognome.Value;
            //Check if user entered exist
            string queryCheck = "select ID, Utente from Utenti where Utente = '" + utenteVal.ToLower() +"' ";
            
            using (SqlConnection sqlConIns = new SqlConnection(mainconn))
            {

                SqlCommand command = new SqlCommand(queryCheck, sqlConIns);
                sqlConIns.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();

                

                if (reader.HasRows ) {

                    string nomeUtente = reader["Utente"].ToString();
                    //Modifica User
                    string queryUpdate = "update Utenti Set Security = '" + livelloDiAccesso.Text + "' where ID = '" + reader["ID"].ToString() + "' ";
                    sqlConIns.Close();
                    SqlConnection sqlConUpd = new SqlConnection(mainconn);
                    SqlCommand sqlUpdateComm = new SqlCommand(queryUpdate, sqlConUpd);
                    sqlConUpd.Open();

                    sqlUpdateComm.ExecuteNonQuery();
                    Response.Write("<script>alert('Utente " + nomeUtente + " e stato modificato !')</script>");
                    sqlConUpd.Close();
                    nome.Value = "";
                    cognome.Value = "";
                    livelloDiAccesso.Text = "";

                } else {

                    Response.Write("<script>alert('Utente " + utenteVal + " non esiste. Controlla Nome Cognome!')</script>");
                    //nome.Value = "";
                    //cognome.Value = "";
                    //livelloDiAccesso.Text = "";

                }

                //string nomeUtente = reader["Utente"].ToString();

                //if (reader["ID"].ToString() == "") {

                //    Response.Write("<script>alert('Utente non esiste. Controlla Nome Cognome!')</script>");

                //} else {

                //    //Modifica User
                //    string queryUpdate = "update Utenti Set Security = '" + livelloDiAccesso.Text + "' where ID = '" + reader["ID"].ToString() + "' ";
                //    sqlConIns.Close();
                //    SqlConnection sqlConUpd = new SqlConnection(mainconn);
                //    SqlCommand sqlUpdateComm = new SqlCommand(queryUpdate, sqlConUpd);
                //    sqlConUpd.Open();

                //    sqlUpdateComm.ExecuteNonQuery();
                //    Response.Write("<script>alert('Utente " + nomeUtente + " e stato modificato !')</script>");
                //    sqlConUpd.Close();
                //    nome.Value = "";
                //    cognome.Value = "";
                //    livelloDiAccesso.Text= "";

                //}

            }

        }

        protected void searchForUser_TextChanged(object sender, EventArgs e)
        {
            if (searchForUser.Text != "")
            {
                string mainconn = ConfigurationManager.ConnectionStrings["GestioneAttivitaConn"].ConnectionString;

                string utente = nome.Value + "." + cognome.Value;
                string[] nome_utente = searchForUser.Text.TrimStart(' ').Split(' ');
                //Check if user exists
                string queryCheck = "SELECT * FROM Utenti where nome='" + nome_utente[0] + "' and cognome='" + nome_utente[1] + "' ";
                SqlConnection conn = new SqlConnection(mainconn);

                SqlCommand command = new SqlCommand(queryCheck, conn);
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    checkUser.Text = "L'utente " + reader["Utente"] + " e stato gia aggiunto prima come " + reader["security"] + " ! ";
                }
                else
                {
                    checkUser.Text = "Questo utente non e stato gia aggiunto prima!";
                }
            }
            else
            {
                checkUser.Text = "";
            }

        }
    }
}