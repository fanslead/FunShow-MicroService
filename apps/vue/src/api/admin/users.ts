import { defHttp } from '/@/utils/http/axios'
import { UserParams, UserListGetResultModel } from './model/userModel'

enum Api {
  LIST = '/api/identity/users',
}
/**
 * @description: Get list value
 */

export const userListApi = (params: UserParams) => {
  params.skipCount = (params.skipCount - 1) * params.maxResultCount
  return defHttp.get<UserListGetResultModel>(
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
