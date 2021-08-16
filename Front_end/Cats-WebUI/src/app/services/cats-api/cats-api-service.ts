import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Breed } from 'src/app/models/breed';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BreedService {
  private breedsEndpoint = environment.breedsEndpoint;
  private imagesEndpoint = environment.imagesEndpoint;

  constructor(private http: HttpClient) { }

  searchBreeds(term: string): Observable<Breed[]> {
    return this.http.get<Breed[]>(this.breedsEndpoint + term).pipe(
      catchError(() => of([]))
    )
  }

  getImageUrl(id: string): Observable<string[]> {
    return this.http.get<string[]>(this.imagesEndpoint + id).pipe(
      catchError(() => of([]))
    )
  }
}