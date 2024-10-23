using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        double num1 = 0, num2 = 0;
        string operation = "";
        public Form1()
        {
            InitializeComponent();
            InitializeCustomControls();
        }
        // Método para crear botones y el TextBox en tiempo de ejecución
        private void InitializeCustomControls()
        {
            // Crear TextBox para mostrar los números y resultados
            TextBox textBoxDisplay = new TextBox();
            textBoxDisplay.Name = "textBoxDisplay";
            textBoxDisplay.Size = new Size(260, 30);
            textBoxDisplay.Location = new Point(10, 10);
            textBoxDisplay.ReadOnly = true;  // Solo lectura
            textBoxDisplay.TextAlign = HorizontalAlignment.Right;
            this.Controls.Add(textBoxDisplay);  // Añadir al formulario

   // Crear botones numéricos en el orden solicitado: 7 8 9, 4 5 6, 1 2 3, 0 .
    int[,] numbers = { { 7, 8, 9 }, { 4, 5, 6 }, { 1, 2, 3 }, { 0, -1, -1 } };  // -1 representa el botón "."
    int xPos = 10, yPos = 50;  // Posición inicial

    for (int row = 0; row < 4; row++)
    {
        for (int col = 0; col < 3; col++)
        {
            if (numbers[row, col] != -1)
            {
                Button btnNumber = new Button();
                btnNumber.Text = numbers[row, col].ToString();
                btnNumber.Name = "btn" + numbers[row, col];
                btnNumber.Size = new Size(50, 50);
                btnNumber.Location = new Point(xPos, yPos);
                btnNumber.Click += new EventHandler(BtnNumber_Click);
                this.Controls.Add(btnNumber);
            }
            else if (row == 3 && col == 1)  // Botón decimal "."
            {
                Button btnDecimal = new Button();
                btnDecimal.Text = ".";
                btnDecimal.Name = "btnDecimal";
                btnDecimal.Size = new Size(50, 50);
                btnDecimal.Location = new Point(xPos, yPos);
                btnDecimal.Click += new EventHandler(BtnDecimal_Click);
                this.Controls.Add(btnDecimal);
            }
            xPos += 60;  // Mover el botón hacia la derecha
        }
        xPos = 10;  // Reiniciar posición horizontal
        yPos += 60;  // Mover a la siguiente fila
    }

            // Botones de operaciones básicas (+, -, *, /)
            string[] operations = { "+", "-", "*", "/" };
            xPos = 190;
            yPos = 50;
            foreach (string op in operations)
            {
                Button btnOperation = new Button();
                btnOperation.Text = op;
                btnOperation.Name = "btn" + op;
                btnOperation.Size = new Size(50, 50);
                btnOperation.Location = new Point(xPos, yPos);
                btnOperation.Click += new EventHandler(BtnOperation_Click);
                this.Controls.Add(btnOperation);
                yPos += 60;
            }

            // Botón C y CE (Clear y Clear Entry)
            Button btnClear = new Button();
            btnClear.Text = "C";
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(50, 50);
            btnClear.Location = new Point(190, yPos);
            btnClear.Click += new EventHandler(BtnClear_Click);
            this.Controls.Add(btnClear);

            Button btnClearEntry = new Button();
            btnClearEntry.Text = "CE";
            btnClearEntry.Name = "btnClearEntry";
            btnClearEntry.Size = new Size(50, 50);
            btnClearEntry.Location = new Point(130, yPos);
            btnClearEntry.Click += new EventHandler(BtnClearEntry_Click);
            this.Controls.Add(btnClearEntry);

            // Botón "="
            Button btnEquals = new Button();
            btnEquals.Text = "=";
            btnEquals.Name = "btnEquals";
            btnEquals.Size = new Size(50,50);  // Botón más alto para "="
            btnEquals.Location = new Point(250, yPos);
            btnEquals.Click += new EventHandler(BtnEquals_Click);
            this.Controls.Add(btnEquals);

            // Botón de raíz cuadrada (√) y elevación al cuadrado (x²)
            Button btnRaizCuadrada = new Button();
            btnRaizCuadrada.Text = "√";
            btnRaizCuadrada.Name = "btnRaizCuadrada";
            btnRaizCuadrada.Size = new Size(50, 50);
            btnRaizCuadrada.Location = new Point(250, 50);
            btnRaizCuadrada.Click += new EventHandler(BtnRaizCuadrada_Click);
            this.Controls.Add(btnRaizCuadrada);

            Button btnPotenciacion = new Button();
            btnPotenciacion.Text = "x²";
            btnPotenciacion.Name = "btnPotenciacion";
            btnPotenciacion.Size = new Size(50, 50);
            btnPotenciacion.Location = new Point(250, 110);
            btnPotenciacion.Click += new EventHandler(BtnPotenciacion_Click);
            this.Controls.Add(btnPotenciacion);
        }

        // Método para manejar el evento Click de los números
        private void BtnNumber_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            TextBox textBoxDisplay = (TextBox)this.Controls["textBoxDisplay"];
            textBoxDisplay.Text += btn.Text;
        }

        // Operación básica (+, -, *, /)
        private void BtnOperation_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            TextBox textBoxDisplay = (TextBox)this.Controls["textBoxDisplay"];
            num1 = Convert.ToDouble(textBoxDisplay.Text);
            operation = btn.Text;
            textBoxDisplay.Clear();
        }

        // Botón "="
        private void BtnEquals_Click(object sender, EventArgs e)
        {
            TextBox textBoxDisplay = (TextBox)this.Controls["textBoxDisplay"];
            num2 = Convert.ToDouble(textBoxDisplay.Text);
            double result = 0;

            // Realizar operación
            switch (operation)
            {
                case "+":
                    result = num1 + num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                case "/":
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    else
                    {
                        MessageBox.Show("No se puede dividir por 0.");
                        return;
                    }
                    break;
            }

            textBoxDisplay.Text = result.ToString();

            // Guardar cálculo en la base de datos
            GuardarCalculoEnBaseDeDatos(num1, operation, num2, result);
        }

        // Guardar cálculos en la base de datos
        private void GuardarCalculoEnBaseDeDatos(double num1, string operacion, double num2, double resultado)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=LAPTOP-V0HABNQ2\\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True"))
            {
                conn.Open();
                string query = "INSERT INTO Calculadora (Numero1, Operacion, Numero2, Resultado) VALUES (@num1, @operacion, @num2, @resultado)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@num1", num1);
                cmd.Parameters.AddWithValue("@operacion", operacion);
                cmd.Parameters.AddWithValue("@num2", num2);
                cmd.Parameters.AddWithValue("@resultado", resultado);
                cmd.ExecuteNonQuery();
            }
        }

        

        // Botón de raíz cuadrada
        private void BtnRaizCuadrada_Click(object sender, EventArgs e)
        {
            TextBox textBoxDisplay = (TextBox)this.Controls["textBoxDisplay"];
            double numero = Convert.ToDouble(textBoxDisplay.Text);
            textBoxDisplay.Text = Math.Sqrt(numero).ToString();
        }

        // Botón de elevar al cuadrado
        private void BtnPotenciacion_Click(object sender, EventArgs e)
        {
            TextBox textBoxDisplay = (TextBox)this.Controls["textBoxDisplay"];
            double numero = Convert.ToDouble(textBoxDisplay.Text);
            textBoxDisplay.Text = Math.Pow(numero, 2).ToString();
        }

        // Botón para limpiar (C)
        private void BtnClear_Click(object sender, EventArgs e)
        {
            TextBox textBoxDisplay = (TextBox)this.Controls["textBoxDisplay"];
            textBoxDisplay.Clear();
            num1 = num2 = 0;
            operation = "";
        }

        // Botón para borrar la entrada actual (CE)
        private void BtnClearEntry_Click(object sender, EventArgs e)
        {
            TextBox textBoxDisplay = (TextBox)this.Controls["textBoxDisplay"];
            textBoxDisplay.Clear();
        }

        private void dataGridViewCalculos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Aquí puedes añadir algún evento personalizado si lo necesitas.
        }

        // Método para mostrar cálculos guardados en un DataGridView
        private void BtnMostrarCalculos_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=LAPTOP-V0HABNQ2\\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True"))
            {
                conn.Open();

                // Consulta SQL para seleccionar todos los cálculos
                string query = "SELECT Numero1 AS 'Número 1', Operacion AS 'Operación', Numero2 AS 'Número 2', Resultado AS 'Resultado' FROM Calculadora";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Asignar los datos al DataGridView
                dataGridViewCalculos.DataSource = dt;
            }
        }



        // Botón de decimal "."
        private void BtnDecimal_Click(object sender, EventArgs e)
        {
            TextBox textBoxDisplay = (TextBox)this.Controls["textBoxDisplay"];
            if (!textBoxDisplay.Text.Contains("."))
            {
                textBoxDisplay.Text += ".";
            }
        }
    }
}
