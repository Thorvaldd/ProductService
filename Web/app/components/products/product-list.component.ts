import { Component, OnInit } from '@angular/core';
import { IProduct } from '../../models/Product';
import {ProductService} from '../../scripts/services/product.service'
import { Router, ROUTER_DIRECTIVES } from '@angular/router-deprecated';

@Component({
    selector: 'product-dashboard',
    templateUrl: 'app/views/products/product-list.component.html',
    directives: [ROUTER_DIRECTIVES]
})

export class ProductListComponent implements OnInit {
    pageTitle = 'Product list';
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