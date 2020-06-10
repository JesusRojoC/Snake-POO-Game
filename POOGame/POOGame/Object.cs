using System;
using System.Collections.Generic;
using System.Text;

namespace POOGame
{
	//Clase principal de la cual heredarán las demás clases.
	class Object
	{
		protected int x, y, width;
		public Object()
		{
			width = 10;
		}
		public Boolean intersetion(Object position)
		{
			int difx = Math.Abs(this.x - position.x);
			int dify = Math.Abs(this.y - position.y);
			if (difx >= 0 && difx < width && dify >= 0 && dify < width)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}