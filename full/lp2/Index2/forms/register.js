const button = document.getElementById("button");

button.addEventListener("click", () => {
  const newPost = {
    namePerson: document.getElementById("names").value,
    surnamePerson: document.getElementById("apellidos").value,
    emailPerson: document.getElementById("emailAddress").value,
    phonePerson: document.getElementById("phoneNumber").value,
    passwordPerson: document.getElementById("pass").value,
  };
  fetch("https://localhost:7063/api/People", { credentials:"omit" }, {
    method: "POST",
    body: JSON.stringify(newPost),
    headers: {
      "Content-Type": "application/json",
    },
  }).then((response) => response.json());
});
