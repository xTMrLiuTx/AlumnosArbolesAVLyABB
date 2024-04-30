using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumnosArbolesAVLyABB
{
    public class ArbolAVL
    {
        private NodoAVL raiz;

        public ArbolAVL()
        {
            raiz = null;
        }

        public void Insertar(Alumno alumno)
        {
            raiz = InsertarRecursivo(raiz, alumno);
        }

        private NodoAVL InsertarRecursivo(NodoAVL nodo, Alumno alumno)
        {
            if (nodo == null)
            {
                nodo = new NodoAVL(alumno);
                return nodo;
            }

            if (alumno.Carnet.CompareTo(nodo.Alumno.Carnet) < 0)
            {
                nodo.Izquierda = InsertarRecursivo(nodo.Izquierda, alumno);
            }
            else if (alumno.Carnet.CompareTo(nodo.Alumno.Carnet) > 0)
            {
                nodo.Derecha = InsertarRecursivo(nodo.Derecha, alumno);
            }
            else
            {
                // Ya existe un nodo con el mismo carnet
                return nodo;
            }

            // Balancear el árbol
            nodo = Balancear(nodo);

            return nodo;
        }

        private NodoAVL Balancear(NodoAVL nodo)
        {
            // Implementar el balanceo del árbol AVL
            //...
            return nodo;
        }

        public Alumno Buscar(string carnet)
        {
            return BuscarRecursivo(raiz, carnet);
        }

        private Alumno BuscarRecursivo(NodoAVL nodo, string carnet)
        {
            if (nodo == null)
            {
                return null;
            }

            if (carnet.CompareTo(nodo.Alumno.Carnet) == 0)
            {
                return nodo.Alumno;
            }
            else if (carnet.CompareTo(nodo.Alumno.Carnet) < 0)
            {
                return BuscarRecursivo(nodo.Izquierda, carnet);
            }
            else
            {
                return BuscarRecursivo(nodo.Derecha, carnet);
            }
        }

        public int ContarSaltos(string carnet)
        {
            return ContarSaltosRecursivo(raiz, carnet, 0);
        }

        private int ContarSaltosRecursivo(NodoAVL nodo, string carnet, int saltos)
        {
            if (nodo == null)
            {
                return -1;
            }

            if (carnet.CompareTo(nodo.Alumno.Carnet) == 0)
            {
                return saltos;
            }
            else if (carnet.CompareTo(nodo.Alumno.Carnet) < 0)
            {
                return ContarSaltosRecursivo(nodo.Izquierda, carnet, saltos + 1);
            }
            else
            {
                return ContarSaltosRecursivo(nodo.Derecha, carnet, saltos + 1);
            }
        }
    }

    public class NodoAVL
    {
        public Alumno Alumno { get; set; }
        public NodoAVL Izquierda { get; set; }
        public NodoAVL Derecha { get; set; }

        public NodoAVL(Alumno alumno)
        {
            Alumno = alumno;
            Izquierda = null;
            Derecha = null;
        }
    }
}
