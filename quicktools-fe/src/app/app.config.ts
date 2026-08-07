import { ApplicationConfig, provideBrowserGlobalErrorListeners } from '@angular/core';
import { provideRouter } from '@angular/router';
import { routes } from './app.routes';
import { provideOptimus } from '@openng/optimus-ui/config';
import Material from '@openng/optimus-ui-themes/material';
import { definePreset } from '@openng/optimus-ui-themes';

const Noir = definePreset(Material, {
    semantic: {
        // Brand color
        primary: {
            50: '{indigo.50}',
            100: '{indigo.100}',
            200: '{indigo.200}',
            300: '{indigo.300}',
            400: '{indigo.400}',
            500: '{indigo.500}',
            600: '{indigo.600}',
            700: '{indigo.700}',
            800: '{indigo.800}',
            900: '{indigo.900}',
            950: '{indigo.950}',
        },

        colorScheme: {
            light: {
                primary: {
                    color: '{indigo.600}',
                    inverseColor: '#ffffff',
                    hoverColor: '{indigo.700}',
                    activeColor: '{indigo.800}',
                },

                highlight: {
                    background: '{indigo.100}',
                    focusBackground: '{indigo.200}',
                    color: '{indigo.900}',
                    focusColor: '{indigo.950}',
                },
            },

            dark: {
                primary: {
                    color: '{indigo.400}',
                    inverseColor: '{slate.950}',
                    hoverColor: '{indigo.300}',
                    activeColor: '{indigo.200}',
                },

                highlight: {
                    background: '{indigo.500}',
                    focusBackground: '{indigo.400}',
                    color: '#ffffff',
                    focusColor: '#ffffff',
                },
            },
        },
    },
});

export const appConfig: ApplicationConfig = {
    providers: [
        provideBrowserGlobalErrorListeners(),
        provideRouter(routes),
        provideOptimus({
            theme: {
                preset: Noir,
                options: {
                    prefix: 'p',
                    cssLayer: false,
                    darkModeSelector: '.dark', // 'system'
                },
            },
            ripple: true,
        }),
    ],
};
