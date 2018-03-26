$(document).ready(function() {
    $('.modal').modal();

    $('#save').click(() => {
        ajaxSave('trainingApparat', getData(), (e) => {
            addElement(e.Id, e.Name);
            close();
        })
    });
    $('#close').click(() => { close() });

    $('#delete').click(() => { remove() });
    $('#closeDelete').click(() => { close() });
    init();
});

let init = () => {
    ajaxGet('trainingApparat', (data) => {
        if (data.length == 0) return;
        data.forEach(element => {
            addElement(element.Id, element.Name, element.IsCardio);
        });
    })
};

let getData = () => new TrainingApparat($('#apparatName').val());

let addElement = (id, elem, isCardio) => {
    var iStyle = "style=\"margin: -4px 0 0 0;\"";
    var btnStyle = "style=\"height: 25px !important;\"";
    var newElem = $(`<a href="#!" class="collection-item">${elem}</a>`);

    var newSpan = $(`<span class="badge"><button ${btnStyle} data-target="deleteTrainingApparatModal" class="btn modal-trigger"><i ${iStyle} id="${id}" class="material-icons">clear</i></button></span>`);
    newSpan.click((e) => { apparatToDeleteId = e.target.id; });
    newElem.append(newSpan);
    $('.collection').append(newElem);
}

let apparatToDeleteId = 0;
let remove = () => {
    $.ajax({
        type: 'DELETE',
        url: `/api/trainingApparat/delete/${apparatToDeleteId}`,
        success: (e) => {
            $('.collection').empty();
            close();
            init();

        }
    });
};

let close = () => {
    $('#createTrainingApparatModal').modal('close');
    $('#deleteTrainingApparatModal').modal('close');
    clean();
};

let clean = () => {
    $('#first_name').val('');
};