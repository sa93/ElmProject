import { Component, OnInit } from '@angular/core';

import { Book } from '../Model/Book';
import { BookService } from '../Services/book-service';

@Component({
  selector: 'book-search',
  templateUrl: './search-component.html',
  styleUrls: ['./search-component.scss']
  
})

export class BookSearchComponent implements OnInit {
  searchText: string = '';
  books: Book[] = [];
  page: number = 1;
  pageSize: number = 10;
  loading: boolean = false;

  constructor(private bookService: BookService) { }

  ngOnInit(): void {
  }

  searchBooks(): void {
    this.loading = true;
    debugger;
    this.bookService.searchBooks(this.searchText, this.page, this.pageSize)
      .subscribe(
        (response) => {
          this.books = response;
          this.loading = false;
        },
        (error) => {
          console.error('Error fetching books', error);
          this.loading = false;
        }
      );
  }

  onScroll(): void {
    // Implement load more logic when user scrolls down
    this.page++;
    this.searchBooks();
  }
}
