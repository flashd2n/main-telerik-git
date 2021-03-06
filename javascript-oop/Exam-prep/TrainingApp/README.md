# Training Planner

Implement functionality for a training planner app. Implement the given classes.

## Class description

### `class Exercise`
- constructor or init method:
    - Takes `name`, `description`, `rest`, `trainingPartner`, `personalRating` and `improvementStats` as parameters
    - **Throws** if any of them are not valid!
- Properties
    - Name:
        - Must be string
        - Length between 1 and 30 (inclusive)
        - Symbols allowed: Latin letters and whitespaces
    - Description:
        - Must be non-empty string
        - Less than 160 symbols (exclusive)
    - Rest:
        - Represents rest time after exercise in seconds
        - Must be an number
        - Positive and less than 120 – nobody can rest for more than 2 minutes (exclusive)
    - TrainingPartner:
        - Must be a string
        - Symbols allowed: Latin letters and whitespaces
        - Must be a readonly property: you can set it once, but **Throw** error if anyone tries to change it afterwards
    - PersonalRating:
        - Must be an number, positive, less than 10 (inclusive)
    - ImprovementStats: `{caloriesBurn: num, performanceGain: num}`
        - An object with properties:
            - caloriesBurn -> non negative number
            - performanceGain -> non negative number
- Methods
    - Update(object)
        - Passed parameter is an object. Mandatory property - “name”.
        - The object will have the properties that must be updated
        - If the passed object’s properties are not valid, **throw error**

### `class GymExercise`
- Extends Exercise
- constructor or init method:
    - Takes `name`, `description`, `rest`, `trainingPartner`, `personalRating`, `improvementStats`, `numberOfSets`, `primaryMuscleGroup`, `secondaryMuscleGroup` and `bestWeight`
    - **Throws** if any of them is not valid!
- Properties
    - NumberOfSets:
        - Must be an number
        - Non negative, less than 10 exclusive
    - PrimaryMuscleGroup:
        - Must be a string, non-empty, less than 50 symbols, only Latin letters and whitespaces (inclusive)
    - SecondaryMuscleGroup:
        - Must be a string, non-empty, less than 75 symbols, only Latin letters and whitespaces (inclusive)
    - BestWeight:
        - Must be an number, non-negative, less than 100 (inclusive)
- Methods
    - Extend Update(object):
        - Extends the base class method to add support for: numberOfSets, primaryMuscleGroup, secondaryMuscleGroup and bestWeight
        - If the passed bestWeight is less than the current, **throw error** with message ‘Train harder, you weakling!’
        - **Throw** if invalid data is passed

### `class PoleDancing`
- Extends Exercise
- constructor or init method:
    - Takes `name`, `description`, `rest`, `trainingPartner`, `personalRating`, `improvementStats`, `difficulty` and `type`
- Properties
    - difficulty:
        - Must be a string
        - Allowed values are: “easy”, “intermediate”, “advanced”, “expert”, “dorylevel”
    - type:
        - Must be a string
        - Allowed values are: “dance” and “strength”
- Methods
    - Extend Update(object)
        - Extend the base class to add support for: difficulty and type
        - **Throw** if invalid data is passed

### `class TrainingPlanner`
- constructor or init method:
    - Takes `personalData`
- Properties
    - personalData: **{weight: num, fatPercentage: num, endurance: num, strength: num}**
        - weight must be an non negative number
        - fatPercentage must be a non-negative number less than 40 (inclusive)
        - endurance must be a non-negative number
        - strength must be a non-negative number
        - **Throw** if any of the data is invalid
    - exerciseDatabase:
        - Array with all exercises
    - schedule:
        - Array of seven objects
            - One for each day of the week
            - Each object has the following properties:
                - `day` with value equal to the day of the week (all lowercase)
                - `dailyExercises` and an array of exercises. 
