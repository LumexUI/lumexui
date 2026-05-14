// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

const instances = new Map();

function readMetrics(element) {
    const style = window.getComputedStyle(element);
    const lineHeight = parseFloat(style.lineHeight) || parseFloat(style.fontSize) * 1.2;
    const paddingY = parseFloat(style.paddingTop) + parseFloat(style.paddingBottom);
    const borderY = parseFloat(style.borderTopWidth) + parseFloat(style.borderBottomWidth);
    const isBorderBox = style.boxSizing === "border-box";

    return { lineHeight, paddingY, borderY, isBorderBox };
}

function adjust(element, options) {
    const { minRows, maxRows } = options;
    const { lineHeight, paddingY, borderY, isBorderBox } = readMetrics(element);

    const extra = isBorderBox ? paddingY + borderY : 0;
    const minHeight = lineHeight * minRows + extra;
    const maxHeight = lineHeight * maxRows + extra;

    // Reset to auto so scrollHeight reflects content, not the previous fitted height.
    element.style.height = "auto";

    const contentHeight = isBorderBox
        ? element.scrollHeight + borderY
        : element.scrollHeight - paddingY;

    const next = Math.min(Math.max(contentHeight, minHeight), maxHeight);
    element.style.height = `${next}px`;
    element.style.overflow = next < maxHeight ? "hidden" : "";
}

function initialize(element, options) {
    // When autosize is disabled the user owns sizing — let the native resize handle
    // and the `rows` attribute drive height. Attaching an input listener would just
    // clobber any manual resize the user makes on the next keystroke.
    if (options.disableAutosize) {
        instances.set(element, { options });
        return;
    }

    const inputHandler = () => adjust(element, instances.get(element).options);

    instances.set(element, { options, inputHandler });
    element.addEventListener("input", inputHandler);

    // Initial fit so the element renders at the correct height before any user input.
    adjust(element, options);
}

function update(element, options) {
    const instance = instances.get(element);
    if (!instance) {
        return;
    }

    instance.options = options;

    if (!options.disableAutosize) {
        adjust(element, options);
    }
}

function destroy(element) {
    const instance = instances.get(element);
    if (!instance) {
        return;
    }

    if (instance.inputHandler) {
        element.removeEventListener("input", instance.inputHandler);
    }
    instances.delete(element);
}

export const textarea = {
    initialize,
    update,
    destroy,
}
