import { EmitterServiceService } from './../emitter-service.service';
import { MyModalComponentComponent } from './../my-modal-component/my-modal-component.component';
import { Component, OnInit, ViewContainerRef, ViewChild } from '@angular/core';
import { ModalDialogService, SimpleModalComponent, IModalDialogButton } from 'ngx-modal-dialog';

@Component({
  selector: 'app-something-clever',
  templateUrl: './somethingClever.component.html',
})
export class SomethingCleverComponent implements OnInit {

  private fromModal;
  private subscription;

  constructor(private modalService: ModalDialogService, private viewRef: ViewContainerRef, private emitter: EmitterServiceService) {
    this.openNewDialog();
    this.subscription = this.emitter.subscribe(data => {
      this.fromModal = data;
      this.processData();
    });
   }

  ngOnInit() {
  }

  openNewDialog() {
    this.modalService.openDialog(this.viewRef, {
      title: 'Some modal title',
      childComponent: MyModalComponentComponent
    });
  }

  processData() {
    console.log('Look Dory, I can process data now :)');
    console.log(this.fromModal);
  }


}
