$(() => {

    $("input").on('keyup', function () {
        ensureValidity();

    })
    $("#car-type").on('change', function () {
        ensureValidity();
        const carType = $("#car-type").val();
        $("#has-leather-seats").prop('checked', carType === "2");
        $("#has-leather-seats").prop('disabled', carType === "2");
        if (carType === "2") {
            $("#form").append("<input type='hidden' name='hasleatherseats' id='hidden' value='true' />")
        }
        else {
            $("#hidden").remove();
        }
    })
    function IsValid() {

        const make = $("#make").val();
        const model = $("#model").val();
        const year = $("#year").val();
        const price = $("#price").val();
        const carType = $("#car-type").val();
        if (carType < 0) {
            return false;
        }
        return make && model && year && price && carType;
    }
    function ensureValidity() {
        $("#save-btn").prop('disabled', !IsValid());
    }
});