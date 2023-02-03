import { BasicPageParams, BasicFetchResult } from '/@/api/model/baseModel'

/**
 * @description: Request list interface parameters
 */
export type RoleParams = BasicPageParams

export interface RoleCreateParams {
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
/**
 * @description: Request list return value
 */
export type RoleListGetResultModel = BasicFetchResult<RoleItem>
