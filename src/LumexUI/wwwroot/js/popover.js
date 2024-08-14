// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

import {
    computePosition,
    flip,
    shift,
    offset
} from '@floating-ui/dom';
import { waitForElement } from './utils/dom.js';
import { moveElementTo } from './elementReference.js';

function show(id) {
    waitForElement(`#popover-${id}`)
        .then(floating => {
            const ref = document.getElementById(`popovertarget-${id}`);

            moveElementTo(floating, 'body');
            computePosition(ref, floating, {
                middleware: [flip(), shift(), offset(8)],
            }).then(({ x, y }) => {
                Object.assign(floating.style, {
                    left: `${x}px`,
                    top: `${y}px`,
                });
            });
        })
        .catch(error => {
            console.error(error.message);
        });
}

export const popover = {
    show
}