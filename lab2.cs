using System;

class LabDwa
{
    public static void Main(string[] args)
    {
        Random rnd = new Random();
        int x = 0;
        bool found = false;

            Console.WriteLine("witaj w mojej grze!");        
            Console.WriteLine("zasady gry:");
            Console.WriteLine("wylosuje liczbe z zakresu 1-2 a nastepnie bedziesz mial 10 prob na jej odganiecie");        
            Console.WriteLine("losuje liczbe z zakresu 1-100");

            x = rnd.Next(1,100);
            for(int i = 0;i<10;i++)
            {
                Console.WriteLine("podaj liczbe z zakresu 1-100");
                int z = Convert.ToInt32(Console.ReadLine());
                if(z == x)
                {
                    found = true;
                    break;
                }
                else 
                {
                    if(z > x)
                    {
                        Console.WriteLine("podales wieksza liczbe od wylosowanej");
                    }
                    else 
                    {
                        Console.WriteLine("podales mniejsza liczbe od wylosowanej");
                    }
                }
            }
            if(found)
                Console.WriteLine("udalo Ci sie odgadnac liczbe gratulacje");
            Console.WriteLine("wylosowana liczba "+Convert.ToString(x));
            
    }
}