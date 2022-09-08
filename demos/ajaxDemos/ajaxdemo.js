"use strict;"

// const xhr = new XMLHttpRequest();
// console.log(`The readystate is ${xhr.readystate}`);


// xhr.onreadystatechange = () => {
//   console.log(`The readystate is ${xhr.readyState} - \nThe status code is ${xhr.status}`)
//   if (xhr.readyState == 4 && xhr.status == 200) {
//     console.log(`The responsetype is ${xhr.responseType.valueOf}.`);
//     console.log(`The responsetext is ${xhr.responseText}`);
//     displyResponseTextInBrowser();
//   }
//   else {
//     console.log(`Jokes are not ready yet!`);
//   }
// };

// xhr.open('GET', 'http://api.icndb.com/jokes/random', true);
// xhr.send();

// // I want a div that I can put p elements 
// // into to display the joke text
// function displyResponseTextInBrowser() {
//   //get the body object
//   let bodie = document.body;
//   //create the div
//   let myDiv = document.createElement('div');
//   //create the p element
//   let myP = document.createElement('p');
//   //add the div and p to the html
//   myDiv.appendChild(myP);
//   bodie.appendChild(myDiv)
//   //convert the JSON string into a JS object
//   let resText = JSON.parse(xhr.responseText);
//   //console.log(resText)
//   //add the text to the p element
//   myP.textContent = resText.value.joke;

// }

// now get 5 Jokes
// const xhr2 = new XMLHttpRequest();
// console.log(`The readystate is ${xhr2.readystate}`);
// xhr2.onreadystatechange = () => {
//   if (xhr2.readyState == 4 && xhr2.status == 200) {
//     displyJokesInBrowser();
//   }
//   else {
//     console.log(`Jokes are not ready yet!`);
//   }
// };
// let five = 5;

// xhr2.open('GET', `http://api.icndb.com/jokes/random/${five}`, true);
// xhr2.send();

// function displyJokesInBrowser() {

//   console.log(xhr2.responseText);
//get the new div element
// let myDiv = document.querySelector('div');
//convert the JSON string into a JS object
// let resText = JSON.parse(xhr.responseText);
//console.log(resText)
// myDiv.appendChild();
//}

/**
 * 
caution! fetching below.
*
**/
// fetch('http://api.icndb.com/jokes/random?firstName=John&lastName=Doe')
//   .then(
//     (res) => {
//       //console.log(`res.ok-${res.ok}, \nheaders${res.headers}, \n value-${res.value},\nresponstype-${res.responseType},\nresponsetext-${res.responseText}`);
//       console.log(res)
//       return res.json()
//     },
//     (rej) => { throw new Error("\nThere was an ERRR...\n") })
//   .then((body) => {
//     // for (let x of body.value) {
//     console.log(body.value.joke);
//     // }
//   })
//   .catch(err => { throw new Error("\nThere was a NEW ERRR...\n") })// lets test if the catch runs either way...


//query the ReimbursementAPI
// fetch('https://localhost:7208/api/ExpenseReimbursement/requestsasync')
//   .then(
//     response => {
//       if (response.ok) {
//         return response.json()
//       }
//       else {
//         console.log(`There was a problem in the response!!!`);
//       }
//     },
//     (rej) => { throw new Error("\nThere was an ERRR...\n") })
//   .then((body) => {
//     for (let x of body) {
//       console.log(`${x.requestID}\n${x.fK_EmployeeID}\n${x.details}\n${x.amount}\n${x.status}`);
//       //save this data in the local storage
//       let myObj = { id: x.fK_EmployeeID, deets: x.details, amt: x.amount, status: x.status }
//       localStorage.setItem(x.requestID, myObj);
//     }
//     return body;
//   })
//   .then((body) => {
//     //get the body object
//     let bodie = document.body;
//     //create the div
//     let myDiv = document.createElement('div');
//     //create the p element
//     for (let x of body) {//iterate over the body to match wtih localstorage keys.
//       let myP = document.createElement('p');
//       myDiv.appendChild(myP);
//       bodie.appendChild(myDiv)
//       let request = localStorage.getItem(JSON.stringify(x.requestID))
//       let parsedrequest = JSON.parse(request);
//       myP.textContent = parsedrequest.deets;
//     }
//     //add the div and p to the html
//     //convert the JSON string into a JS object
//     // let resText = JSON.parse(xhr.responseText);
//     //console.log(resText)
//     //add the text to the p element
//   })
//   .catch(err => { throw new Error(`\nThere was a NEW ERRR...\n -- ${err}`) })// lets test if the catch runs either way...

fetch('https://localhost:7208/api/ExpenseReimbursement/registerasync',
  {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(
      {
        "FirstName": "Benito",
        "LastName": "Mussolini",
        "Ismanager": true,
        "Email": "ouch@myneck.edu",
        "Password": "odevichi"
      }
    )
  })
  .then(res => {
    if (res.ok) {
      return res.json();
    }
  })
  .then(bod => {
    console.log(bod.firstName, bod.lastName, bod.isManager, bod.email);
  })