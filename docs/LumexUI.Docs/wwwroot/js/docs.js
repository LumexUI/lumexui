function interceptNavigation() {
    let currentUrl = window.location.pathname;

    Blazor.addEventListener('enhancedload', () => {
        let newUrl = window.location.pathname;
        if (currentUrl != newUrl) {
            window.scrollTo({ top: 0, left: 0, behavior: 'instant' });
        }

        currentUrl = newUrl;

        let currentTheme = localStorage.getItem('lumexui.theme');
        if (currentTheme) {
            document.documentElement.classList.remove('light', 'dark');
            document.documentElement.classList.add(currentTheme);
        }
    });
};

async function copyToClipboard(elementId) {
    const element = document.getElementById(elementId);
    if (!element) {
        throw Error(`Copy trigger with id '${elementId}' not found.`);
    }

    const text = element.textContent || element.innerText;

    try {
        await navigator.clipboard.writeText(text)
        console.log('Text copied to clipboard');
    } catch (err) {
        console.error('Error copying text:', err);
    }
}

document.addEventListener('DOMContentLoaded', () => {
    interceptNavigation();
});

window.copyToClipboard = copyToClipboard;
window.charts = window.charts || {};

window.charts['activity'] = {
    initialize() {
        const options = {
            chart: {
                type: 'bar',
                height: '100%',
                toolbar: { show: false },
                zoom: { enabled: false },
            },
            colors: ['var(--chart)'],
            series: [
                { data: [400, 300, 200, 300, 200, 278, 189, 239, 300, 200, 278, 189, 349] }
            ],
            xaxis: {
                labels: { show: false },
                axisBorder: { show: false },
                axisTicks: { show: false }
            },
            yaxis: { show: false },
            tooltip: { enabled: false },
            grid: {
                show: false,
                padding: {
                    top: -20,
                    right: -10,
                    bottom: -10,
                    left: -10
                }
            },
            dataLabels: { enabled: false },
            plotOptions: {
                bar: { borderRadius: 4 }
            }
        }

        new ApexCharts(document.getElementById('chart-activity'), options).render();
    },
}

window.charts['stats'] = {
    initialize() {
        const options = {
            chart: {
                type: 'area',
                height: '100%',
                toolbar: { show: false },
                zoom: { enabled: false },
            },
            colors: ['var(--chart)'],
            series: [
                { data: [40, 90, 200, 278, 89, 239, 78, 89] }
            ],
            xaxis: {
                labels: { show: false },
                axisBorder: { show: false },
                axisTicks: { show: false }
            },
            yaxis: { show: false },
            tooltip: { enabled: false },
            grid: {
                show: false,
                padding: {
                    top: -80,
                    left: -10,
                    right: -10,
                    bottom: -15
                }
            },
            dataLabels: { enabled: false },
            stroke: { width: 2 },
            fill: {
                colors: ['var(--chart-fill)'],
                type: 'solid',
            }
        }

        new ApexCharts(document.getElementById('chart-stats'), options).render();
    },
}

window.charts['usage'] = {
    initialize() {
        const options = {
            chart: {
                type: 'donut',
                height: '100%',
            },
            colors: ['var(--chart-1)', 'var(--chart-2)', 'var(--chart-3)', 'var(--chart-4)'],
            labels: ['Mobile', 'Desktop', 'Tablet', 'Smart TV'],
            series: [550, 300, 250, 100],
            tooltip: { enabled: false },
            dataLabels: { enabled: false },
            legend: {
                labels: {
                    colors: 'var(--lumex-foreground)',
                },
                markers: {
                    size: 5,
                    offsetX: -5,
                },
                itemMargin: {
                    vertical: 3
                },
                onItemHover: {
                    highlightDataSeries: false
                },
                onItemClick: {
                    toggleDataSeries: false
                },
            }
        }

        new ApexCharts(document.getElementById('chart-usage'), options).render();
    },
}