<template>
  <BasicModal
    v-bind="$attrs"
    title="新增"
    :helpMessage="['新增租户']"
    width="700px"
    okText="提交"
    @register="register"
    @ok="handleOk"
  >
    <div class="pt-3px pr-3px">
      <BasicForm @register="registerForm" />
    </div>
  </BasicModal>
</template>
<script lang="ts">
  import { defineComponent } from 'vue'
  import { BasicModal } from '/@/components/Modal'
  import { BasicForm, FormSchema, useForm } from '/@/components/Form'
  import { tenantCreateApi } from '/@/api/admin/tenant'
  import { BasicModal, useModalInner } from '/@/components/Modal'
  import { useMessage } from '/@/hooks/web/useMessage'
  const schemas: FormSchema[] = [
    {
      field: 'name',
      component: 'Input',
      label: '名称',
      colProps: {
        span: 24,
      },
      defaultValue: '',
      required: true,
    },
    {
      field: 'adminEmailAddress',
      component: 'Input',
      label: 'admin邮箱地址',
      colProps: {
        span: 24,
      },
      defaultValue: '',
      required: true,
    },
    {
      field: 'adminPassword',
      component: 'Input',
      label: 'admin密码',
      colProps: {
        span: 24,
      },
      defaultValue: '',
      required: true,
    },
  ]
  export default defineComponent({
    components: { BasicModal, BasicForm },
    props: {},
    setup(props, ctx) {
      const [register, { closeModal }] = useModalInner()
      const [registerForm, { getFieldsValue }] = useForm({
        labelWidth: 120,
        schemas,
        showActionButtonGroup: false,
        actionColOptions: {
          span: 24,
        },
      })
      const { createMessage } = useMessage()
      const { success, error } = createMessage
      function handleOk() {
        let fieldsValue = getFieldsValue()
        tenantCreateApi({
          name: fieldsValue.name,
          adminEmailAddress: fieldsValue.adminEmailAddress,
          adminPassword: fieldsValue.adminPassword,
        })
          .then(() => {
            success('操作成功')
            ctx.emit('close')
            closeModal()
          })
          .catch((ex) => {
            console.log(ex)
            error('操作失败')
          })
      }
      return {
        registerForm,
        schemas,
        handleOk,
        register,
      }
    },
  })
</script>
