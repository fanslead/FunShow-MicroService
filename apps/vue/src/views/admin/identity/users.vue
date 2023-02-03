<template>
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
      <a-button type="primary">新增用户</a-button>
    </template>
    <template #bodyCell="{ column, record, text }">
      <template v-if="column.key.indexOf('is') > -1 || column.key.indexOf('lockoutEnabled') > -1">
        <Tag :color="text ? 'green' : 'red'">
          {{ text }}
        </Tag>
      </template>
      <template v-if="column.key === 'action'">
        <TableAction :actions="createActions(record, column)" />
      </template>
    </template>
  </BasicTable>
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
  import { userListApi } from '/@/api/admin/users'
  export default defineComponent({
    components: { BasicTable, TableAction, AAlert: Alert, Tag },
    setup() {
      const checkedKeys = ref<Array<string | number>>([])
      const [registerTable, { getForm }] = useTable({
        title: '用户列表',
        api: userListApi,
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
          {
            title: '账号',
            dataIndex: 'userName',
            fixed: 'left',
            width: 200,
          },
          {
            title: '邮箱',
            dataIndex: 'email',
            fixed: 'left',
            width: 200,
          },
          {
            title: '手机号',
            dataIndex: 'phoneNumber',
            fixed: 'left',
            width: 200,
          },
          {
            title: '是否锁定',
            dataIndex: 'lockoutEnabled',
            fixed: 'left',
            width: 200,
          },
        ]
      }
      function getFormConfig(): Partial<FormProps> {
        return {
          labelWidth: 100,
          schemas: [
            {
              field: `filter`,
              label: `用户名`,
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
        if (!record.editable) {
          return [
            {
              label: '编辑',
            },
          ]
        }
      }
      return {
        registerTable,
        getFormValues,
        checkedKeys,
        onSelectChange,
        createActions,
      }
    },
  })
</script>
