// Copyright (c) LumexUI 2024
// LumexUI licenses this file to you under the MIT license
// See the license here https://github.com/LumexUI/lumexui/blob/main/LICENSE

import { elementReference } from './elementReference.js'

export const Lumex = {
    elementReference
};

window['Lumex'] = Lumex

Blazor.registerCustomEventType('animationend', {
    browserEventName: 'animationend',
    createEventArgs: event => {
        return {
            AnimationName: event.animationName,
            ElapsedTime: event.elapsedTime,
            PseudoElement: event.pseudoElement
        };
    }
})