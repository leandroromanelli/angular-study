import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ChatComponent } from './views/chat/chat.component';
import { VideoChatComponent } from './components/video-chat/video-chat.component';

const routes: Routes = [
  { path: '', component: ChatComponent},
  { path: 'video', component: VideoChatComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
