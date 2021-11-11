import { CovidTestComponent } from './covid-test-component.model';
import { CovidTestDecorator } from './covid-test-decorator.model';

export class PositiveTest extends CovidTestDecorator{
    constructor(covidTestComponent: CovidTestComponent){
        super(covidTestComponent);
    }

    testColor = '#f94144'; // red

    stringToColor(): string{
        return this.testColor;
    }
}
