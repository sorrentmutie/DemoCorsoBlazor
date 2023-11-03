export function createChart() {
    var data = {
        // A labels array that can contain any sort of values
        labels: ['Mon', 'Tue', 'Wed', 'Thu', 'Fri'],
        // Our series array that contains series objects or in this case series data arrays
        series: [
            [5, 2, 4, 2, 0]
        ]
    };
    new Chartist.Line('.ct-chart', data);
}

export function createChart2(element) {
    console.log(element);
    var data = {
        // A labels array that can contain any sort of values
        labels: ['Mon', 'Tue', 'Wed', 'Thu', 'Fri'],
        // Our series array that contains series objects or in this case series data arrays
        series: [
            [5, 2, 4, 2, 0]
        ]
    };
    new Chartist.Line(element, data);
}

export function createChart3(element, data, type) {
    if (type === 'Line') {
        element.chart = new Chartist.Line(element, data);
    } else {
        element.chart = new Chartist.Bar(element, data);
    }
}

export function updateChart(element, data) {
    element.chart.update(data);
}