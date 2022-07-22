// let data = `?titulo=${document.getElementById("TituloEvento").value}
//     &descripcion=${document.getElementById("descrEvento").value}
//     &fecha=${document.getElementById("FechaEvento").value}
//     &imagen=${document.getElementById("imagenEvento").value}
//     `;
//     const contenedor = document.getElementById('cualquiercosa')

let API = "https://localhost:7146/api/Events";
fetch(API)
  .then(response => response.text())
  .then(data => showData(data))
  .catch(error => console.log(error));


const showData = (data) => {
  JSON.parse(data)
  let body = ''
    body += `<p>${data.id}</p><p>${data.name}</p><p>${data.date}</p><p>${data.description}</p>`


  document.getElementById('data').innerHTML = body
};
