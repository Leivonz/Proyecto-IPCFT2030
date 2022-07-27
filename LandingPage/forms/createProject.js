document.getElementById('btnGuardar').addEventListener('click', async () => {
    let checkedvalu = 0;
    if (document.getElementById('incioEstado').checked == true) {
        checkedvalu = 1;
    }
    if (document.getElementById('AdjuEstado').checked == true) {
        checkedvalu = 2;

    }
    if (document.getElementById('DesarolloEstado').checked == true) {
        checkedvalu = 3;

    }
    if (document.getElementById('FinEstado').checked == true) {
        checkedvalu = 4;
    }
    const url = 'https://localhost:7146/api/Projects';
    const newPost = `?CreationDateProject=${document.getElementById('fechainicio').value.trim()}&StartDateProject=${document.getElementById('fechainicio').value.trim()}&EndDateProject=${document.getElementById('fechainicio').value.trim()}&MonthsProject=${1}&DescriptionProject=${document.getElementById('descr').value.trim()}&KeyWordsProject=${document.getElementById('titulo').value.trim()}&ObjectivesProject=${1}&IdArea=${1}&IdProjectStatus=${checkedvalu}&IdObjectiveObjective=${1}&IdPersonResponsable=${4}
  `;
    fetch(url + newPost, {
        method: "POST",
        headers: {"Content-Type": "application/json"},
        //body: JSON.stringify(newPost),
    }).then(res => res.json());
});
