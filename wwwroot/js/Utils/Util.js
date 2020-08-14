var Util = {};

Util.MensajeCargando = () => {
    Swal.fire({
        text: '',
        title: 'Espera un momento',
        imageUrl: '../../img/bar.svg',
        imageWidth: 400,
        imageHeight: 200,
        imageAlt: 'Cargando',
        allowOutsideClick: false,
        allowEscapeKey: false,
        allowEnterKey: false,
        showConfirmButton: false
    });
}

Util.MensajeError = (mensaje) => {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: mensaje
    })
}