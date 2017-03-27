var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { HomeModule } from './home/home.module';
import { SharedModule } from './shared/shared.module';
import { Configuration } from './shared/configuration/app.configuration';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { RouterModule, PreloadAllModules } from '@angular/router';
import { AppRoutes } from './app.routes';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
var AppModule = (function () {
    function AppModule() {
    }
    return AppModule;
}());
AppModule = __decorate([
    NgModule({
        imports: [
            BrowserModule,
            RouterModule.forRoot(AppRoutes, { useHash: true, preloadingStrategy: PreloadAllModules }),
            HttpModule,
            FormsModule,
            SharedModule.forRoot(),
            HomeModule
        ],
        declarations: [
            AppComponent
        ],
        providers: [
            Configuration
        ],
        bootstrap: [AppComponent]
    })
], AppModule);
export { AppModule };
//# sourceMappingURL=app.module.js.map