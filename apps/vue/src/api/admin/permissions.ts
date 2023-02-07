import { defHttp } from '/@/utils/http/axios'
import { PermissionModel, UpdatePermissionParams } from './model/permissionModel'

enum Api {
  GET = '/api/permission-management/permissions',
  UPDATE = '/api/permission-management/permissions',
}

export const getPermissions = (providerName: string, providerKey: string) => {
  return defHttp.get<PermissionModel>(
    {
      url: Api.GET + '?providerName=' + providerName + '&providerKey=' + providerKey,
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

export const updatePermissions = (
  providerName: string,
  providerKey: string,
  params: UpdatePermissionParams,
) => {
  return defHttp.put(
    {
      url: Api.UPDATE + '?providerName=' + providerName + '&providerKey=' + providerKey,
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
