import { EmitterServiceService } from './../emitter-service.service';
import { Component, OnInit, ComponentRef } from '@angular/core';
import { IModalDialog, IModalDialogOptions, IModalDialogButton } from 'ngx-modal-dialog';

@Component({
  selector: 'app-my-modal-component',
  templateUrl: './my-modal-component.component.html',
})
export class MyModalComponentComponent implements OnInit, IModalDialog {

  actionButtons: IModalDialogButton[];

  private data: string;

  constructor(private emitter: EmitterServiceService) {
    this.actionButtons = [
      { text: 'I close and DO NOT save data' }, // no special processing here
      { text: 'I close and save data', onAction: () => this.sendDataToParent() },
      { text: 'I never close', onAction: () => false }
    ];
  }

  dialogInit(reference: ComponentRef<IModalDialog>, options?: IModalDialogOptions) {
  }

  ngOnInit() {
  }

  sendDataToParent() {
    this.emitter.next(this.data);
    return true;
  }

}
