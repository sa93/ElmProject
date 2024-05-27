import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Book } from '../Model/Book';

@Injectable({
  providedIn: 'root'
})
export class BookService {
  private apiUrl = 'https://localhost:5003/Book'; 

  constructor(private http: HttpClient) { }

  searchBooks(searchText: string, page: number, pageSize: number): Observable<Book[]> {
    debugger;
    let params = new HttpParams()
      .set('keyword', searchText)
      .set('page', page.toString())
      .set('pageSize', pageSize.toString());

    return this.http.get<Book[]>(this.apiUrl, { params });
  }
}
