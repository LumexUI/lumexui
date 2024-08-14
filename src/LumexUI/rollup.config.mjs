import { defineConfig } from 'rollup';
import resolve from '@rollup/plugin-node-resolve';

export default defineConfig([
    {
        input: 'wwwroot/js/popover.js',
        output: {
            file: 'wwwroot/js/dist/popover.js',
            format: 'esm',
        },
        plugins: [resolve()],
    }
]);
