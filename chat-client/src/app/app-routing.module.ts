import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './views/home/home.component';
import { CounterComponent } from './views/counter/counter.component';
import { ChatComponent } from './views/chat/chat.component';

const routes: Routes = [
  { path: '', component: HomeComponent},
  { path: 'ngrx', component: CounterComponent},
  { path: 'signalr', component: ChatComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
