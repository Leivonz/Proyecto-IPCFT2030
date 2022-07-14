const button = document.getElementById("button");

button.addEventListener("click", () => {
  const newPost = {
    nombre: document.getElementById("names").value,
    apellido: document.getElementById("apellidos").value,
    correo: document.getElementById("emailAddress").value,
    numero: document.getElementById("phoneNumber").value,
    pass: document.getElementById("pass").value,
    organizacion: document.getElementById("orgName").value,
    nacionalidad: 1
  };
  fetch('https://localhost:7146/api/People',  {
    method: "POST",
    body: JSON.stringify(newPost),
    headers: {
      "access-control-allow-origin": "*", 
      "Content-type": "text/plain; charset=utf-8",
      "server": "Kestrel"
    },
  }).then(res => res.json())
});
