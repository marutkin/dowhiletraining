$(document).ready(function() {
    $('.materialSelect').on('contentChanged', function() {
        $(this).material_select();
    });
    $('#save').click(() => {
        ajaxSave('Training', (getData()), (e) => {
            //addElement(e.Id, e.Name);
            close();
        })
    });
    $('#close').click(() => { close() });

    $('#delete').click(() => { remove() });
    $('#closeDelete').click(() => { close() });
    $.when(ajaxGet('trainingType')).done((t) => {
        trainingTypeStore = t;
        $.each(t, function(key, value) {
            $('#type').append(`<option value="${value.Id}">${value.Name}</option>`);
        });
        $('#type').on('change', function() {
            var elem = $.grep(trainingTypeStore, (e) => {
                return e.Id == this.value;
            })[0];
            $('#apparat').val(elem.Apparat.Name);
        })
        $('select').formSelect();
    });
    init();
});
let trainingTypeStore = [];
let init = () => {
    // initialize
    $('.modal').modal();
    ajaxGet('Training', (data) => {
        if (data.length == 0) return;
        data.forEach(element => {
            addElement(element);
        });
    });
};
let elementTemplate = (name, apparat, count, date) => {
    return `<tr> <td>${name}</td> <td>${apparat}</td> <td>${count}</td> <td>${date}</td></tr>`
}
let addElement = (e) => {

    // var iStyle = "style=\"margin: -4px 0 0 0;\"";
    // var btnStyle = "style=\"height: 25px !important;\"";
    // var newElem = $(`<a href="#!" class="collection-item">${elem}</a>`);

    // var newSpan = $(`<span class="badge"><button ${btnStyle} data-target="deleteTrainingApparatModal" class="btn modal-trigger"><i ${iStyle} id="${id}" class="material-icons">clear</i></button></span>`);
    // newSpan.click((e) => { apparatToDeleteId = e.target.id; });
    // newElem.append(newSpan);
    $('.collection').append(elementTemplate(e.Type.Name, e.Type.Apparat.Name, e.WorkCount, e.WorkoutDate));
}
let getData = () => new Training($('#count').val(), $('#apparat').val(), $('#type').val());

let remove = () => {

};
let clean = () => {
    $('.collection').empty();
    init();
};
let close = () => {
    $('#createTrainingModal').modal('close');
    $('#deleteTrainingModal').modal('close');
    clean();
};