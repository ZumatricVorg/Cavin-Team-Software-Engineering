using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDesignPattern
{
    class SingletonClass
    {
        private static SingletonClass instance;

        private SingletonClass()
        {
            //initialise the objects
            //Console.WriteLine("SingletonClass constructor called");
        }

        public static SingletonClass Instance
        {
            get
            {
                if (instance == null)
                {
                    string c = "Integrated Security=SSPI;Persist Security Info=False;Data Source=.\\SQLEXPRESS;Initial Catalog=OverSurgery;";
                    SqlConnection conn = new SqlConnection(c);
                    // Console.WriteLine("The unique SingletonClass object will be created");
                    instance = new SingletonClass();
                    //Console.WriteLine("The SingletonClass object was created");
                    conn.Open();
                }

                return instance;
            }
        }

        public void print()
        {
           // Console.WriteLine("I'm a method from SingletonClass");
        }

    }
}
