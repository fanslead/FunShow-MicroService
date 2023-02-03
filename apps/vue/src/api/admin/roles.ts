import { defHttp } from '/@/utils/http/axios'
import {
  RoleParams,
  RoleListGetResultModel,
  RoleCreateOrUpdateParams,
  RoleItem,
  RolesItems,
} from './model/roleModel'

enum Api {
  LIST = '/api/identity/roles',
  LIST_ALL = '/api/identity/roles/all',
  BY_ID = '/api/identity/roles',
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

export const roleListAllApi = () => {
  return defHttp.get<RolesItems>(
    {
      url: Api.LIST_ALL,
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

export const getRoleByIdApi = (id: string) => {
  return defHttp.get<RoleItem>(
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
export const roleCreateApi = (params: RoleCreateOrUpdateParams) => {
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
export const roleUpdateApi = (id: string, params: RoleCreateOrUpdateParams) => {
  return defHttp.put<RoleItem>(
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
export const deleteRoleByIdApi = (id: string) => {
  return defHttp.delete(
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
