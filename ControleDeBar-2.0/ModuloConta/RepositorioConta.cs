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
            return listaRegistros.FindAll(conta => conta.estaAberta);        
        }

        public List<Conta> SelecionarContasFechadas(DateTime data)
        {
            return listaRegistros.FindAll(c => c.estaAberta == false && c.data.Date == data.Date);          
        }
    }
}
