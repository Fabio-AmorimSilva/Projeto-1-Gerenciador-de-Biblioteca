import { Component, input, output } from '@angular/core';

@Component({
  selector: 'app-book-genre-card',
  imports: [],
  templateUrl: './book-genre-card.html',
  styleUrl: './book-genre-card.scss',
})
export class BookGenreCard {
  genre = input.required<string>();
  selected = input(false);
  genreClick = output<string>();

  onClick(): void {
    this.genreClick.emit(this.genre());
  }
}
