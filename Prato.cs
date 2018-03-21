using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class Prato: Node
    {
        public Prato(Node left, Node right, string nomePrato): base(left, right, nomePrato)
        {
        }

        // Este método é usado para obter a resposta do usuário.
        public override int GetAnswer()
        {
            var mensagemPergunta = "O prato que você pensou é " + this.getContent() + "?";

            return (int)MessageBox.Show(mensagemPergunta, @"Jogo Gourmet", MessageBoxButtons.YesNo);
        }

        public override void NextNode(int lastOption, Node parent)
        {
            var answer = this.GetAnswer();

            if (answer == (int)DialogResult.Yes)
            {
                MessageBox.Show(@"Acertei!!!", @"Jogo Gourmet");
            }
            else
            {
                // Pega o prato que o jogador pensou

                var resposta = "";
                InputBox.Show(@"Jogo Gourmet", "Qual o prato que você pensou?", ref resposta);

                var acao = "";
                InputBox.Show(@"Jogo Gourmet", "E " + resposta +" é _____ mas " +this.getContent() +" não é...",ref acao);

                if (string.IsNullOrEmpty(acao) || string.IsNullOrEmpty(resposta))
                {
                    const string message = "Por gentileza, você de informar os dados :D !\n"
                                           + "Vamos voltar para o início sem cadastrar seu prato.";
                    MessageBox.Show(message, @"Jogo Gourmet");
                    return;
                }

                // Adiciona um noto prato na árvore

                var novoPrato = new Prato(null, null, resposta);

                if (lastOption == (int)DialogResult.Yes)
                {
                    // Última resposta SIM
                    parent.SetRightChild(new Questao(this, novoPrato, acao));
                }
                else
                {
                    parent.SetLeftChild(new Questao(this, novoPrato, acao));
                }
            }
        }
    }
}