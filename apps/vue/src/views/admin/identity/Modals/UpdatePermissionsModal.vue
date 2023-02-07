<template>
  <BasicModal v-bind="$attrs" @register="register" title="更新权限" @ok="handleOk">
    <ScrollContainer>
      <div ref="wrapperRef" :class="prefixCls">
        <Tabs tab-position="left" :tabBarStyle="tabBarStyle">
          <template v-for="item in model.groups" :key="item.name">
            <TabPane :tab="item.displayName">
              <BasicTree
                :treeData="getTreeData(item)"
                @check="(data, e) => oncheck(data, e, item.name)"
                :checkable="true"
                defaultExpandAll
                :ref="(el) => setItemRef(el, item.name)"
              />
            </TabPane>
          </template>
        </Tabs>
      </div>
    </ScrollContainer>
  </BasicModal>
</template>
<script lang="ts">
  import { defineComponent, ref, unref } from 'vue'
  import { Tabs, TabPane } from 'ant-design-vue'
  import { ScrollContainer } from '/@/components/Container/index'
  import { BasicModal, useModalInner } from '/@/components/Modal'
  import { useMessage } from '/@/hooks/web/useMessage'
  import { BasicTree } from '/@/components/Tree/index'
  import { TreeItem, TreeActionType, CheckKeys } from '/@/components/Tree/index'
  import { getPermissions, updatePermissions } from '/@/api/admin/permissions'
  import {
    PermissionModel,
    PermissionGroupItem,
    UpdatePermissionParams,
  } from '/@/api/admin/model/permissionModel'
  export default defineComponent({
    components: { BasicModal, ScrollContainer, Tabs, TabPane, BasicTree },
    props: {
      permissionData: { type: Object },
    },
    setup(props, ctx) {
      const modelRef = ref({} as PermissionModel)
      const roleRef = ref('')
      const checkedKeys = ref<object>({})
      const selectPermission = ref({} as UpdatePermissionParams)
      const { createMessage } = useMessage()
      const { success, error } = createMessage
      const [register, { closeModal }] = useModalInner((data) => {
        data && onDataReceive(data)
      })
      let itemRefs = {}
      const setItemRef = (el, name) => {
        if (el) {
          if (!itemRefs[name]) itemRefs[name] = el
        }
      }
      function onDataReceive(data) {
        checkedKeys.value = {}
        roleRef.value = data.name
        getPermissions('R', data.name).then((res) => {
          modelRef.value = res
          res.groups.forEach((g) => {
            const asyncTreeAction: TreeActionType | null = unref(itemRefs[g.name])
            asyncTreeAction?.setCheckedKeys([])
          })
        })
        // 方式1;
        // setFieldsValue({
        //   field2: data.data,
        //   field1: data.info,
        // });
        // // 方式2
        // modelRef.value = { field2: data.data, field1: data.info }
        // setProps({
        //   model:{ field2: data.data, field1: data.info }
        // })
      }
      function handleOk() {
        updatePermissions('R', roleRef.value, selectPermission.value)
          .then(() => {
            success('操作成功')
            ctx.emit('close')
            closeModal()
          })
          .catch((ex) => {
            console.log(ex)
            error('操作失败')
            closeModal()
          })
      }
      function getTreeData(data: PermissionGroupItem): TreeItem[] {
        const obj = []
        data.permissions.forEach((item) => {
          obj[item.name] = {
            title: item.displayName,
            key: item.name,
          } as TreeItem
        })
        const treeItem: TreeItem[] = []
        const currentCheckKeys: string[] = []
        data.permissions.forEach((item) => {
          const parent = obj[item.parentName] as TreeItem
          if (parent) {
            const pItem = treeItem.find((p) => p.key == item.parentName) as TreeItem
            pItem.children = pItem.children || []
            pItem.children.push({
              title: item.displayName,
              key: item.name,
            })
          } else {
            // * 根节点
            treeItem.push({
              title: item.displayName,
              key: item.name,
            })
          }
          if (item.isGranted) {
            currentCheckKeys.push(item.name)
          }
        })
        setTimeout(() => {
          const asyncTreeAction: TreeActionType | null = unref(itemRefs[data.name])
          if (!checkedKeys.value[data.name]) {
            const currentCheckKeys: string[] = []
            data.permissions.forEach((p) => {
              if (p.isGranted) currentCheckKeys.push(p.name)
            })
            asyncTreeAction?.setCheckedKeys(currentCheckKeys)
            checkedKeys.value[data.name] = true
          }
        }, 0)
        return treeItem
      }
      function oncheck(checkData: string[], e, name) {
        console.log(checkData)
        console.log(e)
        console.log(name)
      }
      return {
        register,
        oncheck,
        model: modelRef,
        handleOk,
        getTreeData,
        setItemRef,
        prefixCls: 'permission',
        tabBarStyle: {
          width: '180px',
        },
      }
    },
  })
</script>

<style lang="less">
  .permission {
    margin: 12px;
    background-color: @component-background;
    .base-title {
      padding-left: 0;
    }
    .ant-tabs-tab-active {
      background-color: @item-active-bg;
    }
  }
</style>
