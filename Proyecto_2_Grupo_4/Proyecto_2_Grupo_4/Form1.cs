using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
namespace Proyecto_2_Grupo_4
{
    public partial class Form1 : Form
    {
        public Foto imagenActual;
        public LinkedList<Foto> listaSimple = new LinkedList<Foto>();
        public LinkedList<Foto> listaCircular = new LinkedList<Foto>();
        public LinkedList<Foto> listaDoble = new LinkedList<Foto>();
        public LinkedListNode<Foto> nodoActual;
        public LinkedListNode<Foto> nodoFinal;
        public Form1()
        {
            InitializeComponent();
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox2.BorderStyle = BorderStyle.FixedSingle;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            // Cuadro de diálogo Abrir archivo  
            OpenFileDialog open = new OpenFileDialog();
            //   Filtros de imagen
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                //   Mostrar imagen en el cuadro de imagen
                pictureBox1.Image = new Bitmap(open.FileName);
                //  Ruta del archivo de imagen

                txtRutaArchivo.Text = open.FileName;//Se guarda la ruta
                txtNombre.Text = Path.GetFileNameWithoutExtension(txtRutaArchivo.Text);//Se guarda el nombre
                //Se agregan las rutas a las 3 listas
                listaSimple.AddLast(new Foto(this.txtRutaArchivo.Text));
                listaCircular.AddLast(new Foto(this.txtRutaArchivo.Text));
                listaDoble.AddLast(new Foto(this.txtRutaArchivo.Text));
            }
        }
        private void bntListaDoble_Click(object sender, EventArgs e)//Boton para indicar la imagen de la lista doble
        {
            label1.Text = "Album Doble";
            nodoActual = listaDoble.First;
            nodoFinal= listaDoble.Last;
            imagenActual = nodoActual.Value;
            pictureBox2.ImageLocation = imagenActual.RutaArchivo;
        }
        private void btnListaSimple_Click(object sender, EventArgs e)//Boton para mostrar la imagen de la lista Simple
        {
            label1.Text = "Album Simple";
            nodoFinal = listaSimple.Last;
            nodoActual = listaSimple.First;
            imagenActual = nodoActual.Value;
            pictureBox2.ImageLocation = imagenActual.RutaArchivo;
        }
        private void btnCircular_Click(object sender, EventArgs e)//Boton para mostrar album de lista circular
        {
            label1.Text = "Album Circular";
            nodoActual = listaCircular.First;
            nodoFinal = listaCircular.Last;
            imagenActual = nodoActual.Value;
            pictureBox2.ImageLocation = imagenActual.RutaArchivo;
        }

        private void button3_Click(object sender, EventArgs e)//Boton de adelante
        {
            if (label1.Text == "Album Doble")//Configuracion del boton siguiente para el album de doblemente enlazado
            {
                if (nodoActual == nodoFinal)
                {
                    MessageBox.Show("Has llegado a la ultima foto del album");
                }
                else
                {
                    nodoActual = nodoActual.Next;
                    imagenActual = nodoActual.Value;
                    pictureBox2.ImageLocation = imagenActual.RutaArchivo;
                }
            }
            
            if (label1.Text == "Album Simple")//Configuracion del boton siguiente para el album de simplemente ligado
            {
                    if (nodoActual == nodoFinal)
                    {
                        MessageBox.Show("Has llegado a la ultima foto del album");
                    }
                    else
                    {
                        nodoActual = nodoActual.Next;
                        imagenActual = nodoActual.Value;
                        pictureBox2.ImageLocation = imagenActual.RutaArchivo;
                    }

            }
            if (label1.Text == "Album Circular")//Configuracion del botton siguiente para el album circular
            {
                if (nodoActual == nodoFinal)
                {
                    nodoActual = listaCircular.First;
                    imagenActual = nodoActual.Value;
                    pictureBox2.ImageLocation = imagenActual.RutaArchivo;
                }
                else
                { 
                    nodoActual = nodoActual.Next;
                    imagenActual = nodoActual.Value;
                    pictureBox2.ImageLocation = imagenActual.RutaArchivo;
                } 
            }
        }
        private void button2_Click(object sender, EventArgs e)//Boton de atras
        {
            if(label1.Text=="Album Doble")//Configuracion del botton atras para el album doble
            {
               if(nodoActual != null && nodoActual.Previous != null)
                {
                    nodoActual = nodoActual.Previous;
                    imagenActual = nodoActual.Value;
                    pictureBox2.ImageLocation = imagenActual.RutaArchivo;
                }
                else
                {
                    MessageBox.Show("No hay más fotos anteriores.", "Advertencia");
                }
            }
            if (label1.Text == "Album Simple")//Configuracion del botton atras para el album simple
            {
                if (nodoActual != null && nodoActual.Previous != null)
                {
                    MessageBox.Show("No se aplica la funcion de foto anterior.", "Mensaje");
                }
                else
                {
                    MessageBox.Show("No hay más fotos anteriores.", "Advertencia");
                }
            }
            if (label1.Text == "Album Circular")//Configuracion del botton atras para el album circular
            {
                if (nodoActual != null && nodoActual.Previous != null)
                {
                    MessageBox.Show("No se aplica la funcion de foto anterior.", "Mensaje");
                }
                else
                {
                    MessageBox.Show("No se aplica la funcion de foto anterior.", "Mensaje");
                }
            }
        }

        private void bntEliminar_Click(object sender, EventArgs e)//Boton de eliminar posicion actual
        {
            if (label1.Text == "Album Doble")//Configura el boton de eliminar para el album doble
            {

                if (nodoActual.Next != null)
                {
                    nodoActual = nodoActual.Next;
                    listaDoble.Remove(imagenActual);
                    imagenActual = nodoActual.Value;
                    pictureBox2.ImageLocation = imagenActual.RutaArchivo;
                }
                else
                {
                    nodoActual = nodoActual.Previous;
                    listaDoble.Remove(imagenActual);
                    imagenActual = nodoActual.Value;
                    pictureBox2.ImageLocation = imagenActual.RutaArchivo;
                }
            }
            else if(label1.Text == "Album Simple")//Configura el boton de eliminar para el album simple
            {
                if (nodoActual.Next != null)
                {
                    nodoActual = nodoActual.Next;
                    listaSimple.Remove(imagenActual);
                    imagenActual = nodoActual.Value;
                    pictureBox2.ImageLocation = imagenActual.RutaArchivo;
                }
                else
                {
                    nodoActual = nodoActual.Previous;
                    listaSimple.Remove(imagenActual);
                    imagenActual = nodoActual.Value;
                    pictureBox2.ImageLocation = imagenActual.RutaArchivo;
                }

            }
            else if (label1.Text == "Album Circular")//configura el boton de eliminar para el album circular
            {
                if (nodoActual.Next != null)
                {
                    nodoActual = nodoActual.Next;
                    listaCircular.Remove(imagenActual);
                    imagenActual = nodoActual.Value;
                    pictureBox2.ImageLocation = imagenActual.RutaArchivo;
                }
                else
                {
                    nodoActual = nodoActual.Previous;
                    listaCircular.Remove(imagenActual);
                    imagenActual = nodoActual.Value;
                    pictureBox2.ImageLocation = imagenActual.RutaArchivo;
                }

            }
        }

       
    }//class Form
}//class namespace

 

