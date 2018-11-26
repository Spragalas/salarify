import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { EditDialog } from './home/components'
import { MatListModule, MatButtonModule, MatToolbarModule, MatDialogModule, MatFormFieldModule, MatInputModule, MatRadioModule } from "@angular/material";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { RestService } from "./rest.service"

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent, EditDialog

  ],
  entryComponents: [EditDialog],
  imports: [
    BrowserAnimationsModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' }
    ]),
    MatListModule,
    MatButtonModule,
    MatToolbarModule,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    MatRadioModule
  ],
  providers: [RestService],
  bootstrap: [AppComponent]
})
export class AppModule { }
