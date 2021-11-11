import { DatePipe } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { FighterService } from 'src/app/services/fighter.service';
import { CovidTest } from 'src/app/shared/models/covid-test.model';
import { DetailedFighter } from 'src/app/shared/models/detailed-fighter.model';
import { IsolationBubble } from 'src/app/shared/models/isolation-bubble';

@Component({
  selector: 'app-fighter-register-test',
  templateUrl: './fighter-register-test.component.html',
  styleUrls: ['./fighter-register-test.component.css']
})
export class FighterRegisterTestComponent implements OnInit {

  constructor(private fighterService: FighterService, private datePipe: DatePipe) { }

  test: CovidTest;
  @Input() fighter: DetailedFighter;
  isolationBubbles: IsolationBubble[] = [];
  isolationBubble: IsolationBubble;
  isPositive = false;

  dropdownText = 'Pick Isolation Bubble';
  disabledOwnTest = true;

  ngOnInit(): void {
    this.fighterService.getIsolationBubbles().subscribe(isolationBubbles => {
      this.isolationBubbles = isolationBubbles;
    });

    this.disabledOwnTest = this.fighter.testHistory.length !== 0;

    this.test =
    {
      id: 0,
      isPositive: false,
      testDate: new Date(),
      fighterId: Number(localStorage.getItem('fighterId')),
      isolationBubbleId: 0,
      isolationBubbleName: '',
      testDateString: this.datePipe.transform(new Date(), 'dd.MM.yyyy')
    };
  }

  onPickBubble(isolationBubble): void{
    this.isolationBubble = isolationBubble;
    this.dropdownText = isolationBubble.name;
  }

  onRegisterTest(): void {
    if (this.isolationBubble != null){
      this.test.isolationBubbleId = this.isolationBubble.id;
      this.test.isolationBubbleName = this.isolationBubble.name;
      this.test.isPositive = this.isPositive;

      // tslint:disable-next-line: deprecation
      this.fighterService.registerTest(this.test).subscribe(testsData => {
        testsData.forEach(td =>
          {
            td.testDateString = this.datePipe.transform(td.testDate, 'dd.MM.yyyy');
            this.fighter.testHistory.push(td);
          }
      );
    });
    }else{
      alert('You must pick an isolation bubble!');
    }
  }
}
