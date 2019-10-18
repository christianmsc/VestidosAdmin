/* globals Chart:false, feather:false */
var nomesPlanos;
var qtdPlanos;
var vlrTotalPlanos;
var cores;

(function () {
  'use strict'

  feather.replace()

  // Graphs
  var ctx = document.getElementById('myChart')
    var myChart = new Chart(ctx, {
        type: 'bar',
        data: {
            datasets: [{
                label: 'Valor Total por Plano (R$)',
                data: vlrTotalPlanos,
                backgroundColor: cores
            }],
            labels: nomesPlanos
        },
        options: {
            responsive: true,
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: true
                    }
                }]
            }
        }
    });

    var ctx2 = document.getElementById('myChart2')
    var myPieChart = new Chart(ctx2, {
        type: 'pie',
        data: {
            datasets: [{
                data: qtdPlanos,
                backgroundColor: cores
            }],
            labels: nomesPlanos
        },
        options: {
            responsive: true
        }
    });

}())