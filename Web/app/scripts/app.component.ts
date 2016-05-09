import {Component, OnInit} from '@angular/core';
import {ProductService} from './services/product.service'

@Component({
    selector: 'service-app',
    template: '<h1>Start page</h1>',
    providers: [ProductService]
})
export class AppComponent implements OnInit {
    constructor(_productService: ProductService){
        
    }
    
    getProducts(){
    }
    
    ngOnInit(){
        this
    }
}