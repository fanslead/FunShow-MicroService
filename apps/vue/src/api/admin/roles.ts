import { defHttp } from '/@/utils/http/axios'
import { RoleParams, RoleListGetResultModel } from './model/roleModel'

enum Api {
  LIST = '/api/identity/roles',
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
