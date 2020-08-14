var fun = {};

//GetDepCity
fun.GetDepCity = () => {
    if (!localStorage.getItem("DepCity")) {
        let cors = "https://cors-anywhere.herokuapp.com/";
        fetch(cors + 'https://sigma-studios.s3-us-west-2.amazonaws.com/test/colombia.json')
            .then(function (response) {
                return response.json();
            })
            .then(function (json) {
                console.log("Loaded");
                localStorage.setItem("DepCity", JSON.stringify(json));
                fun.FillDept();
            });
    } else {
        fun.FillDept();
    }


}//

fun.FillDept = () => {
    //set state
    let states = JSON.parse(localStorage.getItem("DepCity"));
    Object.keys(states).map((value) => {
        $('#State')
            .append($("<option></option>")
                .attr("value", value)
                .text(value));
    });
}
//
fun.SetCitys = (state) => {
    let citys = JSON.parse(localStorage.getItem("DepCity"))[`${state}`];
    $("#City").empty();
    $('#City').append(new Option("Seleccione", ""));
    citys.map((value) => {
        $('#City').append(new Option(value, value));
    });
}//

$(document).ready(function () {
    $("#FormDev").validate({
        lang: 'ES',
        rules: {
            State: {
                required: true,
                maxlength: 30
            },
            City: {
                required: true,
                maxlength: 50
            },
            Name: {
                required: true,
                maxlength: 50
            },
            Email: {
                required: true,
                email: true,
                maxlength: 30
            }

        }
    });

    fun.GetDepCity();

    $("#State").on('change', function () {
        fun.SetCitys(this.value);
    });

    $("#FormDev").submit(function (e) {

        e.preventDefault(); // avoid to execute the actual submit of the form.
        if ($("#FormDev").valid()) {
            var form = $(this);
            var url = form.attr('action');

            $.ajax({
                type: "POST",
                url: url,
                data: form.serialize(), // serializes the form's elements.
                success: function (d) {

                    $("#FormDev").trigger('reset');
                    if (d.codigo == "01") {
                        $("#MensajeModal").text(d.descripcion);
                    } else {
                        $("#MensajeModal").text(d.descripcion);
                    }
                    $("#ModalMensaje").modal().show();
                    Swal.close();

                },
                error: function (e) {

                    $("#FormDev").trigger('reset');
                    $("#MensajeModal").text("¡Oops Algo salió mal, recarga la página e intenta de nuevo!");
                    $("#ModalMensaje").modal().show();
                    Swal.close();
                },
                beforeSend: function () {
                    Util.MensajeCargando();
                }
            });

        }
    });

});