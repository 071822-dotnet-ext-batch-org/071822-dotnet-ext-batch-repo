"use strict;"

const xhr = new XMLHttpRequest();
console.log(`The readystate is ${xhr.readystate}`);


xhr.onreadystatechange = () => {
  console.log(`The readystate is ${xhr.readyState} - \nThe status code is ${xhr.status}`)
  if (xhr.readyState == 4 && xhr.status == 200) {
    console.log(`The responsetype is ${xhr.responseType.valueOf}.`);
    console.log(`The responsetext is ${xhr.responseText}`);
    displyResponseTextInBrowser();
  }
  else {
    console.log(`Jokes are not ready yet!`);
  }
};

xhr.open('GET', 'http://api.icndb.com/jokes/random', true);
xhr.send();

// I want a div that I can put p elements 
// into to display the joke text
function displyResponseTextInBrowser() {
  //get the body object
  let bodie = document.body;
  //create the div
  let myDiv = document.createElement('div');
  //create the p element
  let myP = document.createElement('p');
  //add the div and p to the html
  myDiv.appendChild(myP);
  bodie.appendChild(myDiv)
  //convert the JSON string into a JS object
  let resText = JSON.parse(xhr.responseText);
  console.log(resText)
  //add the text to the p element
  myP.textContent = resText.value.joke;

}

// now get 5 Jokes
const xhr2 = new XMLHttpRequest();
console.log(`The readystate is ${xhr2.readystate}`);
xhr2.onreadystatechange = () => {
  if (xhr2.readyState == 4 && xhr2.status == 200) {
    displyJokesInBrowser();
  }
  else {
    console.log(`Jokes are not ready yet!`);
  }
};
let five = 5;

xhr2.open('GET', `http://api.icndb.com/jokes/random/${five}`, true);
xhr2.send();

function displyJokesInBrowser() {

  console.log(xhr2.responseText);
  //get the new div element
  // let myDiv = document.querySelector('div');
  //convert the JSON string into a JS object
  // let resText = JSON.parse(xhr.responseText);
  //console.log(resText)
  // myDiv.appendChild();


}


