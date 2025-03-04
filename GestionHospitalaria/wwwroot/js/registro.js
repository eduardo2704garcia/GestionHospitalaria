document.addEventdocument.addEventListener("DOMContentLoaded", function () {
    const form = document.getElementById("frmRegistro"); const form = document.getElementById("frmRegistro");
    if (!form) {
        console.warn("Formulario 'frmRegistro' no encontrado.");
        return;
    }
    form.addEventListener("submit", function (event) {
        event.preventDefault();

        const primerNombre = document.getElementById("inputFirstName").value.trim();
        const primerApellido = document.getElementById("inputLastName").value.trim();
        const correo = document.getElementById("inputEmail").value.trim();
        const clave = document.getElementById("inputPassword").value.trim();

        if (!primerNombre || !primerApellido || !correo || !clave) {
            alert("Por favor, complete todos los campos.");
            return;
        }

        const datos = {
            Nombre: primerNombre,
            Apellido: primerApellido,
            Correo: correo,
            Clave: clave
        };

        fetch("/Acceso/RegistrarAdministrador", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(datos)
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error("Error en el servidor");
                }
                return response.json();
            })
            .then(data => {
                if (data.success) {
                    alert("Registrado con éxito");
                    window.location.href = "/Acceso/Login";
                } else {
                    alert(data.message || "Error al registrar");
                }
            })
            .catch(error => {
                console.error("Error en el registro:", error);
                alert("Ocurrió un error al registrar. Intente nuevamente.");
            });
    });
});
