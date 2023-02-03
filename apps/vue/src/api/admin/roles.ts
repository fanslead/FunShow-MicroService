import { defHttp } from '/@/utils/http/axios'
import { RoleParams, RoleListGetResultModel, RoleCreateParams, RoleItem } from './model/roleModel'

enum Api {
  LIST = '/api/identity/roles',
  CREATE = '/api/identity/roles',
}
/**
 * @description: Get list value
 */

export const roleListApi = (params: RoleParams) => {
  params.skipCount = (params.skipCount - 1) * params.maxResultCount
  return defHttp.get<RoleListGetResultModel>(
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
export const roleCreateApi = (params: RoleCreateParams) => {
  return defHttp.post<RoleItem>(
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
