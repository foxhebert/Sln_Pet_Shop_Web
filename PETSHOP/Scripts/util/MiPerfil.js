const formatoFecha = 'DD/MM/YYYY'

async function getPersonalPerfil(intIdPersonalId) {
    $.blockUI({
        css: {
            border: 'none',
            padding: '15px',
            backgroundColor: '#000',
            '-webkit-border-radius': '10px',
            '-moz-border-radius': '10px',
            opacity: .5,
            color: '#fff'
        },
        message: 'Procesando...'
    });
    const { intIdMenu, formatoFecha, rangeDateInicial } = configMiFichaInicial()
    const { loaderHtml } = APPCONFIG
    const intIdPersonal = intIdPersonalId
    //getAdicionalControlEditarPersonal()
    try {
        const anio = moment().startOf('year').format('YYYY')
        fechaInicio = '01/01/' + anio
        fechaFin = '31/12/' + anio

        $(".rangoFechaIni").html('Enero 01, ' + anio)
        $(".rangoFechaFin").html('Diciembre 31, ' + anio)

        const dataUser = await axios.post('/Personal/GetPersonalData', { intIdMenu, intIdPersonal })
        const dataAusencia = await axios.post('/Personal/ListaAsusencias', { intIdPersonal, fechaInicio, fechaFin })
        const dataResponsabilidad = await axios.post('/Personal/ListaPersonalResponsabilidad', { intIdPersonal, fechaInicio, fechaFin })
        const dataAsistencia = await axios.post('/Personal/ListaPersonalAsistencia', { intIdPersonal, fechaInicio, fechaFin })
        const dataCorreos = await axios.post('/Personal/GetCorreosPersonal', { intIdMenu, intIdPersonal })
        const dataTelefonos = await axios.post('/Personal/GetTelefonosPersonal', { intIdMenu, intIdPersonal })
        const dataGrafico = await axios.post('/Asistencia/ObtenerAsistenciaXFecha', { intIdPersonal, fechaInicio, fechaFin })

        const anioMenor = fechaInicio.substr(-4, 4)
        const anioMayor = fechaFin.substr(-4, 4)

        const mesNumberMenor = parseInt(fechaInicio.substr(3, 2))
        const mesNumberMayor = parseInt(fechaFin.substr(3, 2))

        const anioGnl = anioMenor.substr(2, 2)

        const data_X = ['Ene' + anioGnl, 'Feb' + anioGnl, 'Mar' + anioGnl, 'Abr' + anioGnl, 'May' + anioGnl, 'Jun' + anioGnl, 'Jul' + anioGnl, 'Ago' + anioGnl, 'Set' + anioGnl, 'Oct' + anioGnl, 'Nov' + anioGnl, 'Dic' + anioGnl];

        if (anioMenor != anioMayor) {
            var listaMenorAsis = []
            var listaMenorInasis = []
            var listaMayorAsis = []
            var listaMayorInasis = []

            var numerador = 0

            for (var i = mesNumberMenor; i <= 12; i++) {
                listaMenorAsis[i] = 0
                listaMenorInasis[i] = 0
                data_X[numerador] = meses[i - 1] + anioMenor.substr(2, 2)
                numerador++
            }

            for (var i = 1; i <= mesNumberMayor; i++) {
                listaMayorAsis[i] = 0
                listaMayorInasis[i] = 0
                data_X[numerador] = meses[i - 1] + anioMayor.substr(2, 2)
                numerador++
            }

            dataGrafico.data.forEach(element => {
                if (element.anio == anioMenor) {
                    listaMenorAsis[parseInt(element.mes)] = element.asistencia
                    listaMenorInasis[parseInt(element.mes)] = element.faltas

                } else if (element.anio == anioMayor) {
                    listaMayorAsis[parseInt(element.mes)] = element.asistencia
                    listaMayorInasis[parseInt(element.mes)] = element.faltas
                }
            });

            var list_asistencia = listaMenorAsis.concat(listaMayorAsis).filter(function (el) {
                return el != null;
            });

            var list_inasistencia = listaMenorInasis.concat(listaMayorInasis).filter(function (el) {
                return el != null;
            });
        } else {
            var list_asistencia = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
            var list_inasistencia = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];

            dataGrafico.data.forEach(element => {
                switch (element.mes) {
                    case 1:
                        list_asistencia[0] = element.asistencia;
                        list_inasistencia[0] = element.faltas;
                        break
                    case 2:
                        list_asistencia[1] = element.asistencia;
                        list_inasistencia[1] = element.faltas;
                        break
                    case 3:
                        list_asistencia[2] = element.asistencia;
                        list_inasistencia[2] = element.faltas;
                        break;
                    case 4:
                        list_asistencia[3] = element.asistencia;
                        list_inasistencia[3] = element.faltas;
                        break;
                    case 5:
                        list_asistencia[4] = element.asistencia;
                        list_inasistencia[4] = element.faltas;
                        break;
                    case 6:
                        list_asistencia[5] = element.asistencia;
                        list_inasistencia[5] = element.faltas;
                        break;
                    case 7:
                        list_asistencia[6] = element.asistencia;
                        list_inasistencia[6] = element.faltas;
                        break;
                    case 8:
                        list_asistencia[7] = element.asistencia;
                        list_inasistencia[7] = element.faltas;
                        break;
                    case 9:
                        list_asistencia[8] = element.asistencia;
                        list_inasistencia[8] = element.faltas;
                        break;
                    case 10:
                        list_asistencia[9] = element.asistencia;
                        list_inasistencia[9] = element.faltas;
                        break;
                    case 11:
                        list_asistencia[10] = element.asistencia;
                        list_inasistencia[10] = element.faltas;
                        break;
                    case 12:
                        list_asistencia[11] = element.asistencia;
                        list_inasistencia[11] = element.faltas;
                        break;
                }
            });

            echartGlobalInstance.setOption({
                xAxis: [{
                    type: 'category',
                    name: 'meses',
                    data: data_X
                }],
                series: [{
                    name: 'Asistencias',
                    type: 'bar',
                    data: list_asistencia,
                    label: {
                        show: true,
                        position: 'insideRight'
                    },
                    //markPoint: {
                    //    data: [{
                    //        type: 'max',
                    //        name: 'MAX'
                    //    }, {
                    //        type: 'min',
                    //        name: 'MIN'
                    //    }]
                    //},
                    markLine: {
                        data: [{
                            type: 'average',
                            name: 'PROMEDIO'
                        }]
                    }
                }, {
                    name: 'Inasistencias',
                    type: 'bar',
                    data: list_inasistencia,
                    label: {
                        show: true,
                        position: 'insideRight'
                    },
                    //markPoint: {
                    //    data: [{
                    //        type: 'max',
                    //        name: 'MAX'
                    //    }, {
                    //        type: 'min',
                    //        name: 'MIN'
                    //    }]
                    //},
                    markLine: {
                        data: [{
                            type: 'average',
                            name: 'PROMEDIO'
                        }]
                    }
                }]
            });

        }

        if (dataUser.data.length) {
            document.querySelectorAll('.loading-item-p').forEach((el) => {
                el.classList.remove('skeleton-loader', 'h23x100', 'h22x79', 'dplayinitial', 'bg-loader')
            })
        }
        if (dataAusencia.data.length) {
            var listaAusencia = dataAusencia.data
            var table = ''

            for (i = 0; i < listaAusencia.length; i++) {

                table += '<li>' +
                    '<h5 class="loading-item-p h23x200">' + listaAusencia[i].strDesConcepto + '</h5>' +
                    '<div class="progress">'
                if (listaAusencia[i].strDeTipo == "Días") {
                    var porcent = (listaAusencia[i].intTotalDias * 100) / listaAusencia[i].intTope
                    table += '<div class="progress-bar progress-bar-success" role = "progressbar" style = "width: ' + porcent + '%" aria-valuenow="' + listaAusencia[i].intTotalDias + '" aria-valuemin="0" aria-valuemax="' + listaAusencia[i].intTope + '" >' + listaAusencia[i].intTotalDias + '</div>'
                } else {
                    var porcent = (listaAusencia[i].intTotalHoras * 100) / listaAusencia[i].intTope
                    table += '<div class="progress-bar progress-bar-success" role = "progressbar" style = "width: ' + porcent + '%" aria-valuenow="' + listaAusencia[i].intTotalHoras + '" aria-valuemin="0" aria-valuemax="' + listaAusencia[i].intTope + '" >' + getTimeConceptoHoras(listaAusencia[i].strDesConcepto) + '</div>'
                }

                table += '</div>' +
                    '</li>'
            }
            $("#ausenciaList").html(table)
        }
        if (dataResponsabilidad.data.length) {

            var listResponsabilidad = dataResponsabilidad.data

            var table = ''

            for (i = 0; i < listResponsabilidad.length; i++) {
                table += '<tr>' +
                    '<th scope="row">' + listResponsabilidad[i].strCoPersonal + '</th>' +
                    '<td>' + listResponsabilidad[i].strNombresComp + '</td>' +
                    '<td>' + listResponsabilidad[i].strDesCargo + '</td>' +
                    '<td>' + listResponsabilidad[i].strDeTipo + '</td>' +
                    '</tr>'
            }

            if ($.fn.DataTable.isDataTable('#tableResponsabilidad')) {
                _vartableResponsabilidad.destroy();
            }

            $("#tableResponsabilidad .data").html(table);

            _vartableResponsabilidad = $('#tableResponsabilidad').DataTable({
                responsive: true,
                language: {
                    lengthMenu: 'Mostrar _MENU_ Items',
                    info: 'Mostrar _START_ a _END_ de _TOTAL_ Items',
                    infoEmpty: 'No hay Items para mostrar',
                    search: 'Buscar: ',
                    sSearchPlaceholder: 'Criterio de búsqueda',
                    zeroRecords: 'No se encontraron registros coincidentes',
                    infoFiltered: '(Filtrado de _MAX_ totales Items)',
                    paginate: {
                        previous: 'Anterior',
                        next: 'Siguiente'
                    }
                }
            });
        } else {

            if ($.fn.DataTable.isDataTable('#tableResponsabilidad')) {
                _vartableResponsabilidad.destroy();
            }
            $("#tableResponsabilidad .data").html("")
            _vartableResponsabilidad = $('#tableResponsabilidad').DataTable({
                responsive: true,
                language: {
                    lengthMenu: 'Mostrar _MENU_ Items',
                    info: 'Mostrar _START_ a _END_ de _TOTAL_ Items',
                    infoEmpty: 'No hay Items para mostrar',
                    search: 'Buscar: ',
                    sSearchPlaceholder: 'Criterio de búsqueda',
                    zeroRecords: 'No se encontraron registros coincidentes',
                    infoFiltered: '(Filtrado de _MAX_ totales Items)',
                    paginate: {
                        previous: 'Anterior',
                        next: 'Siguiente'
                    }
                }
            });
        }


        if (dataAsistencia.data.length) {

            var listaAsistencia = dataAsistencia.data
            var total = 0

            listaAsistencia.map((asistencia) => total += asistencia.intTotalDias)

            var table = ''

            for (i = 0; i < listaAsistencia.length; i++) {
                var porcent = (listaAsistencia[i].intTotalDias * 100) / total

                table += '<tr>' +
                    '<th scope="row">' + (i + 1) + '</th>' +
                    '<td>' + listaAsistencia[i].strDesConcepto + '</td>' +
                    '<td> Por ' + listaAsistencia[i].strDeTipo + '</td>' +
                    '<td>' + getHorasByMin(listaAsistencia[i].intTotalHoras) + '</td>' +
                    '<td>' + listaAsistencia[i].intTotalDias + '</td>' +
                    '<td>' +
                    '<div class="progress" >' +
                    '<div class="progress-bar progress-bar-striped progress-bar-success" role = "progressbar" style = "width: ' + porcent + '%" aria-valuenow="' + porcent + '" aria-valuemin="0" aria-valuemax="' + total + '" ></div>'
                '</div>' +
                    '</td> ' +
                    '</tr>'
            }

            if ($.fn.DataTable.isDataTable('#tablePapeleta')) {
                _vartablePapeleta.destroy();
            }

            $("#tablePapeleta .data").html(table);

            _vartablePapeleta = $('#tablePapeleta').DataTable({
                "footerCallback": function (row, data, start, end, display) {
                    var api = this.api(), data;

                    // Remove the formatting to get integer data for summation
                    var intVal = function (i) {
                        return typeof i === 'string' ?
                            i.replace(/[\$,]/g, '') * 1 :
                            typeof i === 'number' ?
                                i : 0;
                    };

                    //// Total over all pages
                    //total = api
                    //    .column(4)
                    //    .data()
                    //    .reduce(function (a, b) {
                    //        return intVal(a) + intVal(b);
                    //    }, 0);

                    // Total over this page
                    pageTotal = api
                        .column(4, { page: 'current' })
                        .data()
                        .reduce(function (a, b) {
                            return intVal(a) + intVal(b);
                        }, 0);

                    // Update footer
                    $(api.column(4).footer()).html(
                        pageTotal
                    );
                },
                language: {
                    lengthMenu: 'Mostrar _MENU_ Items',
                    info: 'Mostrar _START_ a _END_ de _TOTAL_ Items',
                    infoEmpty: 'No hay Items para mostrar',
                    search: 'Buscar: ',
                    sSearchPlaceholder: 'Criterio de búsqueda',
                    zeroRecords: 'No se encontraron registros coincidentes',
                    infoFiltered: '(Filtrado de _MAX_ totales Items)',
                    paginate: {
                        previous: 'Anterior',
                        next: 'Siguiente'
                    }
                }
            });
        } else {

            if ($.fn.DataTable.isDataTable('#tablePapeleta')) {
                _vartablePapeleta.destroy();
            }
            $("#tablePapeleta .data").html("")
            _vartablePapeleta = $('#tablePapeleta').DataTable({
                "footerCallback": function (row, data, start, end, display) {
                    var api = this.api(), data;

                    // Remove the formatting to get integer data for summation
                    var intVal = function (i) {
                        return typeof i === 'string' ?
                            i.replace(/[\$,]/g, '') * 1 :
                            typeof i === 'number' ?
                                i : 0;
                    };

                    //// Total over all pages
                    //total = api
                    //    .column(4)
                    //    .data()
                    //    .reduce(function (a, b) {
                    //        return intVal(a) + intVal(b);
                    //    }, 0);

                    // Total over this page
                    pageTotal = api
                        .column(4, { page: 'current' })
                        .data()
                        .reduce(function (a, b) {
                            return intVal(a) + intVal(b);
                        }, 0);

                    // Update footer
                    $(api.column(4).footer()).html(
                        pageTotal
                    );
                },
                language: {
                    lengthMenu: 'Mostrar _MENU_ Items',
                    info: 'Mostrar _START_ a _END_ de _TOTAL_ Items',
                    infoEmpty: 'No hay Items para mostrar',
                    search: 'Buscar: ',
                    sSearchPlaceholder: 'Criterio de búsqueda',
                    zeroRecords: 'No se encontraron registros coincidentes',
                    infoFiltered: '(Filtrado de _MAX_ totales Items)',
                    paginate: {
                        previous: 'Anterior',
                        next: 'Siguiente'
                    }
                }
            });

        }


        if (dataUser.data.length) {
            const user = dataUser.data[0]
            const INTIDTPEVAL = user.intIdUbigeo
            const INTIDSUPUBI = user.intIdUbigSup
            const INTIDSUPUBIREGION = user.intIdUbiSupReg
            const intIdProvinciaMostrar = user.intIdUbiReg
            const intIdRegionMostrar = user.intIdUbiPais
            const intIdJerOrgLista = user.intIdJerOrg
            const intIdUniOrgLista = user.intIdUniOrg

            $('#showModalEditar').click(function () {
                $('#myModalEditar').modal('show')
            })

            var rutaFoto = `/DirEmpleadosRuta/${user.imgFoto}`;

            $.ajax({
                url: rutaFoto,
                type: 'HEAD',
                error: function () {
                    //Imagen por defecto
                    $("#imagePersonalPer").attr("src", '/DirEmpleadosRuta/person_logo.jpg');
                },
                success: function () {
                    $("#imagePersonalPer").attr("src", rutaFoto);
                }
            });

            //if (user.imgFoto == null || img.height == 0) {
            //    getDocumentElementById('imagePersonalPer').src = `/DirEmpleadosRuta/person_logo.jpg`
            //} else {
            //    getDocumentElementById('imagePersonalPer').src = `/DirEmpleadosRuta/${user.imgFoto}`
            //}
            getDocumentElementById('imagePersonalPer').style.display = 'block'
            getDocumentElementById('loaderImagePersonal').style.display = 'none'
            getDocumentElementById('namePersonalPer').innerHTML = `${user.strApePaterno} ${user.strApeMaterno}, ${user.strNombres}`
            getDocumentElementById('codigoPersonalPer').innerHTML = `${user.strCoPersonal}-${user.strNumRegis}`
            getDocumentElementById('txtTipoDoc').innerHTML = `${user.strTipoDoc}`
            getDocumentElementById('documentoPersdonal').innerHTML = `${user.strNumDoc}`
            getDocumentElementById('admisionPersonalPer').innerHTML = `${user.dttFecAdmin}`
            getDocumentElementById('fotocheckPersonalPer').innerHTML = `${user.strFotocheck}`
            getDocumentElementById('empresaPersonalr').innerHTML = `${user.strDescripcion}`
            if (user.strDirUbi == null) {
                user.strDirUbi = ""
                user.strDireccion = "Sin Dirección"
            }
            getDocumentElementById('direccionPersonal').innerHTML = `<i class="fa fa-map-marker user-profile-icon"></i> ${user.strDir} <br> ${user.strDirUbi}`
            getDocumentElementById('cargoPersonalp').innerHTML = `<i class="fa fa-briefcase user-profile-icon"></i> ${user.strDesCargo}`

            getDocumentElementById('fechaNacimientoPersonal').innerHTML = `<strong>Fecha de Nacimiento:</strong> ${user.dttFecNacim}`
            getDocumentElementById('generoPersonalm').innerHTML = `<strong>Sexo:</strong> ${user.bitflSexo ? "Masculino" : "Femenino"}`
            getDocumentElementById('generoEstadolm').innerHTML = `<strong>Estado:</strong> ${user.bitFlActivo ? "Activo" : "Inactivo"}`

            const dataCabe = user.strCabe.split("|");
            const dataDeta = user.strDeta.split("|");

            var table = ''

            for (var i = 0; i < dataCabe.length; i++) {
                table += '<div class="col-md-4 col-sm-6 pb-2">' + `<span class="border"><b>${dataCabe[i]}: </b>` + dataDeta[i] + '</span></div>'
            }

            $('#planillaPersonal').html(table)


            $('#txtFechaNac').val(user.dttFecNacim)
            $('#CboPais').val(user.intIdUbiSupPais)
            $('#TipVia').val(user.intIdTipoVia)
            $('#TXTTIPVIA').val(user.strDireccion)

            //$.post(
            //    '/Personal/ListarCombos',
            //    {
            //        strEntidad: 'TGUBIGEO',
            //        intIdFiltroGrupo: INTIDSUPUBI,
            //        strGrupo: 'DIST',
            //        strSubGrupo: '',
            //    },
            //    (response) => {
            //        $('#CboDistrito').empty()
            //        $('#CboDistrito').attr('disabled', false)
            //        $('#CboDistrito').append('<option >Seleccione</option>')
            //        response.forEach((element) => {
            //            $('#CboDistrito').append('<option value="' + element.intidTipo + '" >' + element.strDeTipo + '</option>')
            //            if (element.intidTipo == INTIDTPEVAL) {
            //                $('#CboDistrito').val(element.intidTipo)
            //            }
            //        })
            //    }
            //)

            //$.post(
            //    '/Personal/ListarCombos',
            //    {
            //        strEntidad: 'TGUBIGEO',
            //        intIdFiltroGrupo: INTIDSUPUBIREGION,
            //        strGrupo: 'REG',
            //        strSubGrupo: '',
            //    },
            //    (response) => {
            //        $('#CboProvincia').empty()
            //        $('#CboProvincia').attr('disabled', false)
            //        $('#CboProvincia').append('<option >Seleccione</option>')
            //        response.forEach((element) => {
            //            $('#CboProvincia').append('<option value="' + element.intidTipo + '" >' + element.strDeTipo + '</option>')
            //            if (element.intidTipo == intIdProvinciaMostrar) {
            //                $('#CboProvincia').val(element.intidTipo)
            //            }
            //        })
            //    }
            //)

            //$.post(
            //    '/Personal/ListarCombos',
            //    {
            //        strEntidad: 'TGUBIGEO',
            //        intIdFiltroGrupo: user.intIdUbiSupPais,
            //        strGrupo: 'DEPART',
            //        strSubGrupo: '',
            //    },
            //    (response) => {
            //        $('#CboRegion').empty()
            //        $('#CboRegion').attr('disabled', false)
            //        $('#CboRegion').append('<option value="">Seleccione</option>')
            //        response.forEach((element) => {
            //            $('#CboRegion').append('<option value="' + element.intidTipo + '" >' + element.strDeTipo + '</option>')
            //            if (element.intidTipo == intIdRegionMostrar) {
            //                $('#CboRegion').val(element.intidTipo)
            //            }
            //        })
            //    }
            //)
        }
        if (dataCorreos.data.length) {
            const dataCorreosArray = dataCorreos.data
            let dataCorreosInsert = ''
            $('#tituloCorreoPersonal').html(`<li><i class="glyphicon glyphicon-envelope"></i> Otros Emails:</li>`)
            $('#dataCorreoPersonal').empty()
            dataCorreosArray.forEach((item) => {
                if (item.bitFlPrincipal) {
                    getDocumentElementById('correoPrincipalPersonal').innerHTML = `<i class="fa fa-envelope user-profile-icon"></i> ${item.strCorreo}`
                } else {
                    $('#dataCorreoPersonal').append(`<li>${item.strCorreo}</li><br>`)
                }
            })

            // editar
            dataCorreosArray.forEach((element) => {
                if (element.bitFlPrincipal) {
                    $('#Email_Emple').val(element.strCorreo)
                } else {
                    dataCorreosInsert += element.strCorreo + ','
                }
            })
            if (dataCorreosInsert != '') {
                let cadenaEmail = dataCorreosInsert.slice(0, -1)
                $('#TagEmailContainer').html(`<input id="tagsEmail" type="text" class="tags form-control tagsEmailGet" value="${cadenaEmail}" /><div id="suggestions-container" style="position: relative; float: left; width: 250px; margin: 10px;"></div>`)
            } else {
                $('#TagEmailContainer').html(`<input id="tagsEmail" type="text" class="tags form-control tagsEmailGet" value="" /><div id="suggestions-container" style="position: relative; float: left; width: 250px; margin: 10px;"></div>`)
            }
        } else {
            $('#TagEmailContainer').html(`<input id="tagsEmail" type="text" class="tags form-control tagsEmailGet" value="" /><div id="suggestions-container" style="position: relative; float: left; width: 250px; margin: 10px;"></div>`)
        }
        if (dataTelefonos.data.length) {
            const dataTelefonosArray = dataTelefonos.data
            let dataTelefonosInsert = ''
            $('#tituloTelefonoPersonal').html(`<li><i class="glyphicon glyphicon-phone-alt"></i> Otros Telefonos:</li>`)
            $('#dataTelefonoPersonal').empty()
            dataTelefonosArray.forEach((item) => {
                if (item.bitFlPrincipal) {
                    getDocumentElementById('telefonoPrincipalPersonal').innerHTML = `<i class="glyphicon glyphicon-phone-alt"></i> ${item.strNumero}`
                } else {
                    $('#dataTelefonoPersonal').append(`<li>${item.strNumero}</li><br>`)
                }
            })
            // editar

            dataTelefonosArray.forEach((element) => {
                if (element.bitFlPrincipal) {
                    $('#celularEmpleado').val(element.strNumero)
                } else {
                    dataTelefonosInsert += element.strNumero + ','
                }
            })
            if (dataTelefonosInsert != '') {
                let cadenaTekl = dataTelefonosInsert.slice(0, -1)
                $('#tagTelefonosContainer').html(`<input id="tagsTelefono" type="text" class="tags form-control tagsTelefonoGet" value="${cadenaTekl}"  /><div id="suggestions-container" style="position: relative; float: left; width: 250px; margin: 10px;"></div>`)
            } else {
                $('#tagTelefonosContainer').html(`<input id="tagsTelefono" type="text" class="tags form-control tagsTelefonoGet" value=""  /><div id="suggestions-container" style="position: relative; float: left; width: 250px; margin: 10px;"></div>`)
            }
        } else {
            $('#tagTelefonosContainer').html(`<input id="tagsTelefono" type="text" class="tags form-control tagsTelefonoGet" value=""  /><div id="suggestions-container" style="position: relative; float: left; width: 250px; margin: 10px;"></div>`)
        }

        var mailformatEmail = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/

        $('#tagsEmail').tagsInput({
            width: 'auto',
            defaultText: 'Correos',
            placeholderColor: '#666666',
            pattern: mailformatEmail,
            interactive: true,
        })
        $('#tagsTelefono').tagsInput({
            width: 'auto',
            defaultText: 'Teléfonos',
            placeholderColor: '#666666',
            pattern: /^\d{9}$/,
            interactive: true,
        })
        $.unblockUI();
    } catch (error) {
        console.log(error)
        $.unblockUI();
    }
}

