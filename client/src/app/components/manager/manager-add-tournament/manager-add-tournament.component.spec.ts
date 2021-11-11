import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManagerAddTournamentComponent } from './manager-add-tournament.component';

describe('ManagerAddTournamentComponent', () => {
  let component: ManagerAddTournamentComponent;
  let fixture: ComponentFixture<ManagerAddTournamentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ManagerAddTournamentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ManagerAddTournamentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
