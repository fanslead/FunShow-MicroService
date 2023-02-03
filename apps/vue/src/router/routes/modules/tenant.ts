import type { AppRouteModule } from '/@/router/types'
import { LAYOUT } from '/@/router/constant'
import { t } from '/@/hooks/web/useI18n'

const tenant: AppRouteModule = {
  path: '/tenant-management',
  name: '租户管理',
  component: LAYOUT,
  redirect: '/tenant-management/tenants',
  meta: {
    icon: 'ion:ios-keypad',
    title: t('routes.tenant.management'),
    orderNo: 98,
  },
  children: [
    {
      path: 'tenants',
      name: '租户',
      component: () => import('/@/views/admin/tenant/index.vue'),
      meta: {
        title: t('routes.tenant.tenants'),
      },
    },
  ],
}

export default tenant
