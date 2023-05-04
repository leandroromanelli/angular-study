import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { IAppState, loadMessages, loadMessagesSuccess, setMessages } from './app-state';
import { switchMap } from 'rxjs/internal/operators/switchMap';
import { Message } from '../models/message';
import { Store } from '@ngrx/store';
import { tap } from 'rxjs/internal/operators/tap';
import { map } from 'rxjs/internal/operators/map';

@Injectable({
  providedIn: 'root'
})
export class MessageEffectsService {

  constructor(public actions$: Actions,
              public http: HttpClient,
              public store: Store<{ app: IAppState}>) { }

  loadMessages = createEffect(() =>
    this.actions$.pipe(
      ofType(loadMessages),
      switchMap(() => {
        let result = this.http.get<Message[]>('http://localhost:5000/message')

        console.table(result)

        return result
      }),
      tap(messages => this.store.dispatch(setMessages({ payload: messages }))),
      map(() => loadMessagesSuccess())
  ))
}
