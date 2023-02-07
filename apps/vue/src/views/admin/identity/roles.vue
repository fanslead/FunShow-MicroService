<template>
  <div>
    <BasicTable @register="registerTable">
      <template #form-custom> custom-slot </template>
      <template #headerTop>
        <a-alert type="info" show-icon>
          <template #message>
            <template v-if="checkedKeys.length > 0">
              <span>已选中{{ checkedKeys.length }}条记录(可跨页)</span>
              <a-button type="link" @click="checkedKeys = []" size="small">清空</a-button>
            </template>
            <template v-else>
              <span>未选中任何项目</span>
            </template>
          </template>
        </a-alert>
      </template>
      <template #toolbar>
        <a-button type="primary" @click="addRoleModalopenModal">新增角色</a-button>
      </template>
      <template #bodyCell="{ column, record, text }">
        <template v-if="column.key.indexOf('is') > -1">
          <Tag :color="text ? 'green' : 'red'">
            {{ text }}
          </Tag>
        </template>
        <template v-if="column.key === 'action'">
          <TableAction :actions="createActions(record, column)" />
        </template>
      </template>
    </BasicTable>
    <AddRoleModal @register="addRoleModalRegister" @close="reload" />
    <UpdateRoleModal @register="updateRoleModalRegister" @close="reload" />
    <UpdatePermissionsModal @register="updatePermissionsModalRegister" @close="reload" />
  </div>
</template>
<script lang="ts">
  import { defineComponent, ref } from 'vue'
  import {
    BasicColumn,
    TableAction,
    BasicTable,
    FormProps,
    useTable,
    EditRecordRow,
    ActionItem,
  } from '/@/components/Table'
  import { Alert, Tag } from 'ant-design-vue'
  import { roleListApi } from '/@/api/admin/roles'
  import { useModal } from '/@/components/Modal'
  import AddRoleModal from './Modals/AddRoleModal.vue'
  import UpdateRoleModal from './Modals/UpdateRoleModal.vue'
  import UpdatePermissionsModal from './Modals/UpdatePermissionsModal.vue'
  export default defineComponent({
    components: {
      BasicTable,
      TableAction,
      AAlert: Alert,
      Tag,
      AddRoleModal,
      UpdateRoleModal,
      UpdatePermissionsModal,
    },
    setup() {
      const [addRoleModalRegister, { openModal: addRoleModalopenModal }] = useModal()
      const [updateRoleModalRegister, { openModal: updateRoleModalopenModal }] = useModal()
      const [updatePermissionsModalRegister, { openModal: updatePermissionsModalopenModal }] =
        useModal()
      const checkedKeys = ref<Array<string | number>>([])
      const [registerTable, { getForm, reload }] = useTable({
        title: '角色列表',
        api: roleListApi,
        columns: getColumns(),
        useSearchForm: true,
        formConfig: getFormConfig(),
        showTableSetting: false,
        tableSetting: { fullScreen: true },
        showIndexColumn: false,
        rowKey: 'id',
        // rowSelection: {
        //   type: 'checkbox',
        //   selectedRowKeys: checkedKeys,
        //   onChange: onSelectChange,
        // },
        actionColumn: {
          width: 160,
          title: '操作',
          dataIndex: 'action',
          // slots: { customRender: 'action' },
        },
      })
      function getFormValues() {
        console.log(getForm().getFieldsValue())
      }
      function onSelectChange(selectedRowKeys: (string | number)[]) {
        // console.log(selectedRowKeys)
        checkedKeys.value = selectedRowKeys
      }

      function getColumns(): BasicColumn[] {
        return [
          {
            title: 'Id',
            dataIndex: 'id',
            fixed: 'left',
            width: 200,
            defaultHidden: true,
          },
          {
            title: '名称',
            dataIndex: 'name',
            fixed: 'left',
            width: 200,
            sorter: true,
          },
          {
            title: '是否默认',
            dataIndex: 'isDefault',
            fixed: 'left',
            width: 200,
          },
          {
            title: '是否公开',
            dataIndex: 'isPublic',
            fixed: 'left',
            width: 200,
            sorter: true,
          },
        ]
      }
      function getFormConfig(): Partial<FormProps> {
        return {
          labelWidth: 100,
          schemas: [
            {
              field: `filter`,
              label: `角色名`,
              component: 'Input',
              colProps: {
                xl: 12,
                xxl: 8,
              },
            },
          ],
        }
      }
      function createActions(record: EditRecordRow, column: BasicColumn): ActionItem[] {
        let actionItems: ActionItem[] = []
        if (!record.isStatic) {
          actionItems.push({
            label: '编辑',
            onClick: () => updateRoleModalopenModal(true, { id: record.id }),
          })
        }
        actionItems.push({
          label: '权限',
          onClick: () => updatePermissionsModalopenModal(true, { name: record.name }),
        })
        return actionItems
      }

      return {
        registerTable,
        getFormValues,
        checkedKeys,
        onSelectChange,
        createActions,
        addRoleModalRegister,
        addRoleModalopenModal,
        updateRoleModalRegister,
        updatePermissionsModalRegister,
        reload,
      }
    },
  })
</script>
