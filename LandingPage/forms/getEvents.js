
let data = `?titulo=${document.getElementById("TituloEvento").value}
    &descripcion=${document.getElementById("descrEvento").value}
    &fecha=${document.getElementById("FechaEvento").value}
    &imagen=${document.getElementById("imagenEvento").value}
    `;
    const contenedor = document.getElementById('cualquiercosa')

fetch('https://localhost:7146/api/Events'+ data ,{
    method : "get",
    renderData : (data) => data.forEach(element => {
        contenedor.innerHTML += `<div class="card" style="width: 18rem;">
    <img src="${element.imagen}" class="card-img-top" id="img">
    <div class="card-body">
      <h3 href="#">${element.titulo}</h3>
      <p class="card-text">${element.descripcion}</p>
      <p>Ubicacion</p>
      <p>${element.fecha}</p>
    </div>
  </div>`
    })
    ,renderData(data)
});
