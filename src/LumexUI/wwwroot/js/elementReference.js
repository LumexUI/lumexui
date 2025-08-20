// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

import { portal } from './utils/dom.js';

function getScrollHeight(element) {
    if (!(element instanceof HTMLElement)) {
        throw new Error('The provided element is not a valid HTMLElement.');
    }

    return element.scrollHeight;
}

export const elementReference = {
    getScrollHeight,
    portal
}