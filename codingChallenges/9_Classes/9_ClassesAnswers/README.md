# Class Challenge
A class is a blueprint for a datatype. In this challenge, you will be 
    manipulating a class to experiment with how classes work.

# Part 1
1. In the provided Human class: 
    - Create a private string variable, 'lastName'. Give it a default value of "Smyth". (order of these only matters when they are parameters in the constructor.)
    - Create a private string variable, 'firstName'. Give it a default value of "Pat".
2. Create a parameterized constructor that has two parameters. Use these parameters to set the firstName and lastName variables. firstName should be first, lastName should be second.
3. Instantiate a Human without arguments
    - You will run into an error. Work to resolve it.    
4. Instantiate a Human with firstName and lastName args.
5. Refactor Human to create an AboutMe() method that uses interpolation and the firstName and lastName variables to return "My name is Pat Smyth." or "My name is Dick Butkus.", etc.
6. Call the AboutMe() method on both Humans.

# Part 2
1. Create a Human2 Class. Make it exactly the same as the Human class except add two more private member variables to the Human2 Class.
    - 'eyeColor' (string) and 'age' (int) with no default values for either.
2. Create 3 parameterized constructors that:
    - requires all four of the values to be used when creating a Human object.
    - requires firstName, lastName, and age,
    - requires firstName, lastName, and eyeColor.
3. Create Human2.AboutMe2() so that if eyeColor and/or age has not been set, it returns the information that has been set.
    - Testing will check for these exact sentence structures/combinations but with the correct values.
    - ex. "My name is Pat Smyth. My age is 6." (because eyeColor was not set.)
    - ex. "My name is Jim Johnson. My age is 56. My eye color is Brown." (because firstName, lastName, eyeColor, and age had been set)
    - ex. "My name is Jim Smyth." (because only the first and last names had been set.)
4. Create three objects of type Human2.
    - Set only the names and eyeColor on the first
    - Set only the names and age on the second
    - Set all four values on the third
5. Call the Human2.AboutMe2() method on all three new Human2 objects.
6. Create a new public Human2 Property called Weight using the prop + tab + tab shortcut.
    - Add validation to the Weight 'Get' method such that a Weight below 0 and a weight above 400 is not allowed.
    - If an invalid value is inputted to Weight, reset the weight to 0;
7. Instantiate a Human2:
    - Set the Weight to a valid value.
    - Try to set the Weight to an invalid value.
    - Check the new Weight value. It should be 0.

## Reference Materials:
- [Why use private variables?](https://softwareengineering.stackexchange.com/questions/143736/why-do-we-need-private-variables)    
- [Access modifiers and me](https://code-maze.com/csharp-basics-access-modifiers/)
