import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FighterRegisterTestComponent } from './fighter-register-test.component';

describe('FighterRegisterTestComponent', () => {
  let component: FighterRegisterTestComponent;
  let fixture: ComponentFixture<FighterRegisterTestComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FighterRegisterTestComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FighterRegisterTestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
