
var btnAgregar = document.getElementById('btnAgregar');
var trNuevo = document.getElementById('trNuevo');
var contador = 4;
var btnImprimir = document.getElementById('btnImprimir');
var txtCveFamiliar = document.getElementById('txtCveFamiliar');
var txtNoSocio = document.getElementById('txtNoSocio');


function verificarLlenadoPrescripciones() {
    var todasLlenas = true;
    for (var i = 1; i <= contador; i++) {
        var prescripcion = document.getElementById(`txtPrescripcion${i}`);
        if (prescripcion.value.trim() === '') {
            todasLlenas = false;
            break;
        }
    }
    if (todasLlenas) {
        btnAgregar.style.display = 'none';
    } else {
        btnAgregar.style.display = 'block';
    }
}


document.getElementById('txtPrescripcion4').addEventListener('input', verificarLlenadoPrescripciones);


btnAgregar.addEventListener('click', function () {
    contador++;
    var nuevaLinea = document.createElement('tr');
    nuevaLinea.innerHTML = `
        <td><input type="text" class="form-control" id="txtCantSurt${contador}" placeholder="Cantidad a surtir"></td>
        <td><textarea class="form-control no-resize" id="txtPrescripcion${contador}" rows="1" placeholder="Prescripción médica"></textarea></td>
    `;
    trNuevo.parentNode.insertBefore(nuevaLinea, trNuevo);
    verificarLlenadoPrescripciones();

 
/*    btnAgregar.style.display = 'none';*/
});

btnImprimir.addEventListener('click', function () {

    validarCampoVacio(txtCveFamiliar);






    const txtCveFamiliarVal = document.getElementById('txtCveFamiliar').value;
    const txtNombrePacienteVal = document.getElementById('txtNombrePaciente').value;
    const txtNoSocioVal = document.getElementById('txtNoSocio').value;
    const dtFechaNacimientoVal = document.getElementById('dtFechaNacimiento').value;
    const txtNombreMedicoVal = document.getElementById('txtNombreMedico').value;
    const txtCedProfesionalVal = document.getElementById('txtCedProfesional').value;
    const txtUniCedProfVal = document.getElementById('txtUniCedProf').value;
    const txtCedEspecialidadVal = document.getElementById('txtCedEspecialidad').value;
    const txtUniCedEspVal = document.getElementById('txtUniCedEsp').value;
    const cboEspecialidadVal = document.getElementById('cboEspecialidad').value;
    const txtCantSurt1Val = document.getElementById('txtCantSurt1').value;
    const url = '/Home/GeneratePdf';

    fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            cveFamiliar: txtCveFamiliarVal,
            nombrePaciente: txtNombrePacienteVal,
            noSocio: txtNoSocioVal,
            fechaNacimiento: dtFechaNacimientoVal,
            nombreMedico: txtNombreMedicoVal,
            especialidad: cboEspecialidadVal,
            cedulaProfesional: txtCedProfesionalVal,
            uniCedProf: txtUniCedProfVal,
            cedulaEspecialidad: txtCedEspecialidadVal,
            uniCedEsp: txtUniCedEspVal
        })
    })
        .then(response => response.blob())
        .then(blob => {
            // Crear un objeto URL para el blob
            const url = URL.createObjectURL(blob);

            // Crear un enlace temporal y simular el clic para descargar el archivo
            const link = document.createElement('a');
            link.href = url;
            link.download = 'GeneratedPdf.pdf';
            link.click();

            // Liberar el objeto URL
            URL.revokeObjectURL(url);
        })
        .catch(error => {
            console.log('Error al generar el PDF:', error);
        });
});


window.addEventListener('load', function () {
    verificarLlenadoPrescripciones();
});

function validarCampoVacio(input) {
    const valor = input.value.trim();
    const nombre = 'error' + input.id;

    if (valor === '') {
        document.getElementById(nombre).textContent = 'No puede estar vacío';
    } else {
        document.getElementById(nombre).textContent = '';
    }
}

