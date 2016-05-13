import {Component} from '@angular/core';
import {ProductService} from './services/product.service';
import { RouteConfig, ROUTER_DIRECTIVES, ROUTER_PROVIDERS } from '@angular/router-deprecated';

@Component({
    selector: 'service-app',
    template: '<h1>Start page</h1>',
    providers: [ProductService]
})


export class AppComponent {
}