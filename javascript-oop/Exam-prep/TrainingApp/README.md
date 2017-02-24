# Training Planner

Implement functionality for a training planner app. Implement the given classes.

## Class description

### `class Exercise`
- constructor or init method:
    - takes `name`, `description`, `rest`, `trainingPartner`, `personalRating` and `improvementStats` as parameters
- Properties
 - Name:
  - Must be string
Length between 1 and 30 (inclusive)
Symbols allowed: Latin letters and whitespaces
If invalid, throw error
Description
Must be non-empty string
Less than 160 symbols
If invalid, throw error
Rest
Represents rest time after exercise in seconds
Must be an integer
Positive and less than 120 – nobody can rest for more than 2 minutes (exclusive)
If invalid, throw error
TrainingPartner
Must be a string
Symbols allowed: Latin letters and whitespaces
If invalid, throw error
PersonalRating
Must be an integer, positive, less than 10 inclusive
If invalid, throw error
ImprovementStats {caloriesBurn: num, performanceGain: num}
An object with listed properties: 
caloriesBurn -> non negative integer
performanceGain -> non negative integer
If invalid, throw error
Methods
Update(object)
Passed parameter is an object. Mandatory property - “name”.
The object will have the properties that must be updated
If the passed object’s properties are not valid, throw error
Gym Exercise extends Exercise
Properties (name, description, rest, trainingPartner, personalRating, improvementStats, numberOfSets, primaryMuscleGroup, secondaryMuscleGroup, bestWeight)
NumberOfSets
Must be an integer
Non negative, less than 10 exclusive
PrimaryMuscleGroup
Must be a string, non-empty, less than 50 symbols, only Latin letters and whitespaces
SecondaryMuscleGroup
Must be a string, non-empty, less than 75 symbols, only Latin letters and whitespaces
BestWeight
Must be an integer, non-negative, less than 100
Methods
Extend Update(object)
Extends the base class method to add support for: numberOfSets, primaryMuscleGroup, secondaryMuscleGroup and bestWeight
If the passed bestWeight is less than the current, throw error with message ‘Train harder, you weakling!’
Throw if invalid data is passed
Pole Dancing Exercise extends Exercise
Properties (name, description, rest, trainingPartner, personalRating, improvementStats, difficulty, type)
Difficulty
Must be a string
Allowed values are: “easy”, “intermediate”, “advanced”, “expert”, “dorylevel”
Type
Must be a string
Allowed values are: “dance” and “strength”
Methods
Extend Update(object)
Extend the base class to add support for: difficulty and type
Throw if invalid data is passed
Training Planner Class
Properties (personalData)
PersonalData {weight: num, fatPercentage: num, endurance: num, strength: num}
Weight must be an non negative integer
fatPercentage must be a non-negative integer less than 40 inclusive
endurance must be a non-negative integer
strength must be a non-negative integer
Throw if any of the data is invalid
Exercise Database – array with all exercises
Schedule – array of seven objects – one for each day of the week. Each object has property “day: ” equal to the day of the week (all lowercase) and an array of exercises. 
Methods
createExercise(object)
Accepts a single parameter – an object with the appropriate properties for a Gym or Pole dancing exercise
Throws if anything else is passed or if passed parameters do not meet the gym/pole dancing requirements
Returns a new instance of the appropriate class (gym or pole dancing)
addExerciseToDatabase(exercise)
accept a single parameter – a Gym/Pole dancing/Gym-like/Pole dancing-like instance/object
throws if anything else is passed
Adds the exercise to the database
Throws if an exercise with the same name already exists
Provides chaining
addExerciseToDatabase(exercise1, exercise2, exercise3))
accepts a random number of exercise objects
these objects can be Gym/Pole dancing/Gym-like/Pole dancing-like instances/objects
if there is an invalid object, you do not add it to the database, but you add all other valid objects.
If there is an exercise with the same name, you skip that object, but add all unique and valid objects
Provides chaining
addExercisetoSchedule(day, exercise)
accepts two parameters: a day and an exercise
the day must be a string and a valid name of the week (all lowercase)
the exercise must be a valid instance of Gym or Pole dancing or Gym-like/Pole dancing-like object
throw if any data is invalid
add the exercise to the correct day from the schedule
provide chaining
addExercisetoSchedule(day, exercise1, exercise2, exercise3)
accepts as a first parameters a day, which must be a string and a valid day of the week (all lower case)
random number of objects, which can be instances of Gym or Pole dancing or Gym-like/Pole dancing-like objects
if the day is invalid – throw new error
if any of the objects is invalid -> skip it, but add to the correct day of the schedule all other valid objects
More than one exercise can be added to the day
Provide chaining
updateExercise(object)
accepts an instance of Gym or Pole dancing
throw if invalid
finds the correct exercise from the database and updates it
if the exercise is not found, add it to the database
provide chaining
getAllExercises()
return a list of all exercises in the database sorted first by personalRating in descending order, then by performanceGain in descending
searchExercises(query)
accepts a single parameter – an object with possible properties: trainingPartner, rest, caloriesBurn, primaryMuscleGroup, difficulty
the object can contain no properties, all of the properties listed above or some of them
throw if invalid combination of properties is passed
return an array of exercises, which match the passed query object
listExercises(count, property)
accepts two parameters:
count is an integer, which defaults to 10
property is an exercise property, cannot be “name”
throw if invalid property is passed
return “count” number of exercises sorted by  “property” in ascending order
getProgram(day)
accepts a single parameter – a day of the week
the passed parameter must a valid day of the week, all lowercase
throw if invalid data is passed
return an array of exercises which are assigned to that day of the week in the schedule
getProgram(query)
accepts an object with random number of parameters which must be valid exercise parameters
throw if an invalid combination of parameters is passed
throw if any of the parameters is invalid
returns an array of strings -> days, which contain at least one exercise that match the query
getWeeklySchedule()
return the schedule sorted by the combined personal ratings of all exercises in the each day in descending order
train(day)
accepts a single parameter – a valid day of the week, all lowercase
throw if invalid data is passed
calculate the changes to the personal stats using the formulae:
weight = weight – (weight/caloriesBurn)
fatPercentage = fatPercentage – (fatPercentage/ caloriesBurn)
endurance = endurance + (performanceGain / 100)
strength = strength + (performanceGain / 50) 
take into account all the exercises of the passed day
return the updated personalData
trainWeeks(count)
accepts a single parameter – a non-negative integer without a floating point
throw if invalid data is passed
calculate the changes to the personal stats using the formulae:
weight = weight – (weight/caloriesBurn)
fatPercentage = fatPercentage – (fatPercentage/ caloriesBurn)
endurance = endurance + (performanceGain / 100)
strength = strength + (performanceGain / 50) 
take into account all the exercises of each day of the week for “count” number of weeks
return the updated personalData

SOLUTION TEMPLATE

function solve() {
    // Your classes

    return createTrainingPlanner(personalData){
// returns new training planner object
}
}

