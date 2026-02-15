(() => {
    const Cliente = {
        tabla: null,

        init() {
            this.inicializarTabla();
            this.registrarEventos();

        },
        inicializarTabla() {
            // Cargar datos primero manualmente para asegurar que se carguen correctamente
            $.ajax({
                url: '/Cliente/ObtenerClientes',
                type: 'GET',
                dataType: 'json',
                success: (response) => {
                    let datos = [];
                    if (response && response.esCorrecto && response.data && Array.isArray(response.data)) {
                        datos = response.data;
                    }
                    
                    // Inicializar DataTables con los datos cargados
                    this.tabla = $('#tblCliente').DataTable({
                        data: datos,
                        columns: [
                            { data: 'id' },
                            { data: 'nombre' },
                            { data: 'apellido' },
                            { data: 'correoElectronico' },
                            { data: 'telefono' },
                            {
                                data: null,
                                title: 'Acciones',
                                orderable: false,
                                render: function (data, type, row) {
                                    return `
                                        <button class="btn btn-sm btn-success btn-ver" data-id="${row.id}">
                                            <i class="bi bi-pencil"></i> Ver
                                        </button>
                                        <button class="btn btn-sm btn-primary btn-editar" data-id="${row.id}">
                                            <i class="bi bi-pencil"></i> Editar
                                        </button>
                                        <button class="btn btn-sm btn-danger btn-eliminar" data-id="${row.id}">
                                            <i class="bi bi-trash"></i> Eliminar
                                        </button>`;
                                }
                            }
                        ],
                        language: {
                            url: 'https://cdn.datatables.net/plug-ins/1.13.6/i18n/es-ES.json'
                        }
                    });
                },
                error: (xhr, status, error) => {
                    console.error('Error al cargar clientes:', error);
                    // Inicializar tabla vacía en caso de error
                    this.tabla = $('#tblCliente').DataTable({
                        data: [],
                        columns: [
                            { data: 'id' },
                            { data: 'nombre' },
                            { data: 'apellido' },
                            { data: 'correoElectronico' },
                            { data: 'telefono' },
                            {
                                data: null,
                                title: 'Acciones',
                                orderable: false,
                                render: function (data, type, row) {
                                    return `
                                        <button class="btn btn-sm btn-success btn-ver" data-id="${row.id}">
                                            <i class="bi bi-pencil"></i> Ver
                                        </button>
                                        <button class="btn btn-sm btn-primary btn-editar" data-id="${row.id}">
                                            <i class="bi bi-pencil"></i> Editar
                                        </button>
                                        <button class="btn btn-sm btn-danger btn-eliminar" data-id="${row.id}">
                                            <i class="bi bi-trash"></i> Eliminar
                                        </button>`;
                                }
                            }
                        ],
                        language: {
                            url: 'https://cdn.datatables.net/plug-ins/1.13.6/i18n/es-ES.json'
                        }
                    });
                }
            });
        },
        recargarTabla() {
            // Recargar los datos de la tabla
            $.ajax({
                url: '/Cliente/ObtenerClientes',
                type: 'GET',
                dataType: 'json',
                success: (response) => {
                    if (response && response.esCorrecto && response.data && Array.isArray(response.data)) {
                        // Limpiar y agregar nuevos datos
                        this.tabla.clear();
                        this.tabla.rows.add(response.data);
                        this.tabla.draw();
                    }
                },
                error: (xhr, status, error) => {
                    console.error('Error al recargar clientes:', error);
                }
            });
        },
        registrarEventos() {

            $('#tblCliente').on('click', '.btn-editar', function () {
                const id = $(this).data('id');
                Cliente.cargarDatosCliente(id);
            });

            $('#tblCliente').on('click', '.btn-eliminar', function () {
                const id = $(this).data('id');
                Cliente.eliminarCliente(id);
            });


            //Crear            
            $('#btnGuardarCliente').on('click', function () {
                Cliente.guardarCliente();

            });



            //Editar
            $('#btnEditarCliente').on('click', function () {
                Cliente.editarCliente();

            });


        },
        guardarCliente() {
            let form = $('#formCrearCliente');

            if (!form.valid()) {
                return;
            }

            let formData = form.serialize();

            $.ajax({
                url: form.attr('action'), // /Cliente/AgregarCliente
                type: 'POST',
                data: formData,
                success: function (response) {

                    if (response.esCorrecto) {

                        let modalElement = document.getElementById('modalCrearCliente');
                        let modalInstance = bootstrap.Modal.getInstance(modalElement);
                        if (!modalInstance) {
                            modalInstance = new bootstrap.Modal(modalElement);
                        }
                        modalInstance.hide();
                        form[0].reset();
                        Cliente.recargarTabla(); //Recargar la tabla para mostrar el nuevo cliente

                        Swal.fire({
                            title: 'Éxito',
                            text: response.mensaje,
                            icon: 'success',
                        });
                    } else {
                        Swal.fire({
                            title: 'Error',
                            text: response.mensaje || 'Ocurrió un error.',
                            icon: 'warning',
                        });
                    }

                },
                error: function (xhr, status, error) {
                    Swal.fire({
                        title: 'Error',
                        text: 'Ocurrió un error al guardar el cliente. Por favor, intente nuevamente.',
                        icon: 'error',
                    });
                    console.error('Error:', error);
                }
            });
        },
        cargarDatosCliente: function (id) {

            $.get(`/Cliente/ObtenerClientePorId?id=${id}`, function (result) {
                if (result.esCorrecto) {
                    let data = result.data;                 //1. Cargar los datos

                    $('#ClienteId').val(data.id);             //2. Pintar los datos en el formulario
                    $('#formEditarCliente #Nombre').val(data.nombre);
                    $('#formEditarCliente #Apellido').val(data.apellido);
                    $('#formEditarCliente #CorreoElectronico').val(data.correoElectronico);
                    $('#formEditarCliente #Telefono').val(data.telefono);

                    let modalElement = document.getElementById('modalEditarCliente');
                    let modalInstance = new bootstrap.Modal(modalElement);
                    modalInstance.show();   //3. Mostrar el modal

                } else {
                    Swal.fire({
                        title: 'Error',
                        text: result.mensaje || 'No se pudo obtener el cliente.',
                        icon: 'warning'
                    });
                }
            }).fail(function (xhr, status, error) {
                Swal.fire({
                    title: 'Error',
                    text: 'Ocurrió un error al cargar los datos del cliente.',
                    icon: 'error'
                });
                console.error('Error:', error);
            });
        },
        editarCliente: function () {
            let form = $('#formEditarCliente');

            if (!form.valid()) {
                return;
            }

            // El token anti-forgery ya está incluido en form.serialize() si está dentro del formulario
            let formData = form.serialize();

            $.ajax({
                url: form.attr('action'), // /Cliente/ActualizarCliente
                type: 'POST',
                data: formData,
                success: function (response) {

                    if (response.esCorrecto) {

                        let modalElement = document.getElementById('modalEditarCliente');
                        let modalInstance = bootstrap.Modal.getInstance(modalElement);
                        if (!modalInstance) {
                            modalInstance = new bootstrap.Modal(modalElement);
                        }
                        modalInstance.hide();
                        form[0].reset();
                        Cliente.recargarTabla(); //Recargar la tabla para mostrar el cliente actualizado

                        Swal.fire({
                            title: 'Éxito',
                            text: response.mensaje,
                            icon: 'success',
                        });
                    }
                    else {
                        Swal.fire({
                            title: 'Error',
                            text: response.mensaje,
                            icon: 'warning',
                        });

                    }

                },
                error: function (xhr, status, error) {
                    Swal.fire({
                        title: 'Error',
                        text: 'Ocurrió un error al actualizar el cliente. Por favor, intente nuevamente.',
                        icon: 'error',
                    });
                    console.error('Error:', error);
                }
            });

        },
        eliminarCliente: function (id) {

            Swal.fire({
                title: '¿Estás seguro?',
                text: "¡No podrás revertir esta operación!",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonText: 'Sí, eliminar',
            }).then((result) => {
                if (result.isConfirmed) {

                    $.ajax({
                        url: '/Cliente/EliminarCliente',
                        type: 'POST',
                        data: { id: id },
                        success: function (response) {

                            if (response.esCorrecto) {

                                Cliente.recargarTabla(); //Recargar la tabla

                                Swal.fire({
                                    title: 'Éxito',
                                    text: response.mensaje,
                                    icon: 'success',
                                });
                            } else {
                                Swal.fire({
                                    title: 'Error',
                                    text: response.mensaje || 'No se pudo eliminar.',
                                    icon: 'warning'
                                });
                            }

                        },
                        error: function (xhr, status, error) {
                            Swal.fire({
                                title: 'Error',
                                text: 'Ocurrió un error al eliminar el cliente. Por favor, intente nuevamente.',
                                icon: 'error',
                            });
                            console.error('Error:', error);
                        }
                    });

                }

            });

        }

    };

    $(document).ready(() => Cliente.init());

})(); //Encapsula el codigo y evita conflictos con otras librerias o codigos JS

