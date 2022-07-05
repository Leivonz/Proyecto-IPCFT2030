function submitRegister() {
  fetch("https://localhost:7063/api/People", {
    method: "POST",
    body: JSON.stringify({
      namePerson: document.getElementById("names"),
    }),
  });
  console.log("names");
}
