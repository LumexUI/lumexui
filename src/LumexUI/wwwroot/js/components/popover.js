// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

import {
    computePosition,
    flip,
    shift,
    offset,
    arrow,
    size,
    autoUpdate
} from '@floating-ui/dom';

import {
    portal,
    waitForElement
} from '../utils/dom.js';

let cleanupAutoUpdate;

async function initialize(id, options) {
    try {
        const popover = await waitForElement(`[data-popover=${id}]`);
        const overlay = document.querySelector(`[data-popover-overlay=${id}]`);
        const target = document.querySelector(`[data-popovertarget=${id}]`);
        const arrowElement = popover.querySelector('[data-slot=arrow]');
        const ref = target.children.length === 1 ? target.firstElementChild : target;

        portal(popover);

        if (overlay) {
            portal(overlay);
        }

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

        const update = async () => {
            const data = await computePosition(ref, popover, {
                placement,
                middleware: middlewares,
            });

            positionPopover(popover, data);

            if (showArrow) {
                positionArrow(arrowElement, data);
            }
        };

        await update();

        cleanupAutoUpdate = autoUpdate(ref, popover, update);
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
    if (cleanupAutoUpdate) {
        cleanupAutoUpdate();
        cleanupAutoUpdate = null;
    }
}

export const popover = {
    initialize,
    destroy
}