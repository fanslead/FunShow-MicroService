import { defHttp } from '/@/utils/http/axios'
import {
  TenantParams,
  TenantListGetResultModel,
  CreateTenantParams,
  UpdateTenantParams,
  TenantItem,
} from './model/tenantModel'

enum Api {
  LIST = '/api/multi-tenancy/tenants',
  CREATE = '/api/multi-tenancy/tenants',
  BY_ID = '/api/multi-tenancy/tenants',
}
/**
 * @description: Get list value
 */

export const tenantListApi = (params: TenantParams) => {
  params.skipCount = (params.skipCount - 1) * params.maxResultCount
  return defHttp.get<TenantListGetResultModel>(
    {
      url: Api.LIST,
      params,
      headers: {
        // @ts-ignore
        ignoreCancelToken: true,
      },
    },
    {
      isTransformResponse: false,
    },
  )
}

export const tenantCreateApi = (params: CreateTenantParams) => {
  return defHttp.post<TenantItem>(
    {
      url: Api.CREATE,
      params,
      headers: {
        // @ts-ignore
        ignoreCancelToken: true,
      },
    },
    {
      isTransformResponse: false,
    },
  )
}

export const tenantUpdateApi = (id: string, params: UpdateTenantParams) => {
  return defHttp.put<TenantItem>(
    {
      url: Api.BY_ID + '/' + id,
      params,
      headers: {
        // @ts-ignore
        ignoreCancelToken: true,
      },
    },
    {
      isTransformResponse: false,
    },
  )
}

export const tenantGetByIdApi = (id: string) => {
  return defHttp.get<TenantItem>(
    {
      url: Api.BY_ID + '/' + id,
      headers: {
        // @ts-ignore
        ignoreCancelToken: true,
      },
    },
    {
      isTransformResponse: false,
    },
  )
}
