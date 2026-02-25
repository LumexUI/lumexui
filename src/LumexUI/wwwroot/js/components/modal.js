// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

const instances = new Map();

function initialize(element, dotNetRef) {
    const clickHandler = (event) => {
        const rect = element.getBoundingClientRect();
        const isInDialog =
            rect.top <= event.clientY &&
            event.clientY <= rect.top + rect.height &&
            rect.left <= event.clientX &&
            event.clientX <= rect.left + rect.width;

        if (!isInDialog) {
            element.close();
        }
    };

    const closeHandler = () => {
        dotNetRef.invokeMethodAsync("OnClose");
    };

    element.addEventListener("click", clickHandler);
    element.addEventListener("close", closeHandler);

    instances.set(element, { clickHandler, closeHandler });
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
