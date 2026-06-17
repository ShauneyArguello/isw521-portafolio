const botonModo = document.getElementById("btnModo");

if (!botonModo) {
    console.error("No se encontró el botón btnModo en el DOM.");
} else {
    if (localStorage.getItem("modo") === "oscuro") {
        document.body.classList.add("modo-oscuro");
    }

    botonModo.addEventListener("click", function () {
        document.body.classList.toggle("modo-oscuro");

        if (document.body.classList.contains("modo-oscuro")) {
            localStorage.setItem("modo", "oscuro");
        } else {
            localStorage.setItem("modo", "claro");
        }
    });
}