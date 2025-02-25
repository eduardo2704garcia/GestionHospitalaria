window.onload = function () {
    listarPacientes();
};

let objPacientes;

async function listarPacientes() {
    objPacientes = {
        url: "Pacientes/listarPacientes", // Este endpoint devuelve el JSON
        cabeceras: ["ID Paciente", "Nombre", "Fecha Nacimiento", "Teléfono"],
        propiedades: ["id", "nombre", "fechaNacimiento", "telefono"],
        divContenedorTabla: "divContenedorTabla",
        editar: true,
        eliminar: true
        // propiedadID: "id"  // Úsalo si implementas editar/eliminar
    };
    pintar(objPacientes);
}

function filtrarPacientes() {
    let busqueda = get("txtPaciente");
    if (busqueda.trim() === "") {
        listarPacientes();
    } else {
        objPacientes.url = "Pacientes/filtrarPacientes/?busqueda=" + encodeURIComponent(busqueda);
        pintar(objPacientes);
    }
}

function GuardarPaciente() {
    let forma = document.getElementById("frmGuardarPaciente");
    let frm = new FormData(forma);

    fetchPost("Pacientes/GuardarPaciente", "text", frm, function (res) {
        // Después de guardar, actualiza la tabla
        listarPacientes();
        // Limpia el formulario
        LimpiarDatos("frmGuardarPaciente");
        // Cierra el modal
        var modalElement = document.getElementById('modalAgregarPaciente');
        var modalInstance = bootstrap.Modal.getInstance(modalElement);
        modalInstance.hide();
    });
}
