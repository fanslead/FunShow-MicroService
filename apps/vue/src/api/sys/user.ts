import { defHttp, authHttp } from '/@/utils/http/axios'
import { LoginParams, LoginResultModel } from './model/userModel'
import { useGlobSetting } from '/@/hooks/setting'

import { ErrorMessageMode } from '/#/axios'
import { createLocalStorage } from '/@/utils/cache'
import { getToken } from '/@/utils/auth'

const globSetting = useGlobSetting()

enum Api {
  Login = '/connect/token',
  Logout = '/connect/revocat',
  GetUserInfo = '/api/account/my-profile',
  GetPermCode = '/getPermCode',
  TestRetry = '/testRetry',
}

/**
 * @description: user login api
 */
export function loginApi(params: LoginParams, mode: ErrorMessageMode = 'modal') {
  const loginParams = {
    client_id: globSetting.clientId,
    grant_type: globSetting.grantType,
    scope: globSetting.scope,
    ...params,
  }
  return authHttp.post<LoginResultModel>(
    {
      url: Api.Login,
      params: loginParams,
    },
    {
      errorMessageMode: mode,
      isTransformResponse: false,
    },
  )
}

/**
 * @description: getUserInfo
 */
export function getUserInfo() {
  const configuration = createLocalStorage().get('application_configuration')
  const userInfo = configuration.currentUser
  return userInfo
  //return defHttp.get<GetUserInfoModel>({ url: Api.GetUserInfo }, { errorMessageMode: 'none' })
}

export function getPermCode() {
  const configuration = createLocalStorage().get('application_configuration')
  const permissions: string[] = []
  for (const key in configuration.grantedPolicies) {
    if (configuration.grantedPolicies[key]) {
      permissions.push(key)
    }
  }
  return permissions
  //return defHttp.get<string[]>({ url: Api.GetPermCode })
}

export function doLogout() {
  return authHttp.post({
    url: Api.Logout,
    params: {
      client_id: globSetting.clientId,
      token: getToken(),
      token_type_hint: 'access_token',
    },
  })
}

export function testRetry() {
  return defHttp.get(
    { url: Api.TestRetry },
    {
      retryRequest: {
        isOpenRetry: true,
        count: 5,
        waitTime: 1000,
      },
    },
  )
}
