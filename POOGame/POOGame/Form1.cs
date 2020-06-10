using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POOGame
{
    public partial class Form1 : Form
    {
        //Inicialización de los objetos y variables.
        Queue head;
        Graphics graph;
        Food food;
        Obstacule obstacule;
        int xdir = 0, ydir = 0, const_value = 10;
        int score = 0;
        Boolean positionX = true, positionY = true;
        string _message = "Game Over :(";
        public Form1()
        {
            InitializeComponent();

            // Instanciación de objetos
            head = new Queue(10,10);
            graph = canvas.CreateGraphics();
            food = new Food();
            obstacule = new Obstacule();

            MessageBox.Show(Singleton.Instance.message);
        }

        public void move()
        {
            head.setPosition(head.getX() + xdir, head.getY() + ydir);
        }

        //Se tiene un timer dentro del form el cual cambia cada 100 milisegundos
        private void bucle_Tick(object sender, EventArgs e)
        {
            //Llamar a todas las funciones que controlan el juego
            graph.Clear(Color.White);
            head.drawElement(graph);
            food.draw(graph);
            bodyCollision();
            collision();
            move();

            //Detectar cuando la serpiente come
            if (head.intersetion(food))
            {
                food.colocate();
                head.newElement();
                score++;
                puntos.Text = score.ToString();
            }

            //Detectar si la serpiente choca contra el obstaculo
            if(head.intersetion(obstacule))
            {
                endGame();
            }

            //Si tenemos un score >= 5 aparecerá un obstaculo en el juego
            if (score >=5)
            {
                //Método estático
                Obstacule.draw(graph);
            }

            //El jugador gana si consigue 10 puntos
            if(score == 10)
            {
                _message = "Congratulations!";
                endGame();
                
            }

        }

        //Función para terminar el juego
        public void endGame()
        {
            score = 0;
            puntos.Text = "0";
            positionX = true;
            positionY = true;
            xdir = 0;
            ydir = 0;
            head = new Queue(10,10);
            food = new Food();
            MessageBox.Show(_message);
        }

        //Función para detectar si el serpiente choca con su propio cuerpo
        public void bodyCollision()
        {
            Queue temp;
            try
            {
                temp = head.getNext().getNext();
            }
            catch (Exception err)
            {
                temp = null;
            }
            while(temp != null)
            {
                if (head.intersetion(temp))
                {
                    endGame();
                }
                else
                {
                    temp = temp.getNext();
                }
            }
        }

        //Función para detectar si la serpiente choca con los extremos de la pantalla
        public void collision()
        {
            if(head.getX() < 0 || head.getX() > 780 || head.getY() < 0 || head.getY() > 390)
            {
                endGame();
            }
        }

        //Añadimos un key down event al form para detectar si se presiona alguna de las flechas
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (positionX)
            {
                if(e.KeyCode == Keys.Up)
                {
                    ydir = -const_value;
                    xdir = 0;
                    positionX = false;
                    positionY = true;
                }
                if (e.KeyCode == Keys.Down)
                {
                    ydir = const_value;
                    xdir = 0;
                    positionX = false;
                    positionY = true;
                }
            }
            if (positionY)
            {
                if(e.KeyCode == Keys.Right)
                {
                    ydir = 0;
                    xdir = const_value;
                    positionX = true;
                    positionY = false;
                }
                if (e.KeyCode == Keys.Left)
                {
                    ydir = 0;
                    xdir = -const_value;
                    positionX = true;
                    positionY = false;
                }
            }
        }
    }
}
