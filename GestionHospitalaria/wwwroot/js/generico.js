function get(idControl) {
    return document.getElementById(idControl).value;
}

function set(idControl, valor) {
    document.getElementById(idControl).value = valor;
}

function setN(namecontrol, valor) {
    document.getElementsByName(namecontrol)[0].value = valor;
}

function LimpiarDatos(idFormulario) {
    let elementosName = document.querySelectorAll('#' + idFormulario + " [name]");
    for (let i = 0; i < elementosName.length; i++) {
        let elementoActual = elementosName[i];
        let elementoName = elementoActual.name;
        setN(elementoName, "");
    }
}

// Si no usas hdfOculto, puedes eliminar esa referencia.
async function fetchGet(url, tipoRespuesta, callback) {
    try {
        let urlCompleta = `${window.location.protocol}//${window.location.host}/${url}`;
        let res = await fetch(urlCompleta);
        if (tipoRespuesta === "json") {
            res = await res.json();
        } else if (tipoRespuesta === "text") {
            res = await res.text();
        }
        callback(res);
    } catch (e) {
        alert("Ocurrió un problema: " + e.message);
    }
}

async function fetchPost(url, tipoRespuesta, frm, callback) {
    try {
        let urlCompleta = `${window.location.protocol}//${window.location.host}/${url}`;
        let res = await fetch(urlCompleta, {
            method: "POST",
            body: frm
        });

        if (tipoRespuesta === "json") {
            res = await res.json();
        } else if (tipoRespuesta === "text") {
            res = await res.text();
        }
        callback(res);
    } catch (e) {
        alert("Ocurrió un problema en POST: " + e.message);
    }
}

let objConfiguracionGlobal;

// Configuración esperada: { url: "", cabeceras: [], propiedades: [], ... }
function pintar(objConfiguracion) {
    objConfiguracionGlobal = objConfiguracion;
    if (objConfiguracionGlobal.divContenedorTabla === undefined) {
        objConfiguracionGlobal.divContenedorTabla = "divContenedorTabla";
    }
    if (objConfiguracionGlobal.editar === undefined) {
        objConfiguracionGlobal.editar = false;
    }
    if (objConfiguracionGlobal.eliminar === undefined) {
        objConfiguracionGlobal.eliminar = false;
    }
    if (objConfiguracionGlobal.propiedadID === undefined) {
        objConfiguracionGlobal.propiedadID = "";
    }
    fetchGet(objConfiguracion.url, "json", function (res) {
        console.log("Respuesta JSON:", res); // <-- Agrega este log para ver la estructura
        let contenido = "<div id='" + objConfiguracionGlobal.divContenedorTabla + "'>";
        contenido += generarTabla(res);
        contenido += "</div>";
        document.getElementById("divTable").innerHTML = contenido;
    });
}


function generarTabla(res) {
    let contenido = "";
    let cabeceras = objConfiguracionGlobal.cabeceras;
    let propiedades = objConfiguracionGlobal.propiedades;

    contenido += "<div class='table-responsive'>"; //Para hacerle responsive
    contenido += "<table class='table table-striped table-hover table-bordered'>";//colores distintos en cada fila
    contenido += "<thead class='table-dark'><tr>";//Fondo oscuro al encabezado

    for (let i = 0; i < cabeceras.length; i++) {
        contenido += "<th class='text-center'>" + cabeceras[i] + "</th>";
    }

    if (objConfiguracionGlobal.editar === true || objConfiguracionGlobal.eliminar === true) {
        contenido += "<th class='text-center'>Operaciones</th>";
    }

    contenido += "</tr></thead>";
    contenido += "<tbody>";

    for (let i = 0; i < res.length; i++) {
        let obj = res[i];

        contenido += "<tr>";
        for (let j = 0; j < propiedades.length; j++) {
            let propiedadActual = propiedades[j];
            contenido += "<td class='text-center'>" + (obj[propiedadActual] !== null ? obj[propiedadActual] : "") + "</td>";
        }
        if (objConfiguracionGlobal.editar === true || objConfiguracionGlobal.eliminar === true) {
            let propiedadID = objConfiguracionGlobal.propiedadID;
            contenido += "<td class='text-center'>";
            if (objConfiguracionGlobal.editar === true) {
                contenido += `<button onclick="Editar(${obj[propiedadID]})" class="btn btn-primary btn-sm mx-1">Editar</button>`;//tamaño y separacion para eliminar y editar
            }
            if (objConfiguracionGlobal.eliminar === true) {
                contenido += `<button onclick="Eliminar(${obj[propiedadID]})" class="btn btn-danger btn-sm mx-1">Eliminar</button>`;//lo mismo
            }
            contenido += "</td>";
        }
        contenido += "</tr>";
    }

    contenido += "</tbody></table></div>";
    return contenido;
}
