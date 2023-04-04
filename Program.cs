using System;
using System.Runtime.InteropServices;

internal class Program
{
    public const string seaCharacter = "~ ";
    public const string boatCell = "Y ";
    public const string wrongLocation = "X";
    public const string correctLocation = "0";
    private static void Main()
    {
        Console.WriteLine("Ingresar posicion del barco V=1 H=0");
        int number = Int32.Parse(Console.ReadLine());

        while (number != 0 && number != 1) {
            Console.WriteLine("La información ingresada no es correcta, por favor ingrese 0 para posición Horizonta o 1 para posición Vertical");
            number = Int32.Parse(Console.ReadLine());
        }

        Console.WriteLine("Ingresar la longitud del barco");
        int long1 = Int32.Parse(Console.ReadLine());

        while (long1 < 0 || long1 > 9) {
            Console.WriteLine("La información ingresada no es correcta, por favor ingrese un numero de 0 al 9");
            long1 = Int32.Parse(Console.ReadLine());
        }

        Console.WriteLine("Ingrese donde se ubica la Proa x,y:");
        string ProaPos = Console.ReadLine();
        string[] ProaCoor = ProaPos.Split(',');

        int coor1;
        int coor2;

        while (ProaCoor.Length == 1 || int.TryParse(ProaCoor[0], out coor1) == false || int.TryParse(ProaCoor[1], out coor2) == false) {
            Console.WriteLine("Las coordenadas ingresadas son incorrectas. Ingrese la informacion de la siguiente forma (x,y)");
            ProaPos = Console.ReadLine();
            ProaCoor = ProaPos.Split(',');
        }

        Console.WriteLine(ProaCoor[0]);
        Console.WriteLine(ProaCoor[1]);

        string[,] table1 = new string[10, 10];

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++) {

                table1[i, j] = seaCharacter;
                Console.Write(table1[i, j] + " ");
            }
            Console.WriteLine();
        }

        //Horizontal y Vertical

        string[] coor5 = new string[long1];
        

        if (number == 0)
        {
            for (int a = 0; a < long1; a++)
            {
                coor5[a] = ProaCoor[0] + "," + coor2;
                coor2++;
            }

        }
        else
        {
            for (int a = 0; a < long1; a++)
            {
                coor5[a] = coor1 + "," + ProaCoor[1];
                coor1++;
            }
            
        }

        //Separador
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkBlue;

        int contG = 0;
        int contF = 0;
        string valid = "";
        
        do
        {
            Console.WriteLine("En donde cree que estara el barco? Ingrese las coordenadas de la forma x,y");
            string PlayerCoor = Console.ReadLine();
            string[] PlayerCoor2 = PlayerCoor.Split(',');

            int coor3;
            int coor4;

            while (PlayerCoor.Length == 1 || int.TryParse(PlayerCoor2[0], out coor3) == false || int.TryParse(PlayerCoor2[1], out coor4) == false || PlayerCoor == valid)
            {
                Console.WriteLine("Las coordenadas ingresadas son incorrectas. Ingrese la informacion de la siguiente forma (x,y)");
                PlayerCoor = Console.ReadLine();
                PlayerCoor2 = PlayerCoor.Split(',');
                
            }

            if (coor5.Contains(PlayerCoor))
            {

                valid = PlayerCoor;
                contG++;
                for (int i = 0; i < 10; i++)
                {

                    for (int j = 0; j < 10; j++)
                    {

                        if (table1[i, j] == correctLocation || table1[i, j] == wrongLocation)
                        {
                            table1[i, j] = table1[i, j];
                        }
                        else if (i == coor3 && j == coor4)
                        {

                            table1[i, j] = correctLocation;
                        }
                        else
                        {
                            table1[i, j] = seaCharacter;


                        }

                        Console.Write(table1[i, j] + " ");

                    }

                    Console.WriteLine();
                }
            }
            else
            {
                valid = PlayerCoor;
                contF++;
                for (int i = 0; i < 10; i++)
                {

                    for (int j = 0; j < 10; j++)
                    {
                        if (table1[i, j] == correctLocation || table1[i, j] == wrongLocation)
                        {
                            table1[i, j] = table1[i, j];
                        }
                        else if (i == coor3 && j == coor4)
                        {

                            table1[i, j] = wrongLocation;
                        }
                        else
                        {
                            table1[i, j] = seaCharacter;

                        }

                        Console.Write(table1[i, j] + " ");

                    }

                    Console.WriteLine();
                }
            }

            Console.WriteLine("Intentos Correctos: " + contG);
            Console.WriteLine("Intentos Fallidos: " + contF);

            if (contG == long1) {
                for (int i = 0; i < 10; i++)
                {

                    for (int j = 0; j < 10; j++)
                    {

                        if (table1[i, j] == correctLocation)
                        {
                            table1[i, j] = boatCell;
                        }
                        else if (table1[i, j] == wrongLocation)
                        {

                            table1[i, j] = wrongLocation;
                        }
                        else
                        {
                            table1[i, j] = seaCharacter;


                        }

                        Console.Write(table1[i, j] + " ");

                    }

                    Console.WriteLine();
                }
                Console.WriteLine("Gacrias Por Jugar");
            }

        } while (contG != long1);
    }
}