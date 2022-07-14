const button = document.getElementById("button");

button.addEventListener("click", () => {
  const newPost = {
    namePerson: document.getElementById("names").value,
    surnamePerson: document.getElementById("apellidos").value,
    emailPerson: document.getElementById("emailAddress").value,
    phonePerson: document.getElementById("phoneNumber").value,
    passwordPerson: document.getElementById("pass").value,
    organizationName: document.getElementById("orgName").value,
    countryPerson: 1
  };
  fetch("https://localhost:7146/api/People",  {
    method: "POST",
    body: JSON.stringify(newPost),
    headers: {
      "access-control-allow-origin": "*", 
      "Content-type": "application.json; charset=utf-8",
      "server": "Kestrel"
    },
  }).then(res => res.json())
  return res.json()
});
