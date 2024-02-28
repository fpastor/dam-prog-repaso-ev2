
namespace repasoProgEV2
{
    public class repasoGenericos
    {
        public class Node<T>
        {
            private double _id;
            private string _name = string.Empty;
            private List<T>? _children;
            private Node<T>? _parent;

            public double Id
            {
                get
                {
                    return _id;
                }
            }

            public string Name
            {
                get
                {
                    return _name;
                }
            }

            public Node<T>? Parent
            {
                get
                {
                    return _parent;
                }
                set
                {
                    _parent = value;
                }
            }





        }
    }
}
