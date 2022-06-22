using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Rodrigofy {
  public partial class ConfirmaciónDeCompra : System.Web.UI.Page {
    private DataSet DsCanciones = new DataSet(), DsBúsqueda = new DataSet(), DsCarrito = new DataSet();
    private DataSet DsFolio = new DataSet(), DsId = new DataSet();
    private DataRow fila, fila2;
    private GestorBD.GestorBD GestorBD;       //Para manejar la BD.
    private Comunes objComún = new Comunes();     //Para manejar las rutinas de uso común.
    private String cadSql, idUsu, fecha;
    private const int OK = 1;
    protected void Page_Load (object sender , EventArgs e) {
      GestorBD = (GestorBD.GestorBD)Session ["GestorBD"];
      idUsu = Session ["IdCliente"].ToString();
      string nombre, nomCan;
      int total, n, IdCanción;
      //Realiza la búsqueda.
      cadSql = "select nombre from usuarios where idUsuario='" + idUsu + "'";
      GestorBD.consBD(cadSql , DsBúsqueda , "Temp");
      fila = DsBúsqueda.Tables ["Temp"].Rows [0];
      nombre = (string)fila ["nombre"];
      cadSql = "select c.nombre, c.precio from Carrito c where c.idUsuario='" + idUsu + "'";
      GestorBD.consBD(cadSql , DsCarrito , "Carro");
      //Si la busqueda es exitosa.
      if (DsCarrito.Tables ["Carro"].Rows.Count != 0) {

        GrdResumen.DataSource = DsCarrito.Tables ["Carro"];  //Muestra resultados.
        GrdResumen.DataBind();
        lblCarro.Text = "Resumen de compra de " + nombre + " ¡Gracias por tu compra!";
        total = ( DsCarrito.Tables ["Carro"].Rows.Count ) * 12;
        GrdResumen.Caption = "Total de compra es de: $" + total;
        } else { //Caso contrario
        GrdResumen.Visible = false;
        lblCarro.Text = "Tu carrito está vacío";
        }
      //Selecciono la fecha y la convierto
      fecha = Calendar1.SelectedDate.ToShortDateString();
      n = DsCarrito.Tables ["Carro"].Rows.Count;
      for (int i = 0 ; i < n ; i++) { //Ciclo para comprar canciones del carro
        fila = DsCarrito.Tables ["Carro"].Rows [i];
        nomCan = (string)fila ["Nombre"];
        cadSql = "select c.idCanción from Canciones c where c.Nombre = '"+nomCan+"'";
        GestorBD.consBD(cadSql , DsId , "Temp");
        fila2 = DsId.Tables ["Temp"].Rows [0];
        IdCanción = (int)fila2 ["IdCanción"];
        cadSql = "insert into Compras values ('" + idUsu + "'," + IdCanción + ",'" + fecha + "'," + 12.0 + ")";
        if (GestorBD.altaBD(cadSql) == OK) { // Si la alta tiene éxito.
          LblStatus.Text = "Status: Compras realizadas correctamente, puede borrar la canción del carrito";
          } else { //Caso contraio
          LblStatus.Text = "Status: hubo errores";
          }
        }
      }
    }
  }