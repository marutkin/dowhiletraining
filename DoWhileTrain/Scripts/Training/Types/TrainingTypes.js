$(document).ready(function() {
    $('.modal').modal();

    $('#save').click(() => {
        ajaxSave('trainingtype', getData(), (e) => {
            addElement(e.Id, e.Name);
            close();
        })
    });
    $('#close').click(() => { close() });

    $('#delete').click(() => { remove() });
    $('#closeDelete').click(() => { close() });

    $.when(ajaxGet('trainingApparat')).done((a) => {
        $.each(a, function(key, value) {
            $('#apparat').append(`<option value="${value.Id}">${value.Name}</option>`);
        });
        $('select').formSelect();
    });

    init();
});

let init = () => {
    ajaxGet('trainingtype', (data) => {
        if (data.length == 0) return;
        data.forEach(element => {
            addElement(element.Id, element.Name, element.IsCardio, element.Apparat.Name);
        });
    })
};

let getData = () => new TrainingType($('#first_name').val(), $('#isCardio')[0].checked, $('#apparat').val());

let addElement = (id, elem, isCardio, apparat) => {
    var iStyle = "style=\"margin: -4px 0 0 0;\"";
    var btnStyle = "style=\"height: 25px !important;\""
    var newElem = $(`<a href="#!" class="collection-item">${elem} - ${apparat}</a>`);
    var type = '<span class="badge">Силовая</span>';
    if (isCardio) type = '<span class="badge">Кардио</span>';
    var newSpan = $(`<span class="badge"><button ${btnStyle} data-target="deleteTrainingTypeModal" class="btn modal-trigger"><i ${iStyle} id="${id}" class="material-icons">clear</i></button></span>${type}`);
    newSpan.click((e) => { trainingToDeleteId = e.target.id; });
    newElem.append(newSpan);
    $('.collection').append(newElem);
}

let trainingToDeleteId = 0;
let remove = () => {
    $.ajax({
        type: 'DELETE',
        url: `/api/trainingtype/delete/${trainingToDeleteId}`,
        success: (e) => {
            $('.collection').empty();
            close();
            init();
        }
    });
};

let close = () => {
    $('#createTrainingTypeModal').modal('close');
    $('#deleteTrainingTypeModal').modal('close');
    clean();
};

let clean = () => {
    $('#first_name').val('');
};