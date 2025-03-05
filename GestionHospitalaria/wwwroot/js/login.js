document.getElementById("frmLogin").addEventListener("submit", async function (event) {
    event.preventDefault(); // Evita que el formulario se envíe de forma tradicional

    const correo = document.getElementById("inputEmail").value;
    const clave = document.getElementById("inputPassword").value;

    try {
        const response = await fetch("/Acceso/IniciarSesion", {
            method: "POST",
            headers: {
                "Content-Type": "application/x-www-form-urlencoded",
            },
            body: `correo=${encodeURIComponent(correo)}&clave=${encodeURIComponent(clave)}`,
        });

        if (response.redirected) {
            window.location.href = response.url; // Redirigir al dashboard
        } else {
            const error = await response.text();
            alert(error); // Mostrar mensaje de error
        }
    } catch (error) {
        console.error("Error al iniciar sesión:", error);
        alert("Ocurrió un error al intentar iniciar sesión. Por favor, inténtalo de nuevo.");
    }
});