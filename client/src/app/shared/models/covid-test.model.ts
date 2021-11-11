import { CovidTestComponent } from '../helpers/covid-test-component.model';

export class CovidTest extends CovidTestComponent{
    constructor(public id: number, public isPositive: boolean,
                public testDate: Date, public fighterId: number,
                public isolationBubbleId: number,
                public isolationBubbleName: string,
                public testDateString: string){
                    super();
                }
    stringToColor?(): string {
        return '';
    }
}
