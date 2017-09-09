import { Directive, ElementRef, HostListener, Input } from '@angular/core';

@Directive({
  selector: '[appMydir]'
})
export class MydirDirective {

  @Input()
  private colorBg: string;

  constructor(private el: ElementRef) { }

  @HostListener('click') onItemClick() {
    this.el.nativeElement.style.color = 'blue';
    this.el.nativeElement.style.background = this.colorBg || 'yellow';
  }

}
