function submitRegister() {
  fetch("http://sere.egritec.cl/Api/People", {
    method: "POST",
    body: JSON.stringify({
      namePerson: document.getElementById("names"),
      surnamePerson: document.getElementById("lastName"),
      namePerson: document.getElementById("pass"),
      namePerson: document.getElementById("organizacionSelect"),
      namePerson: document.getElementById("personaSelect"),
      emailPerson: document.getElementById("emailAddress"),
      namePerson: document.getElementById("phoneNumber"),
    }),
  });
  console.log("names");
}
