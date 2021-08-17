import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BreedSearchComponent } from './components/breed-search/breed-search.component';
import { HttpClientModule } from '@angular/common/http';
import { BreedDisplayComponent } from './components/breed-display/breed-display.component';

@NgModule({
  declarations: [
    AppComponent,
    BreedSearchComponent,
    BreedDisplayComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
