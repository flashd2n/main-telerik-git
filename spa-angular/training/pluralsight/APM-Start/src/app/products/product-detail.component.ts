import { ProductService } from './product.service';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IProduct } from './product';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {
  public pageTitle: string;
  public product: IProduct;

  constructor(private route: ActivatedRoute,
              private productService: ProductService,
              private router: Router) {
    this.pageTitle = 'Product Detail';
   }

  ngOnInit() {
    const id = +this.route.snapshot.paramMap.get('id');
    console.log(id);
    this.pageTitle += `: ${id}`;
    this.productService.getProducts().subscribe(products => {
      this.product = products.find(x => x.productId === id);
      console.log(this.product);
    }, error =>  console.log(error));
  }

  onBack(): void {
    this.router.navigate(['/products']);
  }

}
