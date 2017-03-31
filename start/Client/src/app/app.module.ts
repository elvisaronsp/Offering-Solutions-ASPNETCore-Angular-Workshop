import { SharedModule } from './shared/shared.module';
import { Configuration } from './shared/configuration/app.configuration';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';

@NgModule({
    imports: [
        BrowserModule,
        HttpModule,
        FormsModule,
        SharedModule
    ],

    declarations: [
        AppComponent
    ],

    providers: [
        Configuration
    ],

    bootstrap: [AppComponent]
})

export class AppModule { }
