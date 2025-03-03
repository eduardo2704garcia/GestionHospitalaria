window.onload = function () {
    ListarMedicos();
    listarEspecialidades();
}

let objMedico;

async function ListarMedicos() {

    objMedico = {
        url: "Medicos/ListarMedicos",
        cabeceras: ["Id Medico", "Nombre", "Apellido", "Especialidad", "Telefono", "Email"],
        propiedades: ["id", "nombre", "apellido", "nombreEspecialidad", "telefono","email"],
        editar: true,
        eliminar: true,
        propiedadID: "id"
    }
    pintar(objMedico);
}

function listarEspecialidades() {
    fetchGet("Especialidades/listarEspecialidades", "json", function (data) {
        data.forEach((especialidad) => {
            let option = document.createElement("option");
            option.value = especialidad.id;
            option.text = especialidad.nombre;
            document.getElementById("Especialidad").appendChild(option);
        });

    });
}

function MostrarModal() {
    LimpiarDatos("frmMedico");
    document.activeElement.blur();
    var myModal = new bootstrap.Modal(document.getElementById("modalMedico"));
    myModal.show();
    ListarMedicos();
    listarEspecialidades();
}

function GuardarMedico() {
    let form = document.getElementById("frmMedico");
    let frm = new FormData(form);
    if (!form.checkValidity()) {
        form.classList.add("was-validated");
        return;
    }
    fetchPost("Medicos/GuardarMedico", "text", frm, function (res) {
        LimpiarDatos("frmMedico");
        Exito("Registro Guardado Con Exito");
        ListarMedicos();
        document.activeElement.blur();
        var myModal = bootstrap.Modal.getInstance(document.getElementById('modalMedico'));
        myModal.hide();
    });
}

function Editar(id) {
    fetchGet("Medicos/RecuperarMedico/?id=" + id, "json", function (data) {
        setN("id", data.id);
        setN("Especialidad", data.especialidadId);
        setN("nombre", data.nombre);
        setN("apellido", data.apellido);
        setN("telefono", data.telefono);
        setN("email", data.email);
        document.activeElement.blur();
        var myModal = new bootstrap.Modal(document.getElementById('modalMedico'));
        myModal.show();
    });
}

function Eliminar(id) {
    fetchGet("Medicos/RecuperarMedico/?id=" + id, "json", function (data) {
        Confirmar(undefined, "¿Desea eliminar el Medico " + data.nombre + " ?", function () {
            fetchGet("Medicos/EliminarMedico/?id=" + id, "text", function (r) {
                Exito("Tratamiento Eliminado con Éxito");
                ListarMedicos();
            });

        });
    });
}

function LimpiarMedico() {
    LimpiarDatos("frmMedico");
}