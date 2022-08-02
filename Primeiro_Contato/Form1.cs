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
        //Variavel que ficara com os nomes dos contatos
        public List<string> nomes = new List<string> { };
        
        //Variavel que segura a situação do numero referente a leitura
        public List<string> feitoounao = new List<string> { };
        
        //Variavel que ficara com os numeros dos contatos
        public List<string> numeros = new List<string> { };

        //variaveis de imagens que serão usadas em diferentes momentos do codigo
        public Image imagem_enviar = Image.FromFile(@"C:\Users\murphys_dev\source\repos\Primeiro_Contato\Primeiro_Contato\bin\Resources\icons8-email-send-32.png");
        public Image imagem_cancel = Image.FromFile(@"C:\Users\murphys_dev\source\repos\Primeiro_Contato\Primeiro_Contato\bin\Resources\icons8-cancel_bt-32.png");
        public Image imagem_done = Image.FromFile(@"C:\Users\murphys_dev\source\repos\Primeiro_Contato\Primeiro_Contato\bin\Resources\icons8-checkmark-32.png");
        public Image imagem_maleta = Image.FromFile(@"C:\Users\murphys_dev\source\repos\Primeiro_Contato\Primeiro_Contato\bin\Resources\icons8-briefcase-32.png");
        public Image imagem_lost = Image.FromFile(@"C:\Users\murphys_dev\source\repos\Primeiro_Contato\Primeiro_Contato\bin\Resources\icons8-cancel-32.png");
        
        //variavel para identificar o estado do button1(enviar) 
        public bool start = true;

        //inicia o navegador
        public IWebDriver driver = new ChromeDriver();
        
        public Form1()
        {
            //navega para whatsapp
            driver.Navigate().GoToUrl("https://web.whatsapp.com/");
            
            //inicializa os componentes 
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //Descobre e faz a checagem do caminho/arquivo
        public void open_file_Click(object sender, EventArgs e)
        {
            //Janela de pesquisa
            OpenFileDialog openFD = new OpenFileDialog();
            
            //Caso ache selecione um arquivo
            if (openFD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //path em string
                string strfilename = openFD.FileName;

                //indentifica se é um arquivo xlsx
                if (strfilename.EndsWith(".xlsx"))
                {
                    //mostra o arquivo ao usuario
                    labelarquivo.Text = (strfilename);
                    labelarquivo.ForeColor = System.Drawing.Color.Green;
                    
                    //chama metodo para entrada de dados contidos no xlsx
                    Atualizar_lista();
                }
                else 
                {
                    //se não for um xlsx mostra ao usuario e não da continuidade
                    labelarquivo.Text = "Por favor adicione um documento .xlsx(Referente a planilha)";
                    labelarquivo.ForeColor = System.Drawing.Color.Red;
                }
            }
            

        }
        
        //Adiciona os dados do xlsx as variaveis
        private void Atualizar_lista()
        {
            //processa a planilha escolhida
            var wbook = new XLWorkbook(labelarquivo.Text);

            //cria uma lista contendo apenas as celulas com dados
            var workSh = wbook.Worksheet(Convert.ToInt32(cont.Text)).RowsUsed();

            //trabalha com cada linha usada
            foreach (var celula in workSh)
            {
                //Testa se o arquivo ainda não passou pelo processo
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
                    else 
                    { 
                        //se não contiver numero adiciona um espaço em branco
                        numeros.Add(""); 
                    }
                    //adiciona o valor da situação da celular
                    feitoounao.Add(celula.Cell(3).Value.ToString());

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

        private async void button_enviar_Click(object sender, EventArgs e)
        {
            //Testa o botão e descobre seu estado
            if (start)
            {
                //testa se a caixa de mensagem está vazia
                if (richTextBox1.Text != "")
                {
                    //testa se foi adicionado o arquivo correto
                    if (labelarquivo.Text.EndsWith(".xlsx"))
                    {
                        //muda a estetica e estado do botão
                        button_enviar.Image = imagem_cancel;
                        button_enviar.ForeColor = System.Drawing.Color.Red;
                        button_enviar.Text = "Cancelar";
                        start = false;

                        //inicia o envio de mensagens
                        await IniciarEnvioAsync();

                    }
                    else { MessageBox.Show("Você deve escolher o arquivo .xlsx"); }


                }
                else { MessageBox.Show("Você deve digitar o texto primeiro!"); }
            }
            else
            {
                //muda a estetica do botão
                button_enviar.Image = imagem_enviar;
                button_enviar.ForeColor = System.Drawing.Color.Black;
                button_enviar.Text = "Enviar";
                start = true;
                
                //atualiza os numeros já enviados
                Atualizar();
                
                //limpas as listas atuais
                nomes.Clear();
                numeros.Clear();
                feitoounao.Clear();    
                
                //carrega o arquivo atualizado 
                Atualizar_lista();
            }
        }
        private async Task IniciarEnvioAsync()
        {
            //variavel de saida da função
            string contexto;
            
            //mensagem escrita pelo usuario
            string mensagem = richTextBox1.Text;

            //para cada numero na lista 
            for (int i = 0; i < numeros.Count; i++)
            {
                //se variavel de teste == n
                if (feitoounao[i] == "n")
                {
                    //Passa pela função 
                    try
                    {
                        //Espera para não pular contato
                        await Task.Delay(2000);

                        //adiciona o ultimo numero trabalhado para o usuario
                        labelnumero.Text = numeros[i];
                        labelnome.Text = nomes[i];
                        labelimagem.Image = imagem_maleta;

                        //retorna se o número teve sucesso e foi enviado
                        contexto = await Task.Run(() => enviar(driver, numeros[i], nomes[i], mensagem));

                        //atualiza o contexeto do numero referente a tabela
                        feitoounao[i] = contexto;
                        
                        //Mostra ao usuario o resultado do numero
                        if (contexto == "Ok") {
                            labelimagem.Image = imagem_done;
                        }
                        else
                        {
                            labelimagem.Image = imagem_lost;
                        }
                    }
                    //Caso não consiga enviar de forma alguma adiciona ao número o problema
                    catch
                    {
                        
                        labelimagem.Image = imagem_lost;
                        feitoounao[i] = "n";
                        await Task.Delay(2000);

                        
                    }

                    //Quando termina o laço atualiza a tabela para refazer caso necessario 
                    Atualizar();
                    nomes.Clear();
                    numeros.Clear();
                    feitoounao.Clear();
                    Atualizar_lista();

                    //atualiza botão 
                    button_enviar.Image = imagem_enviar;
                    button_enviar.ForeColor = System.Drawing.Color.Black;
                    button_enviar.Text = "Enviar";
                    start = true;
                }

            }
        }
        private async Task<string> enviar(IWebDriver driver, string numero,string nome, string mensagem)
        {
            //Adiciona o nome do contato caso esteja na mensagem
            if (mensagem.Contains("@nome"))
            {
               mensagem = mensagem.Replace("@nome", nome);
                
            }

            //transforma a mensagem e url
            mensagem = Uri.EscapeDataString(mensagem);
            
            //gera o link para acessar o whatsapp do contato especifico
            string link = "https://web.whatsapp.com/send?phone=" + numero + "&text=" + mensagem;

            //espera até o link carregar
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
            
            //entra no link
            driver.Navigate().GoToUrl(link);
            
            //tenta clicar no botão de enviar
            try
            {
                //espera até o botão carregar
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

                //caminho do botão 
                driver.FindElement(By.XPath("//*[@id=\"main\"]/footer/div[1]/div/span[2]/div/div[2]/div[2]/button/span")).Click();
                
                //retorna contexto do numero
                return "Ok";
            
            }
            //Caso o contato não tenha whatsapp retorna n para nova tentativa e ou analise
            catch
            {
                //tenta tocar no botão ok 
                driver.FindElement(By.XPath("/html/body/div[1]/div/span[2]/div/span/div/div/div/div/div/div[2]/div/div")).Click();
                return "n";
            }
            
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //ao fechar a form1 atualiza a lista com os contatos ja enviados
            Atualizar();
        }
        private void Atualizar()
        {
            // se o arquivo for xlsx
            if (labelarquivo.Text.EndsWith(".xlsx"))
            {
                //inicia um contador
                int contador = 0;
                
                //abre o arquivo novamente(colocar varivel para receber e guardar o primeiro arquivo escolhido ou travar botão antes do envio terminar
                var wbook = new XLWorkbook(labelarquivo.Text);
                
                //recebe as rows utilizadas
                var workSh = wbook.Worksheet(Convert.ToInt32(cont.Text)).RowsUsed();
                
                foreach (var celula in workSh)
                {
                    //faz os processos somente com os arquivo que antes tinha 'n'
                    if (celula.Cell(3).Value.ToString() == "n")
                    {
                        //se valor do contexto em tabela for diferente do valor de contexto na lista 
                        if (celula.Cell(3).Value.ToString() != feitoounao[contador])
                        {
                            //muda o valor do arquivo para ok
                            celula.Cell(3).Value = "ok";
                        }
                        //aumenta a o contador
                        contador++;

                    }
                }
                //salva a tabela
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
