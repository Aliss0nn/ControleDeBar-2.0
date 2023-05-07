using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.ConsoleApp.ModuloConta;
using ControleDeBar.ConsoleApp.ModuloGarcom;
using ControleDeBar.ConsoleApp.ModuloMesa;
using ControleDeBar.ConsoleApp.ModuloProduto;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloPrincipal
{
    public class TelaPrincipal
    {
        private TelaMesa telaMesa;
        private TelaProduto telaProduto;
        private TelaGarcom telaGarcom;
        private TelaConta telaConta;

        public TelaPrincipal()
        {
            RepositorioMesa repositorioMesa = new RepositorioMesa(new List<Mesa>());
            RepositorioProduto repoositorioProduto = new RepositorioProduto(new List<Produto>());
            RepositorioGarcom repositorioGarcom = new RepositorioGarcom(new List<Garcom>());
            RepositorioConta repositorioConta = new RepositorioConta(new List<Conta>());

            PopularAplicacao(repositorioMesa, repoositorioProduto, repositorioGarcom);

            telaMesa = new TelaMesa(repositorioMesa);
            telaProduto = new TelaProduto(repoositorioProduto);
            telaGarcom = new TelaGarcom(repositorioGarcom);

            telaConta = new TelaConta(repositorioConta, telaMesa, telaGarcom, telaProduto);
        }

        public string ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine("Controle de Bar\n");

            Console.WriteLine("Digite 1 para Cadastrar Mesas");
            Console.WriteLine("Digite 2 para Cadastrar Produtos");
            Console.WriteLine("Digite 3 para Cadastrar Garçons");
            Console.WriteLine("Digite 4 para Cadastrar Contas");

            Console.WriteLine("Digite s para Sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public ITelaCadastravel SelecionarTela()
        {
            string opcao = ApresentarMenu();

            if (opcao == "1")
                return telaMesa;

            else if (opcao == "2")
                return telaProduto;

            else if (opcao == "3")
                return telaGarcom;

            else if (opcao == "4")
                return telaConta;

            else
                return null;
        }

        private static void PopularAplicacao(RepositorioMesa repositorioMesa,
          RepositorioProduto repoositorioProduto, RepositorioGarcom repositorioGarcom)
        {
            Produto produto01 = new Produto("Batata Frita", 30);
            Produto produto03 = new Produto("Cerveja", 10);
            Produto produto02 = new Produto("Poleta Frita", 25);
            Produto produto04 = new Produto("Água", 4);

            Garcom garcom01 = new Garcom("Gabriel Toledo");
            Garcom garcom02 = new Garcom("Fernando Alvarenga");

            Mesa mesa01 = new Mesa("01");
            Mesa mesa02 = new Mesa("02");

            repoositorioProduto.Inserir(produto01);
            repoositorioProduto.Inserir(produto02);
            repoositorioProduto.Inserir(produto03);
            repoositorioProduto.Inserir(produto04);

            repositorioMesa.Inserir(mesa01);
            repositorioMesa.Inserir(mesa02);

            repositorioGarcom.Inserir(garcom01);
            repositorioGarcom.Inserir(garcom02);
        }
    }
}