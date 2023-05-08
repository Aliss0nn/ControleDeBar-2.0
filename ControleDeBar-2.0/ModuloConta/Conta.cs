using ControleDeBar.ConsoleApp.Compartilhado;

using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloConta
{
    public class Conta : EntidadeBase<Conta>
    {
        public Mesa mesa;
        public ArrayList pedidos;
        public Garcom garcom;
        public bool estaAberta;

        public DateTime data;

        public Conta(Mesa m, Garcom g, DateTime dataAbertura)
        {
            mesa = m;
            garcom = g;
            pedidos = new ArrayList();
            data = dataAbertura;

            Abrir();
        }

        public void RegistrarPedido(Produto produto, int quantidadeEscolhida)
        {
            Pedido novoPedido = new Pedido(produto, quantidadeEscolhida);

            pedidos.Add(novoPedido);
        }

        public decimal CalcularValorTotal()
        {
            decimal total = 0;

            foreach (Pedido pedido in pedidos)
            {
                decimal totalPedido = pedido.CalcularTotalParcial();

                total += totalPedido;
            }

            return total;
        }

        public override void AtualizarInformacoes(Conta contaAtualizada)
        {
            garcom = contaAtualizada.garcom;
            mesa = contaAtualizada.mesa;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (garcom == null)
            {
                erros.Add("O campo \"Garçom\" é obrigatorio");
            }

            if (mesa == null)
            {
                erros.Add("O campo \"Mesa\" é obrigatorio");
            }

            return erros;
        }

        private void Abrir()
        {
            estaAberta = true;
            mesa.Ocupar();
        }

        public void Fechar()
        {
            estaAberta = false;
            mesa.Desocupar();
        }
    }
}