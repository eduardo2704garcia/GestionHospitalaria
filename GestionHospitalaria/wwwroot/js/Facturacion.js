window.onload = function () {
    ListarFacturas();
    listarPacientes();

}

let objFactura;

async function ListarFacturas() {

    objFactura = {
        url: "Facturacion/ListarFacturas",
        cabeceras: ["Id Factura", "Paciente", "Monto", "Fecha De Pago", "Metodo de Pago"],
        propiedades: ["id", "nombrePaciente", "monto", "fechaPago", "metodoPago"],
        editar: true,
        eliminar: true,
        propiedadID: "id"
    }
    pintar(objFactura);
}

function listarPacientes() {
    fetchGet("Pacientes/listarPacientes", "json", function (data) {
        let selectPaciente = document.getElementById("Paciente");
        if (selectPaciente) {
            selectPaciente.innerHTML = "<option value=''>Seleccione</option>";
            data.forEach((paciente) => {
                let option = document.createElement("option");
                option.value = paciente.id;
                option.text = paciente.nombre;
                selectPaciente.appendChild(option);
            });
        }
    });
}
function MostrarModal() {
    LimpiarDatos("frmFactura");
    document.activeElement.blur();
    var myModal = new bootstrap.Modal(document.getElementById("modalFactura"));
    myModal.show();
    ListarFacturas();
    listarPacientes();
}

function GuardarFactura() {
    let form = document.getElementById("frmFactura");
    let frm = new FormData(form);
    if (!form.checkValidity()) {
        form.classList.add("was-validated");
        return;
    }
    fetchPost("Facturacion/GuardarFactura", "text", frm, function (res) {
        LimpiarDatos("frmFactura");
        Exito("Registro Guardado Con Éxito");
        ListarFacturas();
        document.activeElement.blur();
        setTimeout(function () {
            var myModal = bootstrap.Modal.getInstance(document.getElementById('modalFactura'));
            if (myModal) {
                myModal.hide();
            }
        }, 150);
    });

}

function Editar(id) {
    fetchGet("Facturacion/RecuperarFactura/?id=" + id, "json", function (data) {
        setN("id", data.id);
        setN("Paciente", data.pacienteId);
        let fechaStr = "";
        if (data.fechaPago) {
            let dt = new Date(data.fechaPago);
            fechaStr = dt.toISOString().split("T")[0];
        }
        setN("fechaPago", fechaStr);
        setN("monto", data.monto);
        setN("metodoPago", data.metodoPago);
        document.activeElement.blur();
        var myModal = new bootstrap.Modal(document.getElementById('modalFactura'));
        myModal.show();
    });
}


function Eliminar(id) {
    fetchGet("Facturacion/RecuperarFactura/?id=" + id, "json", function (data) {
        Confirmar(undefined, "¿Desea eliminar la Factura " + data.id + " ?", function () {
            fetchGet("Facturacion/EliminarFactura/?id=" + id, "text", function (r) {
                Exito("Factura Eliminada con Éxito");
                ListarFacturas();
            });

        });
    });
}

function LimpiarFactura() {
    LimpiarDatos("frmFactura");
}