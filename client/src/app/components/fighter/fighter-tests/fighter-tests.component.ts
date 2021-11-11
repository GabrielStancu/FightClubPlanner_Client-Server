import { DatePipe } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { FighterService } from 'src/app/services/fighter.service';
import { CovidTestDecorator } from 'src/app/shared/helpers/covid-test-decorator.model';
import { NegativeTest } from 'src/app/shared/helpers/negative-test.model';
import { PositiveTest } from 'src/app/shared/helpers/positive-test.model';
import { CovidTest } from 'src/app/shared/models/covid-test.model';
import { DetailedFighter } from 'src/app/shared/models/detailed-fighter.model';

@Component({
  selector: 'app-fighter-tests',
  templateUrl: './fighter-tests.component.html',
  styleUrls: ['./fighter-tests.component.css']
})
export class FighterTestsComponent implements OnInit {
  constructor(private fighterService: FighterService, private datePipe: DatePipe) { }

  @Input() fighterId: number;

  tests: CovidTest[] = [];
  testDecorators: CovidTestDecorator[] = [];
  fighter: DetailedFighter;
  eligibleFighter = true;

  activatedModal = false;

  ngOnInit(): void {
    this.refreshTests();
  }

  refreshTests(): void{
    this.fighterService.getFighterDetails(this.fighterId).subscribe(fighterData => {
      this.fighter = fighterData;
      fighterData.testHistory.forEach(t => t.testDateString = this.datePipe.transform(t.testDate, 'dd.MM.yyyy'));
      this.sortTests(fighterData.testHistory);
      this.colorTests();
      this.eligibleFighter = this.fighter.isEligible;
    });
  }

  onAddTest(): void {
    this.activatedModal = true;
  }

  onCloseModal(): void{
    this.activatedModal = false;
    this.refreshTests();
  }

  sortTests(tests: CovidTest[]): void {
    this.tests = tests.sort(function (a, b){
        return (b.testDate > a.testDate) ? 1 : ((b.testDate < a.testDate) ? -1 : 0);
    });
  }

  colorTests(): void {
    this.tests.forEach(t => t.isPositive ?
      this.testDecorators.push(new PositiveTest(t)) : this.testDecorators.push(new NegativeTest(t)));
  }
}
