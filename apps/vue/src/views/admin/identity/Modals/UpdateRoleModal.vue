<template>
  <BasicModal
    v-bind="$attrs"
    @register="register"
    title="更新角色"
    @visible-change="handleVisibleChange"
    @ok="handleOk"
  >
    <div class="pt-3px pr-3px">
      <BasicForm @register="registerForm" :model="model" />
    </div>
  </BasicModal>
</template>
<script lang="ts">
  import { defineComponent, ref, nextTick } from 'vue'
  import { BasicModal, useModalInner } from '/@/components/Modal'
  import { BasicForm, FormSchema, useForm } from '/@/components/Form/index'
  import { getRoleByIdApi, roleUpdateApi } from '/@/api/admin/roles'
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
      field: 'isDefault',
      component: 'Checkbox',
      label: '是否默认',
      colProps: {
        span: 24,
      },
      defaultValue: false,
      required: true,
    },
    {
      field: 'isPublic',
      component: 'Checkbox',
      label: '是否公开',
      colProps: {
        span: 24,
      },
      defaultValue: false,
      required: true,
    },
  ]
  export default defineComponent({
    components: { BasicModal, BasicForm },
    props: {
      tenantData: { type: Object },
    },
    setup(props, ctx) {
      const modelRef = ref({})
      const idRef = ref('')
      const { createMessage } = useMessage()
      const { success, error } = createMessage
      const [
        registerForm,
        {
          getFieldsValue,
          // setFieldsValue,
          // setProps
        },
      ] = useForm({
        labelWidth: 120,
        schemas,
        showActionButtonGroup: false,
        actionColOptions: {
          span: 24,
        },
      })
      const [register, { closeModal }] = useModalInner((data) => {
        data && onDataReceive(data)
      })
      function onDataReceive(data) {
        idRef.value = data.id
        getRoleByIdApi(data.id).then((res) => {
          modelRef.value = { name: res.name, isDefault: res.isDefault, isPublic: res.isPublic }
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
      function handleVisibleChange(v) {
        v && props.tenantData && nextTick(() => onDataReceive(props.tenantData))
      }
      function handleOk() {
        let fieldsValue = getFieldsValue()
        roleUpdateApi(idRef.value, {
          name: fieldsValue.name,
          isDefault: fieldsValue.isDefault,
          isPublic: fieldsValue.isPublic,
        })
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
      return { register, schemas, registerForm, model: modelRef, handleVisibleChange, handleOk }
    },
  })
</script>
