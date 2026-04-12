import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Apartment } from '../apartment.model';
import { ApartmentService } from '../apartment.service';

@Component({
  selector: 'app-apartment-delete',
  templateUrl: './apartment-delete.component.html',
  styleUrls: ['./apartment-delete.component.css']
})
export class ApartmentDeleteComponent implements OnInit {
  apartment: Apartment | null = null;
  loading = true;
  error = '';

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private apartmentService: ApartmentService
  ) {}

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    if (!id) {
      this.error = 'Invalid apartment ID.';
      this.loading = false;
      return;
    }

    this.apartmentService.getApartment(id).subscribe({
      next: data => {
        this.apartment = data;
        this.loading = false;
      },
      error: err => {
        this.error = err?.message ?? 'Unable to load apartment.';
        this.loading = false;
      }
    });
  }

  delete(): void {
    if (!this.apartment) {
      return;
    }

    this.apartmentService.deleteApartment(this.apartment.id).subscribe({
      next: () => this.router.navigate(['/apartments']),
      error: err => this.error = err?.message ?? 'Unable to delete apartment.'
    });
  }

  cancel(): void {
    this.router.navigate(['/apartments']);
  }
}
