import { loadMessages, setMessages, userLogin } from './../../store/app-state';
import { Component } from '@angular/core';
import { Message } from 'src/app/models/message';
import { FormControl } from '@angular/forms';
import { HubConnectionBuilder } from '@microsoft/signalr';
import { MatDialog } from '@angular/material/dialog';
import { ChatLoginComponent } from '../chat-login/chat-login.component';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Store } from '@ngrx/store';
import { IAppState, addMessage } from 'src/app/store/app-state';
import { Observable, first, map } from 'rxjs';
import { selectMessages, selectUser } from 'src/app/store/app-selectors';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.css']
})
export class ChatComponent {

  username$ = this.store.select(selectUser)

  messages$ = this.store.select(selectMessages)

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
      disableClose: true
    })

    dialogRef.afterClosed().subscribe(result => {
      this.store.dispatch(userLogin(result))
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
          this.store.dispatch(loadMessages())
      })
  }

  openSnackBar(username:string) {
    this.username$.pipe(first()).subscribe((usr) => {
      let message = (usr == username ? 'You' : username) + ' joined the chat'
      this.snackBar.open(message, 'close', {
        duration: 1000,
        horizontalPosition: 'center',
        verticalPosition: 'top'
      })
    })
  }

  sendMessage(){
    this.username$.pipe(first()).subscribe((usr) =>
      this.connection.send('newMessage', usr, this.messageControl.value)
        .then(() =>{
          this.messageControl.setValue('')
      })
    )
  }
}
