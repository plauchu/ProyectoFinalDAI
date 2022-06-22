using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Rodrigofy {
  public partial class BúsquedaCompra : System.Web.UI.Page {
    private DataSet DsCanciones = new DataSet(), DsBúsqueda = new DataSet(), DsCarrito = new DataSet();
    private DataSet DsFolio = new DataSet();
    private DataRow fila;
    private GestorBD.GestorBD GestorBD;       //Para manejar la BD.
    private Comunes objComún = new Comunes();     //Para manejar las rutinas de uso común.
    private String cadSql, idUsu;
    private const int OK = 1;

    protected void Page_Load (object sender , EventArgs e) {
      GestorBD = (GestorBD.GestorBD)Session ["GestorBD"];
      idUsu = Session ["IdCliente"].ToString();
      }

    //Ejecuta la búsqueda.
    protected void btnBuscar_Click (object sender , EventArgs e) {
      //Recupera objetos de Session.
      GestorBD = (GestorBD.GestorBD)Session ["GestorBD"];
      idUsu = Session ["IdCliente"].ToString();

      //Realiza la búsqueda
      //Si solo escribió el nombre del artísta
      if (txtNomCan.Text == "") {
        cadSql = "select a.nombre, c.nombre, precio from Artísta a, Canciones c where a.nombre = '" + txtNomArt.Text + "' and a.idArtísta = c.idArtísta";
        } else {
        //Si solo escribió el nombre de la canción
        if (txtNomArt.Text == "") {
          cadSql = "select a.nombre, c.nombre, precio from Artísta a, Canciones c where c.nombre = '" + txtNomCan.Text + "' and a.idArtísta = c.idArtísta";
          } else {
          //Si no escribió nada
          if (txtNomCan.Text == "" && txtNomArt.Text == "") {
            lblStatus.Text = "Status: Búsqueda no exitosa";
            GrdBúsqueda.Visible = false;
            //Si escribió en los dos
            } else {
            cadSql = "select a.nombre, c.nombre, precio from Artísta a, Canciones c where a.nombre = '" + txtNomArt.Text + "' and c.nombre = '" + txtNomCan.Text + "' and a.idArtísta = c.idArtísta";
            }
          }
        }
      //Realiza la consulta
      GestorBD.consBD(cadSql , DsBúsqueda , "Bus");
      //Verifica que hayan resultados
      if (DsBúsqueda.Tables ["Bus"].Rows.Count != 0) {
        GrdBúsqueda.DataSource = DsBúsqueda.Tables ["Bus"];  //Muestra resultados.
        GrdBúsqueda.DataBind();
        GrdBúsqueda.HeaderRow.Cells [1].Text = "Canción:";
        GrdBúsqueda.HeaderRow.Cells [0].Text = "Artísta:";
        lblStatus.Text = "Status: Búsqueda exitosa";
        lblRes.Visible = true;
        GrdBúsqueda.Visible = true;
        } else { //Caso contrario.
        lblStatus.Text = "Status: Búsqueda no exitosa";
        GrdBúsqueda.Visible = false;
        }
      }

    //Para visulizar o actualizar el carrito.
    protected void btnCarrito_Click (object sender , EventArgs e) {
      //Recupera objetos de Session.
      GestorBD = (GestorBD.GestorBD)Session ["GestorBD"];
      idUsu = Session ["IdCliente"].ToString();
      int total;
      //Realiza la consulta.
      cadSql = "select * from Carrito c where c.idUsuario='" + idUsu + "'";
      GestorBD.consBD(cadSql , DsCarrito , "Carro");
      //Si la busqueda es exitosa.
      if (DsCarrito.Tables ["Carro"].Rows.Count != 0) {

        GrdCanciones.DataSource = DsCarrito.Tables ["Carro"];  //Muestra resultados.
        GrdCanciones.DataBind();
        lblCarrito.Visible = true;
        lblCarrito.Text = "Tu carrito contiene lo siguiente:";
        total = (DsCarrito.Tables ["Carro"].Rows.Count) * 12;
        GrdCanciones.Caption = "Total de compra es de: $"+total;
        GrdCanciones.Visible = true;
        } else { //Caso contrario
        lblCarrito.Visible = true;
        GrdCanciones.Visible = false;
        lblCarrito.Text = "Tu carrito está vacío";
        }
      }

    //Intenta agregar al carrito.
    protected void btnAgregar_Click (object sender , EventArgs e) {
      //Recupera objetos de Session.
      GestorBD = (GestorBD.GestorBD)Session ["GestorBD"];
      idUsu = Session ["IdCliente"].ToString();
      int Folio;
      decimal precio;
      string canción;
      DataRow fila;
      //Si hay algo que intentar agregar.
      if (txtNomCan.Text != "") {

        //Genera el nuevo folio.
        cadSql = "select top 1 Folio from Carrito order by Folio desc";    //Verifica si hay pagos registrados.
        GestorBD.consBD(cadSql , DsFolio , "Fol");
        if (DsFolio.Tables ["Fol"].Rows.Count != 0) {
          fila = DsFolio.Tables ["Fol"].Rows [0];   //Si sí, recupera el máximo folio.
          Folio = (int)fila ["Folio"] + 1;              //Genera el nuevo pago.
          } else
          Folio = 1;       //Si no, crea el primer folio.
        //Realiza las búsquedas
        cadSql="select c.nombre, precio from Canciones c where c.nombre ='"+txtNomCan.Text+"'";
        GestorBD.consBD(cadSql , DsCanciones , "Canc");
        //Si la busqueda es exitosa.
        if (DsCanciones.Tables ["Canc"].Rows.Count != 0) {
          fila = DsCanciones.Tables ["Canc"].Rows [0];
          canción = (string)fila ["Nombre"];
          precio = Convert.ToDecimal(fila ["Precio"]);
          cadSql = "insert into Carrito values ('" + idUsu + "'," + Folio + ",'" + canción + "'," + precio + ")";
          if (GestorBD.altaBD(cadSql) == OK) { //Si la alta es exitosa.
            lblCarrito.Visible = true;
            lblCarrito.Text = "Alta éxitosa, actualiza el carrito";
            } else { //Caso contrario.
            lblCarrito.Visible = true;
            lblCarrito.Text = "Algo salió mal";
            }
          } else {
          lblCarrito.Visible = true;
          lblCarrito.Text = "Canción no existente";
          }
       
        } else {
        lblCarrito.Visible = true;
        lblCarrito.Text = "Campo de canción vacío";
        }
      }
    //Activa los controles que corresponda.
    public void desactivaControles () {
      GrdCanciones.Enabled = true;
      btnBuscar.Enabled = false;
      btnAgregar.Enabled = false;
      btnBorrar.Enabled = false;
      btnCarrito.Enabled = false;
      txtNomArt.Enabled = false;
      txtNomCan.Enabled = false;
      }

    //Cierra la sesión.
    protected void BtnCerrar_Click (object sender , EventArgs e) {
      Environment.Exit(0);
      }

    //Activa los controles que corresponda.
    public void activaControles () {
      GrdCanciones.Enabled = false;
      btnAgregar.Enabled = true;
      btnBuscar.Enabled = true;
      btnBorrar.Enabled = true;
      btnCarrito.Enabled = true;
      txtNomArt.Enabled = true;
      txtNomCan.Enabled = true;
      }
    //Para borrar del carrito.
    protected void btnBorrar_Click (object sender , EventArgs e) {
      //Habilita/deshabilita los controles asociados a la operación.
      desactivaControles();
      lblCarrito.Visible = true;

      //Indica la operación actual.
      lblCarrito.Text = "Baja en proceso";
      }

    //Operaciones al eliminar del carrito.
    protected void GrdAvalan_RowDeleting (object sender , GridViewDeleteEventArgs e) {
      int índiceFila;
      int índiceFolio = 2, índiceUsuario = 1;    //NOTA: Estos valores deben ajustarse
                                                //si se agregan más columnas a GrdAvalan.
      GridViewRow g;

      índiceFila = e.RowIndex; //índice de la fila a que se dió click.
      g = GrdCanciones.Rows [índiceFila]; //Obtiene el contenido de la fila a borrar.

      //Construye y ejecuta la cadena de borrado.
      cadSql = "delete from Carrito where IdUsuario ='" + g.Cells [índiceUsuario].Text + "' and folio =" + g.Cells [índiceFolio].Text;
      if (GestorBD.bajaBD(cadSql) == OK) { //Si la baja fue exitosa.
        activaControles();
        lblCarrito.Visible = true;
        lblCarrito.Text = "Borrado exitoso, actualiza el carrito";
        } else { //Caso contrario.
        activaControles();
        lblCarrito.Visible = true;
        lblCarrito.Text = "Algo salió mal mientras se borraba";
        }
      }
    }
  }