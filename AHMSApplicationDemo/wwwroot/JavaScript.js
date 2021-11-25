var chart = document.getElementById("BarChart").getContext('2d');
var myChart = new chart(chart, {
    type: 'bar',
    data: {
        labels: ['001', '002', '003'],
        datasets: [{
            label: 'Bar Chart',
            data: [100, 200, 300],
            background: 'rgba(6,128,250)'

        }]
    },
    options: {
        scales: {
            yAxes: [{
                ticks: {
                    beginAtzero: true
                }
            }]
        }
    }
})
