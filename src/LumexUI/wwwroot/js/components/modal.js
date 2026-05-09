// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

const instances = new Map();

function initialize(element, dotNetRef) {
    // Only dismiss when both the pointerdown AND the click target the dialog
    // itself (the ::backdrop pseudo-element bubbles to event.target === dialog).
    // Coordinate-based checks misfire when a click bubbles up from inside the
    // dialog with clientX/Y reported outside the dialog's bounding box — e.g.
    // releasing a text-selection drag over the backdrop, or a native <select>
    // dispatching a click whose coordinates sit outside the rect.
    let pointerdownOnBackdrop = false;

    const pointerdownHandler = (event) => {
        pointerdownOnBackdrop = event.target === element;
    };

    const clickHandler = (event) => {
        if (event.target === element && pointerdownOnBackdrop) {
            element.close();
        }

        pointerdownOnBackdrop = false;
    };

    const closeHandler = () => {
        dotNetRef.invokeMethodAsync("OnClose");
    };

    element.addEventListener("pointerdown", pointerdownHandler);
    element.addEventListener("click", clickHandler);
    element.addEventListener("close", closeHandler);

    instances.set(element, { pointerdownHandler, clickHandler, closeHandler });
}

function open(element) {
    if (element && !element.open) {
        element.showModal();
    }
}

function close(element) {
    if (element && element.open) {
        element.close();
    }
}

function destroy(element) {
    const instance = instances.get(element);

    if (instance) {
        element.removeEventListener("pointerdown", instance.pointerdownHandler);
        element.removeEventListener("click", instance.clickHandler);
        element.removeEventListener("close", instance.closeHandler);
        instances.delete(element);
    }
}

export const modal = {
    initialize,
    open,
    close,
    destroy
}
