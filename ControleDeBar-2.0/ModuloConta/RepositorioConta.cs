using ControleDeBar.ConsoleApp.Compartilhado;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloConta
{
    public class RepositorioConta : RepositorioBase<Conta>
    {
        public RepositorioConta(List<Conta> listaContas)
        {
            listaRegistros = listaContas;
        }

        public List<Conta> SelecionarContasEmAberto()
        {
            List<Conta> contasEmAberto = new List<Conta>();

            foreach (Conta conta in listaRegistros)
            {
                if (conta.estaAberta)
                    contasEmAberto.Add(conta);
            }

            return contasEmAberto;
        }

        public List<Conta> SelecionarContasFechadas(DateTime data)
        {
            List<Conta> contasEmAberto = new List<Conta>();

            foreach (Conta conta in listaRegistros)
            {
                if (conta.estaAberta == false && conta.data.Date == data.Date)
                    contasEmAberto.Add(conta);
            }

            return contasEmAberto;
        }
    }
}
