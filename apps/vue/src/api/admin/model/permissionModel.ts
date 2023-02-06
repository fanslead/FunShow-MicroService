export interface GrantedProviderItem {
  providerName: string
  providerKey: string
}
export interface PermissionsItem {
  name: string
  displayName: string
  parentName: string
  isGranted: boolean
  allowedProviders: Array<string>
  grantedProviders: Array<GrantedProviderItem>
}
export interface PermissionGroupItem {
  name: string
  displayName: string
  displayNameKey: string
  displayNameResource: string
}

export interface PermissionModel {
  entityDisplayName: string
  groups: Array<PermissionGroupItem>
}

export interface UpdatePermissionsItem {
  name: string
  isGranted: boolean
}

export interface UpdatePermissionParams {
  permissions: Array<UpdatePermissionsItem>
}
