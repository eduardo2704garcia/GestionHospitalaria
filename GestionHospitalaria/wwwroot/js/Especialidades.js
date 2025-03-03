window.onload = function () {
    listarEspecialidades();
};

let objEspecialidades;

async function listarEspecialidades() {
    objEspecialidades = {
        url: "Especialidades/listarEspecialidades", 
        cabeceras: ["ID Especialidad", "Nombre"], 
        propiedades: ["id", "nombre"], 
        divContenedorTabla: "divContenedorTabla", 
        editar: true, 
        eliminar: true,
        propiedadID: "id"
    };
    pintar(objEspecialidades); 
}


function GuardarEspecialidad() {
    let forma = document.getElementById("frmEspecialidad");
    let frm = new FormData(forma);
    if (!forma.checkValidity()) {
        forma.classList.add("was-validated");
        return;
    }
    fetchPost("Especialidades/GuardarEspecialidades", "text", frm, function (res) {
        listarEspecialidades();
        LimpiarDatos("frmEspecialidad");
        var modalElement = document.getElementById('modalEspecialidad');
        var modalInstance = bootstrap.Modal.getInstance(modalElement);
        modalInstance.hide();
    });
}


function MostrarModal() {
    LimpiarDatos("frmEspecialidad");
    document.activeElement.blur();
    var myModal = new bootstrap.Modal(document.getElementById('modalEspecialidad'));
    myModal.show();
}

function Editar(id) {
    fetchGet("Especialidades/RecuperarEspecialidad/?id=" + id, "json", function (data) {
        // Usa los IDs exactos de tu modal
        setN("id", data.id);
        setN("nombre", data.nombre);
        
        document.activeElement.blur();
        var myModal = new bootstrap.Modal(document.getElementById('modalEspecialidad'));
        myModal.show();
    });
}
function LimpiarEspecialidad() {

    LimpiarDatos("frmEspecialidad");
    listarEspecialidades();
}
function Eliminar(id) {

    fetchGet("Especialidades/RecuperarEspecialidad/?id=" + id, "json", function (data) {
        Confirmar(undefined, "¿Desea eliminar la especialidad " + data.nombre + " ?", function () {
            fetchGet("Especialidades/EliminarEspecialidad/?id=" + id, "text", function (r) {
                Exito("Registro Eliminado con Éxito");
                listarEspecialidades();
            });
        });
    });
}
