import { loadDummy } from './../../store/app-state';
import { Component } from '@angular/core';
import { Message } from 'src/app/models/message';
import { FormControl } from '@angular/forms';
import { HubConnectionBuilder } from '@microsoft/signalr';
import { MatDialog } from '@angular/material/dialog';
import { ChatLoginComponent } from '../chat-login/chat-login.component';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Store } from '@ngrx/store';
import { IAppState, addMessage } from 'src/app/store/app-state';
import { selectDummy, selectMessages } from 'src/app/store/app-selectors';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.css']
})
export class ChatComponent {

  username:string = ''

  messages$ = this.store.select(selectMessages)
  dummyData$ = this.store.select(selectDummy)

  messageControl = new FormControl('');

  constructor(public dialog: MatDialog,
              public snackBar: MatSnackBar,
              public store:Store<{ app: IAppState}>) {
    this.openDialog()
  }

  connection = new HubConnectionBuilder()
    .withUrl('http://localhost:5000/chat')
    .build();

  openDialog(){
    let dialogRef = this.dialog.open(ChatLoginComponent, {
      width: '300px',
      data: this.username,
      disableClose: true
    })

    dialogRef.afterClosed().subscribe(result => {
      this.username = result
      this.startConnection(result)
      this.openSnackBar(result)
    })
  }

  startConnection(usr:string){
    this.connection.on('newMessage', (username: string, message: string) => {
      let msg : Message = {
        messageText: message,
        userName: username
      }

      this.store.dispatch(addMessage(msg))
    })

    this.connection.on('newUser', (username: string) => {
      this.openSnackBar(username)
    })

    this.connection.start()
      .then(() => {
          this.connection.send('newUser', usr)
          this.store.dispatch(loadDummy())
      })
  }

  openSnackBar(username:string) {
      let message = (this.username == username ? 'You' : username) + ' joined the chat'
      this.snackBar.open(message, 'close', {
        duration: 1000,
        horizontalPosition: 'center',
        verticalPosition: 'top'
      })
  }

  sendMessage(){
      this.connection.send('newMessage', this.username, this.messageControl.value)
        .then(() =>{
          this.messageControl.setValue('')
      })
  }
}
