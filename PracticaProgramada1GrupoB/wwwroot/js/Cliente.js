(() => {
    const Cliente = {
        tabla: null,

        init() {
            // Si DataTables no está cargado, la tabla ya muestra datos renderizados en el servidor; no hacer nada.
            if (!$.fn || !$.fn.DataTable) return;
            this.inicializarTabla();
        },

        inicializarTabla() {
            if (this.tabla) {
                this.tabla.destroy();
                $('#tblCliente').empty();
            }

            this.tabla = $('#tblCliente').DataTable({
                ajax: {
                    url: '/Cliente/ObtenerClientes',
                    type: 'GET',
                    //Most server endpoints return a plain JSON array; use '' unless your endpoint returns { data: [...] }
                    dataSrc: ''
                },
                columns: [
                    { data: 'Id' },
                    { data: 'Nombre' },
                    { data: 'Apellido' },
                    { data: 'CorreoElectronico' },
                    { data: 'Telefono' },
                    {
                        data: null,
                        render: function (data, type, row) {
                            return `
                                <a href="/Cliente/Edit/${row.Id}">Edit</a> |
                                <a href="/Cliente/Details/${row.Id}">Details</a> |
                                <a href="/Cliente/Delete/${row.Id}">Delete</a>`;
                        },
                        orderable: false
                    }
                ],
                responsive: true
            });
        }
    };

    $(document).ready(() => Cliente.init());
})();