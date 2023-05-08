namespace ControleDeBar.ConsoleApp.ModuloConta
{
    public class TelaConta : TelaBase<RepositorioConta, Conta>
    {
        private RepositorioConta repositorioConta;

        private TelaMesa telaMesa;
        private TelaGarcom telaGarcom;
        private TelaProduto telaProduto;
        public TelaConta(RepositorioConta repositorioConta,
            TelaMesa telaMesa, TelaGarcom telaGarcom, TelaProduto telaProduto)
        {
            this.repositorioBase = repositorioConta;
            this.repositorioConta = repositorioConta;

            this.telaMesa = telaMesa;
            this.telaGarcom = telaGarcom;
            this.telaProduto = telaProduto;

            nomeEntidade = "Conta";
            sufixo = "s";
        }

        public override string ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine("Cadastro de Contas \n");

            Console.WriteLine("Digite 1 para Abrir Nova Conta");
            Console.WriteLine("Digite 2 para Registrar Pedidos");
            Console.WriteLine("Digite 3 para Fechar Conta");
            Console.WriteLine("Digite 4 para Visualizar Contas Abertas");

            Console.WriteLine("Digite 5 para Visualizar Faturamento do Dia");

            Console.WriteLine("Digite s para Sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public void AbrirNovaConta()
        {
            MostrarCabecalho($"Cadastro de {nomeEntidade}{sufixo}", "Inserindo um novo registro...");

            Conta conta = (Conta)ObterRegistro();

            if (TemErrosDeValidacao(conta))
            {
                AbrirNovaConta(); //chamada recursiva

                return;
            }

            repositorioBase.Inserir(conta);

            AdicionarPedidos(conta);

            MostrarMensagem("Registro inserido com sucesso!", ConsoleColor.Green);
        }

        public bool VisualizarContasAbertas()
        {
            MostrarCabecalho($"Cadastro de {nomeEntidade}{sufixo}", "Visualizando contas em aberto...");

            List<Conta> contasEmAberto = repositorioConta.SelecionarContasEmAberto();

            if (contasEmAberto.Count == 0)
            {
                MostrarMensagem("Nenhuma conta em aberto", ConsoleColor.DarkYellow);
                return false;
            }

            MostrarTabela(contasEmAberto);

            return contasEmAberto.Count > 0;
        }

        public void RegistrarPedidos()
        {
            MostrarCabecalho($"Cadastro de {nomeEntidade}{sufixo}", "Registrando pedidos...");

            bool temContasEmAberto = VisualizarContasAbertas();

            if (temContasEmAberto == false)
                return;

            Conta contaSelecionada = (Conta)EncontrarRegistro("Digite o id da Conta: ");

            Console.WriteLine("Digite 1 para adicionar pedidos");
            Console.WriteLine("Digite 2 para remover pedidos");

            string opcao = Console.ReadLine();

            if (opcao == "1")
                AdicionarPedidos(contaSelecionada);

            else if (opcao == "2")
                RemoverPedidos(contaSelecionada);
        }

        public void FecharConta()
        {
            MostrarCabecalho($"Cadastro de {nomeEntidade}{sufixo}", "Fechando contas...");

            bool temContasEmAberto = VisualizarContasAbertas();

            if (temContasEmAberto == false)
                return;

            Conta contaSelecionada = (Conta)EncontrarRegistro("Digite o id da Conta: ");

            contaSelecionada.Fechar();

            MostrarMensagem("Conta fechada com sucesso", ConsoleColor.Green);
        }

        public void VisualizarFaturamentoDoDia()
        {
            MostrarCabecalho($"Cadastro de {nomeEntidade}{sufixo}", "Visualizando faturamento do dia...");

            Console.WriteLine("Digite a data: ");
            DateTime data = Convert.ToDateTime(Console.ReadLine());

            List<Conta> contasFechadasNoDia = repositorioConta.SelecionarContasFechadas(data);

            FaturamentoDiario faturamentoDiario = new FaturamentoDiario(contasFechadasNoDia);

            decimal totalFaturado = faturamentoDiario.CalcularTotal();

            Console.WriteLine("Contas fechadas na data: " + data.ToShortDateString());

            MostrarTabela(contasFechadasNoDia);

            Console.WriteLine();

            MostrarMensagem("Total faturado: " + totalFaturado, ConsoleColor.Green);
        }

        #region métodos privados

        protected override void MostrarTabela(List<Conta> registros)
        {
            foreach (Conta conta in registros)
            {
                Console.WriteLine("Conta: " + conta.id + ", Mesa: " + conta.mesa.numero + ", Garçom: " + conta.garcom.nome);
                Console.WriteLine();
                foreach (Pedido pedido in conta.pedidos)
                {
                    Console.WriteLine("\tProduto: " + pedido.produto.nome + ", Qtd: " + pedido.quantidadeSolicitada);
                }

                Console.WriteLine("------------------------------------------------------\n");
            }
        }

        protected override Conta ObterRegistro()
        {
            Mesa mesaSelecionada = ObterMesa();

            Garcom garcomSelecionado = ObterGarcom();

            Console.Write("Digite a data: ");

            DateTime dataAbertura = Convert.ToDateTime(Console.ReadLine());

            return new Conta(mesaSelecionada, garcomSelecionado, dataAbertura);
        }


        private void AdicionarPedidos(Conta contaSelecionada)
        {
            Console.WriteLine("Selecionar produtos? [s] ou [n]");

            Console.Write(" -> ");

            string opcao = Console.ReadLine();

            while (opcao == "s")
            {
                Produto produto = ObterProduto();

                Console.Write("Digite a quantidade: ");
                int quantidade = Convert.ToInt32(Console.ReadLine());

                contaSelecionada.RegistrarPedido(produto, quantidade);

                Console.WriteLine("Selecionar mais produtos? [s] ou [n]");

                Console.Write(" -> ");

                opcao = Console.ReadLine();
            }
        }

        private Produto ObterProduto()
        {
            telaProduto.VisualizarRegistros(false);

            Produto produto = (Produto)telaProduto.EncontrarRegistro("Digite o id do Produto: ");

            Console.WriteLine();

            return produto;
        }

        private void RemoverPedidos(Conta contaSelecionada)
        {
            int id = 0;

            if (contaSelecionada.pedidos.Count == 0)
            {
                MostrarMensagem("Nenhum pedido cadastrado para esta conta", ConsoleColor.DarkYellow);
                return;
            }
        }

        private Garcom ObterGarcom()
        {
            telaGarcom.VisualizarRegistros(false);

            Garcom garcomSelecionado = (Garcom)telaGarcom.EncontrarRegistro("Digite o id do Garçom: ");

            Console.WriteLine();

            return garcomSelecionado;
        }

        private Mesa ObterMesa()
        {
            telaMesa.VisualizarRegistros(false);

            Mesa mesaSelecionada = (Mesa)telaMesa.EncontrarRegistro("Digite o id da Mesa: ");

            Console.WriteLine();

            return mesaSelecionada;
        }


        #endregion
    }
}