import { Component, inject, signal, output } from '@angular/core';
import { toSignal } from '@angular/core/rxjs-interop';
import { GenreService } from '../../services/genre-service';
import { BookGenreCard } from '../book-genre-card/book-genre-card';

@Component({
  selector: 'app-category-filter',
  imports: [BookGenreCard],
  templateUrl: './category-filter.html',
  styleUrl: './category-filter.scss',
})
export class CategoryFilter {
  private readonly genreService = inject(GenreService);

  protected readonly genres = toSignal(this.genreService.getAll(), { initialValue: [] });
  protected readonly selectedGenre = signal<string | null>(null);

  genreSelected = output<string | null>();

  protected onGenreClick(genre: string): void {
    const next = this.selectedGenre() === genre ? null : genre;
    this.selectedGenre.set(next);
    this.genreSelected.emit(next);
  }
}
