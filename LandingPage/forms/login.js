function login() {
  let form = document.forms["formulario"];
  let fd = new FormData(form);
  let data = {};
  for (let [key, prop] of fd) {
    data[key] = prop;
  }

  const API = "https://localhost:7146/api/Login";

  fetch(API, {
    method: "post",
    headers: {
      "Content-Type": "application/json",
    },
  })
    .then((data) => data.json())
    .catch((err) => {
      console.error(err);
    });
}

// var jwt = require('jwt-simple');
// var payload = { foo: 'bar' };
// var secret = 'xxx';

// // HS256 secrets are typically 128-bit random strings, for example hex-encoded:
// // var secret = Buffer.from('fe1a1915a379f3be5394b64d14794932', 'hex')

// // encode
// var token = jwt.encode(payload, secret);

// // decode
// var decoded = jwt.decode(token, secret);
// var jwt = localStorage.getItem("jwt");
// if (jwt != null) {
//   window.location.href = '/LandingPage/Intranet/index.html'
// }

// function login() {
//   const username = document.getElementById("emailAddress").value;
//   const password = document.getElementById("pass").value;

//   const xhttp = new XMLHttpRequest();
//   xhttp.open("POST", "https://localhost:7146/api/People");
//   xhttp.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
//   xhttp.send(JSON.stringify({
//     "emailAddress": username,
//     "pass": password
//   }));
//   xhttp.onreadystatechange = function () {
//     if (this.readyState == 4) {
//       const objects = JSON.parse(this.responseText);
//       console.log(objects);
//       if (objects['status'] == 'ok') {
//         localStorage.setItem("jwt", objects['accessToken']);
//         Swal.fire({
//           text: objects['message'],
//           icon: 'success',
//           confirmButtonText: 'OK'
//         }).then((result) => {
//           if (result.isConfirmed) {
//             window.location.href = '/LandingPage/Intranet/index.html';
//           }
//         });
//       } else {
//         Swal.fire({
//           text: objects['message'],
//           icon: 'error',
//           confirmButtonText: 'OK'
//         });
//       }
//     }
//   };
//   return false;
// }
