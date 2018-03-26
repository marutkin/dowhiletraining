class TrainingBase {
    constructor(name, ownerId) {
        this.name = name;
    }
}
class TrainingApparat extends TrainingBase {
    constructor(name) {
        super(name);
    }
}
class TrainingType extends TrainingBase {
    constructor(name, isCardio, apparatId) {
        super(name);
        this.isCardio = isCardio;
        this.apparatId = apparatId;
    }
}
class Training {
    constructor(workCount, apparatId, typeId) {
        this.workCount = workCount;
        this.apparatId = apparatId;
        this.typeId = typeId;
    }
}

let ajaxSave = (dataType, data_p, callback) => {
    var d = $.Deferred();
    $.ajax({
        contentType: 'application/json; charset=utf-8',
        type: 'POST',
        url: `/api/${dataType}/create`,
        data: JSON.stringify(data_p),
        success: (e) => {
            if (callback)
                callback(e);
            d.resolve(e);
        }
    });
    return d.promise();
};

let ajaxGet = (dataType, callback) => {
    var d = $.Deferred();
    $.ajax({
        contentType: 'application/json; charset=utf-8',
        type: 'GET',
        url: `/api/${dataType}/get`,
        success: (e) => {
            if (callback)
                callback(e, { totalCount: e.length });
            d.resolve(e);
        }
    });
    return d.promise();
};