/* globals Chart:false, feather:false */

(function () {
  'use strict'

  feather.replace()

  // Graphs
  var ctx = document.getElementById('myChart')
  // eslint-disable-next-line no-unused-vars
  var myChart = new Chart(ctx, {
    type: 'line',
    data: {
      labels: [
        'Julho',
        'Agosto',
        'Setembro',
        'Outubro',
        'Novembro',
        'Dezembro',
        'Janeiro'
      ],
      datasets: [{
        data: [
          150,
          180,
          200,
          250,
          150,
          100,
          80
        ],
        lineTension: 0,
        backgroundColor: 'transparent',
          borderColor: 'rgb(232, 81, 158)',
        borderWidth: 4,
          pointBackgroundColor: 'rgb(232, 81, 158)'
      }]
    },
    options: {
      scales: {
        yAxes: [{
          ticks: {
            beginAtZero: false
          }
        }]
      },
      legend: {
        display: false
      }
    }
  })
}())