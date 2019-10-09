using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gestione_Attivita_FE
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public string filterVar;
        protected void Page_Load(object sender, EventArgs e)
        {

            string attivita = Request.QueryString["attivita"];
            string dataDa = Request.QueryString["dataDa"];
            string dataA = Request.QueryString["dataA"];
            if (attivita != "")
            {
                filterVar = " and Attivita = '" + attivita + "' ";
            }
            //Populate Gridview
            string mainconn = ConfigurationManager.ConnectionStrings["GestioneAttivitaConn"].ConnectionString;
            string query = "select Date, Attivita, DATEADD(ms, SUM(DATEDIFF(ms, '00:00:00.000', oreLav)), '00:00:00.000') as 'Totale' from CambiamentiAttivita where date >='" + dataDa + "' and date <='" + dataA + "' " + filterVar + " group by date, Attivita order by date ASC";
            //Response.Write(query);
            SqlDataAdapter Adp = new SqlDataAdapter(query, mainconn);
            DataTable Dt = new DataTable();
            Adp.Fill(Dt);
            totalPerAttivita.DataSource = Dt;
            totalPerAttivita.DataBind();
            //End Populate Gridview

        }
    }
}