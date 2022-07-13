const button = document.getElementById("button");

button.addEventListener("click", () => {
  const newPost = {
    nombre: document.getElementById("names").value,
    apellido: document.getElementById("apellidos").value,
    correo: document.getElementById("emailAddress").value,
    numero: document.getElementById("phoneNumber").value,
    pass: document.getElementById("pass").value,
    nombreOrganizacion: document.getElementById("orgName").value,
  };
  fetch("https://localhost:7063/api/People", + newPost, {
    method: "POST",
    mode: "no-cors",
    body: JSON.stringify(newPost),
    headers: {
      "Accept": "application/json",
      "Content-type": "application.json",
      "server": "Kestrel"
    },
  }).then((res) => res.json());
});
