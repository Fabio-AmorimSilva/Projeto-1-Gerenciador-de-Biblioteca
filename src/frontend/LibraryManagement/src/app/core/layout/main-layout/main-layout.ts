import { Component } from '@angular/core';
import { NavBar } from '../nav-bar/nav-bar';
import { BookCard } from '../../../features/books/components/book-card/book-card';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-main-layout',
  imports: [NavBar, BookCard, RouterOutlet],
  templateUrl: './main-layout.html',
  styleUrl: './main-layout.scss',
})
export class MainLayout {}
