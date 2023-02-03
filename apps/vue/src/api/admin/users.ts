import { defHttp } from '/@/utils/http/axios'
import {
  UserParams,
  UserListGetResultModel,
  UserItem,
  CreateOrUpdateUserParams,
} from './model/userModel'
import { RolesItems } from './model/roleModel'
enum Api {
  LIST = '/api/identity/users',
  BY_ID = '/api/identity/users',
  CREATE = '/api/identity/users',
  GET_ASSIGNABLE_ROLE = '/api/identity/users/assignable-roles',
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

export const getUserByIdApi = (id: string) => {
  return defHttp.get<UserItem>(
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

export const getUserAssignablerolesApi = () => {
  return defHttp.get<RolesItems>(
    {
      url: Api.GET_ASSIGNABLE_ROLE,
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
export const updateUserByIdApi = (id: string, params: CreateOrUpdateUserParams) => {
  return defHttp.put<UserItem>(
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

export const createUserByIdApi = (params: CreateOrUpdateUserParams) => {
  return defHttp.put<UserItem>(
    {
      url: Api.BY_ID,
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
export const deleteUserByIdApi = (id: string) => {
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
