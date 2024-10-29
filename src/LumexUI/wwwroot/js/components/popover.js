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
    portalTo,
    waitForElement,
    createOutsideClickHandler
} from '../utils/dom.js';

let destroyOutsideClickHandler;

async function initialize(id, options) {
    try {
        const popover = await waitForElement(`[data-popover=${id}]`);
        const ref = document.querySelector(`[data-popoverref=${id}]`);
        const arrowElement = popover.querySelector('[data-slot=arrow]');

        portalTo(popover);
        destroyOutsideClickHandler = createOutsideClickHandler(popover);

        const {
            placement,
            showArrow,
            offset: offsetVal
        } = options;

        const middlewares = [
            flip(),
            shift(),
            offset(offsetVal),
        ];

        if (showArrow) {
            middlewares.push(arrow({ element: arrowElement }));
        }

        const data = await computePosition(ref, popover, {
            placement: placement,
            middleware: middlewares
        });

        positionPopover(popover, data);

        if (showArrow) {
            positionArrow(arrowElement, placement, data);
        }
    } catch (error) {
        console.error('Error in popover.show:', error);
    }

    function positionPopover(target, data) {
        Object.assign(target.style, {
            left: `${data.x}px`,
            top: `${data.y}px`,
        });
    }

    function positionArrow(target, placement, data) {
        const { x: arrowX, y: arrowY } = data.middlewareData.arrow;
        const staticSide = {
            top: 'bottom',
            right: 'left',
            bottom: 'top',
            left: 'right',
        }[placement.split('-')[0]];

        Object.assign(target.style, {
            left: arrowX != null ? `${arrowX}px` : '',
            top: arrowY != null ? `${arrowY}px` : '',
            [staticSide]: '-4px',
        });
    }
}

function destroy() {
    if (destroyOutsideClickHandler) {
        destroyOutsideClickHandler();
        destroyOutsideClickHandler = null;
    }
}

export const popover = {
    initialize,
    destroy
}