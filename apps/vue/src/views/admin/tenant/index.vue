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
        <a-button type="primary" @click="openAddForm">新增租户</a-button>
      </template>
      <template #bodyCell="{ column, record }">
        <template v-if="column.key === 'action'">
          <TableAction :actions="createActions(record, column)" />
        </template>
      </template>
    </BasicTable>
    <AddModal @register="addFormModalRegister" @close="reload" />
    <UpdateModal @register="updateFormModalRegister" @close="reload" />
  </div>
</template>
<script lang="ts">
  import { defineComponent, ref } from 'vue'
  import {
    BasicColumn,
    BasicTable,
    FormProps,
    useTable,
    TableAction,
    EditRecordRow,
    ActionItem,
  } from '/@/components/Table'
  import { Alert } from 'ant-design-vue'
  import { tenantListApi } from '/@/api/admin/tenant'
  import { useModal } from '/@/components/Modal'
  import AddModal from './Modals/AddModal.vue'
  import UpdateModal from './Modals/UpdateModal.vue'
  export default defineComponent({
    components: { BasicTable, TableAction, AddModal, UpdateModal, AAlert: Alert },
    setup() {
      const [addFormModalRegister, { openModal: openAddForm }] = useModal()
      const [updateFormModalRegister, { openModal: openUpdateForm }] = useModal()
      const checkedKeys = ref<Array<string | number>>([])
      const [registerTable, { getForm, reload }] = useTable({
        title: '租户列表',
        api: tenantListApi,
        columns: getColumns(),
        useSearchForm: true,
        formConfig: getFormConfig(),
        showTableSetting: false,
        tableSetting: { fullScreen: true },
        showIndexColumn: false,
        rowKey: 'id',
        rowSelection: {
          type: 'checkbox',
          selectedRowKeys: checkedKeys,
          onChange: onSelectChange,
        },
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
        ]
      }
      function getFormConfig(): Partial<FormProps> {
        return {
          labelWidth: 100,
          autoSubmitOnEnter: true,
          schemas: [
            {
              field: `filter`,
              label: `租户名`,
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
        return [
          {
            label: '编辑',
            onClick: (_) => openUpdateForm(true, { id: record.id }),
          },
        ]
      }
      return {
        addFormModalRegister,
        updateFormModalRegister,
        openAddForm,
        registerTable,
        getFormValues,
        checkedKeys,
        onSelectChange,
        createActions,
        reload,
      }
    },
  })
</script>
