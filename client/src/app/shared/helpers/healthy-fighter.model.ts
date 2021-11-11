import { FighterComponent } from './fighter-component.model';
import { FighterDecorator } from './fighter-decorator.model';

export class HealthyFighter extends FighterDecorator{
    constructor(fighterComponent: FighterComponent){
        super(fighterComponent);
    }

    fighterColor = '#4c956c'; // green

    stringToColor(): string{
        return this.fighterColor;
    }
}
