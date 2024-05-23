/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        "./Shared/**/*.razor",
        "../../src/LumexUI/Styles/*.cs"
    ],
    theme: {
        extend: {
            colors: {
                /** Base */
                background: {
                    DEFAULT: "hsl(var(--lumex-background) / <alpha-value>)"
                },
                foreground: {
                    50: "hsl(var(--lumex-foreground-50) / <alpha-value>)",
                    100: "hsl(var(--lumex-foreground-100) / <alpha-value>)",
                    200: "hsl(var(--lumex-foreground-200) / <alpha-value>)",
                    300: "hsl(var(--lumex-foreground-300) / <alpha-value>)",
                    400: "hsl(var(--lumex-foreground-400) / <alpha-value>)",
                    500: "hsl(var(--lumex-foreground-500) / <alpha-value>)",
                    600: "hsl(var(--lumex-foreground-600) / <alpha-value>)",
                    700: "hsl(var(--lumex-foreground-700) / <alpha-value>)",
                    800: "hsl(var(--lumex-foreground-800) / <alpha-value>)",
                    900: "hsl(var(--lumex-foreground-900) / <alpha-value>)",
                    DEFAULT: "hsl(var(--lumex-foreground) / <alpha-value>)"
                },
                focus: {
                    DEFAULT: "hsl(var(--lumex-focus) / <alpha-value>)"
                },
                overlay: {
                    DEFAULT: "hsl(var(--lumex-overlay) / <alpha-value>)"
                },
                divider: {
                    DEFAULT: "hsl(var(--lumex-divider) / var(--lumex-divider-opacity ,<alpha-value>))"
                },

                /** Default */
                default: {
                    50: "hsl(var(--lumex-default-50) / <alpha-value>)",
                    100: "hsl(var(--lumex-default-100) / <alpha-value>)",
                    200: "hsl(var(--lumex-default-200) / <alpha-value>)",
                    300: "hsl(var(--lumex-default-300) / <alpha-value>)",
                    400: "hsl(var(--lumex-default-400) / <alpha-value>)",
                    500: "hsl(var(--lumex-default-500) / <alpha-value>)",
                    600: "hsl(var(--lumex-default-600) / <alpha-value>)",
                    700: "hsl(var(--lumex-default-700) / <alpha-value>)",
                    800: "hsl(var(--lumex-default-800) / <alpha-value>)",
                    900: "hsl(var(--lumex-default-900) / <alpha-value>)",
                    DEFAULT: "hsl(var(--lumex-default) / <alpha-value>)",
                    foreground: "hsl(var(--lumex-default-foreground) / <alpha-value>)"
                },

                /** Primary */
                primary: {
                    50: "hsl(var(--lumex-primary-50) / <alpha-value>)",
                    100: "hsl(var(--lumex-primary-100) / <alpha-value>)",
                    200: "hsl(var(--lumex-primary-200) / <alpha-value>)",
                    300: "hsl(var(--lumex-primary-300) / <alpha-value>)",
                    400: "hsl(var(--lumex-primary-400) / <alpha-value>)",
                    500: "hsl(var(--lumex-primary-500) / <alpha-value>)",
                    600: "hsl(var(--lumex-primary-600) / <alpha-value>)",
                    700: "hsl(var(--lumex-primary-700) / <alpha-value>)",
                    800: "hsl(var(--lumex-primary-800) / <alpha-value>)",
                    900: "hsl(var(--lumex-primary-900) / <alpha-value>)",
                    DEFAULT: "hsl(var(--lumex-primary) / <alpha-value>)",
                    foreground: "hsl(var(--lumex-primary-foreground) / <alpha-value>)"
                },

                /** Secondary */
                secondary: {
                    50: "hsl(var(--lumex-secondary-50) / <alpha-value>)",
                    100: "hsl(var(--lumex-secondary-100) / <alpha-value>)",
                    200: "hsl(var(--lumex-secondary-200) / <alpha-value>)",
                    300: "hsl(var(--lumex-secondary-300) / <alpha-value>)",
                    400: "hsl(var(--lumex-secondary-400) / <alpha-value>)",
                    500: "hsl(var(--lumex-secondary-500) / <alpha-value>)",
                    600: "hsl(var(--lumex-secondary-600) / <alpha-value>)",
                    700: "hsl(var(--lumex-secondary-700) / <alpha-value>)",
                    800: "hsl(var(--lumex-secondary-800) / <alpha-value>)",
                    900: "hsl(var(--lumex-secondary-900) / <alpha-value>)",
                    DEFAULT: "hsl(var(--lumex-secondary) / <alpha-value>)",
                    foreground: "hsl(var(--lumex-secondary-foreground) / <alpha-value>)"
                },

                /** Success */
                success: {
                    50: "hsl(var(--lumex-success-50) / <alpha-value>)",
                    100: "hsl(var(--lumex-success-100) / <alpha-value>)",
                    200: "hsl(var(--lumex-success-200) / <alpha-value>)",
                    300: "hsl(var(--lumex-success-300) / <alpha-value>)",
                    400: "hsl(var(--lumex-success-400) / <alpha-value>)",
                    500: "hsl(var(--lumex-success-500) / <alpha-value>)",
                    600: "hsl(var(--lumex-success-600) / <alpha-value>)",
                    700: "hsl(var(--lumex-success-700) / <alpha-value>)",
                    800: "hsl(var(--lumex-success-800) / <alpha-value>)",
                    900: "hsl(var(--lumex-success-900) / <alpha-value>)",
                    DEFAULT: "hsl(var(--lumex-success) / <alpha-value>)",
                    foreground: "hsl(var(--lumex-success-foreground) / <alpha-value>)"
                },

                /** Warning */
                warning: {
                    50: "hsl(var(--lumex-warning-50) / <alpha-value>)",
                    100: "hsl(var(--lumex-warning-100) / <alpha-value>)",
                    200: "hsl(var(--lumex-warning-200) / <alpha-value>)",
                    300: "hsl(var(--lumex-warning-300) / <alpha-value>)",
                    400: "hsl(var(--lumex-warning-400) / <alpha-value>)",
                    500: "hsl(var(--lumex-warning-500) / <alpha-value>)",
                    600: "hsl(var(--lumex-warning-600) / <alpha-value>)",
                    700: "hsl(var(--lumex-warning-700) / <alpha-value>)",
                    800: "hsl(var(--lumex-warning-800) / <alpha-value>)",
                    900: "hsl(var(--lumex-warning-900) / <alpha-value>)",
                    DEFAULT: "hsl(var(--lumex-warning) / <alpha-value>)",
                    foreground: "hsl(var(--lumex-warning-foreground) / <alpha-value>)"
                },

                /** Danger */
                danger: {
                    50: "hsl(var(--lumex-danger-50) / <alpha-value>)",
                    100: "hsl(var(--lumex-danger-100) / <alpha-value>)",
                    200: "hsl(var(--lumex-danger-200) / <alpha-value>)",
                    300: "hsl(var(--lumex-danger-300) / <alpha-value>)",
                    400: "hsl(var(--lumex-danger-400) / <alpha-value>)",
                    500: "hsl(var(--lumex-danger-500) / <alpha-value>)",
                    600: "hsl(var(--lumex-danger-600) / <alpha-value>)",
                    700: "hsl(var(--lumex-danger-700) / <alpha-value>)",
                    800: "hsl(var(--lumex-danger-800) / <alpha-value>)",
                    900: "hsl(var(--lumex-danger-900) / <alpha-value>)",
                    DEFAULT: "hsl(var(--lumex-danger) / <alpha-value>)",
                    foreground: "hsl(var(--lumex-danger-foreground) / <alpha-value>)"
                },

                /** Info */
                info: {
                    50: "hsl(var(--lumex-info-50) / <alpha-value>)",
                    100: "hsl(var(--lumex-info-100) / <alpha-value>)",
                    200: "hsl(var(--lumex-info-200) / <alpha-value>)",
                    300: "hsl(var(--lumex-info-300) / <alpha-value>)",
                    400: "hsl(var(--lumex-info-400) / <alpha-value>)",
                    500: "hsl(var(--lumex-info-500) / <alpha-value>)",
                    600: "hsl(var(--lumex-info-600) / <alpha-value>)",
                    700: "hsl(var(--lumex-info-700) / <alpha-value>)",
                    800: "hsl(var(--lumex-info-800) / <alpha-value>)",
                    900: "hsl(var(--lumex-info-900) / <alpha-value>)",
                    DEFAULT: "hsl(var(--lumex-info) / <alpha-value>)",
                    foreground: "hsl(var(--lumex-info-foreground) / <alpha-value>)"
                }
            },
            fontSize: {
                tiny: ["var(--lumex-font-size-tiny)", "var(--lumex-line-height-tiny)"],
                small: ["var(--lumex-font-size-small)", "var(--lumex-line-height-small)"],
                medium: ["var(--lumex-font-size-medium)", "var(--lumex-line-height-medium)"],
                large: ["var(--lumex-font-size-large)", "var(--lumex-line-height-large)"]
            },
            borderRadius: {
                small: "var(--lumex-radius-small)",
                medium: "var(--lumex-radius-medium)",
                large: "var(--lumex-radius-large)"
            },
            boxShadow: {
                small: "var(--lumex-box-shadow-small)",
                medium: "var(--lumex-box-shadow-medium)",
                large: "var(--lumex-box-shadow-large)"
            },
            opacity: {
                divider: "var(--lumex-divider-opacity)",
                disabled: "var(--lumex-disabled-opacity)",
                focus: "var(--lumex-focus-opacity)",
                hover: "var(--lumex-hover-opacity)"
            },
        },
    },
    plugins: [],
}