$(document).ready(function () {

    const intIdPersonal = window.SISCOP.intIdPersonal
    if (intIdPersonal != "0") {
        getPersonalPerfil(intIdPersonal)
        graficoAsistencia();
    } else {
        graficoAsistencia();
        const anio = moment().startOf('year').format('YYYY')
        fechaInicio = '01/01/' + anio
        fechaFin = '31/12/' + anio
        $(".rangoFechaIni").html(fechaInicio)
        $(".rangoFechaFin").html(fechaFin)
        $.post(
            '/Personal/ListaAsusencias',
            { intIdPersonal, fechaInicio, fechaFin },
            (response) => {
                var listaAusencia = response
                var table = ''

                for (i = 0; i < listaAusencia.length; i++) {

                    table += '<li>' +
                        '<h5 class="loading-item-p h23x200">' + listaAusencia[i].strDesConcepto + '</h5>' +
                        '<div class="progress">'
                    if (listaAusencia[i].strDeTipo == "Días") {
                        var porcent = (listaAusencia[i].intTotalDias * 100) / listaAusencia[i].intTope
                        table += '<div class="progress-bar progress-bar-success" role = "progressbar" style = "width: ' + porcent + '%" aria-valuenow="' + listaAusencia[i].intTotalDias + '" aria-valuemin="0" aria-valuemax="' + listaAusencia[i].intTope + '" >' + listaAusencia[i].intTotalDias + '</div>'
                    } else {
                        var porcent = (listaAusencia[i].intTotalHoras * 100) / listaAusencia[i].intTope
                        table += '<div class="progress-bar progress-bar-success" role = "progressbar" style = "width: ' + porcent + '%" aria-valuenow="' + listaAusencia[i].intTotalHoras + '" aria-valuemin="0" aria-valuemax="' + listaAusencia[i].intTope + '" >' + getTimeConceptoHoras(listaAusencia[i].strDesConcepto) + '</div>'
                    }

                    table += '</div>' +
                        '</li>'
                }
                $("#ausenciaList").html(table)
            });
    }
    var today = new Date(new Date().getFullYear(), new Date().getMonth(), new Date().getDate());
    $('#FechaNac').datetimepicker({
        maxDate: today,
        viewMode: 'days',
        format: formatoFecha
    })

    var intIdPersonal_ = 0

    if (window.SISCOP.intIdPersonal == "0") {
        $("#divCboEmpleado").show()
        $(".adminClass").hide()
    }

    $.post(
        '/Personal/ListarCombosPersonal',
        { intIdMenu: 0, strEntidad: 'TGPERSONAL', intIdFiltroGrupo: 0, strGrupo: 'MIPERFIL', strSubGrupo: '' },
        (response) => {
            $('#cboEmpleados').empty();
            $('#cboEmpleados').append('<option value="0" selected>Seleccione</option>');

            response.forEach(element => {
                $('#cboEmpleados').append('<option value="' + element.intidTipo + '">' + element.strDeTipo + '</option>');

            });
        });

    $('#cboEmpleados').select2({
        placeholder: 'Seleccione',
        allowClear: true
    });

    $("#cboEmpleados").change(function () {
        validarSession()

        intIdPersonal_ = $(this).val();
        getPersonalPerfil(intIdPersonal_)
        if (intIdPersonal_ == 0) {
            $(".adminClass").hide()
        } else {
            $(".adminClass").show()
        }

    })

    $('#guardarPerfilUsuario').click(function () {
        validarSession()
        var intIdPersonalTmp = 0;
        if (window.SISCOP.intIdPersonal == "0") {
            intIdPersonalTmp = intIdPersonal_
        } else {
            intIdPersonalTmp = window.SISCOP.intIdPersonal
        }

        updatePersonalPerfil(intIdPersonalTmp)
    })

    $("#exportPDF").click(function () {
        validarSession()
        window.open('/Personal/exportPDF');
    })

    var meses = ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Set', 'Oct', 'Nov', 'Dic'];

    function getDatos(intIdPersonal, fechaInicio, fechaFin) {
        validarSession()
        const anio = fechaInicio.substr(-4, 4);
        $.post(
            '/Personal/ListaAsusencias',
            { intIdPersonal: intIdPersonal, fechaInicio: fechaInicio, fechaFin: fechaFin },
            (response) => {
                if (response.length) {
                    var listaAusencia = response
                    var table = ''

                    for (i = 0; i < listaAusencia.length; i++) {

                        table += '<li>' +
                            '<h5 class="loading-item-p h23x200">' + listaAusencia[i].strDesConcepto + '</h5>' +
                            '<div class="progress">'

                        if (listaAusencia[i].intTotalDias > 0) {
                            var porcent = (listaAusencia[i].intTotalDias * 100) / listaAusencia[i].intTope
                            table += '<div class="progress-bar progress-bar-success" role="progressbar" style="width: ' + porcent + '%" aria-valuenow="' + listaAusencia[i].intTotalDias + '" aria-valuemin="0" aria-valuemax="' + listaAusencia[i].intTope + '" >' + listaAusencia[i].intTotalDias + '</div>'
                        } else {
                            var porcent = (listaAusencia[i].intTotalHoras * 100) / listaAusencia[i].intTope
                            table += '<div class="progress-bar progress-bar-success" role="progressbar" style="width: ' + porcent + '%" aria-valuenow="' + listaAusencia[i].intTotalHoras + '" aria-valuemin="0" aria-valuemax="' + listaAusencia[i].intTope + '" >' + listaAusencia[i].intTotalHoras + '</div>'
                        }

                        table += '</div>' +
                            '</li>'
                    }
                    $("#ausenciaList").html(table)
                }
            });

        $.post(
            '/Personal/ListaPersonalAsistencia',
            { intIdPersonal: intIdPersonal, fechaInicio: fechaInicio, fechaFin: fechaFin },
            (response) => {
                if (response.length) {

                    var listaAsistencia = response
                    var total = 0

                    listaAsistencia.map((asistencia) => total += asistencia.intTotalDias)

                    var table = ''

                    for (i = 0; i < listaAsistencia.length; i++) {
                        var porcent = (listaAsistencia[i].intTotalDias * 100) / total

                        table += '<tr>' +
                            '<th scope="row">' + (i + 1) + '</th>' +
                            '<td>' + listaAsistencia[i].strDesConcepto + '</td>' +
                            '<td> Por ' + listaAsistencia[i].strDeTipo + '</td>' +
                            '<td>' + getHorasByMin(listaAsistencia[i].intTotalHoras) + '</td>' +
                            '<td>' + listaAsistencia[i].intTotalDias + '</td>' +
                            '<td>' +
                            '<div class="progress" >' +
                            '<div class="progress-bar progress-bar-striped progress-bar-success" role = "progressbar" style = "width: ' + porcent + '%" aria-valuenow="' + porcent + '" aria-valuemin="0" aria-valuemax="' + total + '" ></div>'
                        '</div>' +
                            '</td> ' +
                            '</tr>'
                    }
                    _vartablePapeleta.destroy();
                    $("#tablePapeleta .data").html(table);
                    _vartablePapeleta = $('#tablePapeleta').DataTable({
                        "footerCallback": function (row, data, start, end, display) {
                            var api = this.api(), data;

                            // Remove the formatting to get integer data for summation
                            var intVal = function (i) {
                                return typeof i === 'string' ?
                                    i.replace(/[\$,]/g, '') * 1 :
                                    typeof i === 'number' ?
                                        i : 0;
                            };

                            //// Total over all pages
                            //total = api
                            //    .column(4)
                            //    .data()
                            //    .reduce(function (a, b) {
                            //        return intVal(a) + intVal(b);
                            //    }, 0);

                            // Total over this page
                            pageTotal = api
                                .column(4, { page: 'current' })
                                .data()
                                .reduce(function (a, b) {
                                    return intVal(a) + intVal(b);
                                }, 0);

                            // Update footer
                            $(api.column(4).footer()).html(
                                pageTotal
                            );
                        },
                        language: {
                            lengthMenu: 'Mostrar _MENU_ Items',
                            info: 'Mostrar _START_ a _END_ de _TOTAL_ Items',
                            infoEmpty: 'No hay Items para mostrar',
                            search: 'Buscar: ',
                            sSearchPlaceholder: 'Criterio de búsqueda',
                            zeroRecords: 'No se encontraron registros coincidentes',
                            infoFiltered: '(Filtrado de _MAX_ totales Items)',
                            paginate: {
                                previous: 'Anterior',
                                next: 'Siguiente'
                            }
                        }
                    });
                } else {
                    _vartablePapeleta.destroy();
                    $("#tablePapeleta .data").html('');
                    _vartablePapeleta = $('#tablePapeleta').DataTable({
                        "footerCallback": function (row, data, start, end, display) {
                            var api = this.api(), data;

                            // Remove the formatting to get integer data for summation
                            var intVal = function (i) {
                                return typeof i === 'string' ?
                                    i.replace(/[\$,]/g, '') * 1 :
                                    typeof i === 'number' ?
                                        i : 0;
                            };

                            //// Total over all pages
                            //total = api
                            //    .column(4)
                            //    .data()
                            //    .reduce(function (a, b) {
                            //        return intVal(a) + intVal(b);
                            //    }, 0);

                            // Total over this page
                            pageTotal = api
                                .column(4, { page: 'current' })
                                .data()
                                .reduce(function (a, b) {
                                    return intVal(a) + intVal(b);
                                }, 0);

                            // Update footer
                            $(api.column(4).footer()).html(
                                pageTotal
                            );
                        },
                        language: {
                            lengthMenu: 'Mostrar _MENU_ Items',
                            info: 'Mostrar _START_ a _END_ de _TOTAL_ Items',
                            infoEmpty: 'No hay Items para mostrar',
                            search: 'Buscar: ',
                            sSearchPlaceholder: 'Criterio de búsqueda',
                            zeroRecords: 'No se encontraron registros coincidentes',
                            infoFiltered: '(Filtrado de _MAX_ totales Items)',
                            paginate: {
                                previous: 'Anterior',
                                next: 'Siguiente'
                            }
                        }
                    });
                }
            }
        )

    }

    $('.range-datepicker').on('apply.daterangepicker', function (ev, picker) {
        validarSession()
        var intIdPersonalTmp = 0;
        if (window.SISCOP.intIdPersonal == "0") {
            intIdPersonalTmp = intIdPersonal_
        } else {
            intIdPersonalTmp = window.SISCOP.intIdPersonal
        }

        const filtrojer_ini = picker.startDate.format('DD/MM/YYYY');
        const filtrojer_fin = picker.endDate.format('DD/MM/YYYY');

        const anioMenor = filtrojer_ini.substr(-4, 4)
        const anioMayor = filtrojer_fin.substr(-4, 4)

        const mesNumberMenor = parseInt(filtrojer_ini.substr(3, 2))
        const mesNumberMayor = parseInt(filtrojer_fin.substr(3, 2))

        const anioGnl = anioMenor.substr(2, 2)

        const data_X = ['Ene' + anioGnl, 'Feb' + anioGnl, 'Mar' + anioGnl, 'Abr' + anioGnl, 'May' + anioGnl, 'Jun' + anioGnl, 'Jul' + anioGnl, 'Ago' + anioGnl, 'Set' + anioGnl, 'Oct' + anioGnl, 'Nov' + anioGnl, 'Dic' + anioGnl];

        if (anioMenor != anioMayor && mesNumberMenor == mesNumberMayor) {
            messageResponseMix({ type: 'info', message: 'Debe seleccionar 12 meses' }, 'Perfil')
            return false;
        }

        $.ajax({
            url: '/Asistencia/ObtenerAsistenciaXFecha',
            type: 'POST',
            data:
                { intIdPersonal: intIdPersonalTmp, fechaInicio: filtrojer_ini, fechaFin: filtrojer_fin },
            beforeSend: function () {
                $.blockUI({
                    css: {
                        border: 'none',
                        padding: '15px',
                        backgroundColor: '#000',
                        '-webkit-border-radius': '10px',
                        '-moz-border-radius': '10px',
                        opacity: .5,
                        color: '#fff'
                    },
                    message: 'Procesando...'
                });
            },
            success: function (response) {
                if (anioMenor != anioMayor) {

                    var listaMenorAsis = []
                    var listaMenorInasis = []
                    var listaMayorAsis = []
                    var listaMayorInasis = []

                    var numerador = 0

                    for (var i = mesNumberMenor; i <= 12; i++) {
                        listaMenorAsis[i] = 0
                        listaMenorInasis[i] = 0
                        data_X[numerador] = meses[i - 1] + anioMenor.substr(2, 2)
                        numerador++
                    }

                    for (var i = 1; i <= mesNumberMayor; i++) {
                        listaMayorAsis[i] = 0
                        listaMayorInasis[i] = 0
                        data_X[numerador] = meses[i - 1] + anioMayor.substr(2, 2)
                        numerador++
                    }

                    response.forEach(element => {
                        if (element.anio == anioMenor) {
                            listaMenorAsis[parseInt(element.mes)] = element.asistencia
                            listaMenorInasis[parseInt(element.mes)] = element.faltas

                        } else if (element.anio == anioMayor) {
                            listaMayorAsis[parseInt(element.mes)] = element.asistencia
                            listaMayorInasis[parseInt(element.mes)] = element.faltas
                        }
                    })

                    var list_asistencia = listaMenorAsis.concat(listaMayorAsis).filter(function (el) {
                        return el != null;
                    });

                    var list_inasistencia = listaMenorInasis.concat(listaMayorInasis).filter(function (el) {
                        return el != null;
                    });

                } else {

                    var list_asistencia = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
                    var list_inasistencia = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
                    response.forEach(element => {
                        switch (parseInt(element.mes)) {
                            case 01:
                                list_asistencia[0] = element.asistencia;
                                list_inasistencia[0] = element.faltas;
                                break
                            case 02:
                                list_asistencia[1] = element.asistencia;
                                list_inasistencia[1] = element.faltas;
                                break
                            case 03:
                                list_asistencia[2] = element.asistencia;
                                list_inasistencia[2] = element.faltas;
                                break;
                            case 04:
                                list_asistencia[3] = element.asistencia;
                                list_inasistencia[3] = element.faltas;
                                break;
                            case 05:
                                list_asistencia[4] = element.asistencia;
                                list_inasistencia[4] = element.faltas;
                                break;
                            case 06:
                                list_asistencia[5] = element.asistencia;
                                list_inasistencia[5] = element.faltas;
                                break;
                            case 07:
                                list_asistencia[6] = element.asistencia;
                                list_inasistencia[6] = element.faltas;
                                break;
                            case 08:
                                list_asistencia[7] = element.asistencia;
                                list_inasistencia[7] = element.faltas;
                                break;
                            case 09:
                                list_asistencia[8] = element.asistencia;
                                list_inasistencia[8] = element.faltas;
                                break;
                            case 10:
                                list_asistencia[9] = element.asistencia;
                                list_inasistencia[9] = element.faltas;
                                break;
                            case 11:
                                list_asistencia[10] = element.asistencia;
                                list_inasistencia[10] = element.faltas;
                                break;
                            case 12:
                                list_asistencia[11] = element.asistencia;
                                list_inasistencia[11] = element.faltas;
                                break;
                        }
                    });
                }

                echartGlobalInstance.setOption({
                    xAxis: [{
                        type: 'category',
                        name: 'meses',
                        data: data_X
                    }],
                    series: [{
                        name: 'Asistencias',
                        type: 'bar',
                        data: list_asistencia,
                        label: {
                            show: true,
                            position: 'insideRight'
                        },
                        //markPoint: {
                        //    data: [{
                        //        type: 'max',
                        //        name: 'MAX'
                        //    }, {
                        //        type: 'min',
                        //        name: 'MIN'
                        //    }]
                        //},
                        markLine: {
                            data: [{
                                type: 'average',
                                name: 'PROMEDIO'
                            }]
                        }
                    }, {
                        name: 'Inasistencias',
                        type: 'bar',
                        data: list_inasistencia,
                        label: {
                            show: true,
                            position: 'insideRight'
                        },
                        //markPoint: {
                        //    data: [{
                        //        type: 'max',
                        //        name: 'MAX'
                        //    }, {
                        //        type: 'min',
                        //        name: 'MIN'
                        //    }]
                        //},
                        markLine: {
                            data: [{
                                type: 'average',
                                name: 'PROMEDIO'
                            }]
                        }
                    }]
                });

            },
            complete: function () {
                $.unblockUI();
            }
        });

        getDatos(intIdPersonalTmp, filtrojer_ini, filtrojer_fin)

        $(".rangoFechaIni").html(picker.startDate.format('MMMM D, YYYY'))
        $(".rangoFechaFin").html(picker.endDate.format('MMMM D, YYYY'))
    });

    $('#showModalEditar').click(async function () {
        validarSession()
        var intIdPersonalTmp = 0;
        if (window.SISCOP.intIdPersonal == "0") {
            intIdPersonalTmp = intIdPersonal_
        } else {
            intIdPersonalTmp = window.SISCOP.intIdPersonal
        }
        const intIdPersonal = intIdPersonalTmp
        const { intIdMenu } = configEmpleadoInicial()

        const dataUser = await axios.post('/Personal/GetPersonalData', { intIdMenu, intIdPersonal })
        const dataCorreos = await axios.post('/Personal/GetCorreosPersonal', { intIdMenu, intIdPersonal })
        const dataTelefonos = await axios.post('/Personal/GetTelefonosPersonal', { intIdMenu, intIdPersonal })

        if (dataUser.data.length) {
            const user = dataUser.data[0]
            const INTIDTPEVAL = user.intIdUbigeo
            const INTIDSUPUBI = user.intIdUbigSup
            const INTIDSUPUBIREGION = user.intIdUbiSupReg
            const intIdProvinciaMostrar = user.intIdUbiReg
            const intIdRegionMostrar = user.intIdUbiPais
            const intIdPaisMostrar = user.intIdUbiSupPais

            $.post(
                '/Personal/ListarCombos',
                {
                    intIdMenu: intIdMenu,
                    strEntidad: 'TGTIPO_VIA',
                    intIdFiltroGrupo: 0,
                    strGrupo: '',
                    strSubGrupo: ''
                },
                resp => {
                    const dataTipVia = resp
                    if (dataTipVia.length) {
                        $('#TipVia').empty()
                        $('#TipVia').attr('disabled', false)
                        $('#TipVia').append('<option value="">Via</option>')
                        dataTipVia.forEach((element) => {
                            $('#TipVia').append('<option value="' + element.intidTipo + '">' + element.strDeTipo + '</option>')
                            if (element.intidTipo == user.intIdTipoVia) {
                                $('#TipVia').val(element.intidTipo)
                            }
                        })
                    }
                }
            )

            $('#txtFechaNac').val(user.dttFecNacim)
            $('#TXTTIPVIA').val(user.strDireccion)
            $('#txtIntidUbigeo').val(INTIDTPEVAL);

            if (dataCorreos.data.length) {
                const dataCorreosArray = dataCorreos.data
                let dataCorreosInsert = ''
                $('#tituloCorreoPersonal').html(`<li><i class="glyphicon glyphicon-envelope"></i> Otros Emails:</li>`)
                $('#dataCorreoPersonal').empty()
                dataCorreosArray.forEach((item) => {
                    if (item.bitFlPrincipal) {
                        getDocumentElementById('correoPrincipalPersonal').innerHTML = `<i class="fa fa-envelope user-profile-icon"></i> ${item.strCorreo}`
                    } else {
                        $('#dataCorreoPersonal').append(`<li>${item.strCorreo}</li><br>`)
                    }
                })

                // editar
                dataCorreosArray.forEach((element) => {
                    if (element.bitFlPrincipal) {
                        $('#Email_Emple').val(element.strCorreo)
                    } else {
                        dataCorreosInsert += element.strCorreo + ','
                    }
                })
                if (dataCorreosInsert != '') {
                    let cadenaEmail = dataCorreosInsert.slice(0, -1)
                    $('#TagEmailContainer').html(`<input id="tagsEmail" type="text" class="tags form-control tagsEmailGet" value="${cadenaEmail}" /><div id="suggestions-container" style="position: relative; float: left; width: 250px; margin: 10px;"></div>`)
                } else {
                    $('#TagEmailContainer').html(`<input id="tagsEmail" type="text" class="tags form-control tagsEmailGet" value="" /><div id="suggestions-container" style="position: relative; float: left; width: 250px; margin: 10px;"></div>`)
                }
            } else {
                $('#TagEmailContainer').html(`<input id="tagsEmail" type="text" class="tags form-control tagsEmailGet" value="" /><div id="suggestions-container" style="position: relative; float: left; width: 250px; margin: 10px;"></div>`)
            }
            if (dataTelefonos.data.length) {
                const dataTelefonosArray = dataTelefonos.data
                let dataTelefonosInsert = ''
                $('#tituloTelefonoPersonal').html(`<li><i class="glyphicon glyphicon-phone-alt"></i>Otros Telefonos:</li>`)
                $('#dataTelefonoPersonal').empty()
                dataTelefonosArray.forEach((item) => {
                    if (item.bitFlPrincipal) {
                        getDocumentElementById('telefonoPrincipalPersonal').innerHTML = `<i class="glyphicon glyphicon-phone-alt"></i> ${item.strNumero}`
                    } else {
                        $('#dataTelefonoPersonal').append(`<li>${item.strNumero}</li><br>`)
                    }
                })
                // editar

                dataTelefonosArray.forEach((element) => {
                    if (element.bitFlPrincipal) {
                        $('#celularEmpleado').val(element.strNumero)
                    } else {
                        dataTelefonosInsert += element.strNumero + ','
                    }
                })
                if (dataTelefonosInsert != '') {
                    let cadenaTekl = dataTelefonosInsert.slice(0, -1)
                    $('#tagTelefonosContainer').html(`<input id="tagsTelefono" type="text" class="tags form-control tagsTelefonoGet" value="${cadenaTekl}"  /><div id="suggestions-container" style="position: relative; float: left; width: 250px; margin: 10px;"></div>`)
                } else {
                    $('#tagTelefonosContainer').html(`<input id="tagsTelefono" type="text" class="tags form-control tagsTelefonoGet" value=""  /><div id="suggestions-container" style="position: relative; float: left; width: 250px; margin: 10px;"></div>`)
                }
            } else {
                $('#tagTelefonosContainer').html(`<input id="tagsTelefono" type="text" class="tags form-control tagsTelefonoGet" value=""  /><div id="suggestions-container" style="position: relative; float: left; width: 250px; margin: 10px;"></div>`)
            }

            var mailformatEmail = /^([a-zA-Z0-9_\.\-])+\@@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/

            $('#tagsEmail').tagsInput({
                width: 'auto',
                defaultText: 'Correos',
                placeholderColor: '#666666',
                pattern: mailformatEmail,
                interactive: true,
            })
            $('#tagsTelefono').tagsInput({
                width: 'auto',
                defaultText: 'Teléfonos',
                placeholderColor: '#666666',
                pattern: /^\d{9}$/,
                interactive: true,
            })


            $.post(
                '/Personal/ListarCombos',
                {
                    intIdMenu: intIdMenu,
                    strEntidad: 'TGPAIS',
                    intIdFiltroGrupo: 0,
                    strGrupo: 'EXISTE',
                    strSubGrupo: '',
                },
                response => {
                    $('#CboPais').empty()
                    $('#CboPais').attr('disabled', false)
                    $('#CboPais').append('<option value="">Seleccione</option>')

                    response.forEach(element => {
                        $('#CboPais').append('<option value="' + element.intidTipo + '">' + element.strDeTipo + '</option>')
                        if (element.intidTipo == intIdPaisMostrar) {
                            $('#CboPais').val(element.intidTipo)
                        }
                    })
                }
            )

            $.post(
                '/Personal/ListarCombos',
                {
                    strEntidad: 'TGUBIGEO',
                    intIdFiltroGrupo: INTIDSUPUBI,
                    strGrupo: 'DIST',
                    strSubGrupo: '',
                },
                (response) => {
                    $('#CboDistrito').empty()
                    $('#CboDistrito').attr('disabled', false)
                    $('#CboDistrito').append('<option value="">Seleccione</option>')
                    response.forEach((element) => {
                        $('#CboDistrito').append('<option value="' + element.intidTipo + '" >' + element.strDeTipo + '</option>')
                        if (element.intidTipo == INTIDTPEVAL) {
                            $('#CboDistrito').val(element.intidTipo)
                        }
                    })
                }
            )

            $.post(
                '/Personal/ListarCombos',
                {
                    strEntidad: 'TGUBIGEO',
                    intIdFiltroGrupo: INTIDSUPUBIREGION,
                    strGrupo: 'REG',
                    strSubGrupo: '',
                },
                (response) => {
                    $('#CboProvincia').empty()
                    $('#CboProvincia').attr('disabled', false)
                    $('#CboProvincia').append('<option value="">Seleccione</option>')
                    response.forEach((element) => {
                        $('#CboProvincia').append('<option value="' + element.intidTipo + '" >' + element.strDeTipo + '</option>')
                        if (element.intidTipo == intIdProvinciaMostrar) {
                            $('#CboProvincia').val(element.intidTipo)
                        }
                    })
                }
            )

            $.post(
                '/Personal/ListarCombos',
                {
                    strEntidad: 'TGUBIGEO',
                    intIdFiltroGrupo: user.intIdUbiSupPais,
                    strGrupo: 'DEPART',
                    strSubGrupo: '',
                },
                (response) => {
                    $('#CboRegion').empty()
                    $('#CboRegion').attr('disabled', false)
                    $('#CboRegion').append('<option value="">Seleccione</option>')
                    response.forEach((element) => {
                        $('#CboRegion').append('<option value="' + element.intidTipo + '" >' + element.strDeTipo + '</option>')
                        if (element.intidTipo == intIdRegionMostrar) {
                            $('#CboRegion').val(element.intidTipo)
                        }
                    })
                }
            )
        }

    })

    $('#CboDistrito').on('change', function () {
        var Distrito = $('#CboDistrito').val();
        $('#txtIntidUbigeo').val(Distrito);
    });


})
