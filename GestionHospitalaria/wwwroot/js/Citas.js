window.onload = function () {
    ListarCitas();
    listarPacientes();
    ListarMedicos();
}

let objCita;

async function ListarCitas() {

    objCita = {
        url: "Citas/ListarCitas",
        cabeceras: ["Id Citas", "Paciente", "Medico", "Fecha y Hora", "Estado"],
        propiedades: ["id", "nombrePaciente", "nombreMedico", "fechaHora", "estado",],
        editar: true,
        eliminar: true,
        propiedadID: "id"
    }
    pintar(objCita);
}

function listarPacientes() {
    fetchGet("Pacientes/listarPacientes", "json", function (data) {
        // Obtén el elemento select de Paciente
        let selectPaciente = document.getElementById("Paciente");
        if (selectPaciente) {
            // Limpia el contenido y añade la opción por defecto
            selectPaciente.innerHTML = "<option value=''>Seleccione</option>";
            // Agrega cada opción recibida del servidor
            data.forEach((paciente) => {
                let option = document.createElement("option");
                option.value = paciente.id;
                option.text = paciente.nombre;
                selectPaciente.appendChild(option);
            });
        }
    });
}

function ListarMedicos() {
    fetchGet("Medicos/ListarMedicos", "json", function (data) {
        let selectMedico = document.getElementById("Medico");
        if (selectMedico) {
            selectMedico.innerHTML = "<option value=''>Seleccione</option>";
            data.forEach((medico) => {
                let option = document.createElement("option");
                option.value = medico.id;
                option.text = medico.nombre;
                selectMedico.appendChild(option);
            });
        }
    });
}
function MostrarModal() {
    LimpiarDatos("frmCita");
    document.activeElement.blur();
    var myModal = new bootstrap.Modal(document.getElementById("modalCita"));
    myModal.show();
    ListarCitas();
    listarPacientes();
    ListarMedicos();
}

function GuardarCita() {
    let form = document.getElementById("frmCita");
    let frm = new FormData(form);
    if (!form.checkValidity()) {
        form.classList.add("was-validated");
        return;
    }
    fetchPost("Citas/GuardarCita", "text", frm, function (res) {
        LimpiarDatos("frmCita");
        Exito("Registro Guardado Con Éxito");
        ListarCitas();
        document.activeElement.blur();
        setTimeout(function () {
            var myModal = bootstrap.Modal.getInstance(document.getElementById('modalCita'));
            if (myModal) {
                myModal.hide();
            }
        }, 150);
    });

}

function Editar(id) {
    fetchGet("Citas/RecuperarCita/?id=" + id, "json", function (data) {
        setN("id", data.id);
        setN("Paciente", data.pacienteId);
        setN("Medico", data.medicoId);
        // Convertir data.fechaHora a "yyyy-MM-ddTHH:mm"
        let fechaStr = "";
        if (data.fechaHora) {
            let dt = new Date(data.fechaHora);
            fechaStr = dt.toISOString().slice(0, 16);
        }
        setN("fechaHora", fechaStr);
        setN("estado", data.estado);
        document.activeElement.blur();
        var myModal = new bootstrap.Modal(document.getElementById('modalCita'));
        myModal.show();
    });
}


function Eliminar(id) {
    fetchGet("Citas/RecuperarCita/?id=" + id, "json", function (data) {
        Confirmar(undefined, "¿Desea eliminar la cita " + data.id + " ?", function () {
            fetchGet("Citas/EliminarCita/?id=" + id, "text", function (r) {
                Exito("Tratamiento Eliminado con Éxito");
                ListarCitas();
            });

        });
    });
}

function LimpiarCita() {
    LimpiarDatos("frmCita");
}