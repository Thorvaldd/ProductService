import {Component} from '@angular/core';
import {ROUTER_DIRECTIVES, Routes, ROUTER_PROVIDERS } from '@angular/router';
import { HTTP_PROVIDERS } from '@angular/http';

import {ProductService} from './services/product.service';
import {ProductListComponent} from '../components/products/product-list.component';
import { DashboardComponent } from '../components/dashboard.component';
 
@Component({
    selector: 'service-app',
    templateUrl: 'app/views/app/app.component.html' ,
    providers: [ProductService, ROUTER_PROVIDERS, HTTP_PROVIDERS],
    directives: [ROUTER_DIRECTIVES]
})
@Routes([
    {path : '/', component: DashboardComponent},
    {path: '/products', component: ProductListComponent}
])


export class AppComponent {
}