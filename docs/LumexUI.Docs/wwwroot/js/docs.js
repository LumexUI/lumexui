function interceptNavigation() {
    let currentUrl = window.location.href;

    Blazor.addEventListener('enhancedload', () => {
        let newUrl = window.location.href;
        if (currentUrl != newUrl) {
            window.scrollTo({ top: 0, left: 0, behavior: 'instant' });
        }

        currentUrl = newUrl;
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