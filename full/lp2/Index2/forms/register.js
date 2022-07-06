const button = document.getElementById("button");

button.addEventListener("click", () => {
  const newPost = {
    NamePerson: document.getElementById("names").value,
    SurnamePerson: document.getElementById("apellidos").value,
    EmailPerson: document.getElementById("emailAddress").value,
    PhonePerson: document.getElementById("phoneNumber").value,
    PasswordPerson: document.getElementById("pass").value,
  };
  fetch("http://sere.egritec.cl/Api/People", {
    method: "POST",
    body: JSON.stringify(newPost),
    headers: {
      "Content-type": "application/json",
    },
  }).then((res) => res.json());
});
