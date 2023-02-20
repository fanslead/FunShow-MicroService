import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'FunShow',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44369/',
    redirectUri: baseUrl,
    clientId: 'FunShow_App',
    responseType: 'code',
    scope: 'offline_access FunShow',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44349',
      rootNamespace: 'FunShow',
    },
  },
} as Environment;
