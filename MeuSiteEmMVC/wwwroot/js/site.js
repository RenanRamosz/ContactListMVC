// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
//Script Modal

document.addEventListener('DOMContentLoaded', function () {
    document.querySelectorAll('.btn-total-contatos').forEach(function (button) {
        button.addEventListener("click", function () {
            var usuarioId = this.getAttribute('usuario-id');
            $.ajax({
                type: 'GET',
                url: "/Usuario/ListarContatosPorUsuarioId/" + usuarioId,
                success: function (result) {
                    $("#listaContatosUsuario").html(result);
                    CriarTabelas('#table-contatos-usuario');
                    // Aqui está a correção para abrir o modal
                    var modalContatoUsuario = new bootstrap.Modal(document.getElementById('modalContatosUsuario'));
                    modalContatoUsuario.show(); // Mostra o modal
                }
            });
        });
    });
})

// Script exibir/esconder senha do usuario
document.addEventListener('DOMContentLoaded', function () {
    const alternarSenha = document.querySelector('#togglePassword');
    const senha = document.querySelector('#inputPassword5');
    alternarSenha.addEventListener("click", function () {
        // Alterna o tipo do campo entre 'password' e 'text'
        const type = senha.getAttribute('type') === 'password' ? 'text' : 'password';
        senha.setAttribute('type', type);

        // Alterna o texto do botão entre 'Mostrar' e 'Esconder'
        this.textContent = type === 'password' ? 'Mostrar' : 'Esconder';
    })
})

CriarTabelas('#table-contatos')
CriarTabelas('#table-usuarios')

function CriarTabelas(a) {
    return $(function () {
        $(a).DataTable({
            "ordering": true,
            "paging": true,
            "searching": true,
            "oLanguage": {
                "sEmptyTable": "Nenhum registro encontrado na tabela",
                "sInfo": "Mostrar _START_ até _END_ de _TOTAL_ registros",
                "sInfoEmpty": "Mostrar 0 até 0 de 0 Registros",
                "sInfoFiltered": "(Filtrar de _MAX_ total registros)",
                "sInfoPostFix": "",
                "sInfoThousands": ".",
                "sLengthMenu": "Mostrar _MENU_ registros por pagina",
                "sLoadingRecords": "Carregando...",
                "sProcessing": "Processando...",
                "sZeroRecords": "Nenhum registro encontrado",
                "sSearch": "Pesquisar",
                "oPaginate": {
                    "sNext": "Proximo",
                    "sPrevious": "Anterior",
                    "sFirst": "Primeiro",
                    "sLast": "Ultimo"
                },
                "oAria": {
                    "sSortAscending": ": Ordenar colunas de forma ascendente",
                    "sSortDescending": ": Ordenar colunas de forma descendente"
                }
            }
        });
    });
}
$('.btn-close').on("click", function(){
    $('.alert').hide();
});
