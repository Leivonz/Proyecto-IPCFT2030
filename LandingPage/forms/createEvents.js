document.getElementById("btnGuardar").addEventListener('click', async() => {
  console.log('asd')
  const url = 'https://localhost:7146/api/Events'    
  let archivo = new FormData()
  archivo.append('date', document.getElementById('FechaEvento').value)
  archivo.append('description', document.getElementById('descrEvento').value)
  archivo.append('file', document.getElementById('imagenEvento').files[0])    
  archivo.append('name', document.getElementById('TituloEvento').value)

  const resp = await fetch(url, {
      method: 'POST',
      body: archivo
  }).then(resp => resp.json())
  .then(data => {
      console.log(data)
  })
  
})

