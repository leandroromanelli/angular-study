import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-chat-login',
  templateUrl: './chat-login.component.html',
  styleUrls: ['./chat-login.component.css']
})
export class ChatLoginComponent {
  constructor(@Inject(MAT_DIALOG_DATA) public name: string,
              public dialogRef: MatDialogRef<ChatLoginComponent>
  ){ }
}
