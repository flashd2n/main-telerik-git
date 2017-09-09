import { Component, OnInit, Input, Output, EventEmitter, ContentChild, AfterContentInit } from '@angular/core';

@Component({
  selector: 'app-child',
  templateUrl: './child.component.html',
  styleUrls: ['./child.component.css']
})
export class ChildComponent implements OnInit, AfterContentInit {


  @ContentChild('some')
  el;

  constructor() {
  }

  ngOnInit() {
  }

  ngAfterContentInit(): void {
    console.log(this.el);
  }
}
