// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

export function waitForElement(selector, timeout = 1000) {
    return new Promise((resolve, reject) => {
        const startTime = Date.now();

        const checkExistence = () => {
            const element = document.querySelector(selector);
            if (element) {
                resolve(element);
            } else if (Date.now() - startTime >= timeout) {
                reject(new Error(`Element with selector '${selector}' not found within ${timeout}ms`));
            } else {
                requestAnimationFrame(checkExistence);
            }
        };

        checkExistence();
    });
}

export function createOutsideClickHandler(element, options) {
    const clickHandler = event => {
        if (element && !element.contains(event.target)) {
            element.dispatchEvent(new CustomEvent('clickoutside', { bubbles: true }));
        }
    };

    document.body.addEventListener('click', clickHandler, options);

    return () => {
        document.body.removeEventListener('click', clickHandler, options)
    };
}
