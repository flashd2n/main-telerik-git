import { ProductService } from './product.service';
import { Component, OnInit } from '@angular/core';
import { IProduct } from './product';

@Component({
    selector: 'pm-products',
    templateUrl: './product-list.component.html',
    styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
    public pageTitle: string = 'Product List';
    private newTitle: string;
    public imageWidth: number = 50;
    public imageMargin: number = 2;
    public showImage: boolean = false;
    private filterString: string;
    private errorMessage: string;
    public filteredProducts: IProduct[];
    public products: IProduct[];

    constructor(private productService: ProductService) {
    }

    public get FilterString() {
        return this.filterString;
    }

    public set FilterString(value: string) {
        this.filterString = value;
        this.filteredProducts = this.filterString ? this.filterProducts() : this.products;
    }

    public get NewTitle() {
        return this.newTitle ? this.newTitle : this.pageTitle;
    }

    public toggleImages(): void {
        this.showImage = !this.showImage;
    }

    public onNotify(message: string): void {
        this.newTitle = this.pageTitle + ' ' + message;
    }

    public ngOnInit(): void {
        this.productService.getProducts()
            .subscribe(products => {
                this.products = products;
                this.filteredProducts = this.products;
            }, error => {
                this.errorMessage = <any>error;
                console.log('FROM SUBSCR ' + this.errorMessage);
            });
    }

    private filterProducts(): IProduct[] {
        return this.products.filter((x) => {
            return x.productName.toLowerCase().indexOf(this.filterString.toLowerCase()) !== -1;
        });
    }
}
