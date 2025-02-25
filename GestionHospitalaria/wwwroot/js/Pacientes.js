﻿window.onload = function () {
    listarPacientes();
};

let objPacientes;

async function listarPacientes() {
    objPacientes = {
        url: "Pacientes/listarPacientes",
        cabeceras: ["id Paciente", "Nombre", "FechaNacimiento", "Telefono"],
        propiedades: ["id", "Nombre", "FechaNacimiento", "Telefono"],
        divContenedorTabla: "divContenedorTabla",
        editar: true,
        eliminar: true
    }
    pintar(objPacientes);
}