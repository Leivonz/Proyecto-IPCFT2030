const button = document.getElementById("button");

button.addEventListener("click", () => {
  let newPost = {
    country: document.getElementById("country").value,
  };
  fetch("https://localhost:7063/api/Countries", {
    method: "POST",
    mode: "no-cors",
    body: JSON.stringify(newPost),
    headers: {
      "Accept": "application/json",
      "Content-type": "application.json; charset=UTF-8",
      "Access-Control-Allow-Origin" : "*",
      "Access-Control-Allow-Credentials" : true 
    }
  }).then(res => res.json())
});