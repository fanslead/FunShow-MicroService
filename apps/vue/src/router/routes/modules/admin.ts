import type { AppRouteModule } from '/@/router/types'
import { LAYOUT } from '/@/router/constant'
import { t } from '/@/hooks/web/useI18n'

const tenant: AppRouteModule = {
  path: '/system-management',
  name: '系统管理',
  component: LAYOUT,
  redirect: '/system-management/roles',
  meta: {
    icon: 'ion:ios-keypad',
    title: t('routes.system.management'),
    orderNo: 99,
  },
  children: [
    {
      path: 'roles',
      name: '角色管理',
      component: () => import('/@/views/admin/identity/roles.vue'),
      meta: {
        title: t('routes.system.roles'),
      },
    },
    {
      path: 'users',
      name: '用户管理',
      component: () => import('/@/views/admin/identity/users.vue'),
      meta: {
        title: t('routes.system.users'),
      },
    },
  ],
}

export default tenant
