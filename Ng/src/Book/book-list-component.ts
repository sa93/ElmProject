import { Component, Input } from '@angular/core';
import { Book } from '../Model/Book';


@Component({
  selector: 'book-list',
  templateUrl: './book-list-component.html',
  styleUrls: ['./book-list-component.scss']
})
export class BookListComponent {
  @Input() books: Book[] = [];
}
