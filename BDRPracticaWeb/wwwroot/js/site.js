// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function EditarPais(idPais) {

    if (window.location.href.includes('Home')) {
        window.location.href = 'actualizarPais?IdPais=' + idPais;
    } else {
        window.location.href = 'home/actualizarPais?IdPais=' + idPais;
    }

    
}

function EliminarPais(idPais, nombrePais) {

    if (!confirm("Seguro que quiere borrar el pais " + nombrePais + "?")) {
        return;
    }

    $.ajax({
        url: 'Home/BorrarPais',
        data: { IdPais: idPais }
    }).done(function (data) {
        alert(data);
        location.reload();
    });

}