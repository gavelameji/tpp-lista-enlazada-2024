using System;
using System.Drawing;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Xml.Linq;
using System.Collections;
using System.Collections.Generic;


namespace linkedlist
{
    public class Lista<T> : IEnumerable<T>
    {

        private int _numeroElementos;
        private Node<T> _head;

        // Propiedad de solo lectura.
        public int NumeroElementos { get { return _numeroElementos; } }

        // Añadir un elemento (al final).
        public void Anadir(T data)
        {
            if(data == null) throw new ArgumentNullException("data");
            Node<T> newNode = new Node<T>(data);
            if (_head == null)
            {
                _head = newNode;
                _numeroElementos = 1;
                return;
            }
            GetUltimoNodo().Next = newNode;
            _numeroElementos++;
        }

        // Elimina un elemento de la lista.
        public bool Eliminar(T data) 
        {
            Node<T> prev = _head;
            // Caso 1: La lista está vacía.
            if(_head == null) { return false; }
            // Caso 2: Elemento a eliminar está en la cabeza de la lista.
            if (prev != null && prev.Data.Equals(data))
            {
                _head = prev.Next;
                _numeroElementos--;
                return true;
            }
            // Caso 3: Elemento a eliminar está en el cuerpo de la lista.
            while (prev.Next != null && !prev.Next.Data.Equals(data))
            {
                prev = prev.Next;
            }
            if (prev.Next == null)
                return false;
            prev.Next = prev.Next.Next;
            _numeroElementos--;
            return true;
        }

        // Eliminar por posición.
        public bool Eliminar(int index)
        {
            if (_head == null || index >= _numeroElementos)
                return false;
            if (index == 0)
            {
                _head = _head.Next;
                _numeroElementos--;
                return true;
            }
            Node<T> nodoAEliminar;
            Node<T> nodoAnterior = _head;
            for (int i = 0; i < index - 1; i++)
                nodoAnterior = nodoAnterior.Next;
            nodoAEliminar = nodoAnterior.Next;
            nodoAnterior.Next = nodoAEliminar.Next;
            _numeroElementos--;
            return true;
        }


        // Devuelve el elemento cuya posición se pasa por parámetro.
        public T GetElemento(int index)
        {
            Node<T> node = GetNode(index);
            if (node == null)
                throw new Exception("El índice no existe.");
            return node.Data;
        }

        private Node<T> GetNode(int index)
        {
            if(index < 0 || index >= _numeroElementos)
                return null;
            Node<T> aux = _head;
            int counter = 0;
            while (counter < index)
            {
                aux = aux.Next;
                counter++;
            }
            return aux;
        }

        // Auxiliar: busca el último nodo de la lista.
        private Node<T> GetUltimoNodo()
        {
            Node<T> node = _head;
            while (node.Next != null)
            {
                node = node.Next;
            }
            return node;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("[");
            for(int i = 0; i < _numeroElementos; i++)
            {
                sb.Append(GetElemento(i)).Append(",");
            }
            sb.Append("] -> ").Append(NumeroElementos).Append(" elementos.");
            return sb.ToString();
        }

        public bool Contiene(T data)
        {
            if(data == null) return false;
            for(int i = 0; i < _numeroElementos; i++)
            {
                if (GetElemento(i).Equals(data))
                    return true;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Iterador<T>(_head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Iterador<T>(_head);
        }

        internal class Iterador<T> : IEnumerator<T>
        {

            private Node<T> _currentNode;
            private Node<T> _head;

            public T Current { get { return _currentNode.Data; } }

            object IEnumerator.Current => Current;

            public Iterador(Node<T> head)
            {
                _head = head;
                _currentNode = null;
            }

            public void Dispose()
            {
                // Liberar recursos.
            }

            public bool MoveNext()
            {
                if (_currentNode == null)
                    _currentNode = _head;
                else
                    _currentNode = _currentNode.Next;

                return _currentNode != null;
            }

            public void Reset()
            {
                _currentNode = null;
            }
        }
    }
}