import { Component, inject } from '@angular/core';
import { toSignal } from '@angular/core/rxjs-interop';
import { BookService } from '../../services/book-service';

@Component({
  selector: 'app-book-card',
  imports: [],
  templateUrl: './book-card.html',
  styleUrl: './book-card.scss',
})
export class BookCard {
  private readonly bookService = inject(BookService);
  protected readonly books = toSignal(this.bookService.getAll(), { initialValue: [] });
}
