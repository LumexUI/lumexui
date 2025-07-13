// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

import {
    computePosition,
    flip,
    shift,
    offset,
    arrow,
    size
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
        destroyOutsideClickHandler = createOutsideClickHandler([ref, popover]);

        const {
            offset: offsetVal,
            placement,
            showArrow,
            matchRefWidth,
        } = options;

        const middlewares = [
            offset(offsetVal),
            flip(),
            shift(),
        ];

        if (showArrow) {
            middlewares.push(arrow({ element: arrowElement }));
        }

        if (matchRefWidth) {
            middlewares.push(
                size({
                    apply({ rects, elements }) {
                        Object.assign(elements.floating.style, {
                            width: `${rects.reference.width}px`,
                        });
                    }
                })
            );
        }

        const data = await computePosition(ref, popover, {
            placement: placement,
            middleware: middlewares,
        });

        positionPopover(popover, data);

        if (showArrow) {
            positionArrow(arrowElement, data);
        }
    } catch (error) {
        console.error('Error in popover.initialize:', error);
    }

    function positionPopover(popover, data) {
        Object.assign(popover.style, {
            left: `${data.x}px`,
            top: `${data.y}px`,
        });
    }

    function positionArrow(arrow, data) {
        const { placement, middlewareData } = data;
        const { x: arrowX, y: arrowY } = middlewareData.arrow;

        const staticSide = {
            top: 'bottom',
            right: 'left',
            bottom: 'top',
            left: 'right',
        }[placement.split('-')[0]];

        Object.assign(arrow.style, {
            left: arrowX != null ? `${arrowX}px` : '',
            top: arrowY != null ? `${arrowY}px` : '',
            right: '',
            bottom: '',
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