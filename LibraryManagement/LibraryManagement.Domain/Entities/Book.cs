﻿namespace LibraryManagement.Domain.Entities;

public class Book : Entity
{
    public string Isbn { get; private set; }
    public string Title { get; private set; }
    public string Author { get; private set; }
    public string Genre { get; private set; }
    public int Year { get; private set; }

    protected Book(){}
    
    public Book(
        string isbn, 
        string title, 
        string author, 
        string genre, 
        int year
    )
    {
        Isbn = isbn;
        Title = title;
        Author = author;
        Genre = genre;
        Year = year;
    }
}