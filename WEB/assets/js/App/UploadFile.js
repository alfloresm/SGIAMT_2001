$(document).ready(function () {
    var Id = getQueryStringParameter("ID");
    if (Id == undefined || Id == "") {
        $("#cph_body_FileUpload1").prop('required', true);
    } else {
        $("#cph_body_FileUpload1").prop('required', false);

    }
});


function uploadFileDocuments(codigo) {
    var formData = new FormData();
    var varLstAnexo = ObtenerAnexos2();
    debugger;
    $.each(varLstAnexo, function (key, value) {
        var file = value;
        formData.append(file.name, file);
    });
    console.log("Codigo ingresado al JS es :" + codigo);
    if (varLstAnexo != null) {
        var urlConsultaRest = "ghUploadFile.ashx?Id=" + codigo;
        $.ajax({
            url: urlConsultaRest,
            type: "POST",
            contentType: false, // Not to set any content header  
            processData: false, // Not to process data  
            data: formData,
            success: function (result) {
                //$('#preloader').fadeOut('slow');
                console.log("Documento cargado");

            },
            error: function (err) {
                console.log("error upload file");
            }
        });
    }
}

function ValidacionImagenVoucher() {
    var formData = new FormData();
    var varLstAnexo = ObtenerAnexos2();

    debugger;    
    debugger;
    $.each(varLstAnexo, function (key, value) {
        var file = value;
        formData.append(file.name, file);
    });
    if (varLstAnexo != [undefined]) {
        $('#hftxtimg').val('1');
        console.log($("#hftxtimg").val());
    }
    else {
        $('#hftxtimg').val('2');
        console.log($("#hftxtimg").val());
    }
}

function ObtenerAnexos() {
    var varAnexos = new Array();

    var $targetval = $("#cph_body_FileUpload1");
    var varDocumentoAnexo = $targetval.prop("files");
    if (!varDocumentoAnexo == false) {
        varAnexos.push(varDocumentoAnexo[0]);
    }
    return varAnexos;
}
function ObtenerAnexos2() {
    var varAnexos = new Array();

    var $targetval = $("#ContentPlaceHolder1_FileUpload1");
    var varDocumentoAnexo = $targetval.prop("files");
    if (!varDocumentoAnexo == false) {
        varAnexos.push(varDocumentoAnexo[0]);
    }
    return varAnexos;
}
