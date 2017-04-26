function ladeAntworten(i) {
    var p1 = "#Antworten" + i;
    var p2 = "#Fragen" + i + " option:selected";
    $(p1).empty();
    var frageId = $(p2).val();

    if (frageId != "" && frageId != "0") {
        var sourceString = "/Frage/AjaxLadeAntwortenZuFrage?frageId=" + frageId;
        $.ajax({
            type: 'POST',
            url: sourceString,
            cache: false,
            data: $('#CatererForm').serialize(),
            dataType: 'json',
            success: function (json) {
                ajaxGeraete = json;
                $(p1).append($('<option>').text("Bitte wählen...").attr('value', "0"));
                $.each(json, function (index) {
                    $(p1).append($('<option>').text(json[index].Antworttext).attr('value', json[index].AntwortId)
                );
                    $(p1).prop("disabled", false);
                });
            },
        });
    }
}


function ladeAntwortenInitial(i, FrageId, AntwortIds) {
    var p1 = "#Antworten" + i;
    var p2 = "#Fragen" + i;

    $(p1).empty();
    if (FrageId != "0") {
        $(p1).removeAttr("disabled");
        var sourceString = "/Frage/AjaxLadeAntwortenZuFrage?frageId=" + FrageId;
        $.ajax({
            type: 'POST',
            url: sourceString,
            cache: false,
            data: $('#CatererForm').serialize(),
            dataType: 'json',
            success: function (json) {
                ajaxGeraete = json;
                $(p1).append($('<option>').text("Bitte wählen...").attr('value', "0"));
                $.each(json, function (index) {
                    $(p1).append($('<option>').text(json[index].Antworttext).attr('value', json[index].AntwortId)
                );
                    $(p1).prop("disabled", false);
                });
            },
        }).done(function () { $(p1).val(AntwortIds) });;
    } else {
        $(p2).val(0);
        $(p1).attr("disabled", "disabled");
    }


};

function pruefeCheckboxen() {
    var counter = 0;
    for (var i = 0 ; i < 10; i++) {
        var p1 = "#Checkbox" + i;
        if ($(p1).prop('checked')) {
            counter++;
        }
    }

    if (counter >= 3) {
        for (var i = 0 ; i < 10; i++) {
            var p1 = "#Checkbox" + i;
            if (!($(p1).prop('checked'))) {
                $(p1).attr("disabled", "disabled");
            }
        }
    } else {
        for (var i = 0 ; i < 10; i++) {
            var p1 = "#Checkbox" + i;
            if (!($(p1).prop('checked'))) {
                $(p1).removeAttr("disabled");
            }
        }

    }

}
