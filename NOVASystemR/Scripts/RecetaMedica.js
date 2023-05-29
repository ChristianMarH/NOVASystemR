
var btnAgregar = document.getElementById('btnAgregar');
var trNuevo = document.getElementById('trNuevo');
var contador = 4;
var btnImprimir = document.getElementById('btnImprimir');
var txtCveFamiliar = document.getElementById('txtCveFamiliar');
var txtNoSocio = document.getElementById('txtNoSocio');
var txtNombrePaciente = document.getElementById('txtNombrePaciente');
var dtFechaNacimiento = document.getElementById('dtFechaNacimiento');
var txtCantSurt1 = document.getElementById('txtCantSurt1');
var txtPrescripcion1 = document.getElementById('txtPrescripcion1');


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
    validarCampoVacio(txtNombrePaciente);
    validarCampoVacio(txtNoSocio);
    validarCampoVacio(dtFechaNacimiento);
    validarCampoVacio(txtCantSurt1);
    validarCampoVacio(txtPrescripcion1):
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

