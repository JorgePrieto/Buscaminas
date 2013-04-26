using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 *  NOMBRE:Jorge
 *  APELLIDOS: Prieto
 *  ESTO ES UNA PRUEBA DE GITHUB
 * 
 */

namespace Buscaminas
{
    public partial class Form1 : Form
    {
        //declaro el array de botones
        Button[,] matrizBotones;
        int filas = 20;
        int columnas = 20;
        int anchoBoton = 20;
        int minas = 20;
        public Form1()
        {
            InitializeComponent();


            this.Height = columnas * anchoBoton + 40;
            this.Width = filas * anchoBoton + 20;

            matrizBotones = new Button[filas, columnas];

            for (int i = 0; i < filas; i++)
                for (int j = 0; j < columnas; j++)
                {
                    Button boton = new Button();
                    // boton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    boton.Width = anchoBoton;
                    boton.Height = anchoBoton;
                    boton.Location = new Point(i * anchoBoton, j * anchoBoton);
                    boton.Click += chequeaBoton;
                    boton.Tag = 1; //sirve para identificar
                    matrizBotones[i, j] = boton;
                    panel1.Controls.Add(boton);
                    
                }
              poneMinas();
        }

        private void poneMinas() {
            Random aleatorio = new Random();
            int x, y = 0;
            for (int i = 0; i < minas; i ++)
            {
                x = aleatorio.Next(filas);
                y = aleatorio.Next(columnas);
                while (matrizBotones[x, y].Tag.Equals("1"))
                {
                    x = aleatorio.Next(filas);
                    y = aleatorio.Next(columnas);
                }
                matrizBotones[x, y].Tag = "2";
                matrizBotones[x, y].Text = "B";
            }
        }


        private void chequeaBoton(object sender, EventArgs e)
        {
            // (sender as Button).Enabled = false;
            Button b = (sender as Button);
            //b.BackColor = Color.Blue;
            //declaramos una variable
            int columna = b.Location.X / anchoBoton;
            int fila = b.Location.Y / anchoBoton;

            //colorea en la fila del clic, el boton izquierdo, el derecho
            //            matrizBotones[columna - 1, fila].BackColor = Color.Red;
            //            matrizBotones[columna, fila].BackColor = Color.Red;           
            //            matrizBotones[columna +1, fila].BackColor = Color.Red;

            //colorea en la fila superior del clic, el boton izquierdo, el centro
            //            matrizBotones[columna - 1, fila -1].BackColor = Color.Red;
            //            matrizBotones[columna, fila -1].BackColor = Color.Red;
            //            matrizBotones[columna + 1, fila -1].BackColor = Color.Red;

            //colorea en la fila inferior del clic, el boton izquierdo, el centro
            //            matrizBotones[columna - 1, fila + 1].BackColor = Color.Red;
            //            matrizBotones[columna, fila + 1].BackColor = Color.Red;
            //            matrizBotones[columna + 1, fila + 1].BackColor = Color.Red;
            //se puede hacer un for anidado
            //for (int i = -1; i < 1; i++) {
            //    for (int j = -1; j < 1; j++)
            //    {
            //        matrizBotones[columna + i, fila + j].BackColor = Color.Red;
            //    }
            for (int i = -1; i < 2; i++){
                for (int j = -1; j < 2; j++){
                    if ((columna + j < columnas) && (columna + j >= 0) &&
                        (fila + i < filas) && (fila + i >= 0))
                    {
                        if (matrizBotones[columna + j, fila + i].BackColor != Color.Red)
                        {

                            matrizBotones[columna + j, fila + i].BackColor = Color.Red;
                            chequeaBoton(matrizBotones[columna + j, fila + i], e);
                        }
                    }
                }
            }

        }
    }
}