import { Component, computed, inject, signal } from '@angular/core';
import { toSignal } from '@angular/core/rxjs-interop';
import { BookService } from '../../services/book-service';
import { RouterLink } from "@angular/router";
import { CategoryFilter } from '../category-filter/category-filter';

@Component({
  selector: 'app-book-card',
  imports: [RouterLink, CategoryFilter],
  templateUrl: './book-card.html',
  styleUrl: './book-card.scss',
})
export class BookCard {
  private readonly bookService = inject(BookService);
  private readonly allBooks = toSignal(this.bookService.getAll(), { initialValue: [] });

  protected readonly selectedGenre = signal<string | null>(null);
  protected readonly books = computed(() => {
    const selectedGenre = this.selectedGenre();
    return selectedGenre
      ? this.allBooks().filter((book) => book.genre === selectedGenre)
      : this.allBooks();
  });

  protected onGenreSelected(genre: string | null): void {
    this.selectedGenre.set(genre);
  }
}
