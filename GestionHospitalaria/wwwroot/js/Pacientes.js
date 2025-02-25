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

