// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function deletePenalite (id) {
    if (confirm("Êtes-vous sûr de vouloir supprimer ? ")) {
        $.get("http://localhost:5271/Penalite/Delete?id_penalite=" + id, function (data, status) {

            window.location.href = "http://localhost:5271/Penalite/Delete"
        })
    };
};


function editPenalite(idA,idB,) {
    if (confirm("Êtes-vous sûr de vouloir Modifier ? ")) {
        $.get("http://localhost:5271/Penalite/Edit?id_penalite=" + idA, function (data, status) {

            window.location.href = "http://localhost:5271/Penalite/Acceuil"
        })
    };
};