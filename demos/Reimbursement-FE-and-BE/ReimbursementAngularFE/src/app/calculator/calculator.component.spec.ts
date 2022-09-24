import { ComponentFixture, TestBed } from '@angular/core/testing';
import { CalculatorServiceService } from '../calculator-service.service';
import { CalculatorComponent } from './calculator.component';

describe('CalculatorComponent', () => {
  let calcClassInst: CalculatorComponent; //create a  property to hold the component class instance
  let fixture: ComponentFixture<CalculatorComponent>; // creae a property to hold the entire component

  //the two beforeEach() function calls equate the ARRANGE step.
  // UNCOMMENT these to run the first test.
  // ARRANGE section of the unit tests (in whole or in part)
  // beforeEach(async () => {
  //   await TestBed.configureTestingModule({  // create a TestBed object that IS the environment for your tests.
  //     declarations: [CalculatorComponent]
  //   })
  //     .compileComponents();
  // });

  // beforeEach(() => {
  //   fixture = TestBed.createComponent(CalculatorComponent);// this is reflection! Send the name of the
  //   // class in to get an instance of the whole component back.
  //   calcClassInst = fixture.componentInstance;// get a class instance
  //   // run a 'change detection' cycle to set everything (mainly in the .html and .ts)
  //   fixture.detectChanges();
  // });

  //our first unit test
  // delete the 'x' to include this test in the suite again.
  xit('should create', () => {
    console.log(calcClassInst);
    expect(calcClassInst).toBeTruthy();// make sure that the componment was created.
  });

  xit('should be truthy', () => {
    pending();
  });

  xit('should add the two numbers', () => {
    // ARRANGE
    //already done above

    // ACT
    const sum = calcClassInst.calcAddNumbersReturnSum(1, 2);

    // Assert
    expect(sum).toBe(3);
  });

  it('should only call addNumbersReturnSum() once', () => {
    //ARRANGE
    const cs = new CalculatorServiceService();
    spyOn(cs, 'addNumbersReturnSum').and.returnValue(10);
    const cc = new CalculatorComponent(cs);

    //ACT 
    const sum = cc.calcAddNumbersReturnSum(400, 5);

    //ASSERT
    expect(sum).toBe(10);
    expect(cs.addNumbersReturnSum).toHaveBeenCalledTimes(1);
  });

  it('should use a spy object to mock the dependency', () => {
    // ARRANGE
    //use a reflection-type syntax to assign the specific functions we want to mock in the mocked class.
    //you don't have to mock every function. Just the ones you will be testing/calling
    const calcService = jasmine.createSpyObj('CalculatorServiceService', ['addNumbers', 'addNumbersReturnSum']);
    calcService.addNumbersReturnSum.and.returnValue(100);// functions that return something can be given a static value ot return no matter what is sent as an argument

    // The TestBed object is the testing env for all tests in the Jasmine test suite. 
    // You can only set it up once in the file and it applies to all tests in the suite.
    TestBed.configureTestingModule(
      {
        //you have to give it the classes (providers) you will be using.
        // The object uses provide and useValue properties to tell Testbed to replace the actual service with the spy you created above.
        // This is necessary to isolate the component functions. NOT mocking the service (dependency) makes this an integration test (not a unit test).
        providers: [CalculatorComponent, { provide: CalculatorServiceService, useValue: calcService }]
      }
    );
    let calcClass: CalculatorComponent
    calcClass = TestBed.inject(CalculatorComponent) // inject() is the new function to get an instance to the component class with the mocked dependency injected.
    // ACT
    calcClass.calcAddNumbers(3, 4);
    const sum = calcClass.calcAddNumbersReturnSum(8, 9);

    // ASSERT (EXPECT)
    expect(calcService.addNumbers).toHaveBeenCalledTimes(1);
    expect(sum).toBe(100);
    expect(calcService.addNumbersReturnSum).toHaveBeenCalledTimes(1);
  });
});
