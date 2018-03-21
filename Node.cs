namespace WindowsFormsApp1
{
    public abstract class Node
    {

        private Node _leftChild;
        private Node _rightChild;
        private string _content;


        public Node(Node left, Node right, string content)
        {
            this._leftChild = left;
            this._rightChild = right;
            this._content = content;
        }

        public abstract int GetAnswer();

        public abstract void NextNode(int lastOption, Node parent);


        public Node GetLeftChild()
        {
            return _leftChild;
        }

        public void SetLeftChild(Node leftChild)
        {
            this._leftChild = leftChild;
        }

        public Node GetRightChild()
        {
            return _rightChild;
        }

        public void SetRightChild(Node rightChild)
        {
            this._rightChild = rightChild;
        }

        public string getContent()
        {
            return _content;
        }

        public void SetContent(string content)
        {
            this._content = content;
        }

    }
}