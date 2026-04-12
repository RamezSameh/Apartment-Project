import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Apartment } from '../apartment.model';
import { ApartmentService } from '../apartment.service';

@Component({
  selector: 'app-apartment-list',
  templateUrl: './apartment-list.component.html',
  styleUrls: ['./apartment-list.component.css']
})
export class ApartmentListComponent implements OnInit {
  apartments: Apartment[] = [];
  loading = true;
  error = '';

  constructor(private apartmentService: ApartmentService, private router: Router) {}

  ngOnInit(): void {
    this.loadApartments();
  }

  loadApartments(): void {
    this.loading = true;
    this.error = '';
    this.apartmentService.getApartments().subscribe({
      next: data => {
        this.apartments = data;
        this.loading = false;
      },
      error: err => {
        this.error = err?.message ?? 'Unable to load apartments.';
        this.loading = false;
      }
    });
  }

  getPhotoSrc(apartment: Apartment): string | null {
    return apartment.photoBase64 ? `data:image/*;base64,${apartment.photoBase64}` : null;
  }

  create(): void {
    this.router.navigate(['/apartments/create']);
  }

  details(id: number): void {
    this.router.navigate(['/apartments', id]);
  }

  edit(id: number): void {
    this.router.navigate(['/apartments', id, 'edit']);
  }

  delete(id: number): void {
    this.router.navigate(['/apartments', id, 'delete']);
  }

  book(id: number): void {
    if (!confirm('Do you want to book this apartment?')) {
      return;
    }

    this.apartmentService.bookApartment(id).subscribe({
      next: () => this.loadApartments(),
      error: err => this.error = err?.message ?? 'Unable to book apartment.'
    });
  }
}
