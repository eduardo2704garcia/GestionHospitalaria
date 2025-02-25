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
        let contenido = "";
        contenido = "<div id='" + objConfiguracionGlobal.divContenedorTabla + "'>";
        contenido += generarTabla(res);
        contenido += "</div>";
        document.getElementById("divTable").innerHTML = contenido;
    });
}

function generarTabla(res) {
    let contenido = "";
    let cabeceras = objConfiguracionGlobal.cabeceras;
    let propiedades = objConfiguracionGlobal.propiedades;
    contenido += "<table class='table'>";
    contenido += "<thead><tr>";

    for (let i = 0; i < cabeceras.length; i++) {
        contenido += "<th>" + cabeceras[i] + "</th>";
    }

    if (objConfiguracionGlobal.editar === true || objConfiguracionGlobal.eliminar === true) {
        contenido += "<th>Operaciones</th>";
    }

    contenido += "</tr></thead>";
    contenido += "<tbody>";

    for (let i = 0; i < res.length; i++) {
        let obj = res[i];
        contenido += "<tr>";
        for (let j = 0; j < propiedades.length; j++) {
            let propiedadActual = propiedades[j];
            contenido += "<td>" + (obj[propiedadActual] !== null ? obj[propiedadActual] : "") + "</td>";
        }
        if (objConfiguracionGlobal.editar === true || objConfiguracionGlobal.eliminar === true) {
            let propiedadID = objConfiguracionGlobal.propiedadID;
            contenido += "<td>";
            if (objConfiguracionGlobal.editar === true) {
                contenido += `<i onclick="Editar(${obj[propiedadID]})" class="btn btn-primary">Editar</i>`;
            }
            if (objConfiguracionGlobal.eliminar === true) {
                contenido += `<i onclick="Eliminar(${obj[propiedadID]})" class="btn btn-danger">Eliminar</i>`;
            }
            contenido += "</td>";
        }
        contenido += "</tr>";
    }

    contenido += "</tbody></table>";
    return contenido;
}
