"use strict";

// jQuery Request

(function() {
	let url = "http://api.openweathermap.org/data/2.5/weather?q=London,England";
	let apiKey = "8a79db5299d96ff33ce37b182022172b";

	$.get(url + '&appid=' + apiKey).done(function(response){

		console.log(response);

	});


})();



// FETCH REQUEST

// (function() {
// 	let url = "http://api.openweathermap.org/data/2.5/weather?q=London,England";
// 	let apiKey = "8a79db5299d96ff33ce37b182022172b";

// 	fetch(url + '&appid=' + apiKey).then(function(fetchResponse){
		
// 		if(!fetchResponse.ok){
// 			throw new Error(fetchResponse.statusText);
// 		}

// 		return fetchResponse.json();

// 	}).then(function(jsonData){

// 		updateUISuccess(jsonData);
// 		console.log('log after ui update');

// 	}).catch(function(error){

// 		updateUIError();
// 		console.log('caught error');
		
// 	});

// 	console.log('just a random log');

// // handle XHR success

// 	function updateUISuccess(data){

// 		let condition = data.weather[0].main;
// 		let degC = data.main.temp - 273.15;
// 		let degCInt = Math.floor(degC);
// 		let degF = degC * 1.8 + 32;
// 		let degFInt = Math.floor(degF);
// 		let weatherBox = document.getElementById('weather');
// 		weatherBox.innerHTML = '<p>' + degCInt + '&#176; C / ' + degFInt + '&#176; F</p><p>' + condition + '</p>';

// 	}

// 	// handle XHR error

// 	function updateUIError(){
// 		let weatherBox = document.getElementById('weather');
// 		weatherBox.className = 'hidden';
// 	}

// })();

// XHR REQUEST

// (function() {
// 	let url = "http://api.openweathermap.org/data/2.5/weather?q=London,England";
// 	let apiKey = "8a79db5299d96ff33ce37b182022172b";
//     let httpRequest;

// 	makeRequest();

// 	// create and send an XHR request
// 	function makeRequest(){
// 		httpRequest = new XMLHttpRequest();
// 		httpRequest.onreadystatechange = responseMethod;
// 		httpRequest.open('GET', url + '&appid=' + apiKey);
// 		httpRequest.send();
// 	}

// 	// handle XHR response

// 	function responseMethod(){
// 		if(httpRequest.readyState === 4){
// 			if(httpRequest.status === 200){
// 				updateUISuccess(httpRequest.responseText);
// 			} else{
// 				updateUIError();
// 			}
// 		}
// 	}

// 	// handle XHR success

// 	function updateUISuccess(responseText){

// 		let response = JSON.parse(responseText);
// 		let condition = response.weather[0].main;
// 		let degC = response.main.temp - 273.15;
// 		let degCInt = Math.floor(degC);
// 		let degF = degC * 1.8 + 32;
// 		let degFInt = Math.floor(degF);
// 		let weatherBox = document.getElementById('weather');
// 		weatherBox.innerHTML = '<p>' + degCInt + '&#176; C / ' + degFInt + '&#176; F</p><p>' + condition + '</p>';

// 	}

// 	// handle XHR error

// 	function updateUIError(){
// 		let weatherBox = document.getElementById('weather');
// 		weatherBox.className = 'hidden';
// 	}

// })();