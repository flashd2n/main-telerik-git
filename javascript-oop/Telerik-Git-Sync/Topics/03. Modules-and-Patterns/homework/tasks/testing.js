'use strict';

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


let myCourse = Object.create(Course);
let myCourseTwo = Object.create(Course);
myCourse.init('interesting course', ['css', 'js']);
myCourseTwo.init('interesting course TWO', ['css', 'js']);

console.log('no students');
console.log(myCourse.getAllStudents());

let studentOne = {
    firstname: 'Gosho',
    lastname: 'Goshev'
};
studentOne.id = myCourse.addStudent(studentOne.firstname + ' ' + studentOne.lastname);

console.log('one students');
console.log(myCourse.getAllStudents());

let studentTwo = {
    firstname: 'Tosho',
    lastname: 'Toshev'
};
studentTwo.id = myCourse.addStudent(studentTwo.firstname + ' ' + studentTwo.lastname);

console.log('multiple students');
console.log(myCourse.getAllStudents());

console.log('----- check pushExamResults ----');

// myCourse.pushExamResults([{StudentID: 1, score: 4}, {StudentID: 2}]);  WORKS

// myCourse.pushExamResults([{StudentID: 1, score: 4}, {StudentID: 1, score: 5}]);  WORKS

// myCourse.pushExamResults([{StudentID: studentTwo.id + 5, score: 3}, {StudentID: 1, score: 5}]); WORKS

// myCourse.pushExamResults([{StudentID: 'pesho', score: 3}, {StudentID: 1, score: 5}]); WORKS

myCourse.pushExamResults([{StudentID: 1, score: 100}, {StudentID: 2, score: 50}]); // WORKS

console.log(`----- pushExamResults checks are completed and valid`);

myCourse.submitHomework(1, 1);
myCourse.submitHomework(1, 2);
myCourse.submitHomework(2, 2);


console.log(myCourse.getAllStudentData());

console.log('---- TESTING FINAL METHOD');

console.log(myCourse.getTopStudents());
console.log('----course Two----');
console.log(myCourseTwo.getAllStudents());