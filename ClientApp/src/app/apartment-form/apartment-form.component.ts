import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Apartment } from '../apartment.model';
import { ApartmentService } from '../apartment.service';

@Component({
  selector: 'app-apartment-form',
  templateUrl: './apartment-form.component.html',
  styleUrls: ['./apartment-form.component.css']
})
export class ApartmentFormComponent implements OnInit {
  form: FormGroup;
  loading = true;
  saving = false;
  error = '';
  photoPreview: string | null = null;
  isEdit = false;

  constructor(
    private fb: FormBuilder,
    private apartmentService: ApartmentService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.form = this.fb.group({
      id: [0],
      title: ['', Validators.required],
      location: [''],
      description: [''],
      price: [0, [Validators.required, Validators.min(0)]],
      isAvailable: [true],
      photoBase64: ['']
    });
  }

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.isEdit = !!id;

    if (this.isEdit) {
      this.apartmentService.getApartment(id).subscribe({
        next: apartment => {
          this.form.patchValue({
            id: apartment.id,
            title: apartment.title,
            location: apartment.location,
            description: apartment.description,
            price: apartment.price,
            isAvailable: apartment.isAvailable
          });
          if (apartment.photoBase64) {
            this.photoPreview = `data:image/*;base64,${apartment.photoBase64}`;
          }
          this.loading = false;
        },
        error: err => {
          this.error = err?.message ?? 'Unable to load apartment details.';
          this.loading = false;
        }
      });
    } else {
      this.loading = false;
    }
  }

  fileChanged(event: Event): void {
    const input = event.target as HTMLInputElement;
    const file = input.files?.[0];
    if (!file) {
      return;
    }

    const reader = new FileReader();
    reader.onload = () => {
      const result = reader.result as string;
      this.photoPreview = result;
      const base64 = result.split(',')[1] ?? '';
      this.form.patchValue({ photoBase64: base64 });
    };
    reader.readAsDataURL(file);
  }

  submit(): void {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    this.saving = true;
    this.error = '';
    const apartment = this.form.value as Apartment;

    const action: Observable<unknown> = this.isEdit
      ? this.apartmentService.updateApartment(apartment.id, apartment)
      : this.apartmentService.createApartment(apartment);

    action.subscribe({
      next: () => this.router.navigate(['/apartments']),
      error: (err: any) => {
        this.error = err?.message ?? 'Unable to save apartment.';
        this.saving = false;
      }
    });
  }

  cancel(): void {
    this.router.navigate(['/apartments']);
  }
}
