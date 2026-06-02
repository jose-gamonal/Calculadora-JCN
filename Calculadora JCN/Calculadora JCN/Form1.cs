using System.Data;
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
            txtmain.Focus();
        }

        //função-mestra. chamar ela para calcular a expressao
        private double calc()
        {
            string expressao = "1+66";
            double res = Convert.ToDouble(new DataTable().Compute(expressao, null));
            return res;
        }

        private void btnigual_Click(object sender, EventArgs e)
        {
            txtmain.Text = calc().ToString();
        }

        private void txtmain_TextChanged(object sender, EventArgs e)
        {
            calc().ToString();
        }

        //adicionar 
        //  txtmain.Focus();
        //ao fim das lógicas dos botoes para retornar o foco para a caixa de texto assim que fizer o que deve ser feito
    }
}
