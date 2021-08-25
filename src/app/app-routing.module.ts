import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TournamentFormComponent } from './tournament-form/tournament-form.component';
const routes: Routes = [
  { path: 'tournament-form', component: TournamentFormComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })],

  exports: [RouterModule]
})
export class AppRoutingModule { }
