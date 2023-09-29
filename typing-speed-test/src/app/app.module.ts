import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { TypingSpeedTestSerice } from './services';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [TypingSpeedTestSerice],
  bootstrap: [AppComponent]
})
export class AppModule { }
