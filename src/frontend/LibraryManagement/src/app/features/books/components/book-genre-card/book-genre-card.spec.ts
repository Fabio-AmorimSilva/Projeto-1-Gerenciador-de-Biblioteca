import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BookGenreCard } from './book-genre-card';

describe('BookGenreCard', () => {
  let component: BookGenreCard;
  let fixture: ComponentFixture<BookGenreCard>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BookGenreCard],
    }).compileComponents();

    fixture = TestBed.createComponent(BookGenreCard);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
