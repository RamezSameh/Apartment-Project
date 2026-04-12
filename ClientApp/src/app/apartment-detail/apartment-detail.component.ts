import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Apartment } from '../apartment.model';
import { ApartmentService } from '../apartment.service';

@Component({
  selector: 'app-apartment-detail',
  templateUrl: './apartment-detail.component.html',
  styleUrls: ['./apartment-detail.component.css']
})
export class ApartmentDetailComponent implements OnInit {
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
        this.error = err?.message ?? 'Unable to load apartment details.';
        this.loading = false;
      }
    });
  }

  getPhotoSrc(): string | null {
    return this.apartment?.photoBase64 ? `data:image/*;base64,${this.apartment.photoBase64}` : null;
  }

  edit(): void {
    if (this.apartment) {
      this.router.navigate(['/apartments', this.apartment.id, 'edit']);
    }
  }

  back(): void {
    this.router.navigate(['/apartments']);
  }
}
