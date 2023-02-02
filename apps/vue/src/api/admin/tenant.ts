import { defHttp } from '/@/utils/http/axios'
import { TenantParams, TenantListGetResultModel } from './model/tenantModel'

enum Api {
  Tenant_LIST = '/api/multi-tenancy/tenants',
}
/**
 * @description: Get list value
 */

export const tenantListApi = (params: TenantParams) => {
  params.skipCount = (params.skipCount - 1) * params.maxResultCount
  return defHttp.get<TenantListGetResultModel>(
    {
      url: Api.Tenant_LIST,
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
