alert('cargado');

// Obtener referencias de los elementos
var btnAgregar = document.getElementById('btnAgregar');
var trNuevo = document.getElementById('trNuevo');
var contador = 4; // El número de la última línea de prescripción agregada

// Mostrar el botón 'Agregar otra línea' después de llenar la última línea de prescripción
document.getElementById('txtPrescripcion4').addEventListener('input', function () {
    if (this.value.trim() !== '') {
        btnAgregar.style.display = 'block';
    } else {
        btnAgregar.style.display = 'none';
    }
});

// Agregar una nueva línea de prescripción al hacer clic en el botón 'Agregar otra línea'
btnAgregar.addEventListener('click', function () {
    contador++;
    var nuevaLinea = document.createElement('tr');
    nuevaLinea.innerHTML = `
            <td><input type="text" class="form-control" id="txtCantSurt${contador}" placeholder="Cantidad a surtir"></td>
            <td><textarea class="form-control no-resize" id="txtPrescripcion${contador}" rows="1" placeholder="Prescripción médica"></textarea></td>
        `;
    trNuevo.parentNode.insertBefore(nuevaLinea, trNuevo);
});