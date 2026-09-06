import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Book } from '../models/book';

@Injectable({
  providedIn: 'root',
})
export class BookService {

  private readonly http = inject(HttpClient);
  private readonly apiUrl = 'https://localhost:7290/api/books';

  getAll(): Observable<Book[]> {
    return this.http.get<Book[]>(`${this.apiUrl}`);
  }

  getById(id: string): Observable<Book> {
    return this.http.get<Book>(`${this.apiUrl}/${id}`);
  }
}
