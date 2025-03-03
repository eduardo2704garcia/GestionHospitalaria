window.onload = function () {
    ListarTratamientos();
    listarPacientes();
}

let objTratamiento;

async function ListarTratamientos() {

    objTratamiento= {
        url: "Tratamientos/ListarTratamientos",
        cabeceras: ["Id Tratamientos", "Paciente", "Descripcion", "Fecha", "Costo"],
        propiedades: ["id", "nombrePaciente", "descripcion", "fecha", "costo",],
        editar: true,
        eliminar: true,
        propiedadID: "id"
    }
    pintar(objTratamiento);
}

function listarPacientes() {
    fetchGet("Pacientes/listarPacientes", "json", function (data) {
        data.forEach((paciente) => {
            let option = document.createElement("option");
            option.value = paciente.id;
            option.text = paciente.nombre;
            document.getElementById("Paciente").appendChild(option);
        });

    });
}

function MostrarModal() {
    LimpiarDatos("frmTratamiento");
    var myModal = new bootstrap.Modal(document.getElementById("modalTratamiento"));
    myModal.show();
    ListarTratamientos();
    listarPacientes();
}

function GuardarTratamiento() {
    let form = document.getElementById("frmTratamiento");
    let frm = new FormData(form);
    if (!form.checkValidity()) {
        form.classList.add("was-validated");
        return;
    }
    fetchPost("Tratamientos/GuardarTratamiento", "text", frm, function (res) {

        LimpiarDatos("frmTratamiento");
        Exito("Registro Guardado Con Exito");
        ListarTratamientos();
        var myModal = bootstrap.Modal.getInstance(document.getElementById('modalTratamiento'));
        myModal.hide();
    });
}

function Editar(id) {
    fetchGet("Tratamientos/RecuperarTratamiento/?id=" + id, "json", function (data) {
        // Asigna el id al campo oculto (asegúrate de que el campo tenga id="id")
        setN("id", data.id);
        // Para el paciente, el select tiene id "Paciente", por lo que asignamos su valor:
        setN("Paciente", data.pacienteId);
        // No existe campo "nombrePaciente" en el modal, así que se omite.
        setN("descripcion", data.descripcion);

        // Convertir la fecha al formato "yyyy-MM-dd"
        let fechaStr = "";
        if (data.fecha) {
            let dt = new Date(data.fecha);
            fechaStr = dt.toISOString().split("T")[0];
        }
        setN("fecha", fechaStr);

        setN("costo", data.costo);

        // Abre el modal para editar
        var myModal = new bootstrap.Modal(document.getElementById('modalTratamiento'));
        myModal.show();
    });
}

function Eliminar(id) {
    fetchGet("Tratamientos/RecuperarTratamiento/?id=" + id, "json", function (data) {
        Confirmar(undefined, "¿Desea eliminar el Tratamiento " + data.Descripcion + " ?", function () {
            fetchGet("Tratamientos/EliminarTratamiento/?id=" + id, "text", function (r) {
                Exito("Tratamiento Eliminado con Éxito");
                ListarTratamientos();
            });

        });
    });
}

function LimpiarTratamiento() {
    LimpiarDatos("frmTratamiento");
}