import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    loadComponent: () =>
      import('./core/layout/main-layout/main-layout')
        .then((m => m.MainLayout)),
        
    children: [
      {
        path: '',
        loadComponent: () =>
          import('./features/books/components/book-card/book-card')
            .then(m => m.BookCard)
      },
      {
        path: 'book-details/:id',
        loadComponent: () =>
          import('./features/books/components/book-details/book-details')
            .then(m => m.BookDetails)
      }
    ]
  }
];
