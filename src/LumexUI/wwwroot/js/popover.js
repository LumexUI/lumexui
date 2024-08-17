// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

import {
    computePosition,
    flip,
    shift,
    offset,
    arrow
} from '@floating-ui/dom';

import {
    waitForElement,
    createOutsideClickHandler
} from './utils/dom.js';

import { moveElementTo } from './elementReference.js';

let destroyOutsideClickHandler;

function initialize(id, options) {
    const {
        placement,
        showArrow,
        offset: offsetVal
    } = options;

    waitForElement(`[data-popover=${id}]`)
        .then(popover => {
            destroyOutsideClickHandler = createOutsideClickHandler(popover);

            const ref = document.querySelector(`[data-popoverref=${id}]`);
            const arrowElement = popover.querySelector('[data-slot=arrow]');

            console.log(options);

            moveElementTo(popover, 'body');

            computePosition(ref, popover, {
                placement: placement,
                middleware: [
                    flip(),
                    shift(),
                    offset(offsetVal),
                    showArrow && arrow({ element: arrowElement })
                ],
            }).then(({ x, y, placement, middlewareData }) => {
                Object.assign(popover.style, {
                    left: `${x}px`,
                    top: `${y}px`,
                });

                const { x: arrowX, y: arrowY } = middlewareData.arrow;
                const staticSide = {
                    top: 'bottom',
                    right: 'left',
                    bottom: 'top',
                    left: 'right',
                }[placement.split('-')[0]];

                Object.assign(arrowElement.style, {
                    left: arrowX != null ? `${arrowX}px` : '',
                    top: arrowY != null ? `${arrowY}px` : '',
                    [staticSide]: '-4px',
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