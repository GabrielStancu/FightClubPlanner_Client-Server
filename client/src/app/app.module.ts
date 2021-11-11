import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';

import {HttpClientModule} from '@angular/common/http';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { LoginService } from './services/login.service';
import { SignupComponent } from './components/signup/signup.component';
import { ManagerComponent } from './components/manager/manager.component';
import { FighterComponent } from './components/fighter/fighter.component';
import { TournamentDetailsComponent } from './components/tournament-details/tournament-details.component';
import { ManagerService } from './services/manager.service';
import { CommonModule, DatePipe } from '@angular/common';
import { FighterTournamentsComponent } from './components/fighter/fighter-tournaments/fighter-tournaments.component';
import { FighterTestsComponent } from './components/fighter/fighter-tests/fighter-tests.component';
import { FighterRegisterTestComponent } from './components/fighter/fighter-register-test/fighter-register-test.component';
import { FighterService } from './services/fighter.service';
import { ManagerAddTournamentComponent } from './components/manager/manager-add-tournament/manager-add-tournament.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    SignupComponent,
    ManagerComponent,
    FighterComponent,
    TournamentDetailsComponent,
    FighterTournamentsComponent,
    FighterTestsComponent,
    FighterRegisterTestComponent,
    ManagerAddTournamentComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    CommonModule,
  ],
  providers: [LoginService, ManagerService, FighterService, DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
