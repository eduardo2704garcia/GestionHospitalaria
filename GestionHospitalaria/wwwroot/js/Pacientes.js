window.onload = function () {
    listarPacientes();
};

let objPacientes;

async function listarPacientes() {
    objPacientes = {
        url: "Pacientes/listarPacientes", // Asegúrate de que esta URL devuelva un JSON con la lista de pacientes.
        cabeceras: ["ID Paciente", "Nombre", "Fecha Nacimiento", "Teléfono"],
        propiedades: ["id", "Nombre", "FechaNacimiento", "Telefono"],
        divContenedorTabla: "divContenedorTabla",
        editar: false,  // Si no deseas botones de editar, pon false.
        eliminar: false // Si no deseas botones de eliminar, pon false.
        // propiedadID: "id" // Si necesitas operaciones de editar/eliminar, define la propiedad que representa el ID.
    };
    pintar(objPacientes);
}
