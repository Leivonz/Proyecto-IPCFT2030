window.onload = function () {
  let API = "http://sere.somee.com/Api/Events";
  fetch(API)
    .then((response) => response.json())
    //.then(data => showData(data))
    .then((data) => {
      console.log(data.data)
      const events = data.data
      let body = ''
      events.forEach(element => {
         body += `<p>${element.id}</p><p>${element.name}</p><p>${element.date}</p><p>${element.description}</p>`
      });
      // const parsedData = JSON.parse(data);
      // let body = "";
      // // body += `<p>${parsedData.id}</p><p>${parsedData.name}</p><p>${parsedData.date}</p><p>${parsedData.description}</p>`
      // body += data;

      document.getElementById("data").innerHTML = body;
      // console.log(parsedData);

    })
    .catch((error) => console.log(error));

  const showData = (data) => {
    const parsedData = JSON.parse(data);
    let body = "";
    // body += `<p>${parsedData.id}</p><p>${parsedData.name}</p><p>${parsedData.date}</p><p>${parsedData.description}</p>`
    body += data;

    document.getElementById("data").innerHTML = body;
    console.log(parsedData);
  };
};