- Methods
    - createExercise(object)
        - Accepts a single parameter – an object with the appropriate properties for a Gym or Pole dancing exercise
        - **Throws** if anything else is passed or if passed parameters do not meet the gym/pole dancing requirements
        - Returns a new instance of the appropriate class (gym or pole dancing)
    - addExerciseToDatabase(exercise)
        - Accepts a single parameter – a Gym/Pole dancing/Gym-like/Pole dancing-like instance/object
        - **throws** if anything else is passed
        - Adds the exercise to the database
        - **Throws** if an exercise with the same name already exists
        - Provides chaining
    - addExerciseToDatabase([exercise1, exercise2, exercise3])
        - Accepts an array with random number of exercise objects
        - These objects can be Gym/Pole dancing/Gym-like/Pole dancing-like instances/objects
        - If there is an invalid object, you **do not add it to the database, but you add all other valid objects**.
        - If there is an exercise with the same name, you skip that object, but add all unique and valid objects
        - Provides chaining
    - addExercisetoSchedule(day, exercise)
        - Accepts two parameters: a day and an exercise
        - The day must be a string and a valid name of the week (all lowercase)
        - The exercise must be a valid instance of Gym or Pole dancing or Gym-like/Pole dancing-like object
        - **Throws** if any data is invalid
        - Add the exercise to the correct day from the schedule
        - Provide chaining
    - addExercisetoSchedule(day, [exercise1, exercise2, exercise3])
        - Accepts as a first parameters a day, which must be a string and a valid day of the week (all lower case)
        - An array with random number of objects, which can be instances of Gym or Pole dancing or Gym-like/Pole dancing-like objects
        - If the day is invalid – **throw** new error
        - If any of the objects is invalid do not add any exercises to the schedule and **Throw** an error.
        - More than one exercise can be added to the day
        - Provides chaining
    - updateExercise(exercise)
        - Accepts an instance of Gym or Pole dancing
        - **Throws** if invalid
        - Finds the correct exercise from the database by `name` and updates it
        - If the exercise is not found, add it to the database
        - Provide chaining
    - getAllExercises()
        - Returns a list of all exercises in the database sorted first by `personalRating` in descending order, then by `performanceGain` in descending
    - searchExercises(object)
        - Accepts a single parameter – an object with possible properties: `trainingPartner`, `rest`, `caloriesBurn`, `primaryMuscleGroup` and `difficulty`
        - The object can contain no properties, all of the properties listed above or some of them
        - **Throws** if invalid combination of properties is passed
        - Returns an array of exercises, which match the passed query object
    - listExercises(count, property)
        - Accepts two parameters:
            - count is an number, which defaults to 10
            - property is an exercise property, cannot be “name”
        - **Throws** if invalid property is passed
        - Returns an array with `count` number of exercises sorted by `property` in ascending order
    - getProgram(day)
        - Accepts a single parameter – a day of the week
        - The passed parameter must a valid day of the week, all lowercase
        - **Throws** if invalid data is passed
        - Returns an array of exercises which are assigned to that day of the week in the schedule
    - getProgram(object)
        - Accepts an object with random number of parameters which must be valid exercise parameters
        - **Throws** if an invalid combination of parameters is passed, **throws** if there is a `name` property in the object
        - Returns an array of strings -> days, which contain at least one exercise that match the query
    - getWeeklySchedule()
        - Returns the schedule sorted by the combined personal ratings of all exercises in the each day in ascending order
    - train(day)
        - Accepts a single parameter – a valid day of the week, all lowercase
        - **Throws** if invalid data is passed
        - Calculate the changes to the personal stats using the formulae:
            - `weight` = weight – (weight/caloriesBurn)
            - `fatPercentage` = fatPercentage – (fatPercentage/ caloriesBurn)
            - `endurance` = endurance + (performanceGain / 100)
            - `strength` = strength + (performanceGain / 100) 
        - hint: calculate the total number of caloriesBurn-ed and performanceGain-ed that day and then apply the formula
        - Returns the updated personalData
    - trainWeeks(count)
        - Accepts a single parameter – a non-negative number without a floating point
        - **Throws** if `count` is not a positive number
        - calculate the changes to the personal stats using the formulae:
            - weight = weight – (weight/caloriesBurn)
            - fatPercentage = fatPercentage – (fatPercentage/ caloriesBurn)
            - endurance = endurance + (performanceGain / 100)
            - strength = strength + (performanceGain / 50) 
        - hint: calculate the total number of caloriesBurn-ed and performanceGain-ed in a day and then apply the formula for each day of the week
        - Returns the updated personalData


## SOLUTION TEMPLATE

```javascript
function solve() {

    // Your classes

    return {
        createTrainingPlanner(personalData) {
            // return new instance of Training Planner
        }
    };
}

// Submit the code above this line in bgcoder.com
module.exports = solve;
```
