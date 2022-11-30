class Node<T> where T : struct
{
    private T value;
    private Node<T> next = null;
    private Node<T> child = null;

    public Node(T value)
    {
        this.SetValue(value);
    }

    public void SetNext(Node<T> next)
    {
        this.next = next;
    }

    public void SetChild(Node<T> child)
    {
        this.child = child;
    }

    public Node<T> Next()
    {
        return this.next;
    }

    public Node<T> Child()
    {
        return this.child;
    }

    public T GetValue()
    {
        return this.value;
    }

    public void SetValue(T value)
    {
        this.value = value;
    }
}