import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ManagerService } from 'src/app/services/manager.service';
import { InviteState } from 'src/app/shared/helpers/invite-state.enum';
import { TournamentType } from 'src/app/shared/helpers/tournament-type.enum';
import { Fight } from 'src/app/shared/models/fight.model';
import { FighterDecorator } from 'src/app/shared/helpers/fighter-decorator.model';
import { Fighter } from 'src/app/shared/models/fighter.model';
import { HealthyFighter } from 'src/app/shared/helpers/healthy-fighter.model';
import { Invite } from 'src/app/shared/models/invite.model';
import { SickFighter } from 'src/app/shared/helpers/sick-fighter.model';

@Component({
  selector: 'app-tournament-details',
  templateUrl: './tournament-details.component.html',
  styleUrls: ['./tournament-details.component.css']
})
export class TournamentDetailsComponent implements OnInit {

  constructor(private managerService: ManagerService, private router: Router,
              private datePipe: DatePipe) { }

  tournamentId: number;
  fighterDecorators: FighterDecorator[] = [];
  fights: Fight[] = [];
  invitedFighterId = -1;

  invitableFighters: Fighter[] = [];
  invite: Invite;
  inviteFighterPickerText = 'Invite Fighter';
  tournamentTypePickerText = 'Pick Tournament Type';
  tournamentType: TournamentType;

  ngOnInit(): void {
    this.tournamentId = Number(localStorage.getItem('tournamentId'));
    this.rescheduleFights();
    this.refreshTournamentData();
    this.refreshInvitableFighters();
  }

  rescheduleFights(): void {
    this.managerService.rescheduleFights(this.tournamentId).subscribe(rescheduled => {
      if (rescheduled === false){
        alert('Could not reschedule fights. Not enough fighters!');
      }
    });
  }

  refreshTournamentData(): void{
    this.managerService.getTournamentInfo(this.tournamentId).subscribe(tournamentData => {
      tournamentData.fights.forEach(f => f.fightTimeString = this.datePipe.transform(f.fightTime, 'dd.MM.yyyy'));

      tournamentData.fighters.forEach(f => f.isEligible === true ?
        this.fighterDecorators.push(new HealthyFighter(f)) : this.fighterDecorators.push(new SickFighter(f)));
      this.sortFights(tournamentData.fights);
    });
  }

  refreshInvitableFighters(): void{
    this.managerService.getInvitableFighters(this.tournamentId).subscribe(invitesData => {
      this.invitableFighters = invitesData;
    });
  }

  onGoBack(): void{
    this.router.navigate(['manager']);
  }

  onSendInvite(): void{
    this.invite = {
      fighterId: this.invitedFighterId,
      dateSent: new Date(),
      inviteState: InviteState.NotAnswered,
      tournamentId: this.tournamentId
    };

    this.managerService.sendInvite(this.invite).subscribe(_ => {
      this.refreshInvitableFighters();
      this.inviteFighterPickerText = 'Invite Fighter';
      this.invitedFighterId = -1;
    });
  }

  onPickInvitedFighter(invitedFighter: Fighter): void{
    this.invitedFighterId = invitedFighter.id;
    this.inviteFighterPickerText = invitedFighter.fullName;
  }

  onPickTournamentType(tournamentType: TournamentType): void {
    this.tournamentType = tournamentType;

    if (tournamentType === TournamentType.Weekly){
      this.tournamentTypePickerText = 'Weekly Tournament';
    } else {
      this.tournamentTypePickerText = 'Monthly Tournament';
    }
  }

  onGenerateFights(): void{
    if (this.tournamentType === TournamentType.Weekly){
      this.managerService.generateWeeklyFights(this.tournamentId).subscribe(res => {
        if (res === false){
          alert('Not enough eligible fighters to generate fights!');
        } else {
          this.refreshTournamentData();
        }
      });
    } else {
      this.managerService.generateMonthlyFights(this.tournamentId).subscribe(res => {
        if (res === false){
          alert('Not enough eligible fighters to generate fights!');
        } else {
          this.refreshTournamentData();
        }
      });
    }
  }

  onPickWinner(fight: Fight, winnerId: number): void{
    fight.winnerId = winnerId;
    this.managerService.pickWinner(fight).subscribe(_ => {
      this.refreshTournamentData();
    });
  }

  sortFights(fights: Fight[]): void {
    this.fights = fights.sort(function (a, b){
        return (b.fightTime > a.fightTime) ? 1 : ((b.fightTime < a.fightTime) ? -1 : 0);
    });
  }

  isDisabledPicker(fight: Fight): boolean {
    if (this.datePipe.transform(fight.fightTime, 'yyyy.MM.dd') > this.datePipe.transform(new Date(), 'yyyy.MM.dd')){
      return true;
    }

    return false;
  }
}

