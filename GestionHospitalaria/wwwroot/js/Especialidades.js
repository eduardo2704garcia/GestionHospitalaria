window.onload = function () {
    listarEspecialidades();
};

let objEspecialidades;

async function listarEspecialidades() {
    objEspecialidades = {
        url: "Especialidades/listarEspecialidades", 
        cabeceras: ["ID Especialidad", "Nombre"], 
        propiedades: ["Id", "Nombre"], 
        divContenedorTabla: "divContenedorTabla", 
        editar: true, 
        eliminar: true 
    };
    pintar(objEspecialidades); 
}

function filtrarEspecialidades() {
    let busqueda = get("txtEspecialidad");
    if (busqueda.trim() === "") {
        listarEspecialidades();
    } else {
        objEspecialidades.url = "Especialidades/filtrarEspecialidades/?busqueda=" + encodeURIComponent(busqueda);
        pintar(objEspecialidades); 
    }
}

function GuardarEspecialidad() {
    let forma = document.getElementById("frmGuardarEspecialidad");
    let frm = new FormData(forma);

    fetchPost("Especialidades/GuardarEspecialidades", "text", frm, function (res) {
        listarEspecialidades();
        LimpiarDatos("frmGuardarEspecialidad");
        var modalElement = document.getElementById('modalAgregarEspecialidad');
        var modalInstance = bootstrap.Modal.getInstance(modalElement);
        modalInstance.hide();
    });
}
