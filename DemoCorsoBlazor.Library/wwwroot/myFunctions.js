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

var map;
export function showMap(latitude, longitude, zoom) {
    if (!map) {
        map = L.map('map').setView([latitude, longitude], zoom);
    }
    L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', {
        maxZoom: 19,
        attribution: '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>'
    }).addTo(map);
   
    DotNet.invokeMethodAsync("DemoCorsoBlazor.Library", "GetMarkers")
        .then(markers => {
            for (var i = 0; i < markers.length; i++) {
                var marker = markers[i];
                L.marker([marker.latitudine, marker.longitudine]).addTo(map)
                    .bindPopup(marker.description);
            }

        });
}

export function showPosizione() {
    navigator.geolocation.getCurrentPosition(function (position) {
        var latitude = position.coords.latitude;
        var longitude = position.coords.longitude;
        var zoom = 16;
        map.setView([latitude, longitude], zoom);
        L.marker([latitude, longitude]).addTo(map)
            .bindPopup('You are here!')
            .openPopup();
    }, function (error) {
        navigator.permissions.revoke({ name: 'geolocatoin' }).then(res => {
            alert(resolve.state)
        })
        //alert(error.message);
        
    });
}
