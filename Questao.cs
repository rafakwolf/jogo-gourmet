using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class Questao: Node
    {
        public Questao(Node left, Node right, string content) : base(left, right, content)
        {
        }

        // obtendo a resposta
        public override int GetAnswer()
        {
            var mensagemPergunta = "O prato que você pensou " + this.getContent() + "?";

            return (int)MessageBox.Show(mensagemPergunta, @"Jogo Gourmet", MessageBoxButtons.YesNo);
        }

        // Se resposta SIM usa o nó da direita, caso contrário da esquerda
        public override void NextNode(int lastOption, Node parent)
        {
            var answer = this.GetAnswer();

            if (answer == (int)DialogResult.Yes)
            {
                this.GetRightChild().NextNode(answer, this);
            }
            else
            {
                this.GetLeftChild().NextNode(answer, this);
            }
        }
    }
}