export interface BasicPageParams {
  filter?: string
  sorting?: string
  skipCount: number
  maxResultCount: number
}

export interface BasicFetchResult<T> {
  items: T[]
  totalCount: number
}
