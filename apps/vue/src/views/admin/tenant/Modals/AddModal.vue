<template>
  <BasicModal v-bind="$attrs" title="新增" :helpMessage="['新增租户']" width="700px">
    <BasicForm
      :labelWidth="100"
      :schemas="schemas"
      :actionColOptions="{ span: 24 }"
      @submit="handleSubmit"
    />
  </BasicModal>
</template>
<script lang="ts">
  import { defineComponent } from 'vue'
  import { BasicModal } from '/@/components/Modal'
  import { BasicForm, FormSchema } from '/@/components/Form'
  import { useMessage } from '/@/hooks/web/useMessage'
  const schemas: FormSchema[] = [
    {
      field: 'name',
      component: 'Input',
      label: '名称',
      colProps: {
        span: 8,
      },
      defaultValue: '',
    },
    {
      field: 'adminEmailAddress',
      component: 'Input',
      label: 'admin邮箱地址',
      colProps: {
        span: 8,
      },
      defaultValue: '',
    },
    {
      field: 'adminPassword',
      component: 'Input',
      label: 'admin密码',
      colProps: {
        span: 8,
      },
      defaultValue: '',
    },
  ]
  export default defineComponent({
    components: { BasicModal, BasicForm },
    setup() {
      const { createMessage } = useMessage()
      return {
        schemas,
        handleSubmit: (values: any) => {
          createMessage.success('click search,values:' + JSON.stringify(values));
        },
      }
    },
  })
</script>
