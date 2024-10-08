const lumexui = '../../../src/LumexUI/';
const colors = require('tailwindcss/colors');
const defaultTheme = require('tailwindcss/defaultTheme');

/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        './{Pages,Components}/**/*.{razor,razor.cs}',
        '../LumexUI.Docs.Client/{Pages,Components}/**/*.{razor,razor.cs}',
        `${lumexui}/Styles/*.cs`
    ],
    darkMode: 'class',
    theme: {
        extend: {
            colors: {
                black: colors.black,
                white: colors.white
            },
            fontFamily: {
                sans: ['Inter var', ...defaultTheme.fontFamily.sans],
                mono: ['Fira Code var', ...defaultTheme.fontFamily.mono]
            },
            typography: (theme) => ({
                DEFAULT: {
                    css: {
                        maxWidth: 'none',
                        'h2, h3, h4': {
                            'scroll-margin-top': 'var(--scroll-mt)',
                        },
                        a: {
                            color: 'var(--tw-prose-links) !important',
                            lineHeight: theme('lineHeight.tight'),
                            fontWeight: theme('fontWeight.semibold'),
                            textDecoration: 'none',
                            borderBottom: `1px solid ${theme('colors.orange.400')}`,
                        },
                        'a:hover': {
                            borderBottomWidth: '2px',
                        },
                        pre: {
                            color: theme('colors.zinc.100'),
                            padding: theme('padding.5'),
                            display: 'flex'
                        },
                        'code[class]::before': {
                            content: '""'
                        },
                        'code[class]::after': {
                            content: '""'
                        }
                    }
                }
            }),
        },
    },
    plugins: [
        require(`${lumexui}/Scripts/Plugin/dist/plugin`),
        require('@tailwindcss/typography'),
        function ({ addVariant }) {
            addVariant('children', '& > *')
            addVariant('scrollbar', '&::-webkit-scrollbar')
            addVariant('scrollbar-track', '&::-webkit-scrollbar-track')
            addVariant('scrollbar-thumb', '&::-webkit-scrollbar-thumb')
        },
        function ({ addUtilities, theme }) {
            let color = theme('colors.indigo.200').replace('#', '%23');
            let backgroundImage = `url("data:image/svg+xml,%3Csvg xmlns='http://www.w3.org/2000/svg' width='16' height='16' viewBox='0 0 16 16'%3E%3Ccircle cx='8' cy='8' r='1' fill='${color}' /%3E%3C/svg%3E")`;

            addUtilities({
                '.bg-dots': {
                    backgroundImage
                },
            })
        }
    ],
};
