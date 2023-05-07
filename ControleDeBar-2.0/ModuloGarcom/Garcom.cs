using ControleDeBar.ConsoleApp.Compartilhado;
using System.Collections;

namespace ControleDeBar.ConsoleApp.ModuloGarcom
{
    public class Garcom : EntidadeBase<Garcom>
    {
        public string nome { get; set; }

        public Garcom(string nomeGarcom)
        {
            this.nome = nomeGarcom;
        }

        public override void AtualizarInformacoes(Garcom garcomAtualizado)
        {

            this.nome = garcomAtualizado.nome;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(nome.Trim()))
            {
                erros.Add("O campo \"Nome\" é obrigatório");
            }

            return erros;
        }
    }
}
