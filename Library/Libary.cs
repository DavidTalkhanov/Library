using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }//название книги
        public string Author { get; set; }
        public string Status { get; set; }
        public Book(string title,string author) 
        {
            Id = Guid.NewGuid();
            Title = title;
            Author = author;
            Status = "не занята";
        }
        public void ChangeBookStatus()//меняет статус книги
        {
            if (Status == "не занята")
                Status = "занята";
            else
                Status = "не занята";
        }
    }
    public class Reader
    { 
        public List<Book> Books=new List<Book>();// список книг читателя
        public string Name { get; set; }
        public Reader(List<Book> books, string name)
        {
            Books = books;
            Name = name;
        }   
        public void TakeBook(Book book)//добавление книги в список читателя
        {
            book.Status = "занята";
            Books.Add(book);
        }
        public void ReturnBook(Book book)//возвращение обратно в библиотеку
        {
            book.Status = "не занята";
            for(int i=0;i<Books.Count;i++)
            {
                if (book.Id == Books[i].Id)
                    Books.RemoveAt(i);
            }
        }
        public void LookBoooks()//посмотреть книги читателя
        {
            for (int i = 0; i < Books.Count; i++)
            {
                Console.WriteLine(Books[i].Title + " " + Books[i].Author);
            }
        }
    }
    public class PrivillegedReader:Reader
    { 
        public List<Book>DonatedBooks=new List<Book>();// список подаренных книг
        public PrivillegedReader(List<Book> donatedBooks, List<Book> books, string name) :base(books,name)
        {
            DonatedBooks = donatedBooks;
        }
        public void LookDonatedBooks()// посмотреть подаренные книги
        {
            for (int i = 0; i < DonatedBooks.Count; i++)
                Console.WriteLine(DonatedBooks[i].Title+" "+ DonatedBooks[i].Author);
        }
    }
    public class Library
    {
        public List<Book> Books=new List<Book>();
        public List<Reader> Readers = new List<Reader>();
        public Library(List<Book> books, List<Reader> readers)
        {
            Books = books;
            Readers = readers;
        }
        public void AddBookInLibrary(Book book)//добавление книги в библиотеку
        {
            Books.Add(book);
        }
        public void RemoveBook(Book book)//удаление книги из библиотеки
        {
            for (int i = 0; i < Books.Count; i++)
            {
                if (book.Id == Books[i].Id)
                    Books.RemoveAt(i);
            }
        }
        public void AddReader(Reader reader)//зарегистрировать читателя в библиотеке
        {
            Readers.Add(reader);
        }
        public void RemoveReader(Reader reader)//удалить читателя из библиотеки
        {
            for (int i = 0; i < Readers.Count; i++)
            {
                if(reader.Name == Readers[i].Name)
                    Readers.RemoveAt(i);
            }
        }
        public void IsReader(Reader reader)//посмотреть зарегистрирован ли читатель в библиотеке
        {
            bool flag=false;
            for (int i = 0; i < Readers.Count; i++)
                if (reader.Name == Readers[i].Name)
                {
                    Console.WriteLine("YES");
                    flag = true;
                }
            if(flag==false) 
            {
                Console.WriteLine("NO");
            }
        }
        public void LookUnoccupiedBooks()//посмотреть свободные книги в библиотеке
        {
            for(int i = 0;i < Books.Count;i++)
                if (Books[i].Status=="не занята")
                    Console.WriteLine(Books[i].Title + " " + Books[i].Author);
        }
        public void LookBusydBooks()//посмотреть занятые книги в библиотеке
        {
            for (int i = 0; i < Books.Count; i++)
                if (Books[i].Status == "занята")
                    Console.WriteLine(Books[i].Title + " " + Books[i].Author);
        }
    }
}
