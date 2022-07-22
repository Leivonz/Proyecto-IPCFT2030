// let data = `?titulo=${document.getElementById("TituloEvento").value}
//     &descripcion=${document.getElementById("descrEvento").value}
//     &fecha=${document.getElementById("FechaEvento").value}
//     &imagen=${document.getElementById("imagenEvento").value}
//     `;
//     const contenedor = document.getElementById('cualquiercosa')
let API = "https://localhost:7146/api/Events";
fetch(API)
  .then((response) => response.json)
  .then((data) => showData(data))
  .catch((error) => console.log(error));

const showData = (data) => {
  console.log(data);
  let body = "";
  for (let i = 0; i < data.length; i++) {
    body += `<p></<p>${data[i].name}<p></<p>${data[i].description}<p></<p>${data[i].date}`
  }

  document.getElementById('data').innerHTML = body
};
