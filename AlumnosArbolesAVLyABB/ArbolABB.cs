using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumnosArbolesAVLyABB
{
    public class ArbolABB
    {
        private NodoABB raiz;

        public ArbolABB()
        {
            raiz = null;
        }

        public void Insertar(Alumno alumno)
        {
            if (raiz == null)
            {
                raiz = new NodoABB(alumno);
            }
            else
            {
                raiz = InsertarRecursivo(raiz, alumno);
            }
        }

        private NodoABB InsertarRecursivo(NodoABB nodo, Alumno alumno)
        {
            if (nodo == null)
            {
                return new NodoABB(alumno);
            }

            int comparacion = alumno.Carnet.CompareTo(nodo.Alumno.Carnet);

            if (comparacion < 0)
            {
                nodo.Izquierda = InsertarRecursivo(nodo.Izquierda, alumno);
            }
            else if (comparacion > 0)
            {
                nodo.Derecha = InsertarRecursivo(nodo.Derecha, alumno);
            }
            else
            {
                // Ya existe un nodo con el mismo carnet
                return nodo;
            }

            return nodo;
        }
        public Alumno Buscar(string carnet)
        {
            return BuscarRecursivo(raiz, carnet);
        }

        private Alumno BuscarRecursivo(NodoABB nodo, string carnet)
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

        private int ContarSaltosRecursivo(NodoABB nodo, string carnet, int saltos)
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

    public class NodoABB
    {
        public Alumno Alumno { get; set; }
        public NodoABB Izquierda { get; set; }
        public NodoABB Derecha { get; set; }

        public NodoABB(Alumno alumno)
        {
            Alumno = alumno;
            Izquierda = null;
            Derecha = null;
        }
    }
}
