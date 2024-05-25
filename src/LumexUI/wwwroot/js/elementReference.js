// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

function getScrollHeight(element) {
    if (!element) {
        throw "No element found!";
    }

    return element.scrollHeight;
}

export const elementReference = {
    getScrollHeight
}