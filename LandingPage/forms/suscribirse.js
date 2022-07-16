const button = document.getElementById("button");

button.addEventListener("click", () => {

  const newPost = `?emailList=${document.getElementById("suscribir").value.trim()}
  `;
  fetch("https://localhost:7146/api/EmailLists" + newPost, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    //body: JSON.stringify(newPost),
  }).then((res) => res.json());
});