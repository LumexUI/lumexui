// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

function getValidationMessage(element) {
    if (!(element instanceof HTMLElement)) {
        throw new Error('The provided element is not a valid HTMLElement.');
    }

    if (element instanceof HTMLInputElement ||
        element instanceof HTMLTextAreaElement ||
        element instanceof HTMLSelectElement) {
        return element.validationMessage;
    } else {
        throw new Error('The provided element does not support validation.');
    }
}

export const input = {
    getValidationMessage
}