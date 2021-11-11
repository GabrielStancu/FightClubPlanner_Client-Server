import { CovidTestComponent } from './covid-test-component.model';

export abstract class CovidTestDecorator extends CovidTestComponent{
    constructor(public covidTestComponent: CovidTestComponent){
        super();
    }

    stringToColor(): string{
        if (this.covidTestComponent !== null){
            return this.covidTestComponent.stringToColor();
        }

        return null;
    }
}
