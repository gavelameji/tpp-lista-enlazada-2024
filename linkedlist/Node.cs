using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linkedlist
{
    internal class Node<T>
    {
        // Contenido del nodo
        internal T Data { get; set; }

        // Referencia al siguiente nodo (simplemente enlazada).
        internal Node<T> Next { get; set; }

        // Constructor, le pasamos el contenido.
        internal Node(T data) 
        {
            this.Data = data;
            this.Next = null;
        
        }

    }
}
