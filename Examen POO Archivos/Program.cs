using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Examen_POO_Archivos
{
    class Program
    {

        //Clase 
        class InventarioAmazon
        {
            //Atributos
            string nombre;
            string descripcion;
            double precio;
            int stock;

            //Constructor
            public InventarioAmazon(string nombre, string descripcion, double precio, int stock)
            {
                //Uso de this
                this.nombre = nombre;
                this.descripcion = descripcion;
                this.precio = precio;
                this.stock = stock;
            }


        }
        static void Main(string[] args)
        {
            
            //Variable auxiliar
            int menu;
            
            Console.WriteLine("***BIENVENIDO A AMAZON***");
            Console.Write("\n1)Registrar productos.");
            Console.Write("\n2)Consultar productos.");
            Console.Write("\n3)Cerrar programa.");
            Console.Write("\n\nQue desea hacer?");
            menu = Int32.Parse(Console.ReadLine());

           
                switch (menu)
                {
                    case 1:
                        {
                            //Variables auxiliares
                            
                            string nombre;
                            string descripcion;
                            double precio;
                            int stock;
                            bool repetir = false;
                            char rep = 'N';

                            //Creacion del archivo
                            StreamWriter sw = new StreamWriter("Productos.txt", true);

                            Console.Clear();
                            Console.WriteLine("***INVENTARIO***");

                            do
                            {
                                Console.Write("\nNombre del producto: ");
                                nombre = Console.ReadLine();
                                Console.Write("\ndescripcion del producto: ");
                                descripcion = Console.ReadLine();
                                Console.Write("\nprecio del producto: ");
                                precio = Single.Parse(Console.ReadLine());
                                Console.Write("\nCantidad en stock del producto: ");
                                stock = Int32.Parse(Console.ReadLine());

                                sw.Write("\n" +  nombre +
                                   "\n" + descripcion +
                                   "\n" + precio + "$" +
                                  "\n" +  stock + " Unidades");

                                Console.WriteLine("\nEL producto se ha guardado!");
                                Console.Write("\nDesea escribir otro producto (S/N)? ");
                                rep = char.Parse(Console.ReadLine());
                                if (rep == 'S')
                                {
                                    repetir = true;
                                }
                                else
                                {
                                    repetir = false;
                                }

                                //Creacion del objeto 
                                InventarioAmazon inventarioAmazon = new InventarioAmazon(nombre, descripcion, precio, stock);

                                
                            } while (repetir == true);

                            sw.Close();
                        }
                        break;

                    case 2:
                        {
                            //bloque de lectura
                            try
                            {
                                StreamReader sr = new StreamReader("Productos.txt");
                            string Line;

                            while ((Line = sr.ReadLine()) != null)
                            {
                                Console.Clear();

                                Console.Write(Line);
                            }
                            catch (IOException e)
                            {
                                Console.WriteLine("\nError : " + e.Message);
                                Console.WriteLine("\nRuta : " + e.StackTrace);
                            }

                            Console.ReadKey();
                        }
                        break;
                    case 3:
                        {
                            Console.Write("\nPresione <enter> para Salir del Programa.");
                            Console.ReadKey();
                        }
                        break;

                    default:
                        Console.Write("\nEsa Opción No Existe!!, Presione < enter > para Continuar...");
                        Console.ReadKey();
                        break;
                }
           
           
            
           
        }
    }
}
