import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FighterService } from 'src/app/services/fighter.service';
import { CovidTest } from 'src/app/shared/models/covid-test.model';
import { Fight } from 'src/app/shared/models/fight.model';
import { Tournament } from 'src/app/shared/models/tournament.model';

@Component({
  selector: 'app-fighter',
  templateUrl: './fighter.component.html',
  styleUrls: ['./fighter.component.css']
})
export class FighterComponent implements OnInit {

  constructor(private fighterService: FighterService, private router: Router) { }

  fighterId: number;
  tournaments: Tournament[] = [];
  fights: Fight[] = [];
  tests: CovidTest[] = [];
  test: CovidTest;
  tab = 'tournaments';

  ngOnInit(): void {
    this.fighterId = Number(localStorage.getItem('fighterId'));
    this.getFighterData();
  }

  getFighterData(): void {
    this.fighterService.getFighterDetails(this.fighterId).subscribe(fighterData => {
      this.tournaments = fighterData.tournaments;
      this.fights = fighterData.fightHistory;
      this.tests = fighterData.testHistory;
    });
  }

  onChangeTab(tab: string): void{
    this.tab = tab;
  }

  onLogout(): void{
    localStorage.setItem('fighterId', '-1');
    this.router.navigate(['login']);
  }
}
