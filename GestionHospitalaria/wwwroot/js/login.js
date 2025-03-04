document.addEventListener("DOMContentLoaded", function () {
    const loginForm = document.getElementById("frmLogin");
    if (!loginForm) {
        console.error("No se encontró el formulario de login con id 'frmLogin'.");
        return;
    }

    loginForm.addEventListener("submit", function (event) {
        event.preventDefault();  // Evita el envío tradicional

        // Extrae los valores
        const correo = document.getElementById("inputEmail").value.trim();
        const clave = document.getElementById("inputPassword").value.trim();

        // Valida que sean los datos requeridos
        if (correo === "juan.perez@example.com" && clave === "Admin123!") {
            // Si coinciden, redirige al Home
            window.location.href = "/Home/Index";
        } else {
            alert("Credenciales inválidas.");
        }
    });
});
