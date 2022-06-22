using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Rodrigofy {
  public partial class Pagos : System.Web.UI.Page {
    private DataSet DsCanciones = new DataSet(), DsBúsqueda = new DataSet(), DsCarrito = new DataSet();
    private DataSet DsFolio = new DataSet();
    private DataRow fila;
    private GestorBD.GestorBD GestorBD;       //Para manejar la BD.
    private Comunes objComún = new Comunes();     //Para manejar las rutinas de uso común.
    private String cadSql, idUsu;
    private const int OK = 1;
    protected void Page_Load (object sender , EventArgs e) {
      //Recupera los datos.
      GestorBD = (GestorBD.GestorBD)Session ["GestorBD"];
      idUsu = Session ["IdCliente"].ToString();
      int total;
      //Realiza la búsqueda.
      cadSql = "select * from Carrito c where c.idUsuario='" + idUsu + "'";
      GestorBD.consBD(cadSql , DsCarrito , "Carro");
      //Si la busqueda es exitosa.
      if (DsCarrito.Tables ["Carro"].Rows.Count != 0) {

        GrdCarro.DataSource = DsCarrito.Tables ["Carro"];  //Muestra resultados.
        GrdCarro.DataBind();
        LblCarro.Text = "Tu carrito contiene lo siguiente:";
        total = ( DsCarrito.Tables ["Carro"].Rows.Count ) * 12;
        GrdCarro.Caption = "Total de compra es de: $" + total;
        } else { //Caso contrario
        GrdCarro.Visible = false;
        LblCarro.Text = "Tu carrito está vacío";
        }

      }

    protected void CheckBox1_CheckedChanged (object sender , EventArgs e) {

      }

    //Revisa que las casillas estén marcadas.
    protected void BtnConfirmar_Click (object sender , EventArgs e) {
      if (CheckBox1.Checked == true && CheckBox2.Checked == true) {
        BtnPagar.Visible = true;
        lblStatus.Text = "Status: Campos confirmados, puede pagar";
        } else {// Caso contrario
        lblStatus.Text = "Status: Faltan campos por confirmar";
        }
      }
    }
  }