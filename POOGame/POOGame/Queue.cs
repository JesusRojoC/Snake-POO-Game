using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace POOGame
{
    //Elementos de la serpiente que derivan de la clase padre "Object"
    class Queue : Object
    {

        Queue next;
        public Queue(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public void drawElement(Graphics graph)
        {
            if(next != null)
            {
                next.drawElement(graph);
            }

            graph.FillRectangle(new SolidBrush(Color.DarkGreen), this.x, this.y, this.width, this.width);
        }

        public void setPosition(int x, int y)
        {
            if(next != null)
            {
                next.setPosition(this.x, this.y);
            }

            this.x = x;
            this.y = y;
        }

        //Añadir nuevo cuadro a la serpiente
        public void newElement()
        {
            if(next == null)
            {
                next = new Queue(this.x, this.y);
            }
            else
            {
                next.newElement();
            }
        }

        //"Getters"
        public int getX()
        {
            return this.x;
        }

        public int getY()
        {
            return this.y;
        }

        public Queue getNext()
        {
            return next;
        }
    }
}
