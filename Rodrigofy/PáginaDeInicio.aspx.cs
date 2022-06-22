using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Rodrigofy {
  public partial class PáginaDeInicio : System.Web.UI.Page {
    //Atributos de la clase.
    private DataSet DSNombre = new DataSet();
    private DataSet DSTop = new DataSet();
    private DataRow fila;
    private GestorBD.GestorBD GestorBD;       //Para manejar la BD.
    private Comunes objComún = new Comunes();     //Para manejar las rutinas de uso común.
    private String cadSql, idUsu;

    //Cierra la sesión.
    protected void Button1_Click (object sender , EventArgs e) {
      Environment.Exit(0);
      }

    protected void Page_Load (object sender , EventArgs e) {
      //Recuperamos los datos de la BD
      GestorBD = (GestorBD.GestorBD)Session ["GestorBD"];
      idUsu = Session ["IdCliente"].ToString();
      
      //Búsqueda para la bienvenida.
      cadSql = "select u.Nombre from Usuarios u where u.idUsuario='" + idUsu + "'";
      GestorBD.consBD(cadSql , DSNombre , "Nom");
      fila = DSNombre.Tables ["Nom"].Rows [0];
      LblBienvenido.Text = "Bienvenido "+fila["Nombre"].ToString();

      //Muestra los avales del cliente.
      cadSql = "select top 3 (c.idCanción), ca.Nombre from Compras c, Canciones ca where c.idcanción = ca.idcanción";
      GestorBD.consBD(cadSql , DSTop , "Top");
      GrdTopCanciones.DataSource = DSTop.Tables ["Top"];  //Muestra resultados.
      GrdTopCanciones.DataBind();
      }
    }
  }