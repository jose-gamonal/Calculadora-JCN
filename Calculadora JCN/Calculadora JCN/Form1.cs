using System.Data;
namespace Calculadora_JCN

{
    public partial class Form1 : Form
    {
        string expressao = "";
        public Form1()
        {
            InitializeComponent();
        }

        //foco no textbox ao iniciar
        private void Form1_Load(object sender, EventArgs e)
        {
            txtmain.Focus();
        }

        //função-mestra. chamar ela para calcular a expressao
        public void calc()
        {
            if (txtmain.Text != "")
            {
                double res = Convert.ToDouble(new DataTable().Compute(txtmain.Text, null));
                txtmain.Text = res.ToString();
                expressao = res.ToString();
            }
        }

        private void focus()
        {
            txtmain.Focus();
            txtmain.SelectionStart = txtmain.Text.Length;
            txtmain.SelectionLength = 0;
        }

        private void txtmain_TextChanged(object sender, EventArgs e)
        {

        }

        private void button0_Click(object sender, EventArgs e)
        {
            expressao = expressao + 0.ToString();
            txtmain.Text = expressao.ToString();
            focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            expressao = expressao + 1.ToString();
            txtmain.Text = expressao.ToString();
            focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            expressao = expressao + 2.ToString();
            txtmain.Text = expressao.ToString();
            focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            expressao = expressao + 3.ToString();
            txtmain.Text = expressao.ToString();
            focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            expressao = expressao + 4.ToString();
            txtmain.Text = expressao.ToString();
            focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            expressao = expressao + 5.ToString();
            txtmain.Text = expressao.ToString();
            focus();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            expressao = expressao + 6.ToString();
            txtmain.Text = expressao.ToString();
            focus();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            expressao = expressao + 7.ToString();
            txtmain.Text = expressao.ToString();
            focus();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            expressao = expressao + 8.ToString();
            txtmain.Text = expressao.ToString();
            focus();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            expressao = expressao + 9.ToString();
            txtmain.Text = expressao.ToString();
            focus();
        }

        private void btnmais_Click(object sender, EventArgs e)
        {
            expressao = expressao + "+";
            txtmain.Text = expressao.ToString();
            focus();
        }

        private void btnmenos_Click(object sender, EventArgs e)
        {
            expressao = expressao + "-";
            txtmain.Text = expressao.ToString();
            focus();
        }

        private void btnmult_Click(object sender, EventArgs e)
        {
            expressao = expressao + "*";
            txtmain.Text = expressao.ToString();
            focus();
        }

        private void btndiv_Click(object sender, EventArgs e)
        {
            expressao = expressao + "/";
            txtmain.Text = expressao.ToString();
            focus();
        }

        private void btnvir_Click(object sender, EventArgs e)
        {
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
            focus();
        }

        private void btnopen_Click(object sender, EventArgs e)
        {
            expressao = expressao + "(";
            txtmain.Text = expressao.ToString();
            focus();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            expressao = expressao + ")";
            txtmain.Text = expressao.ToString();
            focus();
        }

        private void btnce_Click(object sender, EventArgs e)
        {
            expressao = "";
            txtmain.Text = "";
            focus();
        }

        private void btnbspc_Click(object sender, EventArgs e)
        {
            char[] expressaochar = expressao.ToCharArray();
            expressao = new string(expressaochar, 0, expressaochar.Length-1);
            txtmain.Text = expressao;
            focus();
        }

        private void btnigual_Click(object sender, EventArgs e)
        {
            calc();
            focus();
        }
    }
}

