// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

// TODO: improve
export function moveElementTo(element, selector) {
    if (!element) {
        throw new Error("No element was found!");
    }

    let destination = document.querySelector(selector);
    if (!destination) {
        throw new Error(`No portal container with the given selector '${selector}' was found!`);
    }

    destination.appendChild(element);
}

function getScrollHeight(element) {
    if (!element) {
        throw new Error("No element was found!");
    }

    return element.scrollHeight;
}

export const elementReference = {
    getScrollHeight,
    moveElementTo
}