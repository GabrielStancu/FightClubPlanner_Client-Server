import { Component, OnInit } from '@angular/core';
import { ManagerService } from 'src/app/services/manager.service';
import { Tournament } from 'src/app/shared/models/tournament.model';

@Component({
  selector: 'app-manager-add-tournament',
  templateUrl: './manager-add-tournament.component.html',
  styleUrls: ['./manager-add-tournament.component.css']
})
export class ManagerAddTournamentComponent implements OnInit {

  constructor(private managerService: ManagerService) { }

  tournament: Tournament;
  tournamentName: string;
  tournamentLocation: string;
  tournamentStartDate: Date;

  ngOnInit(): void {
  }

  onCreateTournament(): void{
    this.tournament = new Tournament(
      this.tournamentName,
      this.tournamentLocation,
      this.tournamentStartDate,
    );
    this.tournament.organizerId = Number(localStorage.getItem('managerId'));

    // tslint:disable-next-line: deprecation
    this.managerService.createTournament(this.tournament).subscribe(tournamentData => {
      if (tournamentData === false){
        alert('Error. Tournament name taken, fields not completed or start date in the past!');
      }
    });
  }

  allFieldsCompleted(): boolean{
    if (this.tournamentName === undefined || this.tournamentName === '' ||
        this.tournamentLocation === undefined || this.tournamentLocation === '' ||
        this.tournamentStartDate === undefined){
          return false;
        }

    return true;
  }

}
