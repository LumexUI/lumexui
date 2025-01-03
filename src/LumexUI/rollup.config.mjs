import { defineConfig } from 'rollup';
import commonjs from '@rollup/plugin-commonjs';
import resolve from '@rollup/plugin-node-resolve';

export default defineConfig([
    {
        input: 'wwwroot/js/components/popover.js',
        output: {
            file: 'wwwroot/js/components/popover.bundle.js',
            format: 'esm',
        },
        plugins: [resolve()],
    },
    {
        input: 'Scripts/Plugin/plugin.js',
        output: {
            file: 'Scripts/Plugin/dist/plugin.js',
            format: 'cjs',
        },
        plugins: [
            resolve(),
            commonjs()
        ],
    }
]);
