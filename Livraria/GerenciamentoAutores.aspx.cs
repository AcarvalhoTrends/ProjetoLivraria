using ProjetoLivraria.DAO;
using ProjetoLivraria.Models;
using System;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace ProjetoLivraria.Livraria
{
    public partial class GerenciamentoAutores : Page
    {
        //Criando uma variável de instância de AutoresDAO (para não precisar instanciar uma todas as vezes que for usar).
        AutoresDAO ioAutoresDAO = new AutoresDAO();

        //Utilizando uma ViewState, como uma propriedade privada da classe, para armazenar a lista de autores cadastrados.
        public BindingList<Autores> ListaAutores
        {
            get
            {
                //Caso a ViewState esteja vazia, chama o método CarregaDados() para preencher os autores.
                if ((BindingList<Autores>)ViewState["ViewStateListaAutores"] == null)
                    this.CarregaDados();
                // Retorna o conteúdo da ViewState.
                return (BindingList<Autores>)ViewState["ViewStateListaAutores"];
            }
            set
            {
                ViewState["ViewStateListaAutores"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void CarregaDados()
        {
            //Chamando o método BuscaAutores para salvar os autores cadastrados na ViewState.
            this.ListaAutores = this.ioAutoresDAO.BuscaAutores();
        }

        //Criando o método BtnNovoAutor_Click descrito na propriedade OnClick deste botão no arquivo .aspx).
        protected void BtnNovoAutor_Click(object sender, EventArgs e)
        {
            try
            {
                //Utilizando o Linq para obter o maior ID de autores cadastrados e incrementando o valor em 1
                //para garantir que a chave primária não se repita (esse campo não é auto-increment no banco).
                decimal ldcIdAutor = this.ListaAutores.OrderByDescending(a => a.aut_id_autor).First().aut_id_autor + 1;
                //Salvando os valores que o usuário preencheu em cada campo do formulário (utilizando o "this.NomeDoControle"
                //é possível recuperar o controle e acessar suas propriedades, isso é possível pois todo controle ASP tem
                //um ID único na página e deve ser marcado como runat="server" para virar um "ServerControl" e ser acessível
                //aqui no "CodeBehind" da página.
                string autNmNome = this.tbxCadastroNomeAutor.Text;
                string autNmSobrenome = this.tbxCadastroSobrenomeAutor.Text;
                string autDsEmail = this.tbxCadastroEmailAutor.Text;
                //Instanciando um objeto do tipo Autores para ser adicionado (perceba que só existe um construtor para essa classe
                //onde devem ser passados todos os valores, fizemos isso como mais uma forma de garantir que não será possível
                //cadastrar autores com informações faltando, mesmo que o banco permita isso - além do RequiredFieldValidator).
                Autores loAutor = new Autores(ldcIdAutor, autNmNome, autNmSobrenome, autDsEmail);
                //Chamando o método de inserir o novo autor na base de dados.
                this.ioAutoresDAO.insereAutores(loAutor);
                //Atualizando a ViewState com o novo autor recém-inserido.
                this.CarregaDados();
                HttpContext.Current.Response.Write("<script>alert('Autor cadastrado com sucesso!');</script>");
            }
            catch
            {
                HttpContext.Current.Response.Write("<script>alert('Erro no cadastro do Autor.');</script>");
            }
            //Limpando os campos do formulário.
            this.tbxCadastroNomeAutor.Text = String.Empty;
            this.tbxCadastroSobrenomeAutor.Text = String.Empty;
            this.tbxCadastroEmailAutor.Text = String.Empty;
        }
    }
}