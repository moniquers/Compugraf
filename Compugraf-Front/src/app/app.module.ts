import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PersonFormComponent } from './components/person/person-form/person-form.component';
import { PersonListComponent } from './components/person/person-list/person-list.component';
import { ToastModule } from 'primeng/toast';
import { ConfirmationService, MessageService } from 'primeng/api';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { InputMaskModule } from 'primeng/inputmask';
import { InputTextModule } from 'primeng/inputtext';

@NgModule({
  declarations: [
    AppComponent,
    PersonFormComponent,
    PersonListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    ToastModule,
    ConfirmDialogModule,
    BrowserAnimationsModule,
    InputMaskModule,
    InputTextModule
  ],
  providers: [
    MessageService,
    ConfirmationService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
