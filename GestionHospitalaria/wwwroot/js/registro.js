document.getElementById("frmRegistro").addEventListener("submit", async function (event) {
    event.preventDefault();

    const formData = {
        Nombre: document.getElementById("inputFirstName").value,
        Apellido: document.getElementById("inputLastName").value,
        Correo: document.getElementById("inputEmail").value,
        Clave: document.getElementById("inputPassword").value
    };

    try {
        const response = await fetch("/Acceso/Registrar", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(formData)
        });

        if (response.ok) {
            window.location.href = "/Acceso/Login";
        } else {
            const error = await response.text();
            mostrarError(error);
        }
    } catch (error) {
        mostrarError("Error de conexión con el servidor");
    }
});

function mostrarError(mensaje) {
    const errorDiv = document.createElement("div");
    errorDiv.className = "alert alert-danger mt-3";
    errorDiv.textContent = mensaje;

    const cardBody = document.querySelector(".card-body");
    cardBody.appendChild(errorDiv);

    setTimeout(() => errorDiv.remove(), 5000);
}