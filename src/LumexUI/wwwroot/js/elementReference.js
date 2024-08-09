// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

function getScrollHeight(element) {
    if (!element) {
        throw new Error("No element was found!");
    }

    return element.scrollHeight;
}

function moveElementTo(element, destinationId) {
    if (!element) {
        throw new Error("No element was found!");
    }

    let destination = document.getElementById(destinationId);
    if (!destination) {
        throw new Error(`No portal container with the given ID '${destinationId}' was found!`);
    }

    destination.appendChild(element);
}

export const elementReference = {
    getScrollHeight,
    moveElementTo
}