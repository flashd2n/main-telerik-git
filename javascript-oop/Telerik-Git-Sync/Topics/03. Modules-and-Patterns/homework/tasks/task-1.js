/* Task Description */
/* 
* Create a module for a Telerik Academy course
  * The course has a title and presentations
    * Each presentation also has a title
    * There is a homework for each presentation
  * There is a set of students listed for the course
    * Each student has firstname, lastname and an ID
      * IDs must be unique integer numbers which are at least 1
  * Each student can submit a homework for each presentation in the course
  * Create method init
    * Accepts a string - course title
    * Accepts an array of strings - presentation titles
    * Throws if there is an invalid title
      * Titles do not start or end with spaces
      * Titles do not have consecutive spaces
      * Titles have at least one character
    * Throws if there are no presentations
  * Create method addStudent which lists a student for the course
    * Accepts a string in the format 'Firstname Lastname'
    * Throws if any of the names are not valid
      * Names start with an upper case letter
      * All other symbols in the name (if any) are lowercase letters
    * Generates a unique student ID and returns it
  * Create method getAllStudents that returns an array of students in the format:
    * {firstname: 'string', lastname: 'string', id: StudentID}
  * Create method submitHomework
    * Accepts studentID and homeworkID
      * homeworkID 1 is for the first presentation
      * homeworkID 2 is for the second one
      * ...
    * Throws if any of the IDs are invalid
  * Create method pushExamResults
    * Accepts an array of items in the format {StudentID: ..., Score: ...}
      * StudentIDs which are not listed get 0 points
    * Throw if there is an invalid StudentID
    * Throw if same StudentID is given more than once ( he tried to cheat (: )
    * Throw if Score is not a number
  * Create method getTopStudents which returns an array of the top 10 performing students
    * Array must be sorted from best to worst
    * If there are less than 10, return them all
    * The final score that is used to calculate the top performing students is done as follows:
      * 75% of the exam result
      * 25% the submitted homework (count of submitted homeworks / count of all homeworks) for the course
*/

'use strict';
function solve() {
var Course = (function(){
    let courseTitle = '';
    let coursePresentations = [];
    let students = [];    

    function init(title, presentations){
      if(presentations === undefined || presentations === null || presentations.length === 0){
        throw new Error ('Missing presentations');
      }
      if(title.length === 0 || title === undefined || title === '' || title === null){
        throw new Error ('Title cannot be empty');
      }
      if(title[0] === ' ' || title[title.length - 1] === ' '){
        throw new Error ('Title cannot start or end with an empty space');
      }
      presentations.forEach(function(x){
        if(x === ''){
          throw new Error('presentation title cannot be empty');
        }
        if(/\s{2,}/.test(x)){
          throw new Error('presentation cannot contain more than one consecutive whitespaces');
        }
      });

      courseTitle = title;
      coursePresentations = presentations;
      return this;
    }

    function addStudent(name){
      let nameInput = name.split(' ');

      if(nameInput.length !== 2){
        throw new Error ('Invalid name count');
      }
      if(!/^[A-Z]/.test(nameInput[0]) || !/^[A-Z]/.test(nameInput[1])){
        throw new Error ('Missing capital letter');
      }
      let studentID = students.length + 1;
      students.push({
        firstname: nameInput[0] + '',
        lastname: nameInput[1] + '',
        ID: +studentID,
        examResult: 0,
        homeworks: 0,
        finalScore: 0
      });

      return studentID;

    }

    function getAllStudents(){

        let result = [];
        
        for(let i = 0; i < students.length; i++){
            result.push({
                firstname: students[i].firstname,
                lastname: students[i].lastname,
                ID: students[i].ID
            });
        }

        return result;

    }

    function submitHomework(studentID, homeworkID){

      validateStudentID(studentID);

      if(homeworkID === 0){
        throw new Error ('cannot have a homework with id 0');
      }
      if(homeworkID % 1 !== 0){
        throw new Error ('id cannot be a floating point number');
      }
      if(homeworkID > coursePresentations.length){
        throw new Error ('invalid homeworkID')
      }

      for(let i = 0; i < students.length; i++){
        if(studentID === students[i].ID){
            students[i].homeworks += 1;
            break;
        }
      }

    }

    function pushExamResults(results){
      let tempIds = [];
      // perform array checks
      if(results === undefined || results === null){
        throw new Error('results cannot be empty');
      }
      if(!Array.isArray(results)){
        throw new Error('results is not an array');
      }
      

      results.forEach(function(x){
        validateStudentID(x.StudentID);
        if(tempIds.includes(x.StudentID)){
          throw new Error ('cheater');
        }
        if(!x.hasOwnProperty('score')){
          throw new Error('results does not contain a score value');
        }
        if(isNaN(x.score)){
          throw new Error('results constains invalid score value');
        }
        tempIds.push(x.StudentID);
      });

      for(let i = 0; i < results.length; i++){

        for(let j = 0; j < students.length; j++){

            if(results[i].StudentID === students[i].ID){
                students[i].examResult = results[i].score;
                break;
            }


        }

      }
    }

    function getTopStudents(){
        let resultCalculation = 0;
        let result = [];

        for(let i = 0; i < students.length; i++){
            resultCalculation = ((students[i].examResult * 75) / 100) + ((students[i].homeworks * 25) / 100);
            students[i].finalScore = resultCalculation;
        }

        students.sort((x,y) => y.finalScore - x.finalScore);

        for(let i = 0; i < 10; i++){
            if(i === students.length){
                break;
            }
            result.push({
                firstname: students[i].firstname,
                lastname: students[i].lastname,
                ID: students[i].ID
            });
        }

        return result;

    }

    function validateStudentID(studentID){
      if(studentID === 0){
        throw new Error ('cannot have a student with id 0');
      }
      if(isNaN(studentID)){
        throw new Error ('student id is not a number');
      }
      if(studentID % 1 !== 0){
        throw new Error ('id cannot be a floating point number');
      }
      if(studentID > students.length){
        throw new Error ('id is not valid');
      }
      if(studentID <= 0){
        throw new Error ('id is not valid');
      }
    }

    function getAllStudentData(){
        return students;
    }

    return{
		  init: init,
		  addStudent: addStudent,
		  getAllStudents: getAllStudents,
		  submitHomework: submitHomework,
		  pushExamResults: pushExamResults,
		  getTopStudents: getTopStudents,
      getAllStudentData: getAllStudentData
	  };
  }());

	return Course;
}


module.exports = solve;



