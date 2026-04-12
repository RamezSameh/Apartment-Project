import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ApartmentListComponent } from './apartment-list/apartment-list.component';
import { ApartmentDetailComponent } from './apartment-detail/apartment-detail.component';
import { ApartmentFormComponent } from './apartment-form/apartment-form.component';
import { ApartmentDeleteComponent } from './apartment-delete/apartment-delete.component';
import { HomeComponent } from './home/home.component';
import { PrivacyComponent } from './privacy/privacy.component';

@NgModule({
  declarations: [
    AppComponent,
    ApartmentListComponent,
    ApartmentDetailComponent,
    ApartmentFormComponent,
    ApartmentDeleteComponent,
    HomeComponent,
    PrivacyComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
