import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import { FighterComponent } from './components/fighter/fighter.component';
import {LoginComponent} from './components/login/login.component';
import { ManagerComponent } from './components/manager/manager.component';
import { SignupComponent } from './components/signup/signup.component';
import { TournamentDetailsComponent } from './components/tournament-details/tournament-details.component';

const routes: Routes = [
    {path: 'login', component: LoginComponent},
    {path: 'signup', component: SignupComponent},
    {path: 'manager', component: ManagerComponent},
    {path: 'fighter', component: FighterComponent},
    {path: 'tournament-details', component: TournamentDetailsComponent},
    {path: '', redirectTo: '/login', pathMatch: 'full'}
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
