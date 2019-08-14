var UiHome = UiHome || {

    pageSelector: "#computadoras-grid",
    t: {},

    init: function () {
        /* Initialize Bootstrap Datatables Integration */
        $(UiHome.pageSelector + '#computadoras-datatable').DataTable();

        UiHome.load();

        /* Initialize Datatables */
        UiHome.t = $(UiHome.pageSelector + ' #computadoras-datatable').DataTable({
            columnDefs: [
                {
                    render: function (data, type, row) {
                        return row.Nombre;
                    },
                    targets: 0
                },
                {
                    render: function (data, type, row) {
                        return row.DiscoTipo;
                    },
                    targets: 1
                },
                {
                    render: function (data, type, row) {
                        return row.DiscoMarca;
                    },
                    targets: 2
                },
                {
                    render: function (data, type, row) {
                        return row.DiscoCapacidad;
                    },
                    targets: 3
                },
                {
                    render: function (data, type, row) {
                        return row.ProcesadorModelo;
                    },
                    targets: 4
                },
                {
                    render: function (data, type, row) {
                        return row.MemoriaMarca;
                    },
                    targets: 5
                },
                {
                    render: function (data, type, row) {
                        return row.MemoriaCapacidad;
                    },
                    targets: 6
                },
            ],
        });
    },

    load: function (params) {
        $.ajax({
            method: 'GET',
            url: "api/homeservice/8",
            dataType: "json",
            success: function (response) {
                if (response == undefined) {
                    alert("Sin datos");
                } else {
                    if (params != undefined) {
                        params.success && params.success(response);
                    } else {
                        UiHome.t.clear().draw();
                        UiHome.t.rows.add(response).draw();
                    }
                }
            },
            error: function (error) {
                alert("Error obteniendo datos");
            },
        });
    },

};