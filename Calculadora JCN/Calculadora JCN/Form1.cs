using Microsoft.VisualBasic.Devices;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Data;
using System.Numerics;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;
namespace Calculadora_JCN

{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CarregarMusicas();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            focus();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            player?.Stop();
            audio?.Dispose();
            player?.Dispose();
        }

        ////////////// PLAYER
        ///
        List<string> musicas = new List<string>();
        private WaveOutEvent player;
        private AudioFileReader audio;
        Random gerador = new Random();


        private void CarregarMusicas()
        {
            string pasta = @"..\..\..\..\..\Musica";

            musicas = Directory.GetFiles(pasta, "*.mp3").ToList();
        }

        private void CarregarMusicaAtual()
        {
            player?.Stop();

            audio?.Dispose();
            player?.Dispose();

            //de 0 a 2 - 2 é EXCLUSIVO, random gera entre 0 e 1
            int indice = gerador.Next(0, 6);
            audio = new AudioFileReader(musicas[indice]);
            lblmusicaatual.Text = Path.GetFileNameWithoutExtension(musicas[indice]);

            player = new WaveOutEvent();
            player.Init(audio);
        }

        private void btntrocarmusica_Click(object sender, EventArgs e)
        {
            CarregarMusicaAtual();
            player.Play();
        }

        private void btnplaypause_Click(object sender, EventArgs e)
        {
            if (musicas.Count == 0)
                return;

            if (player == null)
            {
                CarregarMusicaAtual();
                player.Play();
                btnplaypause.Text = " ⏸";
            }

            if (player.PlaybackState == PlaybackState.Playing)
            {
                player.Pause();
                btnplaypause.Text = " ▶";
            }
            else
            {
                player.Play();
                btnplaypause.Text = " ⏸";
            }
        }


        ////////////// CALCULADORA

        private void txtmain_KeyPress(object sender, KeyPressEventArgs e)
        {
            string permitidos = "0123456789+-*/().";

            if (permitidos.Contains(e.KeyChar) || char.IsControl(e.KeyChar)) // e.KeyChar é o botão pressionado
            {
                e.Handled = false; //deixar passar
            }
            else if (e.KeyChar == '=')
            {
                e.Handled = true;
                calc();
                focus();
            }
            else
            {
                e.Handled = true; //não processar; bloquear
            }
        }

        private void txtmain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                calc();
                focus();
            }
        }

        private void txtexpoente_KeyPress(object sender, KeyPressEventArgs e)
        {
            string permitidos = "0123456789";

            if (permitidos.Contains(e.KeyChar) || char.IsControl(e.KeyChar)) // e.KeyChar é o botão pressionado
            {
                e.Handled = false; //deixar passar
            }
            else if (e.KeyChar == '=')
            {
                e.Handled = true;
                calc();
                focus();
            }
            else
            {
                e.Handled = true; //não processar; bloquear
            }
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

        private void btnvir_Click(object sender, EventArgs e)
        {
            txtmain.Text = txtmain.Text + ".";
            focus();
        }

        private void btnigual_Click(object sender, EventArgs e)
        {
            calc();
            focus();
        }

        public void calc()
        {
            if (txtmain.Text != "")
            {
                double resdouble = Convert.ToDouble(new DataTable().Compute(txtmain.Text, null));
                string resultado = resdouble.ToString();
                resultado = Regex.Replace(resultado, ",", ".");
                txtmain.Text = resultado;
            }
        }

        private void focus()
        {
            txtmain.Focus();
            txtmain.SelectionStart = txtmain.Text.Length;
            txtmain.SelectionLength = 0;
        }


        ////////////// HISTÓRICO
        ///


        //lista que aumenta de tamanho
        //        List<string> historico = new List<string>();
        //historico.Add("33+34");
        //for (int i = historico.Count - 1; i >= 0; i--)
        //{Console.WriteLine(historico[i]);}

    }
}

