using System.Data;
using System.Text.RegularExpressions; //biblioteca para REGEX
namespace Calculadora_JCN

{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //foco no textbox ao iniciar
        private void Form1_Load(object sender, EventArgs e)
        {
            focus();
        }

        public void calc()
        {
            if (txtmain.Text != "")
            {
                double res = Convert.ToDouble(new DataTable().Compute(txtmain.Text, null));
                txtmain.Text = res.ToString();
            }
        }

        private void focus()
        {
            txtmain.Focus();
            txtmain.SelectionStart = txtmain.Text.Length;
            txtmain.SelectionLength = 0;
        }
        private void txtmain_KeyPress(object sender, KeyPressEventArgs e)
        {//aceitar apenas números e símbolos certos
            string permitidos = "0123456789+-*/().";

            if (permitidos.Contains(e.KeyChar) || char.IsControl(e.KeyChar)) // e.KeyChar é o botão pressionado
            {
                e.Handled = false; //deixar passar
            }
            else
            {
                e.Handled = true; //não processar; bloquear
            }
        }

        private void txtmain_TextChanged(object sender, EventArgs e)
        {

        }

        private void button0_Click(object sender, EventArgs e)
        {
            txtmain.Text = txtmain.Text + 0.ToString();
            focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtmain.Text = txtmain.Text + 1.ToString();
            focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtmain.Text = txtmain.Text + 2.ToString();
            focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtmain.Text = txtmain.Text + 3.ToString();
            focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtmain.Text = txtmain.Text + 4.ToString();
            focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtmain.Text = txtmain.Text + 5.ToString();
            focus();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtmain.Text = txtmain.Text + 6.ToString();
            focus();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txtmain.Text = txtmain.Text + 7.ToString();
            focus();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            txtmain.Text = txtmain.Text + 8.ToString();
            focus();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            txtmain.Text = txtmain.Text + 9.ToString();
            focus();
        }

        private void btnmais_Click(object sender, EventArgs e)
        {
            txtmain.Text = txtmain.Text + "+";
            focus();
        }

        private void btnmenos_Click(object sender, EventArgs e)
        {
            txtmain.Text = txtmain.Text + "-";
            focus();
        }

        private void btnmult_Click(object sender, EventArgs e)
        {
            txtmain.Text = txtmain.Text + "*";
            focus();
        }

        private void btndiv_Click(object sender, EventArgs e)
        {
            txtmain.Text = txtmain.Text + "/";
            focus();
        }

        private void btnvir_Click(object sender, EventArgs e)
        {
<<<<<<< Updated upstream
            expressao = expressao + ".";
            txtmain.Text = expressao.ToString();
            focus();
        }

        private void btnfat_Click(object sender, EventArgs e)
        {
            double n = Convert.ToDouble(txtmain.Text);
            double fat = 1;

            for (double i = n; i > 1; i--)
            {
                fat *= i;
            }
            txtmain.Text = fat.ToString();
            expressao = txtmain.Text;
            txtmain.Focus();
            focus();
        }
        private void btnpot_Click(object sender, EventArgs e)
        {
            double n = Convert.ToDouble(txtmain.Text);
            txtmain.Text = Math.Pow(n, 2).ToString();
            expressao = txtmain.Text;
            focus();
        }

        private void btnraiz_Click(object sender, EventArgs e)
        {
            double n = Convert.ToDouble(txtmain.Text);
            txtmain.Text = Math.Sqrt(n).ToString();
            expressao = txtmain.Text;
            focus();
        }

        private void btnposneg_Click(object sender, EventArgs e)
        {
            double n = Convert.ToDouble(txtmain.Text);
            txtmain.Text = (-n).ToString();
            expressao = txtmain.Text;
=======
            txtmain.Text = txtmain.Text + ".";
>>>>>>> Stashed changes
            focus();
        }

        private void btnopen_Click(object sender, EventArgs e)
        {
            txtmain.Text = txtmain.Text + "(";
            focus();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            txtmain.Text = txtmain.Text + ")";
            focus();
        }

        private void btnfat_Click(object sender, EventArgs e)
        {
            Match ultimo = Regex.Match(txtmain.Text, @"-?\d+(?:\.\d+)?$");
            if (ultimo.Success)
            {
                int numero = int.Parse(ultimo.Value);
                int fatorial = numero;
                for (int i = numero - 1; i > 1; i--)
                {
                    fatorial *= i;
                }

                txtmain.Text = Regex.Replace(
                    txtmain.Text,
                    @"-?\d+(?:\.\d+)?$",
                    fatorial.ToString()
                );
            }
        }

        private void btnpot_Click(object sender, EventArgs e)
        {
            Match ultimo = Regex.Match(txtmain.Text, @"-?\d+(?:\.\d+)?$");
            if (ultimo.Success)
            {
                double numero = double.Parse(ultimo.Value);
                double expoente = Convert.ToDouble(txtexpoente.Text);
                numero = Math.Pow(numero, expoente);

                txtmain.Text = Regex.Replace(
                    txtmain.Text,
                    @"-?\d+(?:\.\d+)?$",
                    numero.ToString()
                );
            }
        }

        private void btnraiz_Click(object sender, EventArgs e)
        {
            Match ultimo = Regex.Match(txtmain.Text, @"-?\d+(?:\.\d+)?$");
            if (ultimo.Success)
            {
                double numero = double.Parse(ultimo.Value);
                double indice = Convert.ToDouble(txtexpoente.Text);
                numero = Math.Pow(numero, 1 / indice); //Matematicamente, calcular uma raiz é o mesmo que elevar um número à potência do inverso do índice

                txtmain.Text = Regex.Replace(
                    txtmain.Text,
                    @"-?\d+(?:\.\d+)?$",
                    numero.ToString()
                );
            }
        }

        private void btnposneg_Click(object sender, EventArgs e)
        {
            Match ultimo = Regex.Match(txtmain.Text, @"-?\d+(?:\.\d+)?$");
            if (ultimo.Success)
            {
                double numero = double.Parse(ultimo.Value);
                numero = -(numero);

                txtmain.Text = Regex.Replace(
                    txtmain.Text,
                    @"-?\d+(?:\.\d+)?$",
                    numero.ToString()
                );
            }
        }

        private void btnce_Click(object sender, EventArgs e)
        {
            Match ultimo = Regex.Match(txtmain.Text, @"-?\d+(?:\.\d+)?$");
            if (ultimo.Success)
            {
                txtmain.Text = Regex.Replace(
                    txtmain.Text,
                    @"-?\d+(?:\.\d+)?$",
                    ""
                );
            }
        }
        private void btnc_Click(object sender, EventArgs e)
        {
            txtmain.Text = "";
            focus();
        }

        private void btnbspc_Click(object sender, EventArgs e)
        {
            char[] expressaochar = txtmain.Text.ToCharArray();
            txtmain.Text = new string(expressaochar, 0, expressaochar.Length - 1);
            focus();
        }

        private void btnigual_Click(object sender, EventArgs e)
        {
            calc();
            focus();
        }

        
    }
}

