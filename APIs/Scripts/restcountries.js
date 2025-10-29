let ddlOpciones = document.getElementById('ddlOpciones');
let inputNombre = document.getElementById('nombrePais');
let inputCodigo = document.getElementById('codigoPais');
let inputLang = document.getElementById('langPais');
let btnEnviar = document.getElementById('btnEnviar')

function opcionesBusqueda(valorSeleccionado) {
    if (valorSeleccionado == "" || valorSeleccionado == null)
    {
        return;
    }

    if (valorSeleccionado == "1") {
        inputNombre.style.display = "block"
        inputCodigo.style.display = "none"
        inputLang.style.display = "none"
    }

    if (valorSeleccionado == "2") {
        inputNombre.style.display = "none"
        inputCodigo.style.display = "block"
        inputLang.style.display = "none"
    }

    if (valorSeleccionado == "3") {
        inputNombre.style.display = "none"
        inputCodigo.style.display = "none"
        inputLang.style.display = "block"
    }

    btnEnviar.style.display = "block"

}





