/**
 * @description: Login interface parameters
 */
export interface LoginParams {
  username: string
  password: string
}

export interface RoleInfo {
  roleName: string
  value: string
}

/**
 * @description: Login interface return value
 */
export interface LoginResultModel {
  expires_in: number
  access_token: string
  refresh_token: string
  token_type: string
}

/**
 * @description: Get user information return value
 */
export interface GetUserInfoModel {
  roles: string[]
  // 用户id
  id: string | number
  // 用户名
  username: string
  // 真实名字
  realName: string
  // 头像
  avatar: string
  // 介绍
  desc?: string
  name?: string
  phoneNumber: string
  email: string
}
