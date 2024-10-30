import defaultTheme from 'tailwindcss/defaultTheme';

const defaultTransitionFunction = defaultTheme.transitionTimingFunction.DEFAULT;

export const DEFAULT_TRANSITION_DURATION = '250ms';

export default {
    '.transition-colors-opacity': {
        'transition-property':
            'color, background-color, border-color, text-decoration-color, fill, stroke, opacity',
        'transition-timing-function': defaultTransitionFunction,
        'transition-duration': DEFAULT_TRANSITION_DURATION,
    },
    '.transition-transform-colors': {
        'transition-property':
            'transform, color, background, background-color, border-color, text-decoration-color, fill, stroke',
        'transition-timing-function': defaultTransitionFunction,
        'transition-duration': DEFAULT_TRANSITION_DURATION,
    },
    '.transition-transform-colors-opacity': {
        'transition-property':
            'transform, color, background, background-color, border-color, text-decoration-color, fill, stroke, opacity',
        'transition-timing-function': defaultTransitionFunction,
        'transition-duration': DEFAULT_TRANSITION_DURATION,
    },
};