const button = document.getElementById('button');

button.addEventListener('click', () => {
  // const newPost = {
  //   nombre: document.getElementById('names').value,
  //   apellido: document.getElementById('apellidos').value,
  //   pass: document.getElementById('emailAddress').value,
  //   numero: document.getElementById('phoneNumber').value,
  //   pass: document.getElementById('pass').value,
  //   nacionalidad: 1,
  // };
  const newPost =  `?nombre=${document.getElementById('names').value.trim()}
  &apellido=${document.getElementById('apellidos').value.trim()}
  &correo=${document.getElementById('emailAddress').value.trim()}
  &numero=${document.getElementById('phoneNumber').value.trim()}
  &pass=${document.getElementById('pass').value.trim()}
  &organizacion=${document.getElementById('orgName').value.trim()}
  &nacionalidad=1
  `;
  fetch('https://localhost:7146/api/People' + newPost, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    //body: JSON.stringify(newPost),
  }).then((res) => res.json());
});