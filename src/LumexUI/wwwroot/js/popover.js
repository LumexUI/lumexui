// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

import {
    computePosition,
    flip,
    shift,
    offset
} from '@floating-ui/dom';

import {
    waitForElement,
    createOutsideClickHandler
} from './utils/dom.js';

import { moveElementTo } from './elementReference.js';

let destroyOutsideClickHandler;

function initialize(id, options) {
    const { placement, offset: offsetVal } = options;

    waitForElement(`#popover-${id}`)
        .then(floating => {
            destroyOutsideClickHandler = createOutsideClickHandler(floating);

            const ref = document.getElementById(`popoverref-${id}`);
            console.log(options);
            moveElementTo(floating, 'body');
            computePosition(ref, floating, {
                placement: placement,
                middleware: [flip(), shift(), offset(offsetVal)],
            }).then(({ x, y }) => {
                Object.assign(floating.style, {
                    left: `${x}px`,
                    top: `${y}px`,
                });
            });
        })
        .catch(error => {
            console.error('Error in popover.show:', error);
        });
}

function destroy() {
    destroyOutsideClickHandler();
}

export const popover = {
    initialize,
    destroy
}