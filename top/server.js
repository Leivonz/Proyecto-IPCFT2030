const http = require("http");

http
  .createServer((req, res) => {
    res.writeHead(200, { "content-type": "text/plain" });
    res.end("Hola mundo");
  })
  .listen(3000);

console.log("Servidor iniciado...");
