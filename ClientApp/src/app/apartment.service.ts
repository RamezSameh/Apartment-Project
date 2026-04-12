import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Apartment } from './apartment.model';

@Injectable({
  providedIn: 'root'
})
export class ApartmentService {
  private readonly apiUrl = '/api/apartments';

  constructor(private http: HttpClient) {}

  getApartments(): Observable<Apartment[]> {
    return this.http.get<Apartment[]>(this.apiUrl);
  }

  getApartment(id: number): Observable<Apartment> {
    return this.http.get<Apartment>(`${this.apiUrl}/${id}`);
  }

  createApartment(apartment: Apartment): Observable<Apartment> {
    return this.http.post<Apartment>(this.apiUrl, apartment);
  }

  updateApartment(id: number, apartment: Apartment): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, apartment);
  }

  deleteApartment(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }

  bookApartment(id: number): Observable<void> {
    return this.http.post<void>(`${this.apiUrl}/${id}/book`, {});
  }
}
