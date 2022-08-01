using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using ClosedXML.Excel;
using OpenQA.Selenium.Chrome;
using System.Text.RegularExpressions;
using System.Threading;

namespace Primeiro_Contato
{
    public partial class Form1 : Form
    {
        public List<string> nomes = new List<string> { };
        public List<string> feitoounao = new List<string> { };
        public List<string> numeros = new List<string> { }; 
        public IWebDriver driver = new ChromeDriver();
        public Image imagem_done = Image.FromFile(@"C:\Users\murphys_dev\source\repos\Primeiro_Contato\Primeiro_Contato\bin\Resources\icons8-checkmark-32.png");
        public Image imagem_maleta = Image.FromFile(@"C:\Users\murphys_dev\source\repos\Primeiro_Contato\Primeiro_Contato\bin\Resources\icons8-briefcase-32.png");
        public Image imagem_lost = Image.FromFile(@"C:\Users\murphys_dev\source\repos\Primeiro_Contato\Primeiro_Contato\bin\Resources\icons8-cancel-32.png");


        public Form1()
        {
            
            driver.Navigate().GoToUrl("https://web.whatsapp.com/");
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void open_file_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFD = new OpenFileDialog();
            if (openFD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string strfilename = openFD.FileName;
                labelarquivo.Text = (strfilename);
                labelarquivo.ForeColor = System.Drawing.Color.Green;
                if (strfilename.EndsWith(".xlsx"))
                {
                    labelarquivo.Text = (strfilename);
                    labelarquivo.ForeColor = System.Drawing.Color.Green;
                    var wbook = new XLWorkbook(strfilename);
                    var workSh = wbook.Worksheet(Convert.ToInt32(cont.Text)).RowsUsed();

                    foreach (var celula in workSh)
                    {
                        if (celula.Cell(3).Value.ToString() == "n")
                        {
                            //Adiciona os nomes da primeira fileira
                            nomes.Add(celula.Cell(1).Value.ToString());

                            //Testa se a string contém um numero
                            if (Regex.IsMatch(celula.Cell(2).Value.ToString(), @"^[0-9]+$"))
                            {
                                //adiciona o valor da celula na lista
                                numeros.Add((celula.Cell(2).Value).ToString());
                            }
                            else { numeros.Add(""); }

                            feitoounao.Add(celula.Cell(3).Value.ToString());
                            
                        }
                    }
                    
                    
                }
                else 
                { 
                    labelarquivo.Text = "Por favor adicione um documento .xlsx(Referente a planilha)";
                    labelarquivo.ForeColor = System.Drawing.Color.Red;
                }
            }
            

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
         

        }

        private void button_enviar_Click(object sender, EventArgs e)
        {
            
            
            if (richTextBox1.Text != "")
            {
                if (labelarquivo.Text.EndsWith(".xlsx"))
                {

                    for (int i = 0; i < numeros.Count; i++)
                    {
                        if (feitoounao[i] == "n")
                        {
                            try
                            {
                                enviar(driver, numeros[i], nomes[i], richTextBox1.Text);

                            }
                            catch
                            {
                                labelimagem.Image = imagem_lost;
                            }
                            
                            feitoounao[i] = "ok";
                            
                        }
                    }
                    Atualizar();

                }
                else { MessageBox.Show("Você deve escolher o arquivo .xlsx"); }


            }
            else { MessageBox.Show("Você deve digitar o texto primeiro!"); }
                
        }
        private void enviar(IWebDriver driver, string numero,string nome, string mensagem)
        {
            if (mensagem.Contains("@nome"))
            {
               mensagem = mensagem.Replace("@nome", nome);
                
            }
            mensagem = Uri.EscapeDataString(mensagem);
            string link = "https://web.whatsapp.com/send?phone=" + numero + "&text=" + mensagem;
            
            labelnumero.Text = numero;
            labelnome.Text = nome;

            labelimagem.Image = imagem_maleta;
            




            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
            driver.Navigate().GoToUrl(link);

            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(25);
                driver.FindElement(By.XPath("//*[@id=\"main\"]/footer/div[1]/div/span[2]/div/div[2]/div[2]/button/span")).Click();
                
            
            }
            catch
            {
                //driver.FindElement(By.XPath("//*[@id=\"main\"]/footer/div[1]/div/span[2]/div/div[2]/div[2]/button/span")).Click();
                driver.FindElement(By.XPath("/html/body/div[1]/div/span[2]/div/span/div/div/div/div/div/div[2]/div/div")).Click();
                Console.WriteLine("O número {0} não tem Whatsapp", numero);
            }
            labelimagem.Image = imagem_done;
            Thread.Sleep(2000);
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Atualizar();
        }
        private void Atualizar()
        {
            if (labelarquivo.Text.EndsWith(".xlsx"))
            {
                int contador = 0;
                var wbook = new XLWorkbook(labelarquivo.Text);
                var workSh = wbook.Worksheet(Convert.ToInt32(cont.Text)).RowsUsed();
                foreach (var celula in workSh)
                {
                    if (celula.Cell(3).Value.ToString() == "n")
                    {
                        if (celula.Cell(3).Value.ToString() != feitoounao[contador])
                        {
                            celula.Cell(3).Value = "ok";
                        }
                        contador++;

                    }
                }
                wbook.Save();
            }
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void labelnumero_Click(object sender, EventArgs e)
        {

        }

        private void labelnome_Click(object sender, EventArgs e)
        {

        }

        private void cont_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void labelimagem_Click(object sender, EventArgs e)
        {

        }
    }
}               
