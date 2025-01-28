import { animate as motionAnimate } from 'https://cdn.jsdelivr.net/npm/motion@11.16.4/+esm'
import { mergeDeep } from './utils.js'

const layoutRegistry = {};

async function animateEnter(ref, props) {
    try {
        await animateCore(ref, props, "enter");
    } catch (error) {
        console.error("animateEnter:", error);
    }
}

async function animateExit(ref, props) {
    try {
        await animateCore(ref, props, "exit");
    } catch (error) {
        console.error("animateExit:", error);
    }
}

async function animateLayoutId(ref, props, layoutId) {
    try {
        if (!(ref instanceof HTMLElement)) {
            throw new Error("Invalid element provided");
        }

        const rect = ref.getBoundingClientRect();
        const curr = { ref, rect };

        // If we already have a stored rect for this layoutId,
        // animate from the prev -> curr.
        if (layoutRegistry[layoutId]) {
            const prev = layoutRegistry[layoutId];

            const deltaX = prev.rect.x - curr.rect.x;
            const deltaWidth = prev.rect.width - curr.rect.width;
            const widthAdjustment = Math.abs(deltaWidth / 2);

            const x = deltaX + (deltaWidth < 0 ? -widthAdjustment : widthAdjustment);
            const scaleX = prev.rect.width / curr.rect.width;

            const enter = {
                x: [x, 0], // from a translated pos back to the original (0)
                scaleX: [scaleX, 1] // from a scaled size back to the original (1)
            };

            const transition = {
                onUpdate: latest => {
                    curr.rect = ref.getBoundingClientRect();
                }
            };

            props = mergeDeep(props || {}, { enter, transition });

            // Update the stored rect
            layoutRegistry[layoutId] = curr;

            if (ref != prev.ref) {
                // Animate from prev -> curr
                await animateEnter(ref, props);
            }
        } else {
            // First time we see this layoutId, store it
            layoutRegistry[layoutId] = curr;
        }
    } catch (error) {
        console.error("animateLayoutId:", error);
    }
}

async function animateCore(ref, props, key) {
    if (!(ref instanceof HTMLElement)) {
        throw new Error("Invalid element provided");
    }

    const { transition } = props || {};
    const animationProps = props?.[key];

    await motionAnimate(ref, animationProps, transition);
}

export const motion = {
    animateEnter,
    animateExit,
    animateLayoutId
}