import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ManagerService } from 'src/app/services/manager.service';
import { Tournament } from 'src/app/shared/models/tournament.model';

@Component({
  selector: 'app-manager',
  templateUrl: './manager.component.html',
  styleUrls: ['./manager.component.css']
})
export class ManagerComponent implements OnInit {
  constructor(private managerService: ManagerService, private datePipe: DatePipe,
              private router: Router) {
    this.managerService = managerService;
   }

  tournaments: Tournament[] = [];
  tournament: Tournament;
  managerId: number;

  modalTitle: string;
  activatedModal = false;

  ngOnInit(): void {
    this.managerId = Number(localStorage.getItem('managerId'));
    this.refreshTournamentsList();
  }

  onAddTournament(): void {
    this.tournament = new Tournament('', '', new Date());
    this.modalTitle = 'Add Tournament';
    this.activatedModal = true;
  }

  onCloseModal(): void {
    this.activatedModal = false;
    this.refreshTournamentsList();
  }

  refreshTournamentsList(): void {
    this.managerService.getTournamentsForManager(this.managerId).subscribe(tournamentsData => {
      tournamentsData.forEach(td => td.startDateString = this.datePipe.transform(td.startDate, 'dd.MM.yyyy'));
      this.sortTournaments(tournamentsData);
    });
  }

  onTournamentDetails(tournamentData: Tournament): void {
    localStorage.setItem('tournamentId', tournamentData.id.toString());
    this.router.navigate(['tournament-details']);
  }

  onSignOut(): void{
    localStorage.setItem('managerId', '-1');
    this.router.navigate(['login']);
  }

  sortTournaments(tournaments: Tournament[]): void {
    this.tournaments = tournaments.sort(function (a, b){
        return (b.startDate > a.startDate) ? 1 : ((b.startDate < a.startDate) ? -1 : 0);
    });
  }
}
