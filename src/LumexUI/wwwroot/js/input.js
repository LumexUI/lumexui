// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

function getValidationMessage(element) {
    if (!element) {
        throw new Error("No element was found!");
    }

    if (element instanceof HTMLInputElement ||
        element instanceof HTMLTextAreaElement ||
        element instanceof HTMLSelectElement) {
        return element.validationMessage;
    } else {
        throw new Error("The provided element does not support validation.");
    }
}

export const input = {
    getValidationMessage
}