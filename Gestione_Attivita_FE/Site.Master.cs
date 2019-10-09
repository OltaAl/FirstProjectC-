using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gestione_Attivita_FE
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string nome_cognome = Environment.UserName;
            nome_cognome = nome_cognome.Replace(".", " ");
            //Label1.Text = nome_cognome.ToUpper();
        }
        
    }
}