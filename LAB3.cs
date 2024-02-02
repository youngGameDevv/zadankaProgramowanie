using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace LAB3
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? author { get; set; }
        public int year { get; set; }
        public bool avalible { get; set; }
    }
    public class Helper
    {
        public List<Book> loadData()
        {
            List<Book> books = new List<Book>();
            string path = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "//data.text";
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path));
            }
            else
            {
                string data = File.ReadAllText(path);
                if (data.Length != 0)
                {
                    List<Book> models = JsonConvert.DeserializeObject<List<Book>>(data);
                    models.ForEach(book => books.Add(book));
                    return books;
                }
            }
            return new List<Book>();
        }
        public int getNextId(List<Book> books)
        {
            int maxNum = 1;
            foreach(Book num in books)
            {
                if (num.Id > maxNum)
                    maxNum = num.Id;
            }
            return maxNum;
        }
        public void saveData(List<Book> books)
        {
            string path = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "//data.text";
            string jsonString = System.Text.Json.JsonSerializer.Serialize(books);
            File.WriteAllText(path, jsonString);
            Console.WriteLine("dane zapisane!");
        }

    }

    public class LAB3
    {
        public static void Main()
        {
            List<Book> books = new List<Book>();
            Helper helper = new Helper();
            Console.WriteLine("loading data");
            books = helper.loadData();
            int task = 0;
            string title = "";
            string author = "";
            int year = 0;
            int id = -1;
            bool state = false;
            int firstState = -1;
            while (task != 999)
            {
                task = 0;
                Console.WriteLine("witaj w magazynie ksiazek dostępne operacje:");
                Console.WriteLine("dodanie ksiązki wpisz nr operacji: 1");
                Console.WriteLine("przegladanie ksiazek nr operacji: 2");
                Console.WriteLine("wypozyczenie/oddanie ksiazki nr operacji: 3");
                Console.WriteLine("wyszukanie ksiazki nr operacji: 4");
                Console.WriteLine("aktualizacja informacji o ksiazce nr operacji: 5");
                Console.WriteLine("wyjscie i zapis danych nr operacji: 6");
                Console.WriteLine("podaj nr operacji:");
                try
                {
                    task = Int32.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("wpisales cos innego niz liczbe sprobuj ponownie!");
                    continue;
                }
                switch (task)
                {
                    case 1:
                        Console.WriteLine("podaj tytul:");
                        title = Console.ReadLine();
                        Console.WriteLine("podaj autora:");
                        author = Console.ReadLine();
                        Console.WriteLine("podaj rok wydania:");
                        try
                        {
                             year = Int32.Parse(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("wpisales cos innego niz liczbe sprobuj ponownie!");
                            continue;
                        }
                        Console.WriteLine("podaj status 0 - wypozyczona, 1 = dostepna:");
                        try
                        {
                            firstState = Int32.Parse(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("wpisales cos innego niz liczbe sprobuj ponownie!");
                            continue;
                        }
                        if (firstState == 1)
                            state = true;
                        else
                            state = false;
                        if(title.Length != 0 && author.Length != 0)
                        {
                            Book newBook = new Book();
                            newBook.author = author;
                            newBook.Title = title;
                            newBook.year = year;
                            newBook.avalible = state;
                            newBook.Id = helper.getNextId(books);
                            books.Add(newBook);
                            Console.WriteLine("sukces!");
                        }
                        else
                        {
                            Console.WriteLine("podales bledne dane sprobuj ponownie!");
                            continue;
                        }
                        break;



                    case 2:
                        Console.WriteLine("wypisuje wszystkie ksiazki:");
                        books.ForEach(book => Console.WriteLine($"autor: '{book.author}' title: '{book.Title}' year: '{book.year}' avalible: '{book.avalible}' id: '{book.Id}'"));
                        break;
                   

                    case 3:
                        Console.WriteLine("wypozyczenie ksiazki wpisz 1, oddanie ksiazki wpisz 2");
                        try
                        {
                            task = Int32.Parse(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("wpisales cos innego niz liczbe sprobuj ponownie!");
                            continue;
                        }
                        Console.WriteLine("podaj id ksiazki do zmiany:");
                        try
                        {
                            id = Int32.Parse(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("wpisales cos innego niz liczbe sprobuj ponownie!");
                            continue;
                        }
                        if(id > 0)
                        {
                            foreach(Book book in books)
                            {
                                if(book.Id == id)
                                {
                                    if (task == 1)
                                        book.avalible = false;
                                    else
                                        book.avalible = true;
                                    Console.WriteLine("dokonano zmiany!");
                                }       
                            }
                        }
                        break;



                    case 4:
                        Console.WriteLine("wypisz po tytule wpisz 1");
                        Console.WriteLine("wypisz po autorze wpisz 2");
                        Console.WriteLine("wypisz po roku wydania wpisz 3");
                        try
                        {
                            task = Int32.Parse(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("wpisales cos innego niz liczbe sprobuj ponownie!");
                            continue;
                        }
                        switch(task)
                        {
                            case 1:
                                Console.WriteLine("podaj tytul");
                                title = Console.ReadLine();
                                if(title.Length != 0)
                                {
                                    foreach(Book book in books)
                                    {
                                        if(book.Title == title)
                                        {
                                            Console.WriteLine($"znalazlem! autor:'{book.author}' year'{book.year}' avalible: '{book.avalible}' id: '{book.Id}'");
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("wpisales pusty string!");
                                    continue;
                                }
                                break;
                            case 2:
                                Console.WriteLine("podaj autora");
                                author = Console.ReadLine();
                                if (title.Length != 0)
                                {
                                    foreach (Book book in books)
                                    {
                                        if (book.author == author)
                                        {
                                            Console.WriteLine($"znalazlem! title:'{book.Title}' year'{book.year}' avalible: '{book.avalible}' id: '{book.Id}'");
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("wpisales pusty string!");
                                    continue;
                                }
                                break;
                                
                            case 3:
                                Console.WriteLine("podaj rok");
                                try
                                {
                                    year = Int32.Parse(Console.ReadLine());
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("wpisales cos innego niz liczbe sprobuj ponownie!");
                                    continue;
                                }
                                foreach (Book book in books)
                                {
                                    if (book.year == year)
                                    {
                                        Console.WriteLine($"znalazlem! title:'{book.Title}' author '{book.author}' avalible: '{book.avalible}' id: '{book.Id}'");
                                    }
                                }
                                break;
                        }
                        break;
                    case 5:
                        Console.WriteLine("podaj id ksiazki do zmiany:");
                        try
                        {
                            id = Int32.Parse(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("wpisales cos innego niz liczbe sprobuj ponownie!");
                            continue;
                        };
                        Console.WriteLine("podaj tytul:");
                        title = Console.ReadLine();
                        Console.WriteLine("podaj autora:");
                        author = Console.ReadLine();
                        Console.WriteLine("podaj rok wydania:");
                        try
                        {
                            year = Int32.Parse(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("wpisales cos innego niz liczbe sprobuj ponownie!");
                            continue;
                        }
                        Console.WriteLine("podaj status 0 - wypozyczona, 1 = dostepna:");
                        try
                        {
                            firstState = Int32.Parse(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("wpisales cos innego niz liczbe sprobuj ponownie!");
                            continue;
                        }
                        if (firstState == 1)
                            state = true;
                        else
                            state = false;
                        if (title.Length != 0 && author.Length != 0)
                        {

                            foreach(Book book in books)
                            {
                                if(book.Id == id)
                                {
                                    book.author = author;
                                    book.Title = title;
                                    book.year = year;
                                    book.avalible = state;
                                    Console.WriteLine("sukces!");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("podales bledne dane sprobuj ponownie!");
                            continue;
                        }
                        break;

                    case 6:
                        Console.WriteLine("wybrales koniec aplikacji do zobaczenia ponownie :)");
                        helper.saveData(books);
                        task = 999;
                        break;

                    default:
                        Console.WriteLine("podales zla liczbe");
                        continue;
                }
                Thread.Sleep(5000);
                Console.Clear();
            }

        }



    }
}


