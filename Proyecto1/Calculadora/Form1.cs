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


namespace Calculadora
{
    public partial class btnMostrarCalculos : Form
    {
        public btnMostrarCalculos()
        {
            InitializeComponent();
        }

        //Metodo insert y conexión a BD
        private void GuardarCalculoEnBaseDeDatos(double num1, string operacion, double num2, double resultado)
        {

           // string connectionString = "Data Source=LAPTOP-VOHABNQ2\\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True";
           // "Data Source=LAPTOP-V0HABNQ2\\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True"


            using (SqlConnection conn = new SqlConnection("Data Source=LAPTOP-V0HABNQ2\\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True"))
            {
                conn.Open();
                string query = "INSERT INTO Calculadora2 (Numero1, Operacion, Numero2, Resultado) VALUES (@num1, @operacion, @num2, @resultado)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@num1", num1);
                cmd.Parameters.AddWithValue("@operacion", operacion);
                cmd.Parameters.AddWithValue("@num2", num2);
                cmd.Parameters.AddWithValue("@resultado", resultado);
                cmd.ExecuteNonQuery();
            }
        }
        //Mostrar en la pantalla
        private void btn0_Click(object sender, EventArgs e)
        {
            textBoxDisplay.Text += "0";
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            textBoxDisplay.Text += "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            textBoxDisplay.Text += "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            textBoxDisplay.Text += "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            textBoxDisplay.Text += "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            textBoxDisplay.Text += "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            textBoxDisplay.Text += "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            textBoxDisplay.Text += "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            textBoxDisplay.Text += "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            textBoxDisplay.Text += "9";
        }


        double num1 = 0; //Var qur guarda 1er valor
        string operation = "";
        private void btnAdd_Click(object sender, EventArgs e)
        {
            num1 = Convert.ToDouble(textBoxDisplay.Text);
            operation = "+";
            textBoxDisplay.Clear();
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            num1 = Convert.ToDouble(textBoxDisplay.Text);
            operation = "-";
            textBoxDisplay.Clear();
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            num1 = Convert.ToDouble(textBoxDisplay.Text);
            operation = "*";
            textBoxDisplay.Clear();
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            num1 = Convert.ToDouble(textBoxDisplay.Text);
            operation = "/";
            textBoxDisplay.Clear();
        }

        private void btnSqrt_Click(object sender, EventArgs e)
        {
            double numero = Convert.ToDouble(textBoxDisplay.Text);
            textBoxDisplay.Text = Math.Sqrt(numero).ToString();
        }

        private void btnSquare_Click(object sender, EventArgs e)
        {
            double numero = Convert.ToDouble(textBoxDisplay.Text);
            textBoxDisplay.Text = Math.Pow(numero, 2).ToString();
        }

        //Resultado y parte logica
        private void btnEquals_Click(object sender, EventArgs e)
        {
            double num2 = Convert.ToDouble(textBoxDisplay.Text); //Variable de 2do valor
            double result = 0;

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

            // Para guardar en la base de datos
            GuardarCalculoEnBaseDeDatos(num1, operation, num2, result);
        }
        //Mostrar historial
        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=LAPTOP-V0HABNQ2\\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True"))
            {
                conn.Open();
                string query = "SELECT Numero1, Operacion, Numero2, Resultado,fecha FROM Calculadora2";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // dataGridViewCalculos
                dataGridViewCalculos.DataSource = dt;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBoxDisplay.Clear();
        }
    }
}
