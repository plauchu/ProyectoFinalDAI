using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Rodrigofy {
  public partial class Default : System.Web.UI.Page {
    //Variables de clase.
    GestorBD.GestorBD GestorBD;
    DataSet DsGeneral = new DataSet();
    string cadSql;
    //Acciones iniciales.
    protected void Page_Load (object sender , EventArgs e) {
      //Nota:IsPostBack es una propiedad de cada página. Tiene valor False 
      //La 1a. vez que se carga la página. Tiene valor True las demás veces.
      if (!IsPostBack) {

        GestorBD = new GestorBD.GestorBD("SQLNCLI11" , "DESKTOP-77NC78G\\SQLEXPRESS" , "sa" , "adminadmin" , "Rodrigofy");
        Session ["GestorBD"] = GestorBD;
        }
        
      }
    //Verifica que usuario y contraseña coincidan
    protected void Login1_Authenticate1 (object sender , AuthenticateEventArgs e) {
      string cadSql;

      cadSql = "select * from Usuarios u where u.IdUsuario= '" + Login1.UserName + "' and contraseña = '" + Login1.Password + "'";
      GestorBD = (GestorBD.GestorBD)Session ["GestorBD"];
      GestorBD.consBD(cadSql , DsGeneral , "Temporal");

      //Valida que usuario y contraseña coincidan.
      if (DsGeneral.Tables ["Temporal"].Rows.Count != 0) {
        //Transfiere el control a la siguiente página.
        Session ["IdCliente"] = Login1.UserName;
        Server.Transfer("PáginaDeInicio.aspx");
        }
      }
    }
  }