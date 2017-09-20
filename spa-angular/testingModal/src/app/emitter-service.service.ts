import { Injectable } from '@angular/core';
import 'rxjs/Rx';
import { Subject, Subscription } from 'rxjs/Rx';

@Injectable()
export class EmitterServiceService {

    private events = new Subject();

    subscribe(next, error?, complete?) {
        return this.events.subscribe(next, error, complete);
    }

    next(event) {
        this.events.next(event);
    }
}
