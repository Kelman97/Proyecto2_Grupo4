using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_2_Grupo_4
{
    public class Album
    {

        public LinkedList<Foto> listaSimple = new LinkedList<Foto>();
        public LinkedList<Foto> listaCircular = new LinkedList<Foto>();
        public LinkedList<Foto> listaDoble = new LinkedList<Foto>();
        public LinkedListNode<Foto> nodoActual;
        public Foto imagenActual;

        public void AgregarFoto()
        {

            
        }
        public void EliminarFoto()
        {

        }
        // Lógica para eliminar una foto de cada lista
        public void MostrarFotos()
        {
           

        }
        // Lógica para mostrar todas las fotos de cada lista
    }//Cierre Clase
}//Cierre namespace
