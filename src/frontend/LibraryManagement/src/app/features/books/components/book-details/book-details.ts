import { Component, inject } from '@angular/core';
import { toSignal } from '@angular/core/rxjs-interop';
import { BookService } from '../../services/book-service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-book-details',
  imports: [],
  templateUrl: './book-details.html',
  styleUrl: './book-details.scss',
})
export class BookDetails {
  private readonly bookService = inject(BookService);
  private readonly route = inject(ActivatedRoute);

  private readonly bookId = String(this.route.snapshot.params['id']);
  protected readonly book = toSignal(this.bookService.getById(this.bookId));
}
