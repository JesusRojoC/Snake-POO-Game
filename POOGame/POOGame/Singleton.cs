using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace POOGame
{
    //Mensaje de bienvenida para el usuario
    public class Singleton
    {
        private static Singleton instance = null;
        public string message = "";

        protected Singleton()
        {
            message = "Try to get 10 points!\n \n Press Enter to join the game";
        }

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                    instance = new Singleton();

                return instance;
            }
        }

    }
}