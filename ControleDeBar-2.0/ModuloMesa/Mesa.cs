using ControleDeBar.ConsoleApp.Compartilhado;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloMesa
{
    public class Mesa : EntidadeBase<Mesa>
    {
        public string numero;
        public bool ocupada;

        public Mesa(string numeroMesa)
        {
            numero = numeroMesa;
        }

        public override void AtualizarInformacoes(Mesa mesaAtualizada)
        {

            this.numero = mesaAtualizada.numero;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(numero.Trim()))
            {
                erros.Add("O campo \"Número da Mesa\" é obrigatorio");
            }
            return erros;
        }

        public void Desocupar()
        {
            ocupada = false;
        }

        public void Ocupar()
        {
            ocupada = true;
        }
    }
}
