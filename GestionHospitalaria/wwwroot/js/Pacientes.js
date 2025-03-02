window.onload = function () {
    listarPacientes();
};

let objPacientes;

async function listarPacientes() {
    objPacientes = {
        url: "Pacientes/listarPacientes", // Endpoint que devuelve el JSON
        cabeceras: ["ID Paciente", "Nombre", "Fecha Nacimiento", "Teléfono"],
        propiedades: ["id", "nombre", "fechaNacimiento", "telefono"],
        divContenedorTabla: "divContenedorTabla",
        editar: true,
        eliminar: true,
        propiedadID: "id"
    };
    pintar(objPacientes);
}

function GuardarPaciente() {
    let forma = document.getElementById("frmPaciente");
    let frm = new FormData(forma);
    if (!forma.checkValidity()) {
        forma.classList.add("was-validated");
        return;
    }
    fetchPost("Pacientes/GuardarPaciente", "text", frm, function (res) {
        LimpiarDatos("frmPaciente");
        Exito("Registro Guardado con Éxito");
        listarPacientes();

        var myModal = bootstrap.Modal.getInstance(document.getElementById('modalPaciente'));
        myModal.hide();
    });
}

function MostrarModal() {
    LimpiarDatos("frmPaciente");
    var myModal = new bootstrap.Modal(document.getElementById('modalPaciente'));
    myModal.show();
}

function Editar(id) {
    fetchGet("Pacientes/RecuperarPaciente/?id=" + id, "json", function (data) {
        // Usa los IDs exactos de tu modal
        setN("id", data.id);
        setN("nombre", data.nombre);
        setN("apellido", data.apellido);
        setN("fechaNacimiento", data.fechaNacimiento);
        setN("telefono", data.telefono);
        setN("email", data.email);
        setN("direccion", data.direccion);

        var myModal = new bootstrap.Modal(document.getElementById('modalPaciente'));
        myModal.show();
    });
}
function LimpiarPaciente() {

    LimpiarDatos("frmPaciente");
    listarPacientes();
}
function Eliminar(id) {

    fetchGet("Pacientes/RecuperarPaciente/?id=" + id, "json", function (data) {
        Confirmar(undefined, "¿Desea eliminar el paciente " + data.nombre + " ?", function () {
            fetchGet("Pacientes/EliminarPaciente/?id=" + id, "text", function (r) {
                Exito("Registro Eliminado con Éxito");
                listarPacientes();
            });
        });
    });
}
