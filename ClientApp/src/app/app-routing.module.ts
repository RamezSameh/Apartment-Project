import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ApartmentListComponent } from './apartment-list/apartment-list.component';
import { ApartmentDetailComponent } from './apartment-detail/apartment-detail.component';
import { ApartmentFormComponent } from './apartment-form/apartment-form.component';
import { ApartmentDeleteComponent } from './apartment-delete/apartment-delete.component';
import { PrivacyComponent } from './privacy/privacy.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'apartments', component: ApartmentListComponent },
  { path: 'apartments/create', component: ApartmentFormComponent },
  { path: 'apartments/:id', component: ApartmentDetailComponent },
  { path: 'apartments/:id/edit', component: ApartmentFormComponent },
  { path: 'apartments/:id/delete', component: ApartmentDeleteComponent },
  { path: 'privacy', component: PrivacyComponent },
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
