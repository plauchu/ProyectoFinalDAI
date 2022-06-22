using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Rodrigofy {
  public partial class HistóricoDeCompras : System.Web.UI.Page {
    //Atributos de la clase.
    private DataSet DSCanciones = new DataSet();
    private DataRow fila;
    private GestorBD.GestorBD GestorBD;       //Para manejar la BD.
    private Comunes objComún = new Comunes();     //Para manejar las rutinas de uso común.
    private String cadSql, idUsu, fechaIni, fechaFin;

    //Cierra la sesión.
    protected void BtnCerrar_Click (object sender , EventArgs e) {
      Environment.Exit(0);
      }

    //Ejecuta la conuslta.
    protected void Button1_Click (object sender , EventArgs e) {
      //Recuperamos los datos de la BD
      GestorBD = (GestorBD.GestorBD)Session ["GestorBD"];
      idUsu = Session ["IdCliente"].ToString();

      //Covierto las fechas.
      fechaIni = Calendar1.SelectedDate.ToShortDateString();
      fechaFin = Calendar2.SelectedDate.ToShortDateString();

      //Realizamos la búsqueda
      cadSql = "select c.Nombre from Usuarios u, Compras co, Canciones c where u.idUsuario ='" + idUsu + "' and u.idUsuario = co.idUsuario and co.idCanción = c.idCanción and co.fecha between '" + fechaIni + "' and '" + fechaFin + "'";
      GestorBD.consBD(cadSql , DSCanciones , "Temporal");
      //Si la busqueda es exitosa.
      if (DSCanciones.Tables ["Temporal"].Rows.Count != 0) {

        GrdCompras.DataSource = DSCanciones.Tables ["Temporal"];  //Muestra resultados.
        GrdCompras.DataBind();
        lblCompras.Text = "Realizaste las siguientes compras en ese periodo";
        GrdCompras.Visible = true;
        } else { //Caso contrario.
        lblCompras.Text = "No realizaste compras en ese periodo";
        GrdCompras.Visible = false;
        }
      }

    protected void Page_Load (object sender , EventArgs e) {
      //Recuperamos los datos de la BD
      GestorBD = (GestorBD.GestorBD)Session ["GestorBD"];
      idUsu = Session ["IdCliente"].ToString();
      
      
      }
    }
  }