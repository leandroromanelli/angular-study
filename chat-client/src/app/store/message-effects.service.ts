import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { IAppState, loadDummy, loadDummySuccess, setDummy } from './app-state';
import { switchMap } from 'rxjs/internal/operators/switchMap';
import { Store } from '@ngrx/store';
import { tap } from 'rxjs/internal/operators/tap';
import { map } from 'rxjs/internal/operators/map';
import { DummyData } from '../models/dummy-data';

@Injectable({
  providedIn: 'root'
})
export class MessageEffectsService {

  constructor(public actions$: Actions,
              public http: HttpClient,
              public store: Store<{ app: IAppState}>) { }

  loadDummyData = createEffect(() =>
    this.actions$.pipe(
      ofType(loadDummy),
      switchMap(() => {
        let result = this.http.get<DummyData[]>('http://localhost:5000/dummydata')
        return result
      }),
      tap(dummy => this.store.dispatch(setDummy({ payload: dummy }))),
      map(() => loadDummySuccess())
  ))
}
