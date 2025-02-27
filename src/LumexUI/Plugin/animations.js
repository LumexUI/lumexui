export default {
    animation: {
        "appearance-in": "appearance-in 200ms ease-out normal both",
        "appearance-out": "appearance-out 60ms ease-in normal both",
    },
    keyframes: {
        "appearance-in": {
            "0%": {
                opacity: "0",
                transform: "translateZ(0)  scale(0.85)",
            },
            "100%": {
                opacity: "1",
                transform: "translateZ(0) scale(1)",
            },
        },
        "appearance-out": {
            "0%": {
                opacity: "1",
                transform: "scale(1)",
            },
            "100%": {
                opacity: "0",
                transform: "scale(0.85)",
            },
        }
    },
};