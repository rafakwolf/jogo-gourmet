using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            // Inicio da árvore com as perguntas iniciais

            Node root = new Questao(null, null, "é uma massa");
            root.SetRightChild(new Prato(null, null, "Lasanha"));
            root.SetLeftChild(new Prato(null, null, "Bolo de Chocolate"));

            DialogResult devoContinuar = DialogResult.OK;

            while (devoContinuar == DialogResult.OK)
            {
                devoContinuar = MessageBox.Show(@"Pense em um prato que você gosta...", @"Jogo Gourmet", MessageBoxButtons.OKCancel);

                if (devoContinuar == DialogResult.OK)
                    // Iniando o jogo
                    root.NextNode(0, null);
            }
        }
    }
}
