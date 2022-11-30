class Tree<T> where T : struct
{
    private Node<T> root = null;
    private int length = 0;

    public void AddSibling(int index, T value)
    {
        Node<T> node = new Node<T>(value);
        Node<T> ptr = this.GetNode(index);
        node.SetNext(ptr.Next());
        ptr.SetNext(node);
        this.length++;
    }

    public void AddChild(int index, T value)
    {
        Node<T> node = new Node<T>(value);
        if(index == -1)
        {
            node.SetChild(this.root);
            this.root = node;
        }
        else
        {
            Node<T> ptr = this.GetNode(index);
            node.SetChild(ptr.Child());
            ptr.SetChild(node);
        }
        this.length++;
    }

    public void Remove(int index)
    {
        if(index == 0)
        {
            Node<T> ptr = this.root;
            this.root = ptr.Child();
            if(this.root.Next() != null)
            {
                this.root.SetChild(this.root.Next());
                this.root.SetNext(null);
            }
        }
        else
        {
            Node<T> previousPtr = this.GetNode(index-1);
            if(previousPtr.Child() != null)
            {
                Node<T> ptr = previousPtr.Child();
                previousPtr.SetChild(ptr.Child());

                if(ptr.Child() != null)
                {
                    Node<T> childSiblingPtr = ptr.Child();
                    while(childSiblingPtr.Next() != null)
                    {
                        childSiblingPtr = childSiblingPtr.Next();
                    }
                    childSiblingPtr.SetNext(ptr.Next());
                }
            }
            else
            {
                Node<T> ptr = previousPtr.Next();

                if(ptr.Child() != null)
                {
                    previousPtr.SetNext(ptr.Child());
                    Node<T> childSiblingPtr = ptr.Child();
                    while(childSiblingPtr.Next() != null)
                    {
                        childSiblingPtr = childSiblingPtr.Next();
                    }
                    childSiblingPtr.SetNext(ptr.Next());
                }
                else
                {
                    previousPtr.SetNext(ptr.Next());
                }
            }
        }
        this.length--;
    }

    public int GetLength()
    {
        return this.length;
    }

    public T Get(int index)
    {
        Node<T> ptr = this.GetNode(index);
        return ptr.GetValue();
    }

    private Node<T> GetNode(int index)
    {
        int traverseStep = index;
        return this.Traverse(this.root, ref traverseStep);
    }

    private Node<T> Traverse(Node<T> currentNode, ref int traverseStep)
    {
        Node<T> ptr = currentNode;

        if(traverseStep > 0 && currentNode.Child() != null)
        {
            traverseStep--;
            ptr = this.Traverse(currentNode.Child(), ref traverseStep);
        }

        if(traverseStep > 0 && currentNode.Next() != null)
        {
            traverseStep--;
            ptr = this.Traverse(currentNode.Next(), ref traverseStep);
        }

        return ptr;
    }
}