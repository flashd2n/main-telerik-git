import { Component, OnChanges, Input, Output, EventEmitter } from '@angular/core';

@Component({
    selector: 'pm-star',
    templateUrl: './star.component.html',
    styleUrls: ['./star.component.css']
})
export class StarComponent implements OnChanges {
    public starWidth: number;
    @Input() rating: number = 4;
    @Output() notify: EventEmitter<number> = new EventEmitter<number>();

    ngOnChanges(): void {
        this.starWidth = this.rating * 86 / 5;
    }

    onClick() {
        this.notify.emit(this.rating);
    }
}
