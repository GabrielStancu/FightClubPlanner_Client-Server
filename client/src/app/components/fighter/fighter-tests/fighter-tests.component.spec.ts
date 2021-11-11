import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FighterTestsComponent } from './fighter-tests.component';

describe('FighterTestsComponent', () => {
  let component: FighterTestsComponent;
  let fixture: ComponentFixture<FighterTestsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FighterTestsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FighterTestsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
