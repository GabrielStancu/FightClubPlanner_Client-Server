import { FighterComponent } from './fighter-component.model';
import { FighterDecorator } from './fighter-decorator.model';

export class SickFighter extends FighterDecorator{
    constructor(fighterComponent: FighterComponent){
        super(fighterComponent);
    }

    fighterColor = '#f94144'; // red

    stringToColor(): string{
        return this.fighterColor;
    }
}
