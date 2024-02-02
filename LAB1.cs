using System;
class Program
{
    public double add(double x, double y)
    {
        return x+y;
    }
    public double substract(double x, double y)
    {
        return x-y;
    }
    public double multiply(double x, double y)
    {
        return x*y;
    }
    public double divide(double x, double y)
    {
        return x/y;
    }
    public static void Main(string[] args)
    {
        double c = 0;
        double a=0,b=0;
        int state = 0;
        while(true)
        {
            // reset varaibles
                c = 0;
                a=0;
                b=0;
                state =0;
            // reset varaibles
            Console.WriteLine("podaj pierwsza liczbe");
            a = Convert.ToDouble(Console.ReadLine());
            
            Console.WriteLine("podaj druga liczbe");
            b = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("dodawanie wpisz 1");
            Console.WriteLine("odejmowanie wpisz 2");
            Console.WriteLine("mnozenie wpisz 3");
            Console.WriteLine("dzielenie wpisz 4");
            Console.WriteLine("podaj typ działania :");
            state = Convert.ToInt32(Console.ReadLine());

            if(state <= 0 || state == 4 && b == 0)
            {
                Console.WriteLine("podana bledny typ dzialania lub bledne liczby!");
                continue;
            }

            switch(state)
            {
                case 1:
                    c = a+b;
                    break;
                case 2:
                    c = a-b;
                    break;
                case 3:
                    c = a*b;
                    break;
                case 4:
                    c = a/b;
                    break;
            }
            Console.WriteLine("wynik dzialania:"+Convert.ToString(c));
            Console.WriteLine("wpisz end zeby zakonczyc");
            if(Console.ReadLine() == "end")
            {
                 Console.WriteLine("wybrano zakonczenie wylaczam sie");
                 return;
            }
            Console.Clear();
            
        }
    }
}
