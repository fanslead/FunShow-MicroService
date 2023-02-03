import { BasicPageParams, BasicFetchResult } from '/@/api/model/baseModel'

/**
 * @description: Request list interface parameters
 */
export type TenantParams = BasicPageParams

export interface CreateTenantParams {
  name: string
  adminEmailAddress: string
  adminPassword: string
}

export interface TenantItem {
  id: string
  concurrencyStamp: string
  name: string
  extraProperties: object
}

/**
 * @description: Request list return value
 */
export type TenantListGetResultModel = BasicFetchResult<TenantItem>
