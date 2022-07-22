window.onload = function () {
  let API = "https://localhost:7146/api/Events";
  fetch(API)
    .then((response) => response.json())
    //.then(data => showData(data))
    .then((data) => {
      console.log(data.data)
      const events = data.data
      console.log(events[0].date)
      let count = 0 
      let input = []
      let body = ''
      var options = { year: 'numeric', month: 'long', day: 'numeric' };


      for (let index = events.length-3; index < events.length; index++) {
        count = count +1;
        console.log(count);
        
        let editeddate = events[index].date
        console.log(editeddate);
        let date = editeddate.replaceAll('T00:00:00','')
        console.log(date);
        var parts = date.split('-');
        console.log(parts);
        var mydate = new Date(parts[0], parts[1] - 1, parts[2]); 
        console.log(mydate.toDateString());


        date = mydate.toLocaleDateString("es-ES", options)
        console.log(date);

        // body = 
        // `<div class="hotel"><div class="hotel-img"><img src="${events[index].image}" alt="Hotel 1" class="img-fluid" /> </div> <h3><a style="pointer-events: none "href="#">${events[index].name}</a></h3> <p>${events[index].description}</p> <p>${date}</p> </div>`
        body = 
        `<div class="hotel"><div class="hotel-img"><img src="assets/img/medio ambiente.jpg" alt="Hotel 1" class="img-fluid" /> </div> <h3><a style="pointer-events: none "href="#">${events[index].name}</a></h3> <p>${events[index].description}</p> <p>${date}</p> </div>`
        console.log(body);
        input.push(body)
        console.log(input);
      }
      console.log(document.getElementById("input1"));

      document.getElementById("input1").innerHTML = input[0]
      document.getElementById("input2").innerHTML = input[1]
      document.getElementById("input3").innerHTML = input[2]



      

      // const parsedData = JSON.parse(data);
      // let body = "";
      // // body += `<p>${parsedData.id}</p><p>${parsedData.name}</p><p>${parsedData.date}</p><p>${parsedData.description}</p>`
      // body += data;

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
