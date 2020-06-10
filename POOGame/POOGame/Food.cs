using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace POOGame
{
    class Food : Object
    {
        public Food()
        {
            this.x = generate(78);
            this.y = generate(39);
        }

        public void draw(Graphics graph)
        {
            graph.FillRectangle(new SolidBrush(Color.Red), this.x, this.y, this.width, this.width);
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
