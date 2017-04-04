var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { FoodDataService } from './services/food-data.service';
import { Sorter } from './services/sort.service';
import { RouterModule } from '@angular/router';
import { NavigationComponent } from './components/navigation/navigation.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
var SharedModule = SharedModule_1 = (function () {
    function SharedModule() {
    }
    SharedModule.forRoot = function () {
        return {
            ngModule: SharedModule_1,
            providers: [FoodDataService, Sorter]
        };
    };
    return SharedModule;
}());
SharedModule = SharedModule_1 = __decorate([
    NgModule({
        imports: [
            // Modules
            CommonModule,
            RouterModule
        ],
        declarations: [
            // Components & directives
            NavigationComponent
        ],
        providers: [],
        exports: [
            NavigationComponent
        ]
    })
], SharedModule);
export { SharedModule };
var SharedModule_1;
//# sourceMappingURL=shared.module.js.map