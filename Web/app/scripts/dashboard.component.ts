import { Component, OnInit } from '@angular/core';
import { IProduct } from '../models/Product';
import {ProductService} from './services/product.service'
import { Router } from '@angular/router-deprecated';

@Component({
    selector: 'product-dashboard',
    template: `<h3>dashboard</h3>`
})

export class DashboardComponent implements OnInit {
    errorMessage: string;
    products: IProduct[] = [];
    constructor(private _productService: ProductService) {
    }
    
    
    ngOnInit(){
        this._productService.getProducts()
            .subscribe(
                product =>this.products = product,
                err => this.errorMessage = <any> err
            )
    }
}