import { Injectable } from '@angular/core';
import { IProduct } from './product';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';

@Injectable()
export class ProductService {
    private productUrl: string = './api/products/products.json';

    constructor(private http: HttpClient) { }

    public getProducts(): Observable<IProduct[]> {
        return this.http.get<IProduct[]>(this.productUrl)
            .do(x => console.log(JSON.stringify(x)))
            .catch(this.handleError);
    }

    private handleError(err: HttpErrorResponse) {
        console.log('FROM SERVICE ' + err.message);
        return Observable.throw(err.message);
    }
}
