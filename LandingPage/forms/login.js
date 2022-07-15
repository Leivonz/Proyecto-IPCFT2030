function login() {
  let form = document.forms["formulario"];
  let fd = new FormData(form);
  let data = {};
  for (let [key, prop] of fd) {
    data[key] = prop;
  }
  VALUE = JSON.stringify(data, null, 2);

  const API = "https://localhost:7146/api/People";

  fetch(API, {
    method: "post",
    headers: {
      "Content-Type": "application/json",
    },
    body: VALUE,
  }).then((data) => data.json())
  .catch((err) => {
    console.error(err)
  }) 
}
