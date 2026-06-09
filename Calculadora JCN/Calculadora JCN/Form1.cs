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
            double res = Convert.ToDouble(new DataTable().Compute(txtmain.Text, null));
            txtmain.Text = res.ToString();
            expressao = "";
        }

        private void button0_Click(object sender, EventArgs e)
        {
            expressao = expressao + 0.ToString();
            txtmain.Text = expressao.ToString();
            txtmain.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            expressao = expressao + 1.ToString();
            txtmain.Text = expressao.ToString();
            txtmain.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            expressao = expressao + 2.ToString();
            txtmain.Text = expressao.ToString();
            txtmain.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            expressao = expressao + 3.ToString();
            txtmain.Text = expressao.ToString();
            txtmain.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            expressao = expressao + 4.ToString();
            txtmain.Text = expressao.ToString();
            txtmain.Focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            expressao = expressao + 5.ToString();
            txtmain.Text = expressao.ToString();
            txtmain.Focus();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            expressao = expressao + 6.ToString();
            txtmain.Text = expressao.ToString();
            txtmain.Focus();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            expressao = expressao + 7.ToString();
            txtmain.Text = expressao.ToString();
            txtmain.Focus();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            expressao = expressao + 8.ToString();
            txtmain.Text = expressao.ToString();
            txtmain.Focus();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            expressao = expressao + 9.ToString();
            txtmain.Text = expressao.ToString();
            txtmain.Focus();
        }

        private void btnmais_Click(object sender, EventArgs e)
        {
            expressao = expressao + "+";
            txtmain.Text = expressao.ToString();
            txtmain.Focus();
        }

        private void btnmenos_Click(object sender, EventArgs e)
        {
            expressao = expressao + "-";
            txtmain.Text = expressao.ToString();
            txtmain.Focus();
        }

        private void btnmult_Click(object sender, EventArgs e)
        {
            expressao = expressao + "*";
            txtmain.Text = expressao.ToString();
            txtmain.Focus();
        }

        private void btndiv_Click(object sender, EventArgs e)
        {
            expressao = expressao + "/";
            txtmain.Text = expressao.ToString();
            txtmain.Focus();
        }

        private void btnvir_Click(object sender, EventArgs e)
        {
            expressao = expressao + ".";
            txtmain.Text = expressao.ToString();
            txtmain.Focus();
        }

        private void btnfat_Click(object sender, EventArgs e)
        {
            expressao = expressao + "!";
            txtmain.Text = expressao.ToString();
            txtmain.Focus();
        }
        private void btnpot_Click(object sender, EventArgs e)
        {
            double n = Convert.ToDouble(txtmain.Text);
            txtmain.Text = Math.Pow(n, 2).ToString();
            expressao = txtmain.Text;
            txtmain.Focus();
        }

        private void btnraiz_Click(object sender, EventArgs e)
        {
            double n = Convert.ToDouble(txtmain.Text);
            txtmain.Text = Math.Sqrt(n).ToString();
            expressao = txtmain.Text;
            txtmain.Focus();
        }

        private void btnposneg_Click(object sender, EventArgs e)
        {
            double n = Convert.ToDouble(txtmain.Text);
            txtmain.Text = (-n).ToString();
            expressao = txtmain.Text;
            txtmain.Focus();
        }

        private void btnopen_Click(object sender, EventArgs e)
        {
            expressao = expressao + "(";
            txtmain.Text = expressao.ToString();
            txtmain.Focus();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            expressao = expressao + ")";
            txtmain.Text = expressao.ToString();
            txtmain.Focus();
        }

        private void btnce_Click(object sender, EventArgs e)
        {
            expressao = "";
            txtmain.Text = "";
            txtmain.Focus();
        }

        private void btnbspc_Click(object sender, EventArgs e)
        {
            char[] expressaochar1 = expressao.ToCharArray();
            char[] expressaochar2 = new char[20];
            for(int i = 0; i < expressao.Length-1; i++)
            {
                expressaochar2[i] = expressaochar1[i];
            }
            txtmain.Focus();
        }

        private void btnigual_Click(object sender, EventArgs e)
        {
            calc();
            txtmain.Focus();
        }
    }
}

