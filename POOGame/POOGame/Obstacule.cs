using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace POOGame
{
    //Obstaculo que deriva de la clase padre Object
    class Obstacule : Object
    {

        public Obstacule()
        {
            this.x = generate(78);
            this.y = generate(39);
        }

        //Método estático para generar un obstáculo
        public static void draw(Graphics graph)
        {
            int rectangle_width = 10;
            graph.FillRectangle(new SolidBrush(Color.Black), rectangle_width, rectangle_width, rectangle_width, rectangle_width);
        }

        public void colocate()
        {
            this.x = generate(78);
            this.y = generate(39);
        }

        public int generate(int n)
        {
            Random random = new Random();
            int num = random.Next(0, n) * 10;
            return num;
        }
    }
}