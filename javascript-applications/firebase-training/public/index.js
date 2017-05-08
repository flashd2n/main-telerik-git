'use strict';


let playersReference = firebase.database().ref('players');


playersReference.set({
    John: {
        number: 1,
        age: 30
    },
    Amanda: {
        number: 2,
        age: 20
    },
    Kalin: {
        number: 3,
        age: 28
    }
});

let kalinRefAge = firebase.database().ref('players').child('Kalin').child('age');

console.log(kalinRefAge.key);

// get the value of "age" for "kalin", increments and updates the database

kalinRefAge.transaction(function (result) {
    return result + 1;
});


// try to get the entire database

let entireDatabase = firebase.database().ref();

entireDatabase.on('value', function (snapshot) { // triggers every time data changes

    let data = snapshot.val();

}, function (error) {
    console.log('some error');
});

// AUTH

var email = 'myemaill@email.com';
var password = 'mypassword';

// register

//firebase.auth().createUserWithEmailAndPassword(email, password).then(function (result) {
//    console.log(result); //the .uid is important here -> authkey
//}).catch(function () {
//    console.log('error');
//});

// sign in

//firebase.auth().signInWithEmailAndPassword(email, password).then(function (result) {
//    console.log(result); // returns the same object like register -> important here is authkey // enters uid in localStorage
//
//}).catch(function (error) {
//    console.log(error.code);
//    console.log(error.message);
//});

// sign out

//firebase.auth().signOut().then(function () {
//    console.log('Logged out!');
//}, function (error) {
//    console.log(error.code);
//    console.log(error.message);
//});

$('#testJ').html('jQuery works!');
