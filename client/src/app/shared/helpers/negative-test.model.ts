import { CovidTestComponent } from './covid-test-component.model';
import { CovidTestDecorator } from './covid-test-decorator.model';

export class NegativeTest extends CovidTestDecorator{
    constructor(covidTestComponent: CovidTestComponent){
        super(covidTestComponent);
    }

    testColor = '#4c956c'; // green

    stringToColor(): string{
        return this.testColor;
    }
}
