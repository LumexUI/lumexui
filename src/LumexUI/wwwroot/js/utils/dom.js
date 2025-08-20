// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

export function waitForElement(selector) {
    return new Promise(resolve => {
        if (document.querySelector(selector)) {
            return resolve(document.querySelector(selector));
        }

        const observer = new MutationObserver(() => {
            if (document.querySelector(selector)) {
                observer.disconnect();
                resolve(document.querySelector(selector));
            }
        });

        observer.observe(document.body, {
            childList: true,
            subtree: true
        });
    });
}

export function portal(element, selector = undefined) {
    if (!(element instanceof HTMLElement)) {
        throw new Error('The provided element is not a valid HTMLElement.');
    }

    let destination = selector
        ? document.querySelector(selector)
        : document.body;

    if (!destination) {
        throw new Error(`No portal container with the given selector '${selector}' was found!`);
    }

    if (element.parentElement !== destination) {
        destination.appendChild(element);
    }
}

export function createOutsideClickHandler(elements) {
    const clickHandler = event => {
        const isInsideAny = elements.some(el => el && el.contains(event.target));

        if (!isInsideAny) {
            elements.forEach(el =>
                el?.dispatchEvent(new CustomEvent('clickoutside', { bubbles: true }))
            );
        }
    };

    document.body.addEventListener('click', clickHandler);

    return () => {
        document.body.removeEventListener('click', clickHandler)
    };
}

export function isImageLoaded(img) {
    if (!(img instanceof HTMLElement)) {
        return false;
    }

    return img.complete && img.naturalWidth !== 0;
}