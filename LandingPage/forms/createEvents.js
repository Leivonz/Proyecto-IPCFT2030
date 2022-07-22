const button = document.getElementById("button");

button.addEventListener("click", () => {
  const newPost = `?name=${document.getElementById("TituloEvento").value.trim()}
  &date=${document.querySelector('input[type="date"]').value.trim()}
  &description=${document.getElementById("descrEvento").value}
  &file=${document.getElementById("fileupload").value}
  `;

  fetch("https://localhost:7146/api/Events" + newPost, {
    method: "POST",
    headers: { "Content-Type": "multipart/form-data" },
  }).then((res) => res.json());
});
