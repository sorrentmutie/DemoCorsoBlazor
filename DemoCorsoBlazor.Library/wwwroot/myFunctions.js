export function primaFunzione() {
    console.log("primaFunzione");
}

export function secondaFunzione(a, b) {
    console.log("secondaFunzione");
    return a + b;
}

export function terzaFunzione() {
    DotNet.invokeMethodAsync("DemoCorsoBlazor.Library", "RestituisciArray")
        .then(data => {
            console.log(data);
        });
}

export function quartaFunzione(helloHelper) {
  helloHelper.invokeMethodAsync("SayHello")
        .then(data => console.log(data));
}

var myModal;

export function showModal(id) {
    myModal = new bootstrap.Modal(document.getElementById(id));
    myModal.show();
}

export function hideModal() {
    if (myModal) {
        myModal.hide();
    }
}
