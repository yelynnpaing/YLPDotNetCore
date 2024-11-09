function uuidv4() {
  return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, (c) =>
    (
      +c ^
      (crypto.getRandomValues(new Uint8Array(1))[0] & (15 >> (+c / 4)))
    ).toString(16)
  );
}

function success(message) {
  // Swal.fire({
  //     title: "Success!",
  //     text: message,
  //     icon: "success"
  // });

  Notiflix.Report.success("Success!", message, "Ok");
}

function error(message) {
  // Swal.fire({
  //     title: "Error!",
  //     text: message,
  //     icon: "error"
  // });

  Notiflix.Report.failure("Error!", message, "Ok");

}

function successMessage(message) {
  alert(message);
}

function errorMessage(message) {
  alert(message);
}

function confirmMessage(message) {
    let promise = new Promise(function (successFun, errorFun) {
    // Swal.fire({
    //   title: "Confirm",
    //   text: message,
    //   icon: "warning",
    //   showCancelButton: true,
    //   confirmButtonColor: "#3085d6",
    //   cancelButtonColor: "#d33",
    //   confirmButtonText: "Delete",
    // }).then((result) => {
    //   if (result.isConfirmed) {
    //     successFun();
    //   }
    //   errorFun();
    // });

        Notiflix.Confirm.show(
            'Confirm',
            message,
            'Yes','No',
            function okCb() {
                successFun();
            },
            function cancelCb() {
                errorFun();
            }, 
        );
    });

  return promise;
}
