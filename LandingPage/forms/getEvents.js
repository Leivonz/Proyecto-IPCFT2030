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

<<<<<<< HEAD
const showData = (data) => {
  console.log(data);
  let body = "";
  for (let i = 0; i < data.length; i++) {
    body += `<p></<p>${data[i].name}<p></<p>${data[i].description}<p></<p>${data[i].date}`
  }

=======
// let data = `?titulo=${document.getElementById("TituloEvento").value}
//     &descripcion=${document.getElementById("descrEvento").value}
//     &fecha=${document.getElementById("FechaEvento").value}
//     &imagen=${document.getElementById("imagenEvento").value}
//     `;
//     const contenedor = document.getElementById('cualquiercosa')

// fetch('https://localhost:7146/api/Events'+ data ,{
//     method : "get",
//     renderData : (data) => data.forEach(element => {
//         contenedor.innerHTML += `<div class="card" style="width: 18rem;">
//     <img src="${element.imagen}" class="card-img-top" id="img">
//     <div class="card-body">
//       <h3 href="#">${element.titulo}</h3>
//       <p class="card-text">${element.descripcion}</p>
//       <p>Ubicacion</p>
//       <p>${element.fecha}</p>
//     </div>
//   </div>`
//     })
//     ,renderData(data)
// });

let API = "https://localhost:7146/api/Events";
fetch(API)
  .then(response => response.text())
  .then(data => showData(data))
  .catch(error => console.log(error));



const showData = (data) => {
  console.log(JSON.parse(data))
  let body = "";
  body = `<p>${data.name}</p><p>${data.description}</p><p>${data.date}</p>`

>>>>>>> e2adad86c038d4e6ea8757efc3c660bb689611a9
  document.getElementById('data').innerHTML = body
};
