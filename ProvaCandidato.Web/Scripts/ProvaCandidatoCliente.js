jQuery(document).ready(function () {
    CarregarListadeCidades();

    valorDT = $("#ValorData").val();
    if (valorDT != null && valorDT != "" && valorDT != undefined) {
        $('#DataNascimento').val(valorDT);
    }

})

function CarregarListadeCidades() {
    var url = "http://localhost:59011/Cidades/ObterListadeCidades";


    $.ajax({
        type: 'GET',
        url: url,
        contentType: "application/json; charset=UTF-8",
        //data: $('form').serialize(),
        cache: false,
        async: false,
        success: function (res) {
            LoadCidades(res)
        },
        error: function (res) {
            
        }
    });
}

function LoadCidades(cidades) {
    var cidade = $("#CodigoCidade").val();
    if (cidade == null || cidade == "" || cidade == undefined)
        LimparCombo();
    for (i = 0; i < cidades.length; i++) {
        MontarCombo(cidades[i].Codigo, cidades[i].Nome)
    }
}

function MontarCombo(valor, texto) {
    var cidade = $("#CodigoCidade").val();
    if (cidade != null && cidade != "" && cidade != undefined) {
        if (parseInt(valor) != parseInt(cidade))
            $('<option>', { value: parseInt(valor), text: texto }).appendTo("#CidadeId");
        else
            $('<option>', { value: parseInt(valor), text: texto, selected: true }).appendTo("#CidadeId");
    } else {
        $('<option>', { value: parseInt(valor), text: texto }).appendTo("#CidadeId");
    }
        
}

function LimparCombo() {
    $("#CidadeId").empty();
    $('<option>', { value: "", text: "Selecione..." }).appendTo("#CidadeId");
}

$('#btnEditar').click(function () {
    var DataNascimento = $('#DataNascimento').val();
    
    var url = "http://localhost:59011/Clientes/Edit";

    var strData = DataNascimento;
    var partesData = strData.split('/');
    var data = new Date(partesData[2], partesData[1], partesData[0]);
    if (data >= new Date()) {
        alert("Data de nascimento deve ser menor que a Data de Hoje");
        return;
    }
    if (data == undefined) {
        alert("Preencha corretamente o campo Data de nascimento");
        return;
    }

    $("#CidadeId").val(parseInt($("#CidadeId").val()));
    var dados = $('form').serialize();
    
       
    $.ajax({
        type: 'POST',
        url: url,
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        data: dados,
        cache: false,
        async: false,
        success: function () {
            
            history.back(alert("Registro Editado com sucesso"));
        },
        error: function (res) {
            alert("Erro ao Editar")
        }
    });

});

$('#btnCriar').click(function () {
    var DataNascimento = $('#DataNascimento').val();
    
    var url = "http://localhost:59011/Clientes/Create";

    var strData = DataNascimento;
    var partesData = strData.split('/');
    var data = new Date(partesData[2], partesData[1] - 1, partesData[0]);
    if (data >= new Date()) {
        alert("Data de nascimento deve ser menor que a Data de Hoje");
        return;
    }
    if (data == undefined) {
        alert("Preencha corretamente o campo Data de nascimento");
        return;
    }


    var dados = $('form').serialize();

    var result = {};
    $.each($('form').serializeArray(), function () {
        if (!isNaN(this.value)) { 
            result[this.name] = Number(this.value);
        } else {
            result[this.name] = this.value;
        }
        if (this.name == "Ativo") {
            result[this.name] = $('#Ativo').val();
        }
    });
    

    $.ajax({
        type: 'POST',
        url: url,
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        data: result,
        cache: false,
        async: false,
        success: function () {
            
            history.back(alert("Registro Criado com sucesso"));
        },
        error: function (res) {
            alert("Erro ao Editar")
        }
    });

});



