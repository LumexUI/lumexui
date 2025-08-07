// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

import { createOutsideClickHandler } from '../utils/dom.js';

function initialize(element) {
    const destroyOutsideClickHandler = createOutsideClickHandler([element]);

    return {
        destroy: () => destroyOutsideClickHandler()
    }
}

export const dataGrid = {
    initialize
}