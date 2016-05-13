import { Injectable } from '@angular/core';
import {IProduct} from '../../models/Product';
import {Http, Response} from '@angular/http';
import {Observable} from 'rxjs/Observable'
import 'rxjs/add/operator/map'
import 'rxjs/add/operator/catch';

@Injectable()
export /**
 * ProductServic
 */
 class ProductService {
     constructor(private _http: Http){}
     private apiUrl = "/product/products"
  
  getProducts (): Observable<IProduct[]>{
       var result = this._http.get(this.apiUrl).map((response: Response)=> <IProduct[]> response.json())
       .catch(this.handleError);
       return result;
  }
  
  private handleError(error: Response) {
      // add logging infrastructure
      
      console.error(error);
      return Observable.throw(error.json().error || 'Server error');
  }
  
}