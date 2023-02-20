import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'FunShow',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44322/',
    redirectUri: baseUrl,
    clientId: 'FunShow_Angular',
    responseType: 'code',
    scope: 'offline_access  AccountService IdentityService AdministrationService LoggingService',
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44325',
      rootNamespace: 'FunShow',
    },
  },
} as Environment;
