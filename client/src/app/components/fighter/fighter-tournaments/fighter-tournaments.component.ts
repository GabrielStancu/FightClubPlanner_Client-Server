import { DatePipe } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { FighterService } from 'src/app/services/fighter.service';
import { InviteState } from 'src/app/shared/helpers/invite-state.enum';
import { Fight } from 'src/app/shared/models/fight.model';
import { Invite } from 'src/app/shared/models/invite.model';
import { Tournament } from 'src/app/shared/models/tournament.model';

@Component({
  selector: 'app-fighter-tournaments',
  templateUrl: './fighter-tournaments.component.html',
  styleUrls: ['./fighter-tournaments.component.css']
})
export class FighterTournamentsComponent implements OnInit {

  constructor(private fighterService: FighterService, private datePipe: DatePipe) { }

  @Input() fighterId: number;

  tournaments: Tournament[] = [];
  fights: Fight[] = [];
  invites: Invite[] = [];

  ngOnInit(): void {
    this.refreshFighterData();
  }

  refreshFighterData(): void {
    this.fighterService.getFighterDetails(this.fighterId).subscribe(fighterData => {
      fighterData.tournaments.forEach(td => td.startDateString = this.datePipe.transform(td.startDate, 'dd.MM.yyyy'));
      fighterData.fightHistory.forEach(f => f.fightTimeString = this.datePipe.transform(f.fightTime, 'dd.MM.yyyy'));
      fighterData.invites.forEach(i =>
        {
          i.dateSentString = this.datePipe.transform(i.dateSent, 'dd.MM.yyyy');
          this.parseInviteState(i);
        });

      this.sortTournaments(fighterData.tournaments);
      this.sortFights(fighterData.fightHistory);
      this.sortInvites(fighterData.invites);
    });
  }

  onAnswerInvite(invite: Invite, answer: InviteState): void {
    invite.inviteState = answer;
    this.fighterService.answerInvite(invite).subscribe( () => {
      this.parseInviteState(invite);
      this.refreshFighterData();
    });
  }

  isAnsweredInvite(invite: Invite): boolean {
    if (invite.inviteState === InviteState.NotAnswered){
      return false;
    }

    return true;
  }

  parseInviteState(invite: Invite): void{
      if (invite.inviteState === InviteState.Accepted){
        invite.inviteStateString = 'Accepted';
      } else if (invite.inviteState === InviteState.Declined) {
        invite.inviteStateString = 'Declined';
      } else {
        invite.inviteStateString = 'Not answered';
      }
  }

  sortFights(fights: Fight[]): void {
    this.fights = fights.sort(function (a, b){
        return (b.fightTime > a.fightTime) ? 1 : ((b.fightTime < a.fightTime) ? -1 : 0);
    });
  }

  sortInvites(invites: Invite[]): void {
    this.invites = invites.sort(function (a, b){
        return (b.dateSent > a.dateSent) ? 1 : ((b.dateSent < a.dateSent) ? -1 : 0);
    });
  }

  sortTournaments(tournaments: Tournament[]): void {
    this.tournaments = tournaments.sort(function (a, b){
        return (b.startDate > a.startDate) ? 1 : ((b.startDate < a.startDate) ? -1 : 0);
    });
  }
}
