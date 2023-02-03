import { BasicPageParams, BasicFetchResult } from '/@/api/model/baseModel'

/**
 * @description: Request list interface parameters
 */
export type RoleParams = BasicPageParams

export interface RoleCreateOrUpdateParams {
  name: string
  isDefault: boolean
  isPublic: boolean
}
export interface RoleItem {
  id: string
  concurrencyStamp: string
  name: string
  extraProperties: object
  isDefault: boolean
  isStatic: boolean
  isPublic: boolean
}

export interface RolesItems {
  items: Array<RoleItem>
}
/**
 * @description: Request list return value
 */
export type RoleListGetResultModel = BasicFetchResult<RoleItem>
