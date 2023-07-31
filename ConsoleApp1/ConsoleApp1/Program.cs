using ConsoleApp1.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //set the bacground color
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.DarkBlue;

            //We identify any username and password
            string username = "Vusal";
            string password = "5959";

          Redirection:
            Console.Clear();
            Console.WriteLine("                                                 Welcome to Super Market                                                    ");

            //We accept the username and password from the user and check if they are the same as the ones we identify
            Console.Write("Please Enter Your Username: ");
            string user1 = Console.ReadLine();
            Console.Write("Please Enter Your Password: ");
            string pass1 = Console.ReadLine();
            Console.Clear();
            int option = 0;
            if (username == user1 && password == pass1)
            {
                do
                {
                    Console.WriteLine($"                                                    WELCOME Mr.{username}                 \n");
                    Console.WriteLine(" Please Select Options as followings:                                                                        \n");

                    Console.WriteLine("1. Transaction On Products");
                    Console.WriteLine("2. Transaction On Sales");
                    Console.WriteLine("3. Exit");

                    Console.WriteLine("----------------");
                    Console.WriteLine("Enter an option please:");
                    Console.WriteLine("----------------");

                    while (!int.TryParse(Console.ReadLine(), out option))
                    {
                        Console.WriteLine("Invalid option!");
                        Console.WriteLine("Enter an option please:");
                        Console.WriteLine("----------------");
                    }

                    switch (option)
                    {
                        case 1:
                            Sabmenu.ProductSabmenu();
                            break;
                        case 2:
                            Sabmenu.SalesSubMenu();
                            break;
                        case 0:
                            Console.Clear();
                            Console.WriteLine("Bye");
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("No such option!");
                            break;
                    }
                } while (option != 0);
            }
            else
            {
                // After the user presses any key, they will return to menu...
                Console.WriteLine("Incorrect Password or null, press any key to return Menu");
                Console.ReadKey();
                goto Redirection;


            }

        }
    }
}
