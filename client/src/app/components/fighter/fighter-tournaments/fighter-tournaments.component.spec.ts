import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FighterTournamentsComponent } from './fighter-tournaments.component';

describe('FighterTournamentsComponent', () => {
  let component: FighterTournamentsComponent;
  let fixture: ComponentFixture<FighterTournamentsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FighterTournamentsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FighterTournamentsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
