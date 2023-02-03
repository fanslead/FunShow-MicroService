import { BasicPageParams, BasicFetchResult } from '/@/api/model/baseModel'
/**
 * @description: Request list interface parameters
 */
export type UserParams = BasicPageParams

export interface CreateOrUpdateUserParams {
  userName: string
  name: string
  surname: string
  email: string
  phoneNumber: string
  isActive: boolean
  lockoutEnabled: boolean
  roleNames: Array<string>
  password: string
}

export interface UserItem {
  id: string
  concurrencyStamp: string
  userName: string
  name: string
  surname: string
  deleterId: string
  deletionTime: string
  tenantId: string
  creatorId: string
  creationTime: string
  lastModifierId: string
  lastModificationTime: string
  email: string
  emailConfirmed: boolean
  phoneNumber: string
  phoneNumberConfirmed: boolean
  extraProperties: object
  lockoutEnabled: boolean
  isActive: boolean
  isDeleted: boolean
  lockoutEnd: boolean
}
/**
 * @description: Request list return value
 */
export type UserListGetResultModel = BasicFetchResult<UserItem>
