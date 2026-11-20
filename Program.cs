
using System;
using System.Drawing;
using System.Windows.Forms;

namespace EXAMEN_CAFETERIA_KERENG
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmPedidos());
        }
    }

    public class frmPedidos : Form
    {
        

        TextBox txtCliente;
        DateTimePicker dtpFecha;
        CheckBox chkFrecuente;

        TextBox txtProducto;
        TextBox txtPrecio;
        NumericUpDown nudCantidad;

        RadioButton rbtNormal;
        RadioButton rbtGrande;
        CheckBox chkPorcionExtra;

        RadioButton rbtLocal;
        RadioButton rbtLlevar;

        Label lblEncabezado;
        ListBox lstPedido;

        Label lblSubtotal;
        Label lblDescuento;
        Label lblEmpaque;
        Label lblItbis;
        Label lblTotal;

        Button btnAgregar;
        Button btnCalcular;
        Button btnLimpiar;
        Button btnSalir;

        decimal subtotal = 0;

     

        public frmPedidos()
        {
            CrearFormulario();
        }

       

        void CrearFormulario()
        {
            this.Text = "Cafeteria El Buen Sabor - Pedidos";
            this.Size = new Size(900, 650);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

          

            Label lblCliente = new Label();
            lblCliente.Text = "Cliente:";
            lblCliente.Location = new Point(20, 20);
            lblCliente.AutoSize = true;
            Controls.Add(lblCliente);

            txtCliente = new TextBox();
            txtCliente.Name = "txtCliente";
            txtCliente.Location = new Point(120, 18);
            txtCliente.Width = 280;
            Controls.Add(txtCliente);

            chkFrecuente = new CheckBox();
            chkFrecuente.Name = "chkFrecuente";
            chkFrecuente.Text = "Cliente frecuente";
            chkFrecuente.Location = new Point(120, 50);
            chkFrecuente.AutoSize = true;
            Controls.Add(chkFrecuente);

            

            Label lblFecha = new Label();
            lblFecha.Text = "Fecha:";
            lblFecha.Location = new Point(20, 90);
            lblFecha.AutoSize = true;
            Controls.Add(lblFecha);

            dtpFecha = new DateTimePicker();
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Location = new Point(120, 88);
            dtpFecha.Width = 280;
            dtpFecha.Format = DateTimePickerFormat.Short;
            Controls.Add(dtpFecha);

            Label lblProducto = new Label();
            lblProducto.Text = "Producto:";
            lblProducto.Location = new Point(20, 130);
            lblProducto.AutoSize = true;
            Controls.Add(lblProducto);

            txtProducto = new TextBox();
            txtProducto.Name = "txtProducto";
            txtProducto.Location = new Point(120, 128);
            txtProducto.Width = 280;
            Controls.Add(txtProducto);

       

            Label lblPrecio = new Label();
            lblPrecio.Text = "Precio:";
            lblPrecio.Location = new Point(20, 170);
            lblPrecio.AutoSize = true;
            Controls.Add(lblPrecio);

            txtPrecio = new TextBox();
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Location = new Point(120, 168);
            txtPrecio.Width = 280;
            Controls.Add(txtPrecio);

       

            Label lblCantidad = new Label();
            lblCantidad.Text = "Cantidad:";
            lblCantidad.Location = new Point(20, 210);
            lblCantidad.AutoSize = true;
            Controls.Add(lblCantidad);

            nudCantidad = new NumericUpDown();
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Location = new Point(120, 208);
            nudCantidad.Minimum = 1;
            nudCantidad.Maximum = 20;
            nudCantidad.Value = 1;
            Controls.Add(nudCantidad);

         
            GroupBox grupoTamano = new GroupBox();
            grupoTamano.Text = "Tamaño";
            grupoTamano.Location = new Point(20, 250);
            grupoTamano.Size = new Size(180, 110);
            Controls.Add(grupoTamano);

            rbtNormal = new RadioButton();
            rbtNormal.Name = "rbtNormal";
            rbtNormal.Text = "Normal";
            rbtNormal.Location = new Point(15, 30);
            rbtNormal.Checked = true;
            grupoTamano.Controls.Add(rbtNormal);

            rbtGrande = new RadioButton();
            rbtGrande.Name = "rbtGrande";
            rbtGrande.Text = "Grande (+RD$25)";
            rbtGrande.Location = new Point(15, 65);
            grupoTamano.Controls.Add(rbtGrande);

      

            GroupBox grupoServicio = new GroupBox();
            grupoServicio.Text = "Servicio";
            grupoServicio.Location = new Point(220, 250);
            grupoServicio.Size = new Size(190, 110);
            Controls.Add(grupoServicio);

            rbtLocal = new RadioButton();
            rbtLocal.Name = "rbtLocal";
            rbtLocal.Text = "Consumir en local";
            rbtLocal.Location = new Point(10, 30);
            rbtLocal.Checked = true;
            grupoServicio.Controls.Add(rbtLocal);

            rbtLlevar = new RadioButton();
            rbtLlevar.Name = "rbtLlevar";
            rbtLlevar.Text = "Para llevar (+RD$20)";
            rbtLlevar.Location = new Point(10, 65);
            grupoServicio.Controls.Add(rbtLlevar);

         

            chkPorcionExtra = new CheckBox();
            chkPorcionExtra.Name = "chkPorcionExtra";
            chkPorcionExtra.Text = "Porcion extra (+RD$30)";
            chkPorcionExtra.Location = new Point(30, 380);
            chkPorcionExtra.AutoSize = true;
            Controls.Add(chkPorcionExtra);

        

            btnAgregar = new Button();
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Text = "Agregar al pedido";
            btnAgregar.Location = new Point(470, 20);
            btnAgregar.Size = new Size(350, 45);
            btnAgregar.Click += btnAgregar_Click;
            Controls.Add(btnAgregar);

         

            lblEncabezado = new Label();
            lblEncabezado.Name = "lblEncabezado";
            lblEncabezado.Location = new Point(470, 80);
            lblEncabezado.Size = new Size(400, 25);
            lblEncabezado.Font = new Font("Consolas", 9, FontStyle.Bold);
            lblEncabezado.Text =
                "Cant".PadRight(6) +
                "Producto".PadRight(24) +
                "Precio".PadLeft(10) +
                "Total".PadLeft(12);
            Controls.Add(lblEncabezado);

          

            lstPedido = new ListBox();
            lstPedido.Name = "lstPedido";
            lstPedido.Location = new Point(470, 110);
            lstPedido.Size = new Size(400, 220);
            lstPedido.Font = new Font("Consolas", 9);
            lstPedido.HorizontalScrollbar = true;
            Controls.Add(lstPedido);

           

            Label textoSubtotal = new Label();
            textoSubtotal.Text = "Subtotal:";
            textoSubtotal.Location = new Point(470, 350);
            textoSubtotal.AutoSize = true;
            Controls.Add(textoSubtotal);

            lblSubtotal = new Label();
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Text = "RD$ 0.00";
            lblSubtotal.Location = new Point(650, 350);
            lblSubtotal.Size = new Size(150, 25);
            Controls.Add(lblSubtotal);


            Label textoDescuento = new Label();
            textoDescuento.Text = "Descuento:";
            textoDescuento.Location = new Point(470, 385);
            textoDescuento.AutoSize = true;
            Controls.Add(textoDescuento);

            lblDescuento = new Label();
            lblDescuento.Name = "lblDescuento";
            lblDescuento.Text = "RD$ 0.00";
            lblDescuento.Location = new Point(650, 385);
            lblDescuento.Size = new Size(150, 25);
            Controls.Add(lblDescuento);

       

            Label textoEmpaque = new Label();
            textoEmpaque.Text = "Empaque:";
            textoEmpaque.Location = new Point(470, 420);
            textoEmpaque.AutoSize = true;
            Controls.Add(textoEmpaque);

            lblEmpaque = new Label();
            lblEmpaque.Name = "lblEmpaque";
            lblEmpaque.Text = "RD$ 0.00";
            lblEmpaque.Location = new Point(650, 420);
            lblEmpaque.Size = new Size(150, 25);
            Controls.Add(lblEmpaque);

        

            Label textoItbis = new Label();
            textoItbis.Text = "ITBIS (18%):";
            textoItbis.Location = new Point(470, 455);
            textoItbis.AutoSize = true;
            Controls.Add(textoItbis);

            lblItbis = new Label();
            lblItbis.Name = "lblItbis";
            lblItbis.Text = "RD$ 0.00";
            lblItbis.Location = new Point(650, 455);
            lblItbis.Size = new Size(150, 25);
            Controls.Add(lblItbis);

          

            Label textoTotal = new Label();
            textoTotal.Text = "TOTAL A PAGAR:";
            textoTotal.Location = new Point(470, 500);
            textoTotal.AutoSize = true;
            textoTotal.Font = new Font("Arial", 10, FontStyle.Bold);
            Controls.Add(textoTotal);

            lblTotal = new Label();
            lblTotal.Name = "lblTotal";
            lblTotal.Text = "RD$ 0.00";
            lblTotal.Location = new Point(650, 500);
            lblTotal.Size = new Size(150, 25);
            lblTotal.Font = new Font("Arial", 10, FontStyle.Bold);
            Controls.Add(lblTotal);

            

            btnCalcular = new Button();
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Text = "Calcular total";
            btnCalcular.Location = new Point(20, 440);
            btnCalcular.Size = new Size(120, 45);
            btnCalcular.Click += btnCalcular_Click;
            Controls.Add(btnCalcular);

            

            btnLimpiar = new Button();
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Text = "Nuevo pedido";
            btnLimpiar.Location = new Point(150, 440);
            btnLimpiar.Size = new Size(130, 45);
            btnLimpiar.Click += btnLimpiar_Click;
            Controls.Add(btnLimpiar);

            btnSalir = new Button();
            btnSalir.Name = "btnSalir";
            btnSalir.Text = "Salir";
            btnSalir.Location = new Point(290, 440);
            btnSalir.Size = new Size(120, 45);
            btnSalir.Click += btnSalir_Click;
            Controls.Add(btnSalir);
        }

  

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string producto = txtProducto.Text;
            decimal precio;
            decimal precioUnitario;
            decimal totalLinea;
            int cantidad;
            string tamano;

            if (producto == "")
            {
                MessageBox.Show("Digite el nombre del producto.");
                txtProducto.Focus();
            }
            else if (decimal.TryParse(txtPrecio.Text, out precio) == false || precio <= 0)
            {
                MessageBox.Show("Digite un precio valido.");
                txtPrecio.Focus();
            }
            else
            {
                precioUnitario = precio;
                cantidad = Convert.ToInt32(nudCantidad.Value);

                tamano = "Normal";

                if (rbtGrande.Checked == true)
                {
                    precioUnitario = precioUnitario + 25;
                    tamano = "Grande";
                }

                if (chkPorcionExtra.Checked == true)
                {
                    precioUnitario = precioUnitario + 30;
                }

                totalLinea = precioUnitario * cantidad;

                string nombre = producto + " (" + tamano + ")";

                string linea =
                    cantidad.ToString().PadRight(6) +
                    nombre.PadRight(24) +
                    precioUnitario.ToString("0.00").PadLeft(10) +
                    totalLinea.ToString("0.00").PadLeft(12);

                lstPedido.Items.Add(linea);

                subtotal = subtotal + totalLinea;

                lblSubtotal.Text = "RD$ " + subtotal.ToString("0.00");

     

                txtProducto.Clear();
                txtPrecio.Clear();

                nudCantidad.Value = 1;
                rbtNormal.Checked = true;
                chkPorcionExtra.Checked = false;

                txtProducto.Focus();
            }
        }

  

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            decimal descuento = 0;
            decimal empaque = 0;
            decimal baseImponible;
            decimal itbis;
            decimal total;

            if (lstPedido.Items.Count == 0)
            {
                MessageBox.Show("Debe agregar productos al pedido.");
            }
            else
            {
                if (chkFrecuente.Checked == true)
                {
                    descuento = subtotal * 0.10m;
                }

                if (rbtLlevar.Checked == true)
                {
                    empaque = 20;
                }

                baseImponible = subtotal - descuento + empaque;

                itbis = baseImponible * 0.18m;

                total = baseImponible + itbis;

                lblSubtotal.Text = "RD$ " + subtotal.ToString("0.00");
                lblDescuento.Text = "RD$ " + descuento.ToString("0.00");
                lblEmpaque.Text = "RD$ " + empaque.ToString("0.00");
                lblItbis.Text = "RD$ " + itbis.ToString("0.00");
                lblTotal.Text = "RD$ " + total.ToString("0.00");
            }
        }

       

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCliente.Clear();
            txtProducto.Clear();
            txtPrecio.Clear();

            chkFrecuente.Checked = false;
            chkPorcionExtra.Checked = false;

            rbtNormal.Checked = true;
            rbtLocal.Checked = true;

            nudCantidad.Value = 1;
            dtpFecha.Value = DateTime.Now;

            lstPedido.Items.Clear();

            subtotal = 0;

            lblSubtotal.Text = "RD$ 0.00";
            lblDescuento.Text = "RD$ 0.00";
            lblEmpaque.Text = "RD$ 0.00";
            lblItbis.Text = "RD$ 0.00";
            lblTotal.Text = "RD$ 0.00";

            txtCliente.Focus();
        }

      
        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult respuesta;

            respuesta = MessageBox.Show(
                "¿Desea salir del programa?",
                "Confirmar salida",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (respuesta == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
